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
    public class Services4Section345MasterFeaturesDetails : BaseBusiness, IServices4Section345MasterFeaturesDetails
    {
        public ViewModel.BusinessResultViewModel<ViewModel.Services4Section345MasterFeaturesDetailsIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.Services4Section345MasterFeaturesDetailsIndexViewModel> collection;
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
                totalRecords = unitOfWork.Services4Section345MasterFeaturesDetailsRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services4Section345MasterFeaturesDetails => Services4Section345MasterFeaturesDetails.Tenant_ID, tenant => tenant.ID, (Services4Section345MasterFeaturesDetails, tenant) => new { Services4Section345MasterFeaturesDetails, tenant })
                    .Join(unitOfWork.Services4Section345MasterRepository.Get(), Services4Section345MasterFeaturesDetails_tenant => Services4Section345MasterFeaturesDetails_tenant.Services4Section345MasterFeaturesDetails.S4S345M_id, Services4Section345Master => Services4Section345Master.ID, (Services4Section345MasterFeaturesDetails_tenant, Services4Section345Master) => new { Services4Section345MasterFeaturesDetails_tenant, Services4Section345Master })
                    .Join(unitOfWork.SubSubCategoriesMasterRepository.Get(), Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master => Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master.Services4Section345MasterFeaturesDetails_tenant.Services4Section345MasterFeaturesDetails.SubSubCat_Id, SubSubCategoryMaster => SubSubCategoryMaster.ID, (Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master, SubSubCategoryMaster) => new { Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master, SubSubCategoryMaster })
                    .Count(x => (tenant_Id == null || x.Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master.Services4Section345MasterFeaturesDetails_tenant.Services4Section345MasterFeaturesDetails.Tenant_ID == tenant_Id)
                            && (x.Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master.Services4Section345MasterFeaturesDetails_tenant.Services4Section345MasterFeaturesDetails.ShortDescription.ToString().Contains(searchValue)
                        || x.SubSubCategoryMaster.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master.Services4Section345MasterFeaturesDetails_tenant.Services4Section345MasterFeaturesDetails.S4S345M_id.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master.Services4Section345MasterFeaturesDetails_tenant.Services4Section345MasterFeaturesDetails.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                       ||x.Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master.Services4Section345MasterFeaturesDetails_tenant.Services4Section345MasterFeaturesDetails.Url.ToString().CaseInsensitiveContains(searchValue)
                       ||x.Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master.Services4Section345MasterFeaturesDetails_tenant.Services4Section345MasterFeaturesDetails.Metadata.ToString().CaseInsensitiveContains(searchValue)
                       ||x.Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master.Services4Section345MasterFeaturesDetails_tenant.Services4Section345MasterFeaturesDetails.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                       ||x.Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master.Services4Section345MasterFeaturesDetails_tenant.Services4Section345MasterFeaturesDetails.Keyword.ToString().CaseInsensitiveContains(searchValue)
                       ||x.Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master.Services4Section345MasterFeaturesDetails_tenant.Services4Section345MasterFeaturesDetails.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master.Services4Section345MasterFeaturesDetails_tenant.Services4Section345MasterFeaturesDetails.Tenant.Name.CaseInsensitiveContains(searchValue)
                        ||x.Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master.Services4Section345MasterFeaturesDetails_tenant.Services4Section345MasterFeaturesDetails.CreatedBy.CaseInsensitiveContains(searchValue)
                        ||x.Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master.Services4Section345MasterFeaturesDetails_tenant.Services4Section345MasterFeaturesDetails.UpdatedBy.CaseInsensitiveContains(searchValue)
                        ||x.Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master.Services4Section345MasterFeaturesDetails_tenant.Services4Section345MasterFeaturesDetails.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ||x.Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master.Services4Section345MasterFeaturesDetails_tenant.Services4Section345MasterFeaturesDetails.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.Services4Section345MasterFeaturesDetailsRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services4Section345MasterFeaturesDetails => Services4Section345MasterFeaturesDetails.Tenant_ID, tenant => tenant.ID, (Services4Section345MasterFeaturesDetails, tenant) => new { Services4Section345MasterFeaturesDetails, tenant })
                    .Join(unitOfWork.Services4Section345MasterRepository.Get(), Services4Section345MasterFeaturesDetails_tenant => Services4Section345MasterFeaturesDetails_tenant.Services4Section345MasterFeaturesDetails.S4S345M_id, Services4Section345Master => Services4Section345Master.ID, (Services4Section345MasterFeaturesDetails_tenant, Services4Section345Master) => new { Services4Section345MasterFeaturesDetails_tenant, Services4Section345Master })
                    .Join(unitOfWork.SubSubCategoriesMasterRepository.Get(), Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master => Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master.Services4Section345MasterFeaturesDetails_tenant.Services4Section345MasterFeaturesDetails.SubSubCat_Id, SubSubCategoryMaster => SubSubCategoryMaster.ID, (Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master, SubSubCategoryMaster) => new { Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master, SubSubCategoryMaster })
                    .Where(x => (tenant_Id == null || x.Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master.Services4Section345MasterFeaturesDetails_tenant.Services4Section345MasterFeaturesDetails.Tenant_ID == tenant_Id)
                            && (x.Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master.Services4Section345MasterFeaturesDetails_tenant.Services4Section345MasterFeaturesDetails.ShortDescription.ToString().Contains(searchValue)
                        || x.SubSubCategoryMaster.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master.Services4Section345MasterFeaturesDetails_tenant.Services4Section345MasterFeaturesDetails.S4S345M_id.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master.Services4Section345MasterFeaturesDetails_tenant.Services4Section345MasterFeaturesDetails.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                       || x.Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master.Services4Section345MasterFeaturesDetails_tenant.Services4Section345MasterFeaturesDetails.Url.ToString().CaseInsensitiveContains(searchValue)
                       || x.Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master.Services4Section345MasterFeaturesDetails_tenant.Services4Section345MasterFeaturesDetails.Metadata.ToString().CaseInsensitiveContains(searchValue)
                       || x.Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master.Services4Section345MasterFeaturesDetails_tenant.Services4Section345MasterFeaturesDetails.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                       || x.Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master.Services4Section345MasterFeaturesDetails_tenant.Services4Section345MasterFeaturesDetails.Keyword.ToString().CaseInsensitiveContains(searchValue)
                       || x.Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master.Services4Section345MasterFeaturesDetails_tenant.Services4Section345MasterFeaturesDetails.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master.Services4Section345MasterFeaturesDetails_tenant.Services4Section345MasterFeaturesDetails.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master.Services4Section345MasterFeaturesDetails_tenant.Services4Section345MasterFeaturesDetails.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master.Services4Section345MasterFeaturesDetails_tenant.Services4Section345MasterFeaturesDetails.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master.Services4Section345MasterFeaturesDetails_tenant.Services4Section345MasterFeaturesDetails.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master.Services4Section345MasterFeaturesDetails_tenant.Services4Section345MasterFeaturesDetails.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.Services4Section345MasterFeaturesDetailsIndexViewModel
                    {

                        ID = x.Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master.Services4Section345MasterFeaturesDetails_tenant.Services4Section345MasterFeaturesDetails.ID,
                        SubSubCategory_Name = x.SubSubCategoryMaster.SubSubCategoryName,
                        ShortDescription = x.Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master.Services4Section345MasterFeaturesDetails_tenant.Services4Section345MasterFeaturesDetails.ShortDescription,
                        S4S345M_id = x.Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master.Services4Section345MasterFeaturesDetails_tenant.Services4Section345MasterFeaturesDetails.S4S345M_id,
                        Service_Id= x.Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master.Services4Section345MasterFeaturesDetails_tenant.Services4Section345MasterFeaturesDetails.Service_Id,
                        DisplayIndex = x.Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master.Services4Section345MasterFeaturesDetails_tenant.Services4Section345MasterFeaturesDetails.DisplayIndex,
                        Url = x.Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master.Services4Section345MasterFeaturesDetails_tenant.Services4Section345MasterFeaturesDetails.Url,
                        Metadata = x.Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master.Services4Section345MasterFeaturesDetails_tenant.Services4Section345MasterFeaturesDetails.Metadata,
                        MetaDescription = x.Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master.Services4Section345MasterFeaturesDetails_tenant.Services4Section345MasterFeaturesDetails.MetaDescription,
                        Keyword = x.Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master.Services4Section345MasterFeaturesDetails_tenant.Services4Section345MasterFeaturesDetails.Keyword,
                        TotalViews = x.Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master.Services4Section345MasterFeaturesDetails_tenant.Services4Section345MasterFeaturesDetails.TotalViews,
                        IsActive = x.Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master.Services4Section345MasterFeaturesDetails_tenant.Services4Section345MasterFeaturesDetails.IsActive,
                        TenantName = x.Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master.Services4Section345MasterFeaturesDetails_tenant.Services4Section345MasterFeaturesDetails.Tenant.Name,
                        Tenant_ID = x.Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master.Services4Section345MasterFeaturesDetails_tenant.Services4Section345MasterFeaturesDetails.Tenant.ID,
                        CreatedBy = x.Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master.Services4Section345MasterFeaturesDetails_tenant.Services4Section345MasterFeaturesDetails.CreatedBy,
                        CreatedOn = x.Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master.Services4Section345MasterFeaturesDetails_tenant.Services4Section345MasterFeaturesDetails.CreatedOn,
                        UpdatedBy = x.Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master.Services4Section345MasterFeaturesDetails_tenant.Services4Section345MasterFeaturesDetails.UpdatedBy,
                        UpdatedOn = x.Services4Section345MasterFeaturesDetails_tenant_Services4Section345Master.Services4Section345MasterFeaturesDetails_tenant.Services4Section345MasterFeaturesDetails.UpdatedOn
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.Services4Section345MasterFeaturesDetailsIndexViewModel>
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





        public EntityModel.Services4Section345MasterFeaturesDetails Create(EntityModel.Services4Section345MasterFeaturesDetails entity)
        {
            try
            {
                return unitOfWork.Services4Section345MasterFeaturesDetailsRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.Services4Section345MasterFeaturesDetails GetById(long Id)
        {
            try
            {
                EntityModel.Services4Section345MasterFeaturesDetails entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.Services4Section345MasterFeaturesDetailsRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.Services4Section345MasterFeaturesDetails Update(EntityModel.Services4Section345MasterFeaturesDetails entity)
        {
            try
            {
                return unitOfWork.Services4Section345MasterFeaturesDetailsRepository.Update(entity);
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
                unitOfWork.Services4Section345MasterFeaturesDetailsRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.Services4Section345MasterFeaturesDetails> GetAll()
        {
            try
            {
                return unitOfWork.Services4Section345MasterFeaturesDetailsRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.Services4Section345MasterFeaturesDetails> FindBy(Expression<Func<EntityModel.Services4Section345MasterFeaturesDetails, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.Services4Section345MasterFeaturesDetails> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.Services4Section345MasterFeaturesDetailsRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.Services4Section345MasterFeaturesDetailsRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.Services4Section345MasterFeaturesDetails, bool>> filter = null)
        {
            try
            {
                unitOfWork.Services4Section345MasterFeaturesDetailsRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.Services4Section345MasterFeaturesDetails, bool>> filter = null)
        {
            try
            {
                return unitOfWork.Services4Section345MasterFeaturesDetailsRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
