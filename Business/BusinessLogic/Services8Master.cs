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
    public class Services8Master : BaseBusiness, IServices8Master
    {
        public ViewModel.BusinessResultViewModel<ViewModel.Services8MasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.Services8MasterIndexViewModel> collection;
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
                totalRecords = unitOfWork.Services8MasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services8Master => Services8Master.Tenant_ID, tenant => tenant.ID, (Services8Master, tenant) => new { Services8Master, tenant })
                    .Join(unitOfWork.SubSubCategoriesMasterRepository.Get(), Services8Master_tenant => Services8Master_tenant.Services8Master.SubSubCat_Id, SubSubCategoriesMaster => SubSubCategoriesMaster.ID, (Services8Master_tenant, SubSubCategoriesMaster) => new { Services8Master_tenant, SubSubCategoriesMaster })
                    .Count(x => (tenant_Id == null || x.Services8Master_tenant.Services8Master.Tenant_ID == tenant_Id)
                            && (x.Services8Master_tenant.Services8Master.ID.ToString().Contains(searchValue)
                        || x.Services8Master_tenant.Services8Master.BannerImagePath.CaseInsensitiveContains(searchValue)
                        || x.Services8Master_tenant.Services8Master.BannerOnHeading.CaseInsensitiveContains(searchValue)
                        || x.SubSubCategoriesMaster.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services8Master_tenant.Services8Master.BannerHeadingDescription.CaseInsensitiveContains(searchValue)
                        || x.Services8Master_tenant.Services8Master.BannerOnHeading.CaseInsensitiveContains(searchValue)
                        || x.Services8Master_tenant.Services8Master.Section1Description.CaseInsensitiveContains(searchValue)
                        || x.Services8Master_tenant.Services8Master.Section1Heading.CaseInsensitiveContains(searchValue)
                        || x.Services8Master_tenant.Services8Master.Section2BannerPath.CaseInsensitiveContains(searchValue)
                        || x.Services8Master_tenant.Services8Master.Section2BannerHeadingDescription.CaseInsensitiveContains(searchValue)
                        || x.Services8Master_tenant.Services8Master.Section4Heading.CaseInsensitiveContains(searchValue)
                        || x.Services8Master_tenant.Services8Master.Section5Heading.CaseInsensitiveContains(searchValue)
                        || x.Services8Master_tenant.Services8Master.Section5Description.CaseInsensitiveContains(searchValue)
                        || x.Services8Master_tenant.Services8Master.Section5TextboxMaskedText.CaseInsensitiveContains(searchValue)
                        || x.Services8Master_tenant.Services8Master.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services8Master_tenant.Services8Master.PageTitle.CaseInsensitiveContains(searchValue)
                        || x.Services8Master_tenant.Services8Master.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services8Master_tenant.Services8Master.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services8Master_tenant.Services8Master.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services8Master_tenant.Services8Master.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services8Master_tenant.Services8Master.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services8Master_tenant.Services8Master.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Services8Master_tenant.Services8Master.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services8Master_tenant.Services8Master.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services8Master_tenant.Services8Master.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Services8Master_tenant.Services8Master.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.Services8MasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services8Master => Services8Master.Tenant_ID, tenant => tenant.ID, (Services8Master, tenant) => new { Services8Master, tenant })
                    .Join(unitOfWork.SubSubCategoriesMasterRepository.Get(), Services8Master_tenant => Services8Master_tenant.Services8Master.SubSubCat_Id, SubSubCategoriesMaster => SubSubCategoriesMaster.ID, (Services8Master_tenant, SubSubCategoriesMaster) => new { Services8Master_tenant, SubSubCategoriesMaster })
                    .Where(x => (tenant_Id == null || x.Services8Master_tenant.Services8Master.Tenant_ID == tenant_Id)
                            && (x.Services8Master_tenant.Services8Master.ID.ToString().Contains(searchValue)
                        || x.Services8Master_tenant.Services8Master.BannerImagePath.CaseInsensitiveContains(searchValue)
                        || x.Services8Master_tenant.Services8Master.BannerOnHeading.CaseInsensitiveContains(searchValue)
                        || x.SubSubCategoriesMaster.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services8Master_tenant.Services8Master.BannerHeadingDescription.CaseInsensitiveContains(searchValue)
                        || x.Services8Master_tenant.Services8Master.BannerOnHeading.CaseInsensitiveContains(searchValue)
                        || x.Services8Master_tenant.Services8Master.Section1Description.CaseInsensitiveContains(searchValue)
                        || x.Services8Master_tenant.Services8Master.Section1Heading.CaseInsensitiveContains(searchValue)
                        || x.Services8Master_tenant.Services8Master.Section2BannerPath.CaseInsensitiveContains(searchValue)
                        || x.Services8Master_tenant.Services8Master.Section2BannerHeadingDescription.CaseInsensitiveContains(searchValue)
                        || x.Services8Master_tenant.Services8Master.Section4Heading.CaseInsensitiveContains(searchValue)
                        || x.Services8Master_tenant.Services8Master.Section5Heading.CaseInsensitiveContains(searchValue)
                        || x.Services8Master_tenant.Services8Master.Section5Description.CaseInsensitiveContains(searchValue)
                        || x.Services8Master_tenant.Services8Master.Section5TextboxMaskedText.CaseInsensitiveContains(searchValue)
                        || x.Services8Master_tenant.Services8Master.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services8Master_tenant.Services8Master.PageTitle.CaseInsensitiveContains(searchValue)
                        || x.Services8Master_tenant.Services8Master.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services8Master_tenant.Services8Master.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services8Master_tenant.Services8Master.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services8Master_tenant.Services8Master.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services8Master_tenant.Services8Master.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services8Master_tenant.Services8Master.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Services8Master_tenant.Services8Master.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services8Master_tenant.Services8Master.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services8Master_tenant.Services8Master.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Services8Master_tenant.Services8Master.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.Services8MasterIndexViewModel 
                    {
                        ID = x.Services8Master_tenant.Services8Master.ID,
                        BannerImagePath = String.Concat(busConstant.Settings.CMSPath.TENANAT_UPLOAD_DIRECTORY, x.Services8Master_tenant.tenant.ID) + "/" + x.Services8Master_tenant.Services8Master.BannerImagePath,
                        BannerOnHeading = x.Services8Master_tenant.Services8Master.BannerOnHeading,
                        SubSubCategoryName = x.SubSubCategoriesMaster.SubSubCategoryName,
                        BannerHeadingDescription = x.Services8Master_tenant.Services8Master.BannerHeadingDescription,
                        Cat_Id = x.Services8Master_tenant.Services8Master.Cat_Id,
                        SubCat_Id = x.Services8Master_tenant.Services8Master.SubCat_Id,
                        SubSubCat_Id = x.Services8Master_tenant.Services8Master.SubSubCat_Id,
                        Section1Heading = x.Services8Master_tenant.Services8Master.Section1Heading,
                        Section1Description = x.Services8Master_tenant.Services8Master.Section1Description,
                        Section2BannerPath = String.Concat(busConstant.Settings.CMSPath.TENANAT_UPLOAD_DIRECTORY, x.Services8Master_tenant.tenant.ID) + "/" + x.Services8Master_tenant.Services8Master.Section2BannerPath,
                        Section2BannerHeadingDescription = x.Services8Master_tenant.Services8Master.Section2BannerHeadingDescription,
                        Section4Heading = x.Services8Master_tenant.Services8Master.Section4Heading,
                        Section5Heading = x.Services8Master_tenant.Services8Master.Section5Heading,
                        Section5Description = x.Services8Master_tenant.Services8Master.Section5Description,
                        Section5TextboxMaskedText = x.Services8Master_tenant.Services8Master.Section5TextboxMaskedText,
                        DisplayIndex = x.Services8Master_tenant.Services8Master.DisplayIndex,
                        PageTitle = x.Services8Master_tenant.Services8Master.PageTitle,
                        Url = x.Services8Master_tenant.Services8Master.Url.ToString(),
                        Metadata= x.Services8Master_tenant.Services8Master.Metadata.ToString(),
                        MetaDescription= x.Services8Master_tenant.Services8Master.MetaDescription.ToString(),
                        Keyword= x.Services8Master_tenant.Services8Master.Keyword.ToString(),
                        TotalViews= x.Services8Master_tenant.Services8Master.TotalViews,
                        IsActive = x.Services8Master_tenant.Services8Master.IsActive,
                        TenantName = x.Services8Master_tenant.Services8Master.Tenant.Name,
                        CreatedBy = x.Services8Master_tenant.Services8Master.CreatedBy,
                        UpdatedBy = x.Services8Master_tenant.Services8Master.UpdatedBy,
                        CreatedOn= x.Services8Master_tenant.Services8Master.CreatedOn,
                        UpdatedOn= x.Services8Master_tenant.Services8Master.UpdatedOn
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.Services8MasterIndexViewModel>
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





        public EntityModel.Services8Master Create(EntityModel.Services8Master entity)
        {
            try
            {
                return unitOfWork.Services8MasterRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.Services8Master GetById(long Id)
        {
            try
            {
                EntityModel.Services8Master entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.Services8MasterRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.Services8Master Update(EntityModel.Services8Master entity)
        {
            try
            {
                return unitOfWork.Services8MasterRepository.Update(entity);
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
                var x = DataAccess.GetScalar.ByStoredProcedure("[dbo].[usp_DeleteService8]", param);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.Services8Master> GetAll()
        {
            try
            {
                return unitOfWork.Services8MasterRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.Services8Master> FindBy(Expression<Func<EntityModel.Services8Master, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.Services8Master> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.Services8MasterRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.Services8MasterRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.Services8Master, bool>> filter = null)
        {
            try
            {
                unitOfWork.Services8MasterRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.Services8Master, bool>> filter = null)
        {
            try
            {
                return unitOfWork.Services8MasterRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
