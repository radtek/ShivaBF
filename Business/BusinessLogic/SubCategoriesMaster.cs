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
    public class SubCategoriesMaster : BaseBusiness, ISubCategoriesMaster
    {
        public ViewModel.BusinessResultViewModel<ViewModel.SubCategoriesMasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.SubCategoriesMasterIndexViewModel> collection;
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
                totalRecords = unitOfWork.SubCategoriesMasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), Sub_Categories => Sub_Categories.Tenant_ID, tenant => tenant.ID, (Sub_Categories, tenant) => new { Sub_Categories, tenant })
                    .Join(unitOfWork.CategoriesMasterRepository.Get(), Sub_Categories_tenant => Sub_Categories_tenant.Sub_Categories.Cat_Id, Categories => Categories.ID, (Sub_Categories_tenant, Categories) => new { Sub_Categories_tenant,Categories})
                    .Count(x => (tenant_Id == null || x.Sub_Categories_tenant.Sub_Categories.Tenant_ID == tenant_Id)
                            && (x.Sub_Categories_tenant.Sub_Categories.ID.ToString().Contains(searchValue)
                        || x.Sub_Categories_tenant.Sub_Categories.SubCategoryName.CaseInsensitiveContains(searchValue)
                         || x.Categories.CategoryName.CaseInsensitiveContains(searchValue)
                        || x.Sub_Categories_tenant.Sub_Categories.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.Sub_Categories_tenant.Sub_Categories.DisplayOnHome.ToString().CaseInsensitiveContains(searchValue)
                         ||x.Sub_Categories_tenant.Sub_Categories.Url.ToString().CaseInsensitiveContains(searchValue)
                          ||x.Sub_Categories_tenant.Sub_Categories.Metadata.ToString().CaseInsensitiveContains(searchValue)
                           ||x.Sub_Categories_tenant.Sub_Categories.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                            ||x.Sub_Categories_tenant.Sub_Categories.Keyword.ToString().CaseInsensitiveContains(searchValue)
                            ||x.Sub_Categories_tenant.Sub_Categories.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Sub_Categories_tenant.Sub_Categories.Tenant.Name.CaseInsensitiveContains(searchValue)
                        ||x.Sub_Categories_tenant.Sub_Categories.CreatedBy.CaseInsensitiveContains(searchValue)
                        ||x.Sub_Categories_tenant.Sub_Categories.UpdatedBy.CaseInsensitiveContains(searchValue)
                        ||x.Sub_Categories_tenant.Sub_Categories.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ||x.Sub_Categories_tenant.Sub_Categories.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.SubCategoriesMasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), Sub_Categories => Sub_Categories.Tenant_ID, tenant => tenant.ID, (Sub_Categories, tenant) => new { Sub_Categories, tenant })
                    .Join(unitOfWork.CategoriesMasterRepository.Get(), Sub_Categories_tenant => Sub_Categories_tenant.Sub_Categories.Cat_Id, Categories => Categories.ID, (Sub_Categories_tenant, Categories) => new { Sub_Categories_tenant, Categories })
                    .Where(x => (tenant_Id == null || x.Sub_Categories_tenant.Sub_Categories.Tenant_ID == tenant_Id)
                            && (x.Sub_Categories_tenant.Sub_Categories.ID.ToString().Contains(searchValue)
                        || x.Sub_Categories_tenant.Sub_Categories.SubCategoryName.CaseInsensitiveContains(searchValue)
                         || x.Categories.CategoryName.CaseInsensitiveContains(searchValue)
                        || x.Sub_Categories_tenant.Sub_Categories.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.Sub_Categories_tenant.Sub_Categories.DisplayOnHome.ToString().CaseInsensitiveContains(searchValue)
                         || x.Sub_Categories_tenant.Sub_Categories.Url.ToString().CaseInsensitiveContains(searchValue)
                          || x.Sub_Categories_tenant.Sub_Categories.Metadata.ToString().CaseInsensitiveContains(searchValue)
                           || x.Sub_Categories_tenant.Sub_Categories.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                            || x.Sub_Categories_tenant.Sub_Categories.Keyword.ToString().CaseInsensitiveContains(searchValue)
                            || x.Sub_Categories_tenant.Sub_Categories.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.Sub_Categories_tenant.Sub_Categories.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Sub_Categories_tenant.Sub_Categories.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Sub_Categories_tenant.Sub_Categories.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Sub_Categories_tenant.Sub_Categories.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Sub_Categories_tenant.Sub_Categories.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.SubCategoriesMasterIndexViewModel
                    {
                        ID = x.Sub_Categories_tenant.Sub_Categories.ID,
                        SubCategoryName = x.Sub_Categories_tenant.Sub_Categories.SubCategoryName,
                        CategoryName = x.Categories.CategoryName,
                        DisplayIndex = x.Sub_Categories_tenant.Sub_Categories.DisplayIndex,
                        DisplayOnHome = x.Sub_Categories_tenant.Sub_Categories.DisplayOnHome,
                        Url = x.Sub_Categories_tenant.Sub_Categories.Url,
                        Metadata = x.Sub_Categories_tenant.Sub_Categories.Metadata,
                        MetaDescription = x.Sub_Categories_tenant.Sub_Categories.MetaDescription,
                        Keyword = x.Sub_Categories_tenant.Sub_Categories.Keyword,
                        TotalViews = x.Sub_Categories_tenant.Sub_Categories.TotalViews,
                        IsActive = x.Sub_Categories_tenant.Sub_Categories.IsActive,
                        TenantName = x.Sub_Categories_tenant.Sub_Categories.Tenant.Name,
                        Tenant_ID = x.Sub_Categories_tenant.Sub_Categories.Tenant.ID,
                        CreatedBy = x.Sub_Categories_tenant.Sub_Categories.CreatedBy,
                        CreatedOn = x.Sub_Categories_tenant.Sub_Categories.CreatedOn,
                        UpdatedBy = x.Sub_Categories_tenant.Sub_Categories.UpdatedBy,
                        UpdatedOn = x.Sub_Categories_tenant.Sub_Categories.UpdatedOn
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.SubCategoriesMasterIndexViewModel>
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





        public EntityModel.SubCategoriesMaster Create(EntityModel.SubCategoriesMaster entity)
        {
            try
            {
                return unitOfWork.SubCategoriesMasterRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.SubCategoriesMaster GetById(long Id)
        {
            try
            {
                EntityModel.SubCategoriesMaster entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.SubCategoriesMasterRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.SubCategoriesMaster Update(EntityModel.SubCategoriesMaster entity)
        {
            try
            {
                return unitOfWork.SubCategoriesMasterRepository.Update(entity);
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
                unitOfWork.SubCategoriesMasterRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.SubCategoriesMaster> GetAll()
        {
            try
            {
                return unitOfWork.SubCategoriesMasterRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.SubCategoriesMaster> FindBy(Expression<Func<EntityModel.SubCategoriesMaster, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.SubCategoriesMaster> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.SubCategoriesMasterRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.SubCategoriesMasterRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.SubCategoriesMaster, bool>> filter = null)
        {
            try
            {
                unitOfWork.SubCategoriesMasterRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.SubCategoriesMaster, bool>> filter = null)
        {
            try
            {
                return unitOfWork.SubCategoriesMasterRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
