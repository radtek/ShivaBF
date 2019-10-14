using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Web;
using Dapper;
using SHF.Business.Interface;
using SHF.EntityModel;
using SHF.Helper;


namespace SHF.Business.BusinessLogic
{
    public class CategoriesMaster : BaseBusiness, ICategoriesMaster
    {
        public ViewModel.BusinessResultViewModel<ViewModel.CategoriesMasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.CategoriesMasterIndexViewModel> collection;
            // ArrayList arrayList;
            try
            {
                //Datatable parameter
                var draw = Request.Form.GetValues("draw").FirstOrDefault();
                //paging parameter
                var start = Request.Form.GetValues("start").FirstOrDefault();
                var length = Request.Form.GetValues("length").FirstOrDefault();
                //sorting parameter            
                var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
                var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();

                //Global filter parameter
                var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();

                int pageSize = length != null ? Convert.ToInt32(length) : busConstant.Numbers.Integer.ZERO;
                int skip = start != null ? Convert.ToInt32(start) : busConstant.Numbers.Integer.ZERO;
                int totalRecords = busConstant.Numbers.Integer.ZERO;


                //Count total Records meeting criteria
                totalRecords = unitOfWork.CategoriesMasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), Categories => Categories.Tenant_ID, tenant => tenant.ID, (Categories, tenant) => new { Categories, tenant })
                    .Count(x => (tenant_Id == null || x.Categories.Tenant_ID == tenant_Id)
                            && (x.Categories.ID.ToString().Contains(searchValue)
                        || x.Categories.CategoryName.CaseInsensitiveContains(searchValue)
                        || x.Categories.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.Categories.DisplayOnHome.ToString().CaseInsensitiveContains(searchValue)
                         || x.Categories.Url.ToString().CaseInsensitiveContains(searchValue)
                          || x.Categories.Metadata.ToString().CaseInsensitiveContains(searchValue)
                           || x.Categories.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                            || x.Categories.Keyword.ToString().CaseInsensitiveContains(searchValue)
                            || x.Categories.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Categories.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Categories.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Categories.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Categories.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.CategoriesMasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), Categories => Categories.Tenant_ID, tenant => tenant.ID, (Categories, tenant) => new { Categories, tenant })
                    .Where(x => (tenant_Id == null || x.Categories.Tenant_ID == tenant_Id)
                            && (x.Categories.ID.ToString().Contains(searchValue)
                        || x.Categories.CategoryName.CaseInsensitiveContains(searchValue)
                        || x.Categories.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.Categories.DisplayOnHome.ToString().CaseInsensitiveContains(searchValue)
                         || x.Categories.Url.ToString().CaseInsensitiveContains(searchValue)
                          || x.Categories.Metadata.ToString().CaseInsensitiveContains(searchValue)
                           || x.Categories.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                            || x.Categories.Keyword.ToString().CaseInsensitiveContains(searchValue)
                            || x.Categories.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Categories.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Categories.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Categories.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Categories.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.CategoriesMasterIndexViewModel
                    {
                        ID = x.Categories.ID,
                        CategoryName = x.Categories.CategoryName,
                        DisplayIndex = x.Categories.DisplayIndex,
                        DisplayOnHome = x.Categories.DisplayOnHome,
                        Url = x.Categories.Url,
                        Metadata = x.Categories.Metadata,
                        MetaDescription = x.Categories.MetaDescription,
                        Keyword = x.Categories.Keyword,
                        TotalViews = x.Categories.TotalViews,
                        IsActive = x.Categories.IsActive,
                        TenantName = x.tenant.Name,
                        Tenant_ID = x.tenant.ID,
                        CreatedBy = x.Categories.CreatedBy,
                        CreatedOn = x.Categories.CreatedOn,
                        UpdatedBy = x.Categories.UpdatedBy,
                        UpdatedOn = x.Categories.UpdatedOn
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.CategoriesMasterIndexViewModel>
                {
                    Draw = draw,
                    RecordsFiltered = totalRecords,
                    RecordsTotal = totalRecords,
                    Data = collection
                };

                return businessResultViewModel;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                collection = null;
            }
        }





        public EntityModel.CategoriesMaster Create(EntityModel.CategoriesMaster entity)
        {
            try
            {
                return unitOfWork.CategoriesMasterRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.CategoriesMaster GetById(long Id)
        {
            try
            {
                EntityModel.CategoriesMaster entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.CategoriesMasterRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.CategoriesMaster Update(EntityModel.CategoriesMaster entity)
        {
            try
            {
                return unitOfWork.CategoriesMasterRepository.Update(entity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void Delete(long Id)
        {
            try
            {
                unitOfWork.CategoriesMasterRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.CategoriesMaster> GetAll()
        {
            try
            {
                return unitOfWork.CategoriesMasterRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.CategoriesMaster> FindBy(Expression<Func<EntityModel.CategoriesMaster, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.CategoriesMaster> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.CategoriesMasterRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.CategoriesMasterRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.CategoriesMaster, bool>> filter = null)
        {
            try
            {
                unitOfWork.CategoriesMasterRepository.DeleteWhere(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        //public IEnumerable<ProductDropdownListViewModel> GetDropdownList()
        //{
        //    try
        //    {
        //        var productDropdownListViewModel = unitOfWork.ProductRepository.Get().Select(x => new ViewModel.ProductDropdownListViewModel
        //        {
        //            ID = x.ID,
        //            Name = x.Name
        //        });

        //        return productDropdownListViewModel;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        public Int32 Count(Expression<Func<EntityModel.CategoriesMaster, bool>> filter = null)
        {
            try
            {
                return unitOfWork.CategoriesMasterRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
