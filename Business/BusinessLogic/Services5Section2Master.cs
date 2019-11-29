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
    public class Services5Section2Master : BaseBusiness, IServices5Section2Master
    {
        public ViewModel.BusinessResultViewModel<ViewModel.Services5Section2MasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.Services5Section2MasterIndexViewModel> collection;
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
                totalRecords = unitOfWork.Services5Section2MasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services5Section2Master => Services5Section2Master.Tenant_ID, tenant => tenant.ID, (Services5Section2Master, tenant) => new { Services5Section2Master, tenant })
                    .Join(unitOfWork.Services5MasterRepository.Get(), Services5Section2Master_tenant => Services5Section2Master_tenant.Services5Section2Master.Service_Id, Services5Master => Services5Master.ID, (Services5Section2Master_tenant, Services5Master) => new { Services5Section2Master_tenant, Services5Master })
                    .Count(x => (tenant_Id == null || x.Services5Section2Master_tenant.Services5Section2Master.Tenant_ID == tenant_Id)
                            && (x.Services5Section2Master_tenant.Services5Section2Master.ID.ToString().Contains(searchValue)
                        || x.Services5Section2Master_tenant.Services5Section2Master.AncharTagTitle.CaseInsensitiveContains(searchValue)
                        || x.Services5Section2Master_tenant.Services5Section2Master.AncharTagUrl.CaseInsensitiveContains(searchValue)
                        || x.Services5Section2Master_tenant.Services5Section2Master.ImageFilePath.CaseInsensitiveContains(searchValue)
                        || x.Services5Master.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services5Section2Master_tenant.Services5Section2Master.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services5Section2Master_tenant.Services5Section2Master.Url.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services5Section2Master_tenant.Services5Section2Master.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services5Section2Master_tenant.Services5Section2Master.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services5Section2Master_tenant.Services5Section2Master.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services5Section2Master_tenant.Services5Section2Master.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services5Section2Master_tenant.Services5Section2Master.Tenant.Name.CaseInsensitiveContains(searchValue)
                        ||x.Services5Section2Master_tenant.Services5Section2Master.CreatedBy.CaseInsensitiveContains(searchValue)
                        ||x.Services5Section2Master_tenant.Services5Section2Master.UpdatedBy.CaseInsensitiveContains(searchValue)
                        ||x.Services5Section2Master_tenant.Services5Section2Master.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ||x.Services5Section2Master_tenant.Services5Section2Master.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.Services5Section2MasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services5Section2Master => Services5Section2Master.Tenant_ID, tenant => tenant.ID, (Services5Section2Master, tenant) => new { Services5Section2Master, tenant })
                    .Join(unitOfWork.Services5MasterRepository.Get(), Services5Section2Master_tenant => Services5Section2Master_tenant.Services5Section2Master.Service_Id, Services5Master => Services5Master.ID, (Services5Section2Master_tenant, Services5Master) => new { Services5Section2Master_tenant, Services5Master })
                    .Where(x => (tenant_Id == null || x.Services5Section2Master_tenant.Services5Section2Master.Tenant_ID == tenant_Id)
                            && (x.Services5Section2Master_tenant.Services5Section2Master.ID.ToString().Contains(searchValue)
                        || x.Services5Section2Master_tenant.Services5Section2Master.AncharTagTitle.CaseInsensitiveContains(searchValue)
                        || x.Services5Section2Master_tenant.Services5Section2Master.AncharTagUrl.CaseInsensitiveContains(searchValue)
                        || x.Services5Section2Master_tenant.Services5Section2Master.ImageFilePath.CaseInsensitiveContains(searchValue)
                        || x.Services5Master.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services5Section2Master_tenant.Services5Section2Master.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services5Section2Master_tenant.Services5Section2Master.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services5Section2Master_tenant.Services5Section2Master.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services5Section2Master_tenant.Services5Section2Master.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services5Section2Master_tenant.Services5Section2Master.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services5Section2Master_tenant.Services5Section2Master.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services5Section2Master_tenant.Services5Section2Master.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Services5Section2Master_tenant.Services5Section2Master.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services5Section2Master_tenant.Services5Section2Master.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services5Section2Master_tenant.Services5Section2Master.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Services5Section2Master_tenant.Services5Section2Master.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.Services5Section2MasterIndexViewModel
                    {
                        ID = x.Services5Section2Master_tenant.Services5Section2Master.ID,
                        AncharTagTitle = x.Services5Section2Master_tenant.Services5Section2Master.AncharTagTitle,
                        AncharTagUrl = x.Services5Section2Master_tenant.Services5Section2Master.AncharTagUrl,
                        ImageFilePath = String.Concat(busConstant.Settings.CMSPath.TENANAT_UPLOAD_DIRECTORY, x.Services5Section2Master_tenant.tenant.ID) + "/" + x.Services5Section2Master_tenant.Services5Section2Master.ImageFilePath,
                        SubSubCategoryName = x.Services5Master.SubSubCategoryName,
                        DisplayIndex = x.Services5Section2Master_tenant.Services5Section2Master.DisplayIndex,
                        Url = x.Services5Section2Master_tenant.Services5Section2Master.Url,
                        Metadata = x.Services5Section2Master_tenant.Services5Section2Master.Metadata,
                        MetaDescription = x.Services5Section2Master_tenant.Services5Section2Master.MetaDescription,
                        Keyword = x.Services5Section2Master_tenant.Services5Section2Master.Keyword,
                        TotalViews = x.Services5Section2Master_tenant.Services5Section2Master.TotalViews,
                        IsActive = x.Services5Section2Master_tenant.Services5Section2Master.IsActive,
                        TenantName = x.Services5Section2Master_tenant.Services5Section2Master.Tenant.Name,
                        Tenant_ID = x.Services5Section2Master_tenant.Services5Section2Master.Tenant.ID,
                        CreatedBy = x.Services5Section2Master_tenant.Services5Section2Master.CreatedBy,
                        CreatedOn = x.Services5Section2Master_tenant.Services5Section2Master.CreatedOn,
                        UpdatedBy = x.Services5Section2Master_tenant.Services5Section2Master.UpdatedBy,
                        UpdatedOn = x.Services5Section2Master_tenant.Services5Section2Master.UpdatedOn,
                        ServiceUrl = x.Services5Master.Url
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.Services5Section2MasterIndexViewModel>
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





        public EntityModel.Services5Section2Master Create(EntityModel.Services5Section2Master entity)
        {
            try
            {
                return unitOfWork.Services5Section2MasterRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.Services5Section2Master GetById(long Id)
        {
            try
            {
                EntityModel.Services5Section2Master entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.Services5Section2MasterRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.Services5Section2Master Update(EntityModel.Services5Section2Master entity)
        {
            try
            {
                return unitOfWork.Services5Section2MasterRepository.Update(entity);
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
                var param = new DynamicParameters();
                param.Add("@serviceId", Id);
                var x = DataAccess.GetScalar.ByStoredProcedure("[dbo].[usp_DeleteServices5Section2Master]", param);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.Services5Section2Master> GetAll()
        {
            try
            {
                return unitOfWork.Services5Section2MasterRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.Services5Section2Master> FindBy(Expression<Func<EntityModel.Services5Section2Master, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.Services5Section2Master> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.Services5Section2MasterRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.Services5Section2MasterRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.Services5Section2Master, bool>> filter = null)
        {
            try
            {
                unitOfWork.Services5Section2MasterRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.Services5Section2Master, bool>> filter = null)
        {
            try
            {
                return unitOfWork.Services5Section2MasterRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
