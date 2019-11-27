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
    public class Services1Section8FAQMapping : BaseBusiness, IServices1Section8FAQMapping
    {
        public ViewModel.BusinessResultViewModel<ViewModel.Services1Section8FAQMappingIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.Services1Section8FAQMappingIndexViewModel> collection;
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
                totalRecords = unitOfWork.Services1Section8FAQMappingRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services1Section8FAQMapping => Services1Section8FAQMapping.Tenant_ID, tenant => tenant.ID, (Services1Section8FAQMapping, tenant) => new { Services1Section8FAQMapping, tenant })
                    .Join(unitOfWork.FAQMasterRepository.Get(), Services1Section8FAQMapping_tenant => Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.FAQMaster_Id, FAQMaster => FAQMaster.ID, (Services1Section8FAQMapping_tenant, FAQMaster) => new { Services1Section8FAQMapping_tenant, FAQMaster })
                    .Join(unitOfWork.Services1MasterRepository.Get(), Services1Section8FAQMapping_tenant_FAQMaster => Services1Section8FAQMapping_tenant_FAQMaster.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.Service_Id, Services1Master => Services1Master.ID, (Services1Section8FAQMapping_tenant_FAQMaster, Services1Master) => new { Services1Section8FAQMapping_tenant_FAQMaster, Services1Master })
                    .Join(unitOfWork.SubSubCategoriesMasterRepository.Get(), Services1Section8FAQMapping_tenant_FAQMaster_Services1Master => Services1Section8FAQMapping_tenant_FAQMaster_Services1Master.Services1Section8FAQMapping_tenant_FAQMaster.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.SubSubCat_Id, SubSubCategoryMaster => SubSubCategoryMaster.ID, (Services1Section8FAQMapping_tenant_FAQMaster_Services1Master, SubSubCategoryMaster) => new { Services1Section8FAQMapping_tenant_FAQMaster_Services1Master, SubSubCategoryMaster })
                    .Count(x => (tenant_Id == null || x.Services1Section8FAQMapping_tenant_FAQMaster_Services1Master.Services1Section8FAQMapping_tenant_FAQMaster.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.Tenant_ID == tenant_Id)
                            && (x.Services1Section8FAQMapping_tenant_FAQMaster_Services1Master.Services1Section8FAQMapping_tenant_FAQMaster.FAQMaster.Description.ToString().Contains(searchValue)
                       || x.Services1Section8FAQMapping_tenant_FAQMaster_Services1Master.Services1Section8FAQMapping_tenant_FAQMaster.FAQMaster.Title.ToString().Contains(searchValue)
                            || x.SubSubCategoryMaster.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                      || x.Services1Section8FAQMapping_tenant_FAQMaster_Services1Master.Services1Section8FAQMapping_tenant_FAQMaster.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                         // || x.Services1Section8FAQMapping_tenant_FAQMaster_Services1Master.Services1Section8FAQMapping_tenant_FAQMaster.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.DisplayOnHome.ToString().CaseInsensitiveContains(searchValue)
                         || x.Services1Section8FAQMapping_tenant_FAQMaster_Services1Master.Services1Section8FAQMapping_tenant_FAQMaster.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.Url.ToString().CaseInsensitiveContains(searchValue)
                          || x.Services1Section8FAQMapping_tenant_FAQMaster_Services1Master.Services1Section8FAQMapping_tenant_FAQMaster.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.Metadata.ToString().CaseInsensitiveContains(searchValue)
                           || x.Services1Section8FAQMapping_tenant_FAQMaster_Services1Master.Services1Section8FAQMapping_tenant_FAQMaster.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                            || x.Services1Section8FAQMapping_tenant_FAQMaster_Services1Master.Services1Section8FAQMapping_tenant_FAQMaster.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.Keyword.ToString().CaseInsensitiveContains(searchValue)
                            || x.Services1Section8FAQMapping_tenant_FAQMaster_Services1Master.Services1Section8FAQMapping_tenant_FAQMaster.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services1Section8FAQMapping_tenant_FAQMaster_Services1Master.Services1Section8FAQMapping_tenant_FAQMaster.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Services1Section8FAQMapping_tenant_FAQMaster_Services1Master.Services1Section8FAQMapping_tenant_FAQMaster.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services1Section8FAQMapping_tenant_FAQMaster_Services1Master.Services1Section8FAQMapping_tenant_FAQMaster.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services1Section8FAQMapping_tenant_FAQMaster_Services1Master.Services1Section8FAQMapping_tenant_FAQMaster.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Services1Section8FAQMapping_tenant_FAQMaster_Services1Master.Services1Section8FAQMapping_tenant_FAQMaster.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.Services1Section8FAQMappingRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services1Section8FAQMapping => Services1Section8FAQMapping.Tenant_ID, tenant => tenant.ID, (Services1Section8FAQMapping, tenant) => new { Services1Section8FAQMapping, tenant })
                    .Join(unitOfWork.FAQMasterRepository.Get(), Services1Section8FAQMapping_tenant => Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.FAQMaster_Id, FAQMaster => FAQMaster.ID, (Services1Section8FAQMapping_tenant, FAQMaster) => new { Services1Section8FAQMapping_tenant, FAQMaster })
                    .Join(unitOfWork.Services1MasterRepository.Get(), Services1Section8FAQMapping_tenant_FAQMaster => Services1Section8FAQMapping_tenant_FAQMaster.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.Service_Id, Services1Master => Services1Master.ID, (Services1Section8FAQMapping_tenant_FAQMaster, Services1Master) => new { Services1Section8FAQMapping_tenant_FAQMaster, Services1Master })
                    .Join(unitOfWork.SubSubCategoriesMasterRepository.Get(), Services1Section8FAQMapping_tenant_FAQMaster_Services1Master => Services1Section8FAQMapping_tenant_FAQMaster_Services1Master.Services1Section8FAQMapping_tenant_FAQMaster.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.SubSubCat_Id, SubSubCategoryMaster => SubSubCategoryMaster.ID, (Services1Section8FAQMapping_tenant_FAQMaster_Services1Master, SubSubCategoryMaster) => new { Services1Section8FAQMapping_tenant_FAQMaster_Services1Master, SubSubCategoryMaster })
                    .Where(x => (tenant_Id == null || x.Services1Section8FAQMapping_tenant_FAQMaster_Services1Master.Services1Section8FAQMapping_tenant_FAQMaster.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.Tenant_ID == tenant_Id)
                            && (x.Services1Section8FAQMapping_tenant_FAQMaster_Services1Master.Services1Section8FAQMapping_tenant_FAQMaster.FAQMaster.Description.ToString().Contains(searchValue)
                       || x.Services1Section8FAQMapping_tenant_FAQMaster_Services1Master.Services1Section8FAQMapping_tenant_FAQMaster.FAQMaster.Title.ToString().Contains(searchValue)
                            || x.SubSubCategoryMaster.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                      || x.Services1Section8FAQMapping_tenant_FAQMaster_Services1Master.Services1Section8FAQMapping_tenant_FAQMaster.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                         // || x.Services1Section8FAQMapping_tenant_FAQMaster_Services1Master.Services1Section8FAQMapping_tenant_FAQMaster.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.DisplayOnHome.ToString().CaseInsensitiveContains(searchValue)
                         || x.Services1Section8FAQMapping_tenant_FAQMaster_Services1Master.Services1Section8FAQMapping_tenant_FAQMaster.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.Url.ToString().CaseInsensitiveContains(searchValue)
                          || x.Services1Section8FAQMapping_tenant_FAQMaster_Services1Master.Services1Section8FAQMapping_tenant_FAQMaster.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.Metadata.ToString().CaseInsensitiveContains(searchValue)
                           || x.Services1Section8FAQMapping_tenant_FAQMaster_Services1Master.Services1Section8FAQMapping_tenant_FAQMaster.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                            || x.Services1Section8FAQMapping_tenant_FAQMaster_Services1Master.Services1Section8FAQMapping_tenant_FAQMaster.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.Keyword.ToString().CaseInsensitiveContains(searchValue)
                            || x.Services1Section8FAQMapping_tenant_FAQMaster_Services1Master.Services1Section8FAQMapping_tenant_FAQMaster.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services1Section8FAQMapping_tenant_FAQMaster_Services1Master.Services1Section8FAQMapping_tenant_FAQMaster.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Services1Section8FAQMapping_tenant_FAQMaster_Services1Master.Services1Section8FAQMapping_tenant_FAQMaster.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services1Section8FAQMapping_tenant_FAQMaster_Services1Master.Services1Section8FAQMapping_tenant_FAQMaster.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services1Section8FAQMapping_tenant_FAQMaster_Services1Master.Services1Section8FAQMapping_tenant_FAQMaster.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Services1Section8FAQMapping_tenant_FAQMaster_Services1Master.Services1Section8FAQMapping_tenant_FAQMaster.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.Services1Section8FAQMappingIndexViewModel
                    {
                        ID = x.Services1Section8FAQMapping_tenant_FAQMaster_Services1Master.Services1Section8FAQMapping_tenant_FAQMaster.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.ID,
                        SubSubCategory_Name = x.SubSubCategoryMaster.SubSubCategoryName,
                        Description = x.Services1Section8FAQMapping_tenant_FAQMaster_Services1Master.Services1Section8FAQMapping_tenant_FAQMaster.FAQMaster.Description,
                        Title = x.Services1Section8FAQMapping_tenant_FAQMaster_Services1Master.Services1Section8FAQMapping_tenant_FAQMaster.FAQMaster.Title,
                        DisplayIndex = x.Services1Section8FAQMapping_tenant_FAQMaster_Services1Master.Services1Section8FAQMapping_tenant_FAQMaster.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.DisplayIndex,
                        Url = x.Services1Section8FAQMapping_tenant_FAQMaster_Services1Master.Services1Section8FAQMapping_tenant_FAQMaster.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.Url,
                        Metadata = x.Services1Section8FAQMapping_tenant_FAQMaster_Services1Master.Services1Section8FAQMapping_tenant_FAQMaster.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.Metadata,
                        MetaDescription = x.Services1Section8FAQMapping_tenant_FAQMaster_Services1Master.Services1Section8FAQMapping_tenant_FAQMaster.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.MetaDescription,
                        Keyword = x.Services1Section8FAQMapping_tenant_FAQMaster_Services1Master.Services1Section8FAQMapping_tenant_FAQMaster.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.Keyword,
                        TotalViews = x.Services1Section8FAQMapping_tenant_FAQMaster_Services1Master.Services1Section8FAQMapping_tenant_FAQMaster.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.TotalViews,
                        IsActive = x.Services1Section8FAQMapping_tenant_FAQMaster_Services1Master.Services1Section8FAQMapping_tenant_FAQMaster.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.IsActive,
                        TenantName = x.Services1Section8FAQMapping_tenant_FAQMaster_Services1Master.Services1Section8FAQMapping_tenant_FAQMaster.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.Tenant.Name,
                        Tenant_ID = x.Services1Section8FAQMapping_tenant_FAQMaster_Services1Master.Services1Section8FAQMapping_tenant_FAQMaster.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.Tenant.ID,
                        CreatedBy = x.Services1Section8FAQMapping_tenant_FAQMaster_Services1Master.Services1Section8FAQMapping_tenant_FAQMaster.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.CreatedBy,
                        CreatedOn = x.Services1Section8FAQMapping_tenant_FAQMaster_Services1Master.Services1Section8FAQMapping_tenant_FAQMaster.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.CreatedOn,
                        UpdatedBy = x.Services1Section8FAQMapping_tenant_FAQMaster_Services1Master.Services1Section8FAQMapping_tenant_FAQMaster.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.UpdatedBy,
                        UpdatedOn = x.Services1Section8FAQMapping_tenant_FAQMaster_Services1Master.Services1Section8FAQMapping_tenant_FAQMaster.Services1Section8FAQMapping_tenant.Services1Section8FAQMapping.UpdatedOn,
                        ServiceUrl = x.Services1Section8FAQMapping_tenant_FAQMaster_Services1Master.Services1Master.Url
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.Services1Section8FAQMappingIndexViewModel>
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





        public EntityModel.Services1Section8FAQMapping Create(EntityModel.Services1Section8FAQMapping entity)
        {
            try
            {
                return unitOfWork.Services1Section8FAQMappingRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.Services1Section8FAQMapping GetById(long Id)
        {
            try
            {
                EntityModel.Services1Section8FAQMapping entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.Services1Section8FAQMappingRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.Services1Section8FAQMapping Update(EntityModel.Services1Section8FAQMapping entity)
        {
            try
            {
                return unitOfWork.Services1Section8FAQMappingRepository.Update(entity);
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
                var x = DataAccess.GetScalar.ByStoredProcedure("[dbo].[usp_DeleteServices1Section8FAQMapping]", param);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.Services1Section8FAQMapping> GetAll()
        {
            try
            {
                return unitOfWork.Services1Section8FAQMappingRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.Services1Section8FAQMapping> FindBy(Expression<Func<EntityModel.Services1Section8FAQMapping, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.Services1Section8FAQMapping> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.Services1Section8FAQMappingRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.Services1Section8FAQMappingRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.Services1Section8FAQMapping, bool>> filter = null)
        {
            try
            {
                unitOfWork.Services1Section8FAQMappingRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.Services1Section8FAQMapping, bool>> filter = null)
        {
            try
            {
                return unitOfWork.Services1Section8FAQMappingRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
