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
    public class Services6Section2MasterFeaturesDetails : BaseBusiness, IServices6Section2MasterFeaturesDetails
    {
        public ViewModel.BusinessResultViewModel<ViewModel.Services6Section2MasterFeaturesDetailsIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.Services6Section2MasterFeaturesDetailsIndexViewModel> collection;
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
                totalRecords = unitOfWork.Services6Section2MasterFeaturesDetailsRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services6Section2MasterFeaturesDetails => Services6Section2MasterFeaturesDetails.Tenant_ID, tenant => tenant.ID, (Services6Section2MasterFeaturesDetails, tenant) => new { Services6Section2MasterFeaturesDetails, tenant })
                    .Join(unitOfWork.Services6Section2MasterRepository.Get(), Services6Section2MasterFeaturesDetails_tenant => Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.S6S2M_Id, Services6Section2Master => Services6Section2Master.ID, (Services6Section2MasterFeaturesDetails_tenant, Services6Section2Master) => new { Services6Section2MasterFeaturesDetails_tenant, Services6Section2Master })
                    .Join(unitOfWork.SubSubCategoriesMasterRepository.Get(), Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master => Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.SubSubCat_Id, SubSubCategoryMaster => SubSubCategoryMaster.ID, (Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master, SubSubCategoryMaster) => new { Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master, SubSubCategoryMaster })
                     .Join(unitOfWork.Services6MasterRepository.Get(), Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster => Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.Service_Id, Services6Master => Services6Master.ID, (Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster, Services6Master) => new { Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster, Services6Master })
                    .Count(x => (tenant_Id == null || x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.Tenant_ID == tenant_Id)
                            && (x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.Price.ToString().Contains(searchValue)
                        || x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.SubSubCategoryMaster.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.S6S2M_Id.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.AncharTagTitle.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.AncharTagUrl.ToString().CaseInsensitiveContains(searchValue) 
                        || x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.Services6Section2MasterFeaturesDetailsRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services6Section2MasterFeaturesDetails => Services6Section2MasterFeaturesDetails.Tenant_ID, tenant => tenant.ID, (Services6Section2MasterFeaturesDetails, tenant) => new { Services6Section2MasterFeaturesDetails, tenant })
                    .Join(unitOfWork.Services6Section2MasterRepository.Get(), Services6Section2MasterFeaturesDetails_tenant => Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.S6S2M_Id, Services6Section2Master => Services6Section2Master.ID, (Services6Section2MasterFeaturesDetails_tenant, Services6Section2Master) => new { Services6Section2MasterFeaturesDetails_tenant, Services6Section2Master })
                    .Join(unitOfWork.SubSubCategoriesMasterRepository.Get(), Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master => Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.SubSubCat_Id, SubSubCategoryMaster => SubSubCategoryMaster.ID, (Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master, SubSubCategoryMaster) => new { Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master, SubSubCategoryMaster })
                     .Join(unitOfWork.Services6MasterRepository.Get(), Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster => Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.Service_Id, Services6Master => Services6Master.ID, (Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster, Services6Master) => new { Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster, Services6Master })
                    .Where(x => (tenant_Id == null || x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.Tenant_ID == tenant_Id)
                            && (x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.Price.ToString().Contains(searchValue)
                        || x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.SubSubCategoryMaster.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.S6S2M_Id.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.AncharTagTitle.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.AncharTagUrl.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.Services6Section2MasterFeaturesDetailsIndexViewModel
                    {
                        ID = x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.ID,
                        SubSubCategory_Name = x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.SubSubCategoryMaster.SubSubCategoryName,
                        Price = x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.Price,
                        S6S2M_Id= x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.S6S2M_Id,
                        AncharTagTitle = x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.AncharTagTitle,
                        AncharTagUrl = x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.AncharTagUrl,
                        Service_Id = x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.Service_Id,
                        DisplayIndex = x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.DisplayIndex,
                        Url = x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.Url,
                        Metadata = x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.Metadata,
                        MetaDescription = x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.MetaDescription,
                        Keyword = x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.Keyword,
                        TotalViews = x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.TotalViews,
                        IsActive = x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.IsActive,
                        TenantName = x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.Tenant.Name,
                        Tenant_ID = x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.Tenant.ID,
                        CreatedBy = x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.CreatedBy,
                        CreatedOn = x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.CreatedOn,
                        UpdatedBy = x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.UpdatedBy,
                        UpdatedOn = x.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master_SubSubCategoryMaster.Services6Section2MasterFeaturesDetails_tenant_Services6Section2Master.Services6Section2MasterFeaturesDetails_tenant.Services6Section2MasterFeaturesDetails.UpdatedOn,
                        ServiceUrl = x.Services6Master.Url
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.Services6Section2MasterFeaturesDetailsIndexViewModel>
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





        public EntityModel.Services6Section2MasterFeaturesDetails Create(EntityModel.Services6Section2MasterFeaturesDetails entity)
        {
            try
            {
                return unitOfWork.Services6Section2MasterFeaturesDetailsRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.Services6Section2MasterFeaturesDetails GetById(long Id)
        {
            try
            {
                EntityModel.Services6Section2MasterFeaturesDetails entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.Services6Section2MasterFeaturesDetailsRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.Services6Section2MasterFeaturesDetails Update(EntityModel.Services6Section2MasterFeaturesDetails entity)
        {
            try
            {
                return unitOfWork.Services6Section2MasterFeaturesDetailsRepository.Update(entity);
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
                unitOfWork.Services6Section2MasterFeaturesDetailsRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.Services6Section2MasterFeaturesDetails> GetAll()
        {
            try
            {
                return unitOfWork.Services6Section2MasterFeaturesDetailsRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.Services6Section2MasterFeaturesDetails> FindBy(Expression<Func<EntityModel.Services6Section2MasterFeaturesDetails, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.Services6Section2MasterFeaturesDetails> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.Services6Section2MasterFeaturesDetailsRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.Services6Section2MasterFeaturesDetailsRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.Services6Section2MasterFeaturesDetails, bool>> filter = null)
        {
            try
            {
                unitOfWork.Services6Section2MasterFeaturesDetailsRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.Services6Section2MasterFeaturesDetails, bool>> filter = null)
        {
            try
            {
                return unitOfWork.Services6Section2MasterFeaturesDetailsRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
