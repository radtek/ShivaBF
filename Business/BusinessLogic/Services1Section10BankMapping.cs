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
    public class Services1Section10BankMapping : BaseBusiness, IServices1Section10BankMapping
    {
        public ViewModel.BusinessResultViewModel<ViewModel.Services1Section10BankMappingIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.Services1Section10BankMappingIndexViewModel> collection;
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
                totalRecords = unitOfWork.Services1Section10BankMappingRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services1Section10BankMapping => Services1Section10BankMapping.Tenant_ID, tenant => tenant.ID, (Services1Section10BankMapping, tenant) => new { Services1Section10BankMapping, tenant })
                    .Join(unitOfWork.BankMasterRepository.Get(), Services1Section10BankMapping_tenant => Services1Section10BankMapping_tenant.Services1Section10BankMapping.BankMaster_Id, BankMaster => BankMaster.ID, (Services1Section10BankMapping_tenant, BankMaster) => new { Services1Section10BankMapping_tenant, BankMaster })
                    .Join(unitOfWork.Services1MasterRepository.Get(), Services1Section10BankMapping_tenant_BankMaster => Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.Service_Id, Services1Master => Services1Master.ID, (Services1Section10BankMapping_tenant_BankMaster, Services1Master) => new { Services1Section10BankMapping_tenant_BankMaster, Services1Master })
                    .Join(unitOfWork.SubSubCategoriesMasterRepository.Get(), Services1Section10BankMapping_tenant_BankMaster_Services1Master => Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.SubSubCat_Id, SubSubCategoryMaster => SubSubCategoryMaster.ID, (Services1Section10BankMapping_tenant_BankMaster_Services1Master, SubSubCategoryMaster) => new { Services1Section10BankMapping_tenant_BankMaster_Services1Master, SubSubCategoryMaster })
                    .Count(x => (tenant_Id == null || x.Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.Tenant_ID == tenant_Id)
                            && (x.Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.BankMaster.Description.ToString().Contains(searchValue)
                      || x.SubSubCategoryMaster.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                      || x.Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                         // || x.Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.DisplayOnHome.ToString().CaseInsensitiveContains(searchValue)
                         || x.Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.Url.ToString().CaseInsensitiveContains(searchValue)
                          || x.Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.Metadata.ToString().CaseInsensitiveContains(searchValue)
                           || x.Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                            || x.Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.Keyword.ToString().CaseInsensitiveContains(searchValue)
                            || x.Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.Services1Section10BankMappingRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services1Section10BankMapping => Services1Section10BankMapping.Tenant_ID, tenant => tenant.ID, (Services1Section10BankMapping, tenant) => new { Services1Section10BankMapping, tenant })
                    .Join(unitOfWork.BankMasterRepository.Get(), Services1Section10BankMapping_tenant => Services1Section10BankMapping_tenant.Services1Section10BankMapping.BankMaster_Id, BankMaster => BankMaster.ID, (Services1Section10BankMapping_tenant, BankMaster) => new { Services1Section10BankMapping_tenant, BankMaster })
                    .Join(unitOfWork.Services1MasterRepository.Get(), Services1Section10BankMapping_tenant_BankMaster => Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.Service_Id, Services1Master => Services1Master.ID, (Services1Section10BankMapping_tenant_BankMaster, Services1Master) => new { Services1Section10BankMapping_tenant_BankMaster, Services1Master })
                    .Join(unitOfWork.SubSubCategoriesMasterRepository.Get(), Services1Section10BankMapping_tenant_BankMaster_Services1Master => Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.SubSubCat_Id, SubSubCategoryMaster => SubSubCategoryMaster.ID, (Services1Section10BankMapping_tenant_BankMaster_Services1Master, SubSubCategoryMaster) => new { Services1Section10BankMapping_tenant_BankMaster_Services1Master, SubSubCategoryMaster })
                    .Where(x => (tenant_Id == null || x.Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.Tenant_ID == tenant_Id)
                            && (x.Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.BankMaster.Description.ToString().Contains(searchValue)
                      || x.SubSubCategoryMaster.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                      || x.Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                         // || x.Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.DisplayOnHome.ToString().CaseInsensitiveContains(searchValue)
                         || x.Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.Url.ToString().CaseInsensitiveContains(searchValue)
                          || x.Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.Metadata.ToString().CaseInsensitiveContains(searchValue)
                           || x.Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                            || x.Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.Keyword.ToString().CaseInsensitiveContains(searchValue)
                            || x.Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.Services1Section10BankMappingIndexViewModel
                    {
                        ID = x.Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.ID,
                        SubSubCategory_Name = x.SubSubCategoryMaster.SubSubCategoryName,
                        Description = x.Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.BankMaster.Description,
                        BankMaster_Id =Convert.ToInt64(x.Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.BankMaster_Id),
                        DisplayIndex = x.Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.DisplayIndex,
                        Url = x.Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.Url,
                        Metadata = x.Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.Metadata,
                        MetaDescription = x.Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.MetaDescription,
                        Keyword = x.Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.Keyword,
                        TotalViews = x.Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.TotalViews,
                        IsActive = x.Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.IsActive,
                        TenantName = x.Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.Tenant.Name,
                        Tenant_ID = x.Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.Tenant.ID,
                        CreatedBy = x.Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.CreatedBy,
                        CreatedOn = x.Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.CreatedOn,
                        UpdatedBy = x.Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.UpdatedBy,
                        UpdatedOn = x.Services1Section10BankMapping_tenant_BankMaster_Services1Master.Services1Section10BankMapping_tenant_BankMaster.Services1Section10BankMapping_tenant.Services1Section10BankMapping.UpdatedOn
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.Services1Section10BankMappingIndexViewModel>
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





        public EntityModel.Services1Section10BankMapping Create(EntityModel.Services1Section10BankMapping entity)
        {
            try
            {
                return unitOfWork.Services1Section10BankMappingRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.Services1Section10BankMapping GetById(long Id)
        {
            try
            {
                EntityModel.Services1Section10BankMapping entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.Services1Section10BankMappingRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.Services1Section10BankMapping Update(EntityModel.Services1Section10BankMapping entity)
        {
            try
            {
                return unitOfWork.Services1Section10BankMappingRepository.Update(entity);
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
                unitOfWork.Services1Section10BankMappingRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.Services1Section10BankMapping> GetAll()
        {
            try
            {
                return unitOfWork.Services1Section10BankMappingRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.Services1Section10BankMapping> FindBy(Expression<Func<EntityModel.Services1Section10BankMapping, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.Services1Section10BankMapping> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.Services1Section10BankMappingRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.Services1Section10BankMappingRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.Services1Section10BankMapping, bool>> filter = null)
        {
            try
            {
                unitOfWork.Services1Section10BankMappingRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.Services1Section10BankMapping, bool>> filter = null)
        {
            try
            {
                return unitOfWork.Services1Section10BankMappingRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
