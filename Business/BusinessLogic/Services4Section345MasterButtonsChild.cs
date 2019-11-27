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
    public class Services4Section345MasterButtonsChild : BaseBusiness, IServices4Section345MasterButtonsChild
    {
        public ViewModel.BusinessResultViewModel<ViewModel.Services4Section345MasterButtonsChildIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.Services4Section345MasterButtonsChildIndexViewModel> collection;
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
                totalRecords = unitOfWork.Services4Section345MasterButtonsChildRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services4Section345MasterButtonsChild => Services4Section345MasterButtonsChild.Tenant_ID, tenant => tenant.ID, (Services4Section345MasterButtonsChild, tenant) => new { Services4Section345MasterButtonsChild, tenant })
                    .Join(unitOfWork.Services4Section345MasterRepository.Get(), Services4Section345MasterButtonsChild_tenant => Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.S4S345M_id, Services4Section345Master => Services4Section345Master.ID, (Services4Section345MasterButtonsChild_tenant, Services4Section345Master) => new { Services4Section345MasterButtonsChild_tenant, Services4Section345Master })
                    .Join(unitOfWork.SubSubCategoriesMasterRepository.Get(), Services4Section345MasterButtonsChild_tenant_Services4Section345Master => Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.SubSubCat_Id, SubSubCategoryMaster => SubSubCategoryMaster.ID, (Services4Section345MasterButtonsChild_tenant_Services4Section345Master, SubSubCategoryMaster) => new { Services4Section345MasterButtonsChild_tenant_Services4Section345Master, SubSubCategoryMaster })
                     .Join(unitOfWork.Services4MasterRepository.Get(), Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster => Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.Service_Id, Services4Master => Services4Master.ID, (Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster, Services4Master) => new { Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster, Services4Master })
                    .Count(x => (tenant_Id == null || x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.Tenant_ID == tenant_Id)
                            && (x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.FeatureDescription.ToString().Contains(searchValue)
                        || x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.SubSubCategoryMaster.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.S4S345M_id.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.Price.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.AncharTagTitle.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.AncharTagUrl.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.Services4Section345MasterButtonsChildRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services4Section345MasterButtonsChild => Services4Section345MasterButtonsChild.Tenant_ID, tenant => tenant.ID, (Services4Section345MasterButtonsChild, tenant) => new { Services4Section345MasterButtonsChild, tenant })
                    .Join(unitOfWork.Services4Section345MasterRepository.Get(), Services4Section345MasterButtonsChild_tenant => Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.S4S345M_id, Services4Section345Master => Services4Section345Master.ID, (Services4Section345MasterButtonsChild_tenant, Services4Section345Master) => new { Services4Section345MasterButtonsChild_tenant, Services4Section345Master })
                    .Join(unitOfWork.SubSubCategoriesMasterRepository.Get(), Services4Section345MasterButtonsChild_tenant_Services4Section345Master => Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.SubSubCat_Id, SubSubCategoryMaster => SubSubCategoryMaster.ID, (Services4Section345MasterButtonsChild_tenant_Services4Section345Master, SubSubCategoryMaster) => new { Services4Section345MasterButtonsChild_tenant_Services4Section345Master, SubSubCategoryMaster })
                     .Join(unitOfWork.Services4MasterRepository.Get(), Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster => Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.Service_Id, Services4Master => Services4Master.ID, (Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster, Services4Master) => new { Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster, Services4Master })
                    .Where(x => (tenant_Id == null || x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.Tenant_ID == tenant_Id)
                            && (x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.FeatureDescription.ToString().Contains(searchValue)
                        || x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.SubSubCategoryMaster.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.S4S345M_id.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.Price.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.AncharTagTitle.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.AncharTagUrl.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.Services4Section345MasterButtonsChildIndexViewModel
                    {

                        ID = x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.ID,
                        SubSubCategory_Name = x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.SubSubCategoryMaster.SubSubCategoryName,
                        FeatureDescription = x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.FeatureDescription,
                        S4S345M_id = x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.S4S345M_id,
                        Price = x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.Price,
                        AncharTagTitle = x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.AncharTagTitle,
                        AncharTagUrl = x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.AncharTagUrl,
                        Service_Id = x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.Service_Id,
                        DisplayIndex = x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.DisplayIndex,
                        Url = x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.Url,
                        Metadata = x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.Metadata,
                        MetaDescription = x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.MetaDescription,
                        Keyword = x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.Keyword,
                        TotalViews = x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.TotalViews,
                        IsActive = x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.IsActive,
                        TenantName = x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.Tenant.Name,
                        Tenant_ID = x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.Tenant.ID,
                        CreatedBy = x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.CreatedBy,
                        CreatedOn = x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.CreatedOn,
                        UpdatedBy = x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.UpdatedBy,
                        UpdatedOn = x.Services4Section345MasterButtonsChild_tenant_Services4Section345Master_SubSubCategoryMaster.Services4Section345MasterButtonsChild_tenant_Services4Section345Master.Services4Section345MasterButtonsChild_tenant.Services4Section345MasterButtonsChild.UpdatedOn,
                        ServiceUrl = x.Services4Master.Url
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.Services4Section345MasterButtonsChildIndexViewModel>
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





        public EntityModel.Services4Section345MasterButtonsChild Create(EntityModel.Services4Section345MasterButtonsChild entity)
        {
            try
            {
                return unitOfWork.Services4Section345MasterButtonsChildRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.Services4Section345MasterButtonsChild GetById(long Id)
        {
            try
            {
                EntityModel.Services4Section345MasterButtonsChild entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.Services4Section345MasterButtonsChildRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.Services4Section345MasterButtonsChild Update(EntityModel.Services4Section345MasterButtonsChild entity)
        {
            try
            {
                return unitOfWork.Services4Section345MasterButtonsChildRepository.Update(entity);
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
                var x = DataAccess.GetScalar.ByStoredProcedure("[dbo].[usp_DeleteServices4Section345MasterButtonsChild]", param);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.Services4Section345MasterButtonsChild> GetAll()
        {
            try
            {
                return unitOfWork.Services4Section345MasterButtonsChildRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.Services4Section345MasterButtonsChild> FindBy(Expression<Func<EntityModel.Services4Section345MasterButtonsChild, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.Services4Section345MasterButtonsChild> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.Services4Section345MasterButtonsChildRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.Services4Section345MasterButtonsChildRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.Services4Section345MasterButtonsChild, bool>> filter = null)
        {
            try
            {
                unitOfWork.Services4Section345MasterButtonsChildRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.Services4Section345MasterButtonsChild, bool>> filter = null)
        {
            try
            {
                return unitOfWork.Services4Section345MasterButtonsChildRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
