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
    public class Services6Master : BaseBusiness, IServices6Master
    {
        public ViewModel.BusinessResultViewModel<ViewModel.Services6MasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.Services6MasterIndexViewModel> collection;
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
                totalRecords = unitOfWork.Services6MasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services6Master => Services6Master.Tenant_ID, tenant => tenant.ID, (Services6Master, tenant) => new { Services6Master, tenant })
                    .Join(unitOfWork.SubSubCategoriesMasterRepository.Get(), Services6Master_tenant => Services6Master_tenant.Services6Master.SubSubCat_Id, SubSubCategoriesMaster => SubSubCategoriesMaster.ID, (Services6Master_tenant, SubSubCategoriesMaster) => new { Services6Master_tenant, SubSubCategoriesMaster })
                    .Count(x => (tenant_Id == null || x.Services6Master_tenant.Services6Master.Tenant_ID == tenant_Id)
                            && (x.Services6Master_tenant.Services6Master.ID.ToString().Contains(searchValue)
                        || x.Services6Master_tenant.Services6Master.BannerImagePath.CaseInsensitiveContains(searchValue)
                        || x.Services6Master_tenant.Services6Master.BannerOnHeading.CaseInsensitiveContains(searchValue)
                        || x.SubSubCategoriesMaster.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services6Master_tenant.Services6Master.BannerHeadingDescription.CaseInsensitiveContains(searchValue)
                        || x.Services6Master_tenant.Services6Master.BannerOnHeading.CaseInsensitiveContains(searchValue)
                        || x.Services6Master_tenant.Services6Master.Section1Description.CaseInsensitiveContains(searchValue)
                        || x.Services6Master_tenant.Services6Master.Section2Heading.CaseInsensitiveContains(searchValue)
                        || x.Services6Master_tenant.Services6Master.Section2HeadingDescription.CaseInsensitiveContains(searchValue)
                        || x.Services6Master_tenant.Services6Master.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services6Master_tenant.Services6Master.PageTitle.CaseInsensitiveContains(searchValue)
                        || x.Services6Master_tenant.Services6Master.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services6Master_tenant.Services6Master.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services6Master_tenant.Services6Master.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services6Master_tenant.Services6Master.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services6Master_tenant.Services6Master.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services6Master_tenant.Services6Master.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Services6Master_tenant.Services6Master.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services6Master_tenant.Services6Master.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services6Master_tenant.Services6Master.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Services6Master_tenant.Services6Master.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.Services6MasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services6Master => Services6Master.Tenant_ID, tenant => tenant.ID, (Services6Master, tenant) => new { Services6Master, tenant })
                    .Join(unitOfWork.SubSubCategoriesMasterRepository.Get(), Services6Master_tenant => Services6Master_tenant.Services6Master.SubSubCat_Id, SubSubCategoriesMaster => SubSubCategoriesMaster.ID, (Services6Master_tenant, SubSubCategoriesMaster) => new { Services6Master_tenant, SubSubCategoriesMaster })
                    .Where(x => (tenant_Id == null || x.Services6Master_tenant.Services6Master.Tenant_ID == tenant_Id)
                            && (x.Services6Master_tenant.Services6Master.ID.ToString().Contains(searchValue)
                        || x.Services6Master_tenant.Services6Master.BannerImagePath.CaseInsensitiveContains(searchValue)
                        || x.Services6Master_tenant.Services6Master.BannerOnHeading.CaseInsensitiveContains(searchValue)
                        || x.SubSubCategoriesMaster.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services6Master_tenant.Services6Master.BannerHeadingDescription.CaseInsensitiveContains(searchValue)
                        || x.Services6Master_tenant.Services6Master.BannerOnHeading.CaseInsensitiveContains(searchValue)
                        || x.Services6Master_tenant.Services6Master.Section1Description.CaseInsensitiveContains(searchValue)
                        || x.Services6Master_tenant.Services6Master.Section2Heading.CaseInsensitiveContains(searchValue)
                        || x.Services6Master_tenant.Services6Master.Section2HeadingDescription.CaseInsensitiveContains(searchValue)
                        || x.Services6Master_tenant.Services6Master.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services6Master_tenant.Services6Master.PageTitle.CaseInsensitiveContains(searchValue)
                        || x.Services6Master_tenant.Services6Master.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services6Master_tenant.Services6Master.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services6Master_tenant.Services6Master.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services6Master_tenant.Services6Master.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services6Master_tenant.Services6Master.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services6Master_tenant.Services6Master.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Services6Master_tenant.Services6Master.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services6Master_tenant.Services6Master.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services6Master_tenant.Services6Master.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Services6Master_tenant.Services6Master.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.Services6MasterIndexViewModel 
                    {
                        ID = x.Services6Master_tenant.Services6Master.ID,
                        BannerImagePath = String.Concat(busConstant.Settings.CMSPath.TENANAT_UPLOAD_DIRECTORY, x.Services6Master_tenant.tenant.ID) + "/" + x.Services6Master_tenant.Services6Master.BannerImagePath,
                        BannerOnHeading = x.Services6Master_tenant.Services6Master.BannerOnHeading,
                        SubSubCategoryName = x.SubSubCategoriesMaster.SubSubCategoryName,
                        BannerHeadingDescription = x.Services6Master_tenant.Services6Master.BannerHeadingDescription,
                        Cat_Id = x.Services6Master_tenant.Services6Master.Cat_Id,
                        SubCat_Id = x.Services6Master_tenant.Services6Master.SubCat_Id,
                        SubSubCat_Id = x.Services6Master_tenant.Services6Master.SubSubCat_Id,
                        Section1Description = x.Services6Master_tenant.Services6Master.Section1Description,
                        Section2Heading = x.Services6Master_tenant.Services6Master.Section2Heading,
                        Section2HeadingDescription = x.Services6Master_tenant.Services6Master.Section2HeadingDescription,
                        DisplayIndex = x.Services6Master_tenant.Services6Master.DisplayIndex,
                        PageTitle = x.Services6Master_tenant.Services6Master.PageTitle,
                        Url = x.Services6Master_tenant.Services6Master.Url.ToString(),
                        Metadata= x.Services6Master_tenant.Services6Master.Metadata.ToString(),
                        MetaDescription= x.Services6Master_tenant.Services6Master.MetaDescription.ToString(),
                        Keyword= x.Services6Master_tenant.Services6Master.Keyword.ToString(),
                        TotalViews= x.Services6Master_tenant.Services6Master.TotalViews,
                        IsActive = x.Services6Master_tenant.Services6Master.IsActive,
                        TenantName = x.Services6Master_tenant.Services6Master.Tenant.Name,
                        CreatedBy = x.Services6Master_tenant.Services6Master.CreatedBy,
                        UpdatedBy = x.Services6Master_tenant.Services6Master.UpdatedBy,
                        CreatedOn= x.Services6Master_tenant.Services6Master.CreatedOn,
                        UpdatedOn= x.Services6Master_tenant.Services6Master.UpdatedOn
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.Services6MasterIndexViewModel>
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





        public EntityModel.Services6Master Create(EntityModel.Services6Master entity)
        {
            try
            {
                return unitOfWork.Services6MasterRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.Services6Master GetById(long Id)
        {
            try
            {
                EntityModel.Services6Master entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.Services6MasterRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.Services6Master Update(EntityModel.Services6Master entity)
        {
            try
            {
                return unitOfWork.Services6MasterRepository.Update(entity);
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
                var x = DataAccess.GetScalar.ByStoredProcedure("[dbo].[usp_DeleteService6]", param);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.Services6Master> GetAll()
        {
            try
            {
                return unitOfWork.Services6MasterRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.Services6Master> FindBy(Expression<Func<EntityModel.Services6Master, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.Services6Master> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.Services6MasterRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.Services6MasterRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.Services6Master, bool>> filter = null)
        {
            try
            {
                unitOfWork.Services6MasterRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.Services6Master, bool>> filter = null)
        {
            try
            {
                return unitOfWork.Services6MasterRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
