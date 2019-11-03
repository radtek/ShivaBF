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
    public class Services2Section3DownloadMaster : BaseBusiness, IServices2Section3DownloadMaster
    {
        public ViewModel.BusinessResultViewModel<ViewModel.Services2Section3DownloadMasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.Services2Section3DownloadMasterIndexViewModel> collection;
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
                totalRecords = unitOfWork.Services2Section3DownloadMasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services2Section3DownloadMaster => Services2Section3DownloadMaster.Tenant_ID, tenant => tenant.ID, (Services2Section3DownloadMaster, tenant) => new { Services2Section3DownloadMaster, tenant })
                    .Join(unitOfWork.Services2MasterRepository.Get(), Services2Section3DownloadMaster_tenant => Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.Service_Id, Services2Master => Services2Master.ID, (Services2Section3DownloadMaster_tenant, Services2Master) => new { Services2Section3DownloadMaster_tenant, Services2Master })
                    .Count(x => (tenant_Id == null || x.Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.Tenant_ID == tenant_Id)
                            && (x.Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.ID.ToString().Contains(searchValue)
                        || x.Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.AncharTagTitle.CaseInsensitiveContains(searchValue)
                        || x.Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.AncharTagUrl.CaseInsensitiveContains(searchValue)
                        || x.Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.DownloadFilePath.CaseInsensitiveContains(searchValue)
                        || x.Services2Master.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.Url.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.Tenant.Name.CaseInsensitiveContains(searchValue)
                        ||x.Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.CreatedBy.CaseInsensitiveContains(searchValue)
                        ||x.Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.UpdatedBy.CaseInsensitiveContains(searchValue)
                        ||x.Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ||x.Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.Services2Section3DownloadMasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services2Section3DownloadMaster => Services2Section3DownloadMaster.Tenant_ID, tenant => tenant.ID, (Services2Section3DownloadMaster, tenant) => new { Services2Section3DownloadMaster, tenant })
                    .Join(unitOfWork.Services2MasterRepository.Get(), Services2Section3DownloadMaster_tenant => Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.Service_Id, Services2Master => Services2Master.ID, (Services2Section3DownloadMaster_tenant, Services2Master) => new { Services2Section3DownloadMaster_tenant, Services2Master })
                    .Where(x => (tenant_Id == null || x.Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.Tenant_ID == tenant_Id)
                            && (x.Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.ID.ToString().Contains(searchValue)
                        || x.Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.AncharTagTitle.CaseInsensitiveContains(searchValue)
                        || x.Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.AncharTagUrl.CaseInsensitiveContains(searchValue)
                        || x.Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.DownloadFilePath.CaseInsensitiveContains(searchValue)
                        || x.Services2Master.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.Services2Section3DownloadMasterIndexViewModel
                    {
                        ID = x.Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.ID,
                        AncharTagTitle = x.Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.AncharTagTitle,
                        AncharTagUrl = x.Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.AncharTagUrl,
                        DownloadFilePath = x.Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.DownloadFilePath,
                        SubSubCategoryName = x.Services2Master.SubSubCategoryName,
                        DisplayIndex = x.Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.DisplayIndex,
                        Url = x.Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.Url,
                        Metadata = x.Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.Metadata,
                        MetaDescription = x.Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.MetaDescription,
                        Keyword = x.Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.Keyword,
                        TotalViews = x.Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.TotalViews,
                        IsActive = x.Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.IsActive,
                        TenantName = x.Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.Tenant.Name,
                        Tenant_ID = x.Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.Tenant.ID,
                        CreatedBy = x.Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.CreatedBy,
                        CreatedOn = x.Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.CreatedOn,
                        UpdatedBy = x.Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.UpdatedBy,
                        UpdatedOn = x.Services2Section3DownloadMaster_tenant.Services2Section3DownloadMaster.UpdatedOn,
                        ServiceUrl = x.Services2Master.Url
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.Services2Section3DownloadMasterIndexViewModel>
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





        public EntityModel.Services2Section3DownloadMaster Create(EntityModel.Services2Section3DownloadMaster entity)
        {
            try
            {
                return unitOfWork.Services2Section3DownloadMasterRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.Services2Section3DownloadMaster GetById(long Id)
        {
            try
            {
                EntityModel.Services2Section3DownloadMaster entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.Services2Section3DownloadMasterRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.Services2Section3DownloadMaster Update(EntityModel.Services2Section3DownloadMaster entity)
        {
            try
            {
                return unitOfWork.Services2Section3DownloadMasterRepository.Update(entity);
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
                unitOfWork.Services2Section3DownloadMasterRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.Services2Section3DownloadMaster> GetAll()
        {
            try
            {
                return unitOfWork.Services2Section3DownloadMasterRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.Services2Section3DownloadMaster> FindBy(Expression<Func<EntityModel.Services2Section3DownloadMaster, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.Services2Section3DownloadMaster> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.Services2Section3DownloadMasterRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.Services2Section3DownloadMasterRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.Services2Section3DownloadMaster, bool>> filter = null)
        {
            try
            {
                unitOfWork.Services2Section3DownloadMasterRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.Services2Section3DownloadMaster, bool>> filter = null)
        {
            try
            {
                return unitOfWork.Services2Section3DownloadMasterRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
