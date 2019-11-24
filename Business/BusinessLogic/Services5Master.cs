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
    public class Services5Master : BaseBusiness, IServices5Master
    {
        public ViewModel.BusinessResultViewModel<ViewModel.Services5MasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.Services5MasterIndexViewModel> collection;
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
                totalRecords = unitOfWork.Services5MasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services5Master => Services5Master.Tenant_ID, tenant => tenant.ID, (Services5Master, tenant) => new { Services5Master, tenant })
                    .Join(unitOfWork.SubSubCategoriesMasterRepository.Get(), Services5Master_tenant => Services5Master_tenant.Services5Master.SubSubCat_Id, SubSubCategoriesMaster => SubSubCategoriesMaster.ID, (Services5Master_tenant, SubSubCategoriesMaster) => new { Services5Master_tenant, SubSubCategoriesMaster })
                    .Count(x => (tenant_Id == null || x.Services5Master_tenant.Services5Master.Tenant_ID == tenant_Id)
                            && (x.Services5Master_tenant.Services5Master.ID.ToString().Contains(searchValue)
                        || x.Services5Master_tenant.Services5Master.BannerImagePath.CaseInsensitiveContains(searchValue)
                        || x.Services5Master_tenant.Services5Master.BannerOnHeading.CaseInsensitiveContains(searchValue)
                        || x.SubSubCategoriesMaster.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services5Master_tenant.Services5Master.BannerHeadingDescription.CaseInsensitiveContains(searchValue)
                        || x.Services5Master_tenant.Services5Master.BannerOnHeading.CaseInsensitiveContains(searchValue)
                        || x.Services5Master_tenant.Services5Master.Section1Description.CaseInsensitiveContains(searchValue)
                        || x.Services5Master_tenant.Services5Master.Section2Heading.CaseInsensitiveContains(searchValue)
                        || x.Services5Master_tenant.Services5Master.Section2HeadingDescription.CaseInsensitiveContains(searchValue)
                        || x.Services5Master_tenant.Services5Master.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services5Master_tenant.Services5Master.PageTitle.CaseInsensitiveContains(searchValue)
                        || x.Services5Master_tenant.Services5Master.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services5Master_tenant.Services5Master.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services5Master_tenant.Services5Master.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services5Master_tenant.Services5Master.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services5Master_tenant.Services5Master.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services5Master_tenant.Services5Master.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Services5Master_tenant.Services5Master.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services5Master_tenant.Services5Master.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services5Master_tenant.Services5Master.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Services5Master_tenant.Services5Master.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.Services5MasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services5Master => Services5Master.Tenant_ID, tenant => tenant.ID, (Services5Master, tenant) => new { Services5Master, tenant })
                    .Join(unitOfWork.SubSubCategoriesMasterRepository.Get(), Services5Master_tenant => Services5Master_tenant.Services5Master.SubSubCat_Id, SubSubCategoriesMaster => SubSubCategoriesMaster.ID, (Services5Master_tenant, SubSubCategoriesMaster) => new { Services5Master_tenant, SubSubCategoriesMaster })
                    .Where(x => (tenant_Id == null || x.Services5Master_tenant.Services5Master.Tenant_ID == tenant_Id)
                            && (x.Services5Master_tenant.Services5Master.ID.ToString().Contains(searchValue)
                        || x.Services5Master_tenant.Services5Master.BannerImagePath.CaseInsensitiveContains(searchValue)
                        || x.Services5Master_tenant.Services5Master.BannerOnHeading.CaseInsensitiveContains(searchValue)
                        || x.SubSubCategoriesMaster.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services5Master_tenant.Services5Master.BannerHeadingDescription.CaseInsensitiveContains(searchValue)
                        || x.Services5Master_tenant.Services5Master.BannerOnHeading.CaseInsensitiveContains(searchValue)
                        || x.Services5Master_tenant.Services5Master.Section1Description.CaseInsensitiveContains(searchValue)
                        || x.Services5Master_tenant.Services5Master.Section2Heading.CaseInsensitiveContains(searchValue)
                        || x.Services5Master_tenant.Services5Master.Section2HeadingDescription.CaseInsensitiveContains(searchValue)
                        || x.Services5Master_tenant.Services5Master.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services5Master_tenant.Services5Master.PageTitle.CaseInsensitiveContains(searchValue)
                        || x.Services5Master_tenant.Services5Master.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services5Master_tenant.Services5Master.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services5Master_tenant.Services5Master.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services5Master_tenant.Services5Master.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services5Master_tenant.Services5Master.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services5Master_tenant.Services5Master.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Services5Master_tenant.Services5Master.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services5Master_tenant.Services5Master.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services5Master_tenant.Services5Master.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Services5Master_tenant.Services5Master.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.Services5MasterIndexViewModel 
                    {
                        ID = x.Services5Master_tenant.Services5Master.ID,
                        BannerImagePath = String.Concat(busConstant.Settings.CMSPath.TENANAT_UPLOAD_DIRECTORY, x.Services5Master_tenant.tenant.ID) + "/" + x.Services5Master_tenant.Services5Master.BannerImagePath,
                        BannerOnHeading = x.Services5Master_tenant.Services5Master.BannerOnHeading,
                        SubSubCategoryName = x.SubSubCategoriesMaster.SubSubCategoryName,
                        BannerHeadingDescription = x.Services5Master_tenant.Services5Master.BannerHeadingDescription,
                        Cat_Id = x.Services5Master_tenant.Services5Master.Cat_Id,
                        SubCat_Id = x.Services5Master_tenant.Services5Master.SubCat_Id,
                        SubSubCat_Id = x.Services5Master_tenant.Services5Master.SubSubCat_Id,
                        Section1Description = x.Services5Master_tenant.Services5Master.Section1Description,
                        Section2Heading = x.Services5Master_tenant.Services5Master.Section2Heading,
                        Section2HeadingDescription = x.Services5Master_tenant.Services5Master.Section2HeadingDescription,
                        DisplayIndex = x.Services5Master_tenant.Services5Master.DisplayIndex,
                        PageTitle = x.Services5Master_tenant.Services5Master.PageTitle,
                        Url = x.Services5Master_tenant.Services5Master.Url.ToString(),
                        Metadata= x.Services5Master_tenant.Services5Master.Metadata.ToString(),
                        MetaDescription= x.Services5Master_tenant.Services5Master.MetaDescription.ToString(),
                        Keyword= x.Services5Master_tenant.Services5Master.Keyword.ToString(),
                        TotalViews= x.Services5Master_tenant.Services5Master.TotalViews,
                        IsActive = x.Services5Master_tenant.Services5Master.IsActive,
                        TenantName = x.Services5Master_tenant.Services5Master.Tenant.Name,
                        CreatedBy = x.Services5Master_tenant.Services5Master.CreatedBy,
                        UpdatedBy = x.Services5Master_tenant.Services5Master.UpdatedBy,
                        CreatedOn= x.Services5Master_tenant.Services5Master.CreatedOn,
                        UpdatedOn= x.Services5Master_tenant.Services5Master.UpdatedOn
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.Services5MasterIndexViewModel>
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





        public EntityModel.Services5Master Create(EntityModel.Services5Master entity)
        {
            try
            {
                return unitOfWork.Services5MasterRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.Services5Master GetById(long Id)
        {
            try
            {
                EntityModel.Services5Master entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.Services5MasterRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.Services5Master Update(EntityModel.Services5Master entity)
        {
            try
            {
                return unitOfWork.Services5MasterRepository.Update(entity);
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
                unitOfWork.Services5MasterRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.Services5Master> GetAll()
        {
            try
            {
                return unitOfWork.Services5MasterRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.Services5Master> FindBy(Expression<Func<EntityModel.Services5Master, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.Services5Master> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.Services5MasterRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.Services5MasterRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.Services5Master, bool>> filter = null)
        {
            try
            {
                unitOfWork.Services5MasterRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.Services5Master, bool>> filter = null)
        {
            try
            {
                return unitOfWork.Services5MasterRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
