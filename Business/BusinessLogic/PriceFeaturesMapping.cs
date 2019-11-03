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
    public class PriceFeaturesMapping : BaseBusiness, IPriceFeaturesMapping
    {
        public ViewModel.BusinessResultViewModel<ViewModel.PriceFeaturesMappingIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.PriceFeaturesMappingIndexViewModel> collection;
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
                totalRecords = unitOfWork.PriceFeaturesMappingRepository.Get().Join(unitOfWork.TenantRepository.Get(), PriceFeaturesMapping => PriceFeaturesMapping.Tenant_ID, tenant => tenant.ID, (PriceFeaturesMapping, tenant) => new { PriceFeaturesMapping, tenant })
                    .Join(unitOfWork.PriceFeaturesMasterRepository.Get(), PriceFeaturesMapping_tenant => PriceFeaturesMapping_tenant.PriceFeaturesMapping.PriceFeaturesMaster_Id, PriceFeaturesMaster => PriceFeaturesMaster.ID, (PriceFeaturesMapping_tenant, PriceFeaturesMaster) => new { PriceFeaturesMapping_tenant, PriceFeaturesMaster })
                    .Join(unitOfWork.Services1MasterRepository.Get(), PriceFeaturesMapping_tenant_PriceFeaturesMaster => PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMapping_tenant.PriceFeaturesMapping.Service_Id, Services1Master => Services1Master.ID, (PriceFeaturesMapping_tenant_PriceFeaturesMaster, Services1Master) => new { PriceFeaturesMapping_tenant_PriceFeaturesMaster, Services1Master })
                    .Join(unitOfWork.Services1Section6PriceMasterRepository.Get(), PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master => PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMapping_tenant.PriceFeaturesMapping.S1S6PM_Id, Services1Section6PriceMaster => Services1Section6PriceMaster.ID, (PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master, Services1Section6PriceMaster) => new { PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master, Services1Section6PriceMaster })
                    .Join(unitOfWork.SubSubCategoriesMasterRepository.Get(), PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster => PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.Services1Master.SubSubCat_Id, SubSubCategoryMaster => SubSubCategoryMaster.ID, (PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster, SubSubCategoryMaster) => new { PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster, SubSubCategoryMaster })
                    .Count(x => (tenant_Id == null || x.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMaster.Tenant_ID == tenant_Id)
                            && (x.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMaster.Description.ToString().Contains(searchValue)
                        || x.SubSubCategoryMaster.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMapping_tenant.PriceFeaturesMapping.S1S6PM_Id.ToString().CaseInsensitiveContains(searchValue)
                        || x.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMapping_tenant.PriceFeaturesMapping.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                       // || x.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMapping_tenant.PriceFeaturesMapping.DisplayOnHome.ToString().CaseInsensitiveContains(searchValue)
                         ||x.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMapping_tenant.PriceFeaturesMapping.Url.ToString().CaseInsensitiveContains(searchValue)
                          ||x.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMapping_tenant.PriceFeaturesMapping.Metadata.ToString().CaseInsensitiveContains(searchValue)
                           ||x.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMapping_tenant.PriceFeaturesMapping.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                            ||x.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMapping_tenant.PriceFeaturesMapping.Keyword.ToString().CaseInsensitiveContains(searchValue)
                            ||x.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMapping_tenant.PriceFeaturesMapping.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        ||x.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMapping_tenant.PriceFeaturesMapping.Tenant.Name.CaseInsensitiveContains(searchValue)
                        ||x.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMapping_tenant.PriceFeaturesMapping.CreatedBy.CaseInsensitiveContains(searchValue)
                        ||x.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMapping_tenant.PriceFeaturesMapping.UpdatedBy.CaseInsensitiveContains(searchValue)
                        ||x.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMapping_tenant.PriceFeaturesMapping.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ||x.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMapping_tenant.PriceFeaturesMapping.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.PriceFeaturesMappingRepository.Get().Join(unitOfWork.TenantRepository.Get(), PriceFeaturesMapping => PriceFeaturesMapping.Tenant_ID, tenant => tenant.ID, (PriceFeaturesMapping, tenant) => new { PriceFeaturesMapping, tenant })
                    .Join(unitOfWork.PriceFeaturesMasterRepository.Get(), PriceFeaturesMapping_tenant => PriceFeaturesMapping_tenant.PriceFeaturesMapping.PriceFeaturesMaster_Id, PriceFeaturesMaster => PriceFeaturesMaster.ID, (PriceFeaturesMapping_tenant, PriceFeaturesMaster) => new { PriceFeaturesMapping_tenant, PriceFeaturesMaster })
                    .Join(unitOfWork.Services1MasterRepository.Get(), PriceFeaturesMapping_tenant_PriceFeaturesMaster => PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMapping_tenant.PriceFeaturesMapping.Service_Id, Services1Master => Services1Master.ID, (PriceFeaturesMapping_tenant_PriceFeaturesMaster, Services1Master) => new { PriceFeaturesMapping_tenant_PriceFeaturesMaster, Services1Master })
                    .Join(unitOfWork.Services1Section6PriceMasterRepository.Get(), PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master => PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMapping_tenant.PriceFeaturesMapping.S1S6PM_Id, Services1Section6PriceMaster => Services1Section6PriceMaster.ID, (PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master, Services1Section6PriceMaster) => new { PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master, Services1Section6PriceMaster })
                    .Join(unitOfWork.SubSubCategoriesMasterRepository.Get(), PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster => PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.Services1Master.SubSubCat_Id, SubSubCategoryMaster => SubSubCategoryMaster.ID, (PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster, SubSubCategoryMaster) => new { PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster, SubSubCategoryMaster })
                    .Where(x => (tenant_Id == null || x.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMaster.Tenant_ID == tenant_Id)
                            && (x.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMaster.Description.ToString().Contains(searchValue)
                        || x.SubSubCategoryMaster.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMapping_tenant.PriceFeaturesMapping.S1S6PM_Id.ToString().CaseInsensitiveContains(searchValue)
                        || x.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMapping_tenant.PriceFeaturesMapping.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                         // || x.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMapping_tenant.PriceFeaturesMapping.DisplayOnHome.ToString().CaseInsensitiveContains(searchValue)
                         || x.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMapping_tenant.PriceFeaturesMapping.Url.ToString().CaseInsensitiveContains(searchValue)
                          || x.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMapping_tenant.PriceFeaturesMapping.Metadata.ToString().CaseInsensitiveContains(searchValue)
                           || x.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMapping_tenant.PriceFeaturesMapping.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                            || x.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMapping_tenant.PriceFeaturesMapping.Keyword.ToString().CaseInsensitiveContains(searchValue)
                            || x.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMapping_tenant.PriceFeaturesMapping.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMapping_tenant.PriceFeaturesMapping.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMapping_tenant.PriceFeaturesMapping.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMapping_tenant.PriceFeaturesMapping.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMapping_tenant.PriceFeaturesMapping.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMapping_tenant.PriceFeaturesMapping.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.PriceFeaturesMappingIndexViewModel
                    {
                        ID = x.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMapping_tenant.PriceFeaturesMapping.ID,
                        SubSubCategory_Name = x.SubSubCategoryMaster.SubSubCategoryName,
                        Description = x.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMaster.Description,
                        S1S6PM_Id= x.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMapping_tenant.PriceFeaturesMapping.S1S6PM_Id,
                        PriceFeaturesMaster_Id= x.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMapping_tenant.PriceFeaturesMapping.PriceFeaturesMaster_Id,
                        DisplayIndex = x.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMapping_tenant.PriceFeaturesMapping.DisplayIndex,
                        Url = x.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMapping_tenant.PriceFeaturesMapping.Url,
                        Metadata = x.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMapping_tenant.PriceFeaturesMapping.Metadata,
                        MetaDescription = x.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMapping_tenant.PriceFeaturesMapping.MetaDescription,
                        Keyword = x.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMapping_tenant.PriceFeaturesMapping.Keyword,
                        TotalViews = x.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMapping_tenant.PriceFeaturesMapping.TotalViews,
                        IsActive = x.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMapping_tenant.PriceFeaturesMapping.IsActive,
                        TenantName = x.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMapping_tenant.PriceFeaturesMapping.Tenant.Name,
                        Tenant_ID = x.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMapping_tenant.PriceFeaturesMapping.Tenant.ID,
                        CreatedBy = x.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMapping_tenant.PriceFeaturesMapping.CreatedBy,
                        CreatedOn = x.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMapping_tenant.PriceFeaturesMapping.CreatedOn,
                        UpdatedBy = x.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMapping_tenant.PriceFeaturesMapping.UpdatedBy,
                        UpdatedOn = x.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.PriceFeaturesMapping_tenant_PriceFeaturesMaster.PriceFeaturesMapping_tenant.PriceFeaturesMapping.UpdatedOn,
                        ServiceUrl = x.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master_Services1Section6PriceMaster.PriceFeaturesMapping_tenant_PriceFeaturesMaster_Services1Master.Services1Master.Url
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.PriceFeaturesMappingIndexViewModel>
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





        public EntityModel.PriceFeaturesMapping Create(EntityModel.PriceFeaturesMapping entity)
        {
            try
            {
                return unitOfWork.PriceFeaturesMappingRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.PriceFeaturesMapping GetById(long Id)
        {
            try
            {
                EntityModel.PriceFeaturesMapping entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.PriceFeaturesMappingRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.PriceFeaturesMapping Update(EntityModel.PriceFeaturesMapping entity)
        {
            try
            {
                return unitOfWork.PriceFeaturesMappingRepository.Update(entity);
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
                unitOfWork.PriceFeaturesMappingRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.PriceFeaturesMapping> GetAll()
        {
            try
            {
                return unitOfWork.PriceFeaturesMappingRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.PriceFeaturesMapping> FindBy(Expression<Func<EntityModel.PriceFeaturesMapping, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.PriceFeaturesMapping> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.PriceFeaturesMappingRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.PriceFeaturesMappingRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.PriceFeaturesMapping, bool>> filter = null)
        {
            try
            {
                unitOfWork.PriceFeaturesMappingRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.PriceFeaturesMapping, bool>> filter = null)
        {
            try
            {
                return unitOfWork.PriceFeaturesMappingRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
