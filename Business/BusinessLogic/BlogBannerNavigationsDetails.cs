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
    public class BlogBannerNavigationsDetails : BaseBusiness, IBlogBannerNavigationsDetails
    {
        public ViewModel.BusinessResultViewModel<ViewModel.BlogsBannerNavigationsDetailsIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.BlogsBannerNavigationsDetailsIndexViewModel> collection;
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
                totalRecords = unitOfWork.BannerNavigationsDetailsRepository.Get().Join(unitOfWork.TenantRepository.Get(), BannerNavigationsDetails => BannerNavigationsDetails.Tenant_ID, tenant => tenant.ID, (BannerNavigationsDetails, tenant) => new { BannerNavigationsDetails, tenant })
                    .Join(unitOfWork.BlogMasterRepository.Get(), BannerNavigationsDetails_tenant => BannerNavigationsDetails_tenant.BannerNavigationsDetails.Blog_Id, Blog => Blog.ID, (BannerNavigationsDetails_tenant, Blog) => new { BannerNavigationsDetails_tenant, Blog })
                  .Count(x => (tenant_Id == null || x.BannerNavigationsDetails_tenant.BannerNavigationsDetails.Tenant_ID == tenant_Id)
                            && (x.BannerNavigationsDetails_tenant.BannerNavigationsDetails.ID.ToString().Contains(searchValue)
                        || x.BannerNavigationsDetails_tenant.BannerNavigationsDetails.AncharTagTitle.CaseInsensitiveContains(searchValue)
                        || x.BannerNavigationsDetails_tenant.BannerNavigationsDetails.AncharTagUrl.CaseInsensitiveContains(searchValue)
                        || x.Blog.BlogTitle.CaseInsensitiveContains(searchValue)
                        || x.BannerNavigationsDetails_tenant.BannerNavigationsDetails.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.BannerNavigationsDetails_tenant.BannerNavigationsDetails.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.BannerNavigationsDetails_tenant.BannerNavigationsDetails.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.BannerNavigationsDetails_tenant.BannerNavigationsDetails.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.BannerNavigationsDetails_tenant.BannerNavigationsDetails.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.BannerNavigationsDetails_tenant.BannerNavigationsDetails.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.BannerNavigationsDetails_tenant.BannerNavigationsDetails.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.BannerNavigationsDetails_tenant.BannerNavigationsDetails.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.BannerNavigationsDetails_tenant.BannerNavigationsDetails.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.BannerNavigationsDetails_tenant.BannerNavigationsDetails.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.BannerNavigationsDetailsRepository.Get().Join(unitOfWork.TenantRepository.Get(), BannerNavigationsDetails => BannerNavigationsDetails.Tenant_ID, tenant => tenant.ID, (BannerNavigationsDetails, tenant) => new { BannerNavigationsDetails, tenant })
                    .Join(unitOfWork.BlogMasterRepository.Get(), BannerNavigationsDetails_tenant => BannerNavigationsDetails_tenant.BannerNavigationsDetails.Blog_Id, Blog => Blog.ID, (BannerNavigationsDetails_tenant, Blog) => new { BannerNavigationsDetails_tenant, Blog })
                  .Where(x => (tenant_Id == null || x.BannerNavigationsDetails_tenant.BannerNavigationsDetails.Tenant_ID == tenant_Id)
                            && (x.BannerNavigationsDetails_tenant.BannerNavigationsDetails.ID.ToString().Contains(searchValue)
                        || x.BannerNavigationsDetails_tenant.BannerNavigationsDetails.AncharTagTitle.CaseInsensitiveContains(searchValue)
                        || x.BannerNavigationsDetails_tenant.BannerNavigationsDetails.AncharTagUrl.CaseInsensitiveContains(searchValue)
                        || x.Blog.BlogTitle.CaseInsensitiveContains(searchValue)
                        || x.BannerNavigationsDetails_tenant.BannerNavigationsDetails.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.BannerNavigationsDetails_tenant.BannerNavigationsDetails.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.BannerNavigationsDetails_tenant.BannerNavigationsDetails.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.BannerNavigationsDetails_tenant.BannerNavigationsDetails.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.BannerNavigationsDetails_tenant.BannerNavigationsDetails.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.BannerNavigationsDetails_tenant.BannerNavigationsDetails.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.BannerNavigationsDetails_tenant.BannerNavigationsDetails.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.BannerNavigationsDetails_tenant.BannerNavigationsDetails.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.BannerNavigationsDetails_tenant.BannerNavigationsDetails.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.BannerNavigationsDetails_tenant.BannerNavigationsDetails.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.BlogsBannerNavigationsDetailsIndexViewModel 
                    {
                        ID = x.BannerNavigationsDetails_tenant.BannerNavigationsDetails.ID,
                        AncharTagTitle = x.BannerNavigationsDetails_tenant.BannerNavigationsDetails.AncharTagTitle,
                        AncharTagUrl = x.BannerNavigationsDetails_tenant.BannerNavigationsDetails.AncharTagUrl,
                        BlogTitle = x.Blog.BlogTitle,
                        Url= x.BannerNavigationsDetails_tenant.BannerNavigationsDetails.Url.ToString(),
                        Metadata= x.BannerNavigationsDetails_tenant.BannerNavigationsDetails.Metadata.ToString(),
                        MetaDescription= x.BannerNavigationsDetails_tenant.BannerNavigationsDetails.MetaDescription.ToString(),
                        Keyword= x.BannerNavigationsDetails_tenant.BannerNavigationsDetails.Keyword.ToString(),
                        TotalViews= x.BannerNavigationsDetails_tenant.BannerNavigationsDetails.TotalViews,
                        IsActive = x.BannerNavigationsDetails_tenant.BannerNavigationsDetails.IsActive,
                        TenantName = x.BannerNavigationsDetails_tenant.BannerNavigationsDetails.Tenant.Name,
                        CreatedBy = x.BannerNavigationsDetails_tenant.BannerNavigationsDetails.CreatedBy,
                        UpdatedBy = x.BannerNavigationsDetails_tenant.BannerNavigationsDetails.UpdatedBy,
                        CreatedOn= x.BannerNavigationsDetails_tenant.BannerNavigationsDetails.CreatedOn,
                        UpdatedOn= x.BannerNavigationsDetails_tenant.BannerNavigationsDetails.UpdatedOn
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.BlogsBannerNavigationsDetailsIndexViewModel>
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





        public EntityModel.BlogBannerNavigationsDetails Create(EntityModel.BlogBannerNavigationsDetails entity)
        {
            try
            {
                return unitOfWork.BannerNavigationsDetailsRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.BlogBannerNavigationsDetails GetById(long Id)
        {
            try
            {
                EntityModel.BlogBannerNavigationsDetails entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.BannerNavigationsDetailsRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.BlogBannerNavigationsDetails Update(EntityModel.BlogBannerNavigationsDetails entity)
        {
            try
            {
                return unitOfWork.BannerNavigationsDetailsRepository.Update(entity);
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
                unitOfWork.BannerNavigationsDetailsRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.BlogBannerNavigationsDetails> GetAll()
        {
            try
            {
                return unitOfWork.BannerNavigationsDetailsRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.BlogBannerNavigationsDetails> FindBy(Expression<Func<EntityModel.BlogBannerNavigationsDetails, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.BlogBannerNavigationsDetails> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.BannerNavigationsDetailsRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.BannerNavigationsDetailsRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.BlogBannerNavigationsDetails, bool>> filter = null)
        {
            try
            {
                unitOfWork.BannerNavigationsDetailsRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.BlogBannerNavigationsDetails, bool>> filter = null)
        {
            try
            {
                return unitOfWork.BannerNavigationsDetailsRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
