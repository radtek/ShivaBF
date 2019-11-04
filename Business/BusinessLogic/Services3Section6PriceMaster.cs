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
    public class Services3Section6PriceMaster : BaseBusiness, IServices3Section6PriceMaster
    {
        public ViewModel.BusinessResultViewModel<ViewModel.Services3Section6PriceMasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.Services3Section6PriceMasterIndexViewModel> collection;
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
                totalRecords = unitOfWork.Services3Section6PriceMasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services3Section6PriceMaster => Services3Section6PriceMaster.Tenant_ID, tenant => tenant.ID, (Services3Section6PriceMaster, tenant) => new { Services3Section6PriceMaster, tenant })
                    .Join(unitOfWork.Services3MasterRepository.Get(), Services3Section6PriceMaster_tenant => Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.Service_Id, Services3Master => Services3Master.ID, (Services3Section6PriceMaster_tenant, Services3Master) => new { Services3Section6PriceMaster_tenant, Services3Master })
                    .Join(unitOfWork.StateMasterRepository.Get(), Services3Section6PriceMaster_tenant_Services3Master => Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.State_Id, stateMaster => stateMaster.ID, (Services3Section6PriceMaster_tenant_Services3Master, stateMaster) => new { Services3Section6PriceMaster_tenant_Services3Master, stateMaster })
                    .Count(x => (tenant_Id == null || x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.Tenant_ID == tenant_Id)
                            && (x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.ID.ToString().Contains(searchValue)
                        || x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.AncharTagTitle.CaseInsensitiveContains(searchValue)
                        || x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.AncharTagUrl.CaseInsensitiveContains(searchValue)
                        || x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.HeadingText.CaseInsensitiveContains(searchValue)
                        || x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.Price.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services3Section6PriceMaster_tenant_Services3Master.Services3Master.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.Url.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.Tenant.Name.CaseInsensitiveContains(searchValue)
                        ||x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.CreatedBy.CaseInsensitiveContains(searchValue)
                        ||x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.UpdatedBy.CaseInsensitiveContains(searchValue)
                        ||x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ||x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.Services3Section6PriceMasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services3Section6PriceMaster => Services3Section6PriceMaster.Tenant_ID, tenant => tenant.ID, (Services3Section6PriceMaster, tenant) => new { Services3Section6PriceMaster, tenant })
                    .Join(unitOfWork.Services3MasterRepository.Get(), Services3Section6PriceMaster_tenant => Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.Service_Id, Services3Master => Services3Master.ID, (Services3Section6PriceMaster_tenant, Services3Master) => new { Services3Section6PriceMaster_tenant, Services3Master })
                    .Join(unitOfWork.StateMasterRepository.Get(), Services3Section6PriceMaster_tenant_Services3Master => Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.State_Id, stateMaster => stateMaster.ID, (Services3Section6PriceMaster_tenant_Services3Master, stateMaster) => new { Services3Section6PriceMaster_tenant_Services3Master, stateMaster })
                    .Where(x => (tenant_Id == null || x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.Tenant_ID == tenant_Id)
                            && (x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.ID.ToString().Contains(searchValue)
                        || x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.AncharTagTitle.CaseInsensitiveContains(searchValue)
                        || x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.AncharTagUrl.CaseInsensitiveContains(searchValue)
                        || x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.HeadingText.CaseInsensitiveContains(searchValue)
                        || x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.Price.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services3Section6PriceMaster_tenant_Services3Master.Services3Master.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.Services3Section6PriceMasterIndexViewModel
                    {
                        ID = x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.ID,
                        StateFullName = x.stateMaster.StateFullName,
                        AncharTagTitle = x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.AncharTagTitle,
                        AncharTagUrl = x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.AncharTagUrl,
                        Heading = x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.HeadingText,
                        Description = x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.Description,
                        Price = Convert.ToInt32(x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.Price),
                        SubSubCategoryName = x.Services3Section6PriceMaster_tenant_Services3Master.Services3Master.SubSubCategoryName,
                        DisplayIndex = x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.DisplayIndex,
                        Url = x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.Url,
                        Metadata = x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.Metadata,
                        MetaDescription = x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.MetaDescription,
                        Keyword = x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.Keyword,
                        TotalViews = x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.TotalViews,
                        IsActive = x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.IsActive,
                        TenantName = x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.Tenant.Name,
                        Tenant_ID = x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.Tenant.ID,
                        CreatedBy = x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.CreatedBy,
                        CreatedOn = x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.CreatedOn,
                        UpdatedBy = x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.UpdatedBy,
                        UpdatedOn = x.Services3Section6PriceMaster_tenant_Services3Master.Services3Section6PriceMaster_tenant.Services3Section6PriceMaster.UpdatedOn
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.Services3Section6PriceMasterIndexViewModel>
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





        public EntityModel.Services3Section6PriceMaster Create(EntityModel.Services3Section6PriceMaster entity)
        {
            try
            {
                return unitOfWork.Services3Section6PriceMasterRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.Services3Section6PriceMaster GetById(long Id)
        {
            try
            {
                EntityModel.Services3Section6PriceMaster entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.Services3Section6PriceMasterRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.Services3Section6PriceMaster Update(EntityModel.Services3Section6PriceMaster entity)
        {
            try
            {
                return unitOfWork.Services3Section6PriceMasterRepository.Update(entity);
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
                unitOfWork.Services3Section6PriceMasterRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.Services3Section6PriceMaster> GetAll()
        {
            try
            {
                return unitOfWork.Services3Section6PriceMasterRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.Services3Section6PriceMaster> FindBy(Expression<Func<EntityModel.Services3Section6PriceMaster, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.Services3Section6PriceMaster> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.Services3Section6PriceMasterRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.Services3Section6PriceMasterRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.Services3Section6PriceMaster, bool>> filter = null)
        {
            try
            {
                unitOfWork.Services3Section6PriceMasterRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.Services3Section6PriceMaster, bool>> filter = null)
        {
            try
            {
                return unitOfWork.Services3Section6PriceMasterRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
