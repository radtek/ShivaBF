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
    public class Services2Section4Master : BaseBusiness, IServices2Section4Master
    {
        public ViewModel.BusinessResultViewModel<ViewModel.Services2Section4MasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.Services2Section4MasterIndexViewModel> collection;
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
                totalRecords = unitOfWork.Services2Section4MasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services2Section4Master => Services2Section4Master.Tenant_ID, tenant => tenant.ID, (Services2Section4Master, tenant) => new { Services2Section4Master, tenant })
                    .Join(unitOfWork.Services2MasterRepository.Get(), Services2Section4Master_tenant => Services2Section4Master_tenant.Services2Section4Master.Service_Id, Services2Master => Services2Master.ID, (Services2Section4Master_tenant, Services2Master) => new { Services2Section4Master_tenant, Services2Master })
                    .Count(x => (tenant_Id == null || x.Services2Section4Master_tenant.Services2Section4Master.Tenant_ID == tenant_Id)
                            && (x.Services2Section4Master_tenant.Services2Section4Master.ID.ToString().Contains(searchValue)
                        || x.Services2Section4Master_tenant.Services2Section4Master.AncharTagTitle.CaseInsensitiveContains(searchValue)
                        || x.Services2Section4Master_tenant.Services2Section4Master.AncharTagUrl.CaseInsensitiveContains(searchValue)
                        || x.Services2Section4Master_tenant.Services2Section4Master.Heading.CaseInsensitiveContains(searchValue)
                         || x.Services2Section4Master_tenant.Services2Section4Master.Description.CaseInsensitiveContains(searchValue)
                        || x.Services2Section4Master_tenant.Services2Section4Master.Price.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services2Master.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services2Section4Master_tenant.Services2Section4Master.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services2Section4Master_tenant.Services2Section4Master.Url.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services2Section4Master_tenant.Services2Section4Master.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services2Section4Master_tenant.Services2Section4Master.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services2Section4Master_tenant.Services2Section4Master.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services2Section4Master_tenant.Services2Section4Master.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services2Section4Master_tenant.Services2Section4Master.Tenant.Name.CaseInsensitiveContains(searchValue)
                        ||x.Services2Section4Master_tenant.Services2Section4Master.CreatedBy.CaseInsensitiveContains(searchValue)
                        ||x.Services2Section4Master_tenant.Services2Section4Master.UpdatedBy.CaseInsensitiveContains(searchValue)
                        ||x.Services2Section4Master_tenant.Services2Section4Master.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ||x.Services2Section4Master_tenant.Services2Section4Master.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.Services2Section4MasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services2Section4Master => Services2Section4Master.Tenant_ID, tenant => tenant.ID, (Services2Section4Master, tenant) => new { Services2Section4Master, tenant })
                    .Join(unitOfWork.Services2MasterRepository.Get(), Services2Section4Master_tenant => Services2Section4Master_tenant.Services2Section4Master.Service_Id, Services2Master => Services2Master.ID, (Services2Section4Master_tenant, Services2Master) => new { Services2Section4Master_tenant, Services2Master })
                    .Where(x => (tenant_Id == null || x.Services2Section4Master_tenant.Services2Section4Master.Tenant_ID == tenant_Id)
                            && (x.Services2Section4Master_tenant.Services2Section4Master.ID.ToString().Contains(searchValue)
                        || x.Services2Section4Master_tenant.Services2Section4Master.AncharTagTitle.CaseInsensitiveContains(searchValue)
                        || x.Services2Section4Master_tenant.Services2Section4Master.AncharTagUrl.CaseInsensitiveContains(searchValue)
                        || x.Services2Section4Master_tenant.Services2Section4Master.Heading.CaseInsensitiveContains(searchValue)
                         || x.Services2Section4Master_tenant.Services2Section4Master.Description.CaseInsensitiveContains(searchValue)
                        || x.Services2Section4Master_tenant.Services2Section4Master.Price.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services2Master.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services2Section4Master_tenant.Services2Section4Master.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services2Section4Master_tenant.Services2Section4Master.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services2Section4Master_tenant.Services2Section4Master.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services2Section4Master_tenant.Services2Section4Master.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services2Section4Master_tenant.Services2Section4Master.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services2Section4Master_tenant.Services2Section4Master.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services2Section4Master_tenant.Services2Section4Master.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Services2Section4Master_tenant.Services2Section4Master.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services2Section4Master_tenant.Services2Section4Master.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services2Section4Master_tenant.Services2Section4Master.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Services2Section4Master_tenant.Services2Section4Master.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.Services2Section4MasterIndexViewModel
                    {
                        ID = x.Services2Section4Master_tenant.Services2Section4Master.ID,
                        AncharTagTitle = x.Services2Section4Master_tenant.Services2Section4Master.AncharTagTitle,
                        AncharTagUrl = x.Services2Section4Master_tenant.Services2Section4Master.AncharTagUrl,
                        HeadingText = x.Services2Section4Master_tenant.Services2Section4Master.Heading,
                        Description = x.Services2Section4Master_tenant.Services2Section4Master.Description,
                        Price = x.Services2Section4Master_tenant.Services2Section4Master.Price,
                        SubSubCategoryName = x.Services2Master.SubSubCategoryName,
                        DisplayIndex = x.Services2Section4Master_tenant.Services2Section4Master.DisplayIndex,
                        Url = x.Services2Section4Master_tenant.Services2Section4Master.Url,
                        Metadata = x.Services2Section4Master_tenant.Services2Section4Master.Metadata,
                        MetaDescription = x.Services2Section4Master_tenant.Services2Section4Master.MetaDescription,
                        Keyword = x.Services2Section4Master_tenant.Services2Section4Master.Keyword,
                        TotalViews = x.Services2Section4Master_tenant.Services2Section4Master.TotalViews,
                        IsActive = x.Services2Section4Master_tenant.Services2Section4Master.IsActive,
                        TenantName = x.Services2Section4Master_tenant.Services2Section4Master.Tenant.Name,
                        Tenant_ID = x.Services2Section4Master_tenant.Services2Section4Master.Tenant.ID,
                        CreatedBy = x.Services2Section4Master_tenant.Services2Section4Master.CreatedBy,
                        CreatedOn = x.Services2Section4Master_tenant.Services2Section4Master.CreatedOn,
                        UpdatedBy = x.Services2Section4Master_tenant.Services2Section4Master.UpdatedBy,
                        UpdatedOn = x.Services2Section4Master_tenant.Services2Section4Master.UpdatedOn,
                        ServiceUrl = x.Services2Master.Url
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.Services2Section4MasterIndexViewModel>
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





        public EntityModel.Services2Section4Master Create(EntityModel.Services2Section4Master entity)
        {
            try
            {
                return unitOfWork.Services2Section4MasterRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.Services2Section4Master GetById(long Id)
        {
            try
            {
                EntityModel.Services2Section4Master entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.Services2Section4MasterRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.Services2Section4Master Update(EntityModel.Services2Section4Master entity)
        {
            try
            {
                return unitOfWork.Services2Section4MasterRepository.Update(entity);
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
                unitOfWork.Services2Section4MasterRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.Services2Section4Master> GetAll()
        {
            try
            {
                return unitOfWork.Services2Section4MasterRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.Services2Section4Master> FindBy(Expression<Func<EntityModel.Services2Section4Master, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.Services2Section4Master> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.Services2Section4MasterRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.Services2Section4MasterRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.Services2Section4Master, bool>> filter = null)
        {
            try
            {
                unitOfWork.Services2Section4MasterRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.Services2Section4Master, bool>> filter = null)
        {
            try
            {
                return unitOfWork.Services2Section4MasterRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
