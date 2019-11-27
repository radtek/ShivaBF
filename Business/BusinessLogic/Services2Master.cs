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
    public class Services2Master : BaseBusiness, IServices2Master
    {
        public ViewModel.BusinessResultViewModel<ViewModel.Services2MasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.Services2MasterIndexViewModel> collection;
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
                totalRecords = unitOfWork.Services2MasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services2Master => Services2Master.Tenant_ID, tenant => tenant.ID, (Services2Master, tenant) => new { Services2Master, tenant })
                    .Join(unitOfWork.SubSubCategoriesMasterRepository.Get(), Services2Master_tenant => Services2Master_tenant.Services2Master.SubSubCat_Id, SubSubCategoriesMaster => SubSubCategoriesMaster.ID, (Services2Master_tenant, SubSubCategoriesMaster) => new { Services2Master_tenant, SubSubCategoriesMaster })
                    .Count(x => (tenant_Id == null || x.Services2Master_tenant.Services2Master.Tenant_ID == tenant_Id)
                            && (x.Services2Master_tenant.Services2Master.ID.ToString().Contains(searchValue)
                        || x.Services2Master_tenant.Services2Master.BannerImagePath.CaseInsensitiveContains(searchValue)
                        || x.Services2Master_tenant.Services2Master.BannerOnHeading.CaseInsensitiveContains(searchValue)
                        || x.SubSubCategoriesMaster.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services2Master_tenant.Services2Master.BannerHeadingDescription.CaseInsensitiveContains(searchValue)
                        || x.Services2Master_tenant.Services2Master.BannerOnHeading.CaseInsensitiveContains(searchValue)
                        || x.Services2Master_tenant.Services2Master.Section1Description.CaseInsensitiveContains(searchValue)
                        || x.Services2Master_tenant.Services2Master.Section2FAQDescription.CaseInsensitiveContains(searchValue)
                        || x.Services2Master_tenant.Services2Master.Section3DownloadDescription.CaseInsensitiveContains(searchValue)
                        || x.Services2Master_tenant.Services2Master.Section4PriceingDescription.CaseInsensitiveContains(searchValue)
                        || x.Services2Master_tenant.Services2Master.Section4PriceingHeading.CaseInsensitiveContains(searchValue)
                        || x.Services2Master_tenant.Services2Master.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services2Master_tenant.Services2Master.PageTitle.CaseInsensitiveContains(searchValue)
                        || x.Services2Master_tenant.Services2Master.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services2Master_tenant.Services2Master.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services2Master_tenant.Services2Master.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services2Master_tenant.Services2Master.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services2Master_tenant.Services2Master.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services2Master_tenant.Services2Master.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Services2Master_tenant.Services2Master.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services2Master_tenant.Services2Master.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services2Master_tenant.Services2Master.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Services2Master_tenant.Services2Master.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.Services2MasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services2Master => Services2Master.Tenant_ID, tenant => tenant.ID, (Services2Master, tenant) => new { Services2Master, tenant })
                    .Join(unitOfWork.SubSubCategoriesMasterRepository.Get(), Services2Master_tenant => Services2Master_tenant.Services2Master.SubSubCat_Id, SubSubCategoriesMaster => SubSubCategoriesMaster.ID, (Services2Master_tenant, SubSubCategoriesMaster) => new { Services2Master_tenant, SubSubCategoriesMaster })
                    .Where(x => (tenant_Id == null || x.Services2Master_tenant.Services2Master.Tenant_ID == tenant_Id)
                            && (x.Services2Master_tenant.Services2Master.ID.ToString().Contains(searchValue)
                        || x.Services2Master_tenant.Services2Master.BannerImagePath.CaseInsensitiveContains(searchValue)
                        || x.Services2Master_tenant.Services2Master.BannerOnHeading.CaseInsensitiveContains(searchValue)
                        || x.SubSubCategoriesMaster.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services2Master_tenant.Services2Master.BannerHeadingDescription.CaseInsensitiveContains(searchValue)
                        || x.Services2Master_tenant.Services2Master.BannerOnHeading.CaseInsensitiveContains(searchValue)
                        || x.Services2Master_tenant.Services2Master.Section1Description.CaseInsensitiveContains(searchValue)
                        || x.Services2Master_tenant.Services2Master.Section2FAQDescription.CaseInsensitiveContains(searchValue)
                        || x.Services2Master_tenant.Services2Master.Section3DownloadDescription.CaseInsensitiveContains(searchValue)
                        || x.Services2Master_tenant.Services2Master.Section4PriceingDescription.CaseInsensitiveContains(searchValue)
                        || x.Services2Master_tenant.Services2Master.Section4PriceingHeading.CaseInsensitiveContains(searchValue)
                        || x.Services2Master_tenant.Services2Master.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                         || x.Services2Master_tenant.Services2Master.PageTitle.CaseInsensitiveContains(searchValue)
                        || x.Services2Master_tenant.Services2Master.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services2Master_tenant.Services2Master.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services2Master_tenant.Services2Master.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services2Master_tenant.Services2Master.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services2Master_tenant.Services2Master.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services2Master_tenant.Services2Master.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Services2Master_tenant.Services2Master.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services2Master_tenant.Services2Master.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services2Master_tenant.Services2Master.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Services2Master_tenant.Services2Master.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.Services2MasterIndexViewModel 
                    {
                        ID = x.Services2Master_tenant.Services2Master.ID,
                        BannerImagePath = String.Concat(busConstant.Settings.CMSPath.TENANAT_UPLOAD_DIRECTORY, x.Services2Master_tenant.tenant.ID) + "/" + x.Services2Master_tenant.Services2Master.BannerImagePath,
                        BannerOnHeading = x.Services2Master_tenant.Services2Master.BannerOnHeading,
                        SubSubCategoryName = x.SubSubCategoriesMaster.SubSubCategoryName,
                        BannerHeadingDescription = x.Services2Master_tenant.Services2Master.BannerHeadingDescription,
                        Cat_Id = x.Services2Master_tenant.Services2Master.Cat_Id,
                        SubCat_Id = x.Services2Master_tenant.Services2Master.SubCat_Id,
                        SubSubCat_Id = x.Services2Master_tenant.Services2Master.SubSubCat_Id,
                        Section1Description = x.Services2Master_tenant.Services2Master.Section1Description,
                        Section2FAQDescription = x.Services2Master_tenant.Services2Master.Section2FAQDescription,
                        Section3DownloadDescription = x.Services2Master_tenant.Services2Master.Section3DownloadDescription,
                        Section4PriceingHeading = x.Services2Master_tenant.Services2Master.Section4PriceingHeading,
                        Section4PriceingDescription = x.Services2Master_tenant.Services2Master.Section4PriceingDescription,
                        DisplayIndex = x.Services2Master_tenant.Services2Master.DisplayIndex,
                        PageTitle = x.Services2Master_tenant.Services2Master.PageTitle,
                        Url = x.Services2Master_tenant.Services2Master.Url.ToString(),
                        Metadata= x.Services2Master_tenant.Services2Master.Metadata.ToString(),
                        MetaDescription= x.Services2Master_tenant.Services2Master.MetaDescription.ToString(),
                        Keyword= x.Services2Master_tenant.Services2Master.Keyword.ToString(),
                        TotalViews= x.Services2Master_tenant.Services2Master.TotalViews,
                        IsActive = x.Services2Master_tenant.Services2Master.IsActive,
                        TenantName = x.Services2Master_tenant.Services2Master.Tenant.Name,
                        CreatedBy = x.Services2Master_tenant.Services2Master.CreatedBy,
                        UpdatedBy = x.Services2Master_tenant.Services2Master.UpdatedBy,
                        CreatedOn= x.Services2Master_tenant.Services2Master.CreatedOn,
                        UpdatedOn= x.Services2Master_tenant.Services2Master.UpdatedOn
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.Services2MasterIndexViewModel>
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





        public EntityModel.Services2Master Create(EntityModel.Services2Master entity)
        {
            try
            {
                return unitOfWork.Services2MasterRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.Services2Master GetById(long Id)
        {
            try
            {
                EntityModel.Services2Master entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.Services2MasterRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.Services2Master Update(EntityModel.Services2Master entity)
        {
            try
            {
                return unitOfWork.Services2MasterRepository.Update(entity);
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
                var x = DataAccess.GetScalar.ByStoredProcedure("[dbo].[usp_DeleteService2]", param);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.Services2Master> GetAll()
        {
            try
            {
                return unitOfWork.Services2MasterRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.Services2Master> FindBy(Expression<Func<EntityModel.Services2Master, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.Services2Master> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.Services2MasterRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.Services2MasterRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.Services2Master, bool>> filter = null)
        {
            try
            {
                unitOfWork.Services2MasterRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.Services2Master, bool>> filter = null)
        {
            try
            {
                return unitOfWork.Services2MasterRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
