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
    public class HomePageBanner : BaseBusiness, IHomePageBanner
    {
        public ViewModel.BusinessResultViewModel<ViewModel.HomePageBannerIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.HomePageBannerIndexViewModel> collection;
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
                totalRecords = unitOfWork.HomePageBannerRepository.Get().Join(unitOfWork.TenantRepository.Get(), HomePageBanner => HomePageBanner.Tenant_ID, tenant => tenant.ID, (HomePageBanner, tenant) => new { HomePageBanner, tenant })
                      .Count(x => (tenant_Id == null || x.HomePageBanner.Tenant_ID == tenant_Id)
                            && (x.HomePageBanner.ID.ToString().Contains(searchValue)
                        || x.HomePageBanner.BannerImagePath.CaseInsensitiveContains(searchValue)
                        || x.HomePageBanner.BannerOnHeading1.CaseInsensitiveContains(searchValue)
                        || x.HomePageBanner.BannerOnHeading2.CaseInsensitiveContains(searchValue)
                        || x.HomePageBanner.BannerHeadingDescription.CaseInsensitiveContains(searchValue)
                        || x.HomePageBanner.AncharTagTitle.CaseInsensitiveContains(searchValue)
                        || x.HomePageBanner.AncharTagUrl.CaseInsensitiveContains(searchValue)
                        || x.HomePageBanner.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageBanner.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageBanner.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageBanner.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageBanner.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageBanner.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageBanner.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.HomePageBanner.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.HomePageBanner.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.HomePageBanner.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.HomePageBanner.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.HomePageBannerRepository.Get().Join(unitOfWork.TenantRepository.Get(), HomePageBanner => HomePageBanner.Tenant_ID, tenant => tenant.ID, (HomePageBanner, tenant) => new { HomePageBanner, tenant })
                      .Where(x => (tenant_Id == null || x.HomePageBanner.Tenant_ID == tenant_Id)
                            && (x.HomePageBanner.ID.ToString().Contains(searchValue)
                        || x.HomePageBanner.BannerImagePath.CaseInsensitiveContains(searchValue)
                        || x.HomePageBanner.BannerOnHeading1.CaseInsensitiveContains(searchValue)
                        || x.HomePageBanner.BannerOnHeading2.CaseInsensitiveContains(searchValue)
                        || x.HomePageBanner.BannerHeadingDescription.CaseInsensitiveContains(searchValue)
                        || x.HomePageBanner.AncharTagTitle.CaseInsensitiveContains(searchValue)
                        || x.HomePageBanner.AncharTagUrl.CaseInsensitiveContains(searchValue)
                        || x.HomePageBanner.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageBanner.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageBanner.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageBanner.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageBanner.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageBanner.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageBanner.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.HomePageBanner.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.HomePageBanner.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.HomePageBanner.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.HomePageBanner.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.HomePageBannerIndexViewModel 
                    {
                        ID = x.HomePageBanner.ID,
                        BannerImagePath = String.Concat(busConstant.Settings.CMSPath.TENANAT_UPLOAD_DIRECTORY, x.tenant.ID) + "/" + x.HomePageBanner.BannerImagePath,
                        BannerOnHeading1 = x.HomePageBanner.BannerOnHeading1,
                        BannerOnHeading2 = x.HomePageBanner.BannerOnHeading2,
                        BannerHeadingDescription = x.HomePageBanner.BannerHeadingDescription,
                        AncharTagTitle = x.HomePageBanner.AncharTagTitle,
                        AncharTagUrl = x.HomePageBanner.AncharTagUrl,
                        DisplayIndex = x.HomePageBanner.DisplayIndex,
                        Url= x.HomePageBanner.Url.ToString(),
                        Metadata= x.HomePageBanner.Metadata.ToString(),
                        MetaDescription= x.HomePageBanner.MetaDescription.ToString(),
                        Keyword= x.HomePageBanner.Keyword.ToString(),
                        TotalViews= x.HomePageBanner.TotalViews,
                        IsActive = x.HomePageBanner.IsActive,
                        TenantName = x.HomePageBanner.Tenant.Name,
                        CreatedBy = x.HomePageBanner.CreatedBy,
                        UpdatedBy = x.HomePageBanner.UpdatedBy,
                        CreatedOn= x.HomePageBanner.CreatedOn,
                        UpdatedOn= x.HomePageBanner.UpdatedOn
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.HomePageBannerIndexViewModel>
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





        public EntityModel.HomePageBanner Create(EntityModel.HomePageBanner entity)
        {
            try
            {
                return unitOfWork.HomePageBannerRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.HomePageBanner GetById(long Id)
        {
            try
            {
                EntityModel.HomePageBanner entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.HomePageBannerRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.HomePageBanner Update(EntityModel.HomePageBanner entity)
        {
            try
            {
                return unitOfWork.HomePageBannerRepository.Update(entity);
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
                unitOfWork.HomePageBannerRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.HomePageBanner> GetAll()
        {
            try
            {
                return unitOfWork.HomePageBannerRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.HomePageBanner> FindBy(Expression<Func<EntityModel.HomePageBanner, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.HomePageBanner> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.HomePageBannerRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.HomePageBannerRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.HomePageBanner, bool>> filter = null)
        {
            try
            {
                unitOfWork.HomePageBannerRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.HomePageBanner, bool>> filter = null)
        {
            try
            {
                return unitOfWork.HomePageBannerRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
