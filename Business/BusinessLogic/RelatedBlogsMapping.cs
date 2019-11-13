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
    public class RelatedBlogsMapping : BaseBusiness, IRelatedBlogsMapping
    {
        public ViewModel.BusinessResultViewModel<ViewModel.RelatedBlogsMappingIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.RelatedBlogsMappingIndexViewModel> collection;
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
                totalRecords = unitOfWork.RelatedBlogsMappingRepository.Get().Join(unitOfWork.TenantRepository.Get(), RelatedBlogsMapping => RelatedBlogsMapping.Tenant_ID, tenant => tenant.ID, (RelatedBlogsMapping, tenant) => new { RelatedBlogsMapping, tenant })
                    .Join(unitOfWork.BlogMasterRepository.Get(), RelatedBlogsMapping_tenant => RelatedBlogsMapping_tenant.RelatedBlogsMapping.Blog_Id, Blog => Blog.ID, (RelatedBlogsMapping_tenant, Blog) => new { RelatedBlogsMapping_tenant, Blog })
                    .Join(unitOfWork.BlogMasterRepository.Get(), RelatedBlogsMapping_tenant_Blog => RelatedBlogsMapping_tenant_Blog.RelatedBlogsMapping_tenant.RelatedBlogsMapping.Related_Blog_Id, RelatedBlog => RelatedBlog.ID, (RelatedBlogsMapping_tenant_Blog, RelatedBlog) => new { RelatedBlogsMapping_tenant_Blog, RelatedBlog })
                  .Count(x => (tenant_Id == null || x.RelatedBlogsMapping_tenant_Blog.RelatedBlogsMapping_tenant.RelatedBlogsMapping.Tenant_ID == tenant_Id)
                            && (x.RelatedBlogsMapping_tenant_Blog.RelatedBlogsMapping_tenant.RelatedBlogsMapping.ID.ToString().Contains(searchValue)
                        || x.RelatedBlogsMapping_tenant_Blog.Blog.BlogTitle.CaseInsensitiveContains(searchValue)
                        || x.RelatedBlogsMapping_tenant_Blog.RelatedBlogsMapping_tenant.RelatedBlogsMapping.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.RelatedBlogsMapping_tenant_Blog.RelatedBlogsMapping_tenant.RelatedBlogsMapping.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.RelatedBlogsMapping_tenant_Blog.RelatedBlogsMapping_tenant.RelatedBlogsMapping.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.RelatedBlogsMapping_tenant_Blog.RelatedBlogsMapping_tenant.RelatedBlogsMapping.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.RelatedBlogsMapping_tenant_Blog.RelatedBlogsMapping_tenant.RelatedBlogsMapping.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.RelatedBlogsMapping_tenant_Blog.RelatedBlogsMapping_tenant.RelatedBlogsMapping.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.RelatedBlogsMapping_tenant_Blog.RelatedBlogsMapping_tenant.RelatedBlogsMapping.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.RelatedBlogsMapping_tenant_Blog.RelatedBlogsMapping_tenant.RelatedBlogsMapping.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.RelatedBlogsMapping_tenant_Blog.RelatedBlogsMapping_tenant.RelatedBlogsMapping.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.RelatedBlogsMapping_tenant_Blog.RelatedBlogsMapping_tenant.RelatedBlogsMapping.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.RelatedBlogsMappingRepository.Get().Join(unitOfWork.TenantRepository.Get(), RelatedBlogsMapping => RelatedBlogsMapping.Tenant_ID, tenant => tenant.ID, (RelatedBlogsMapping, tenant) => new { RelatedBlogsMapping, tenant })
                    .Join(unitOfWork.BlogMasterRepository.Get(), RelatedBlogsMapping_tenant => RelatedBlogsMapping_tenant.RelatedBlogsMapping.Blog_Id, Blog => Blog.ID, (RelatedBlogsMapping_tenant, Blog) => new { RelatedBlogsMapping_tenant, Blog })
                    .Join(unitOfWork.BlogMasterRepository.Get(), RelatedBlogsMapping_tenant_Blog => RelatedBlogsMapping_tenant_Blog.RelatedBlogsMapping_tenant.RelatedBlogsMapping.Related_Blog_Id, RelatedBlog => RelatedBlog.ID, (RelatedBlogsMapping_tenant_Blog, RelatedBlog) => new { RelatedBlogsMapping_tenant_Blog, RelatedBlog })
                  .Where(x => (tenant_Id == null || x.RelatedBlogsMapping_tenant_Blog.RelatedBlogsMapping_tenant.RelatedBlogsMapping.Tenant_ID == tenant_Id)
                            && (x.RelatedBlogsMapping_tenant_Blog.RelatedBlogsMapping_tenant.RelatedBlogsMapping.ID.ToString().Contains(searchValue)
                        || x.RelatedBlogsMapping_tenant_Blog.Blog.BlogTitle.CaseInsensitiveContains(searchValue)
                        || x.RelatedBlogsMapping_tenant_Blog.RelatedBlogsMapping_tenant.RelatedBlogsMapping.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.RelatedBlogsMapping_tenant_Blog.RelatedBlogsMapping_tenant.RelatedBlogsMapping.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.RelatedBlogsMapping_tenant_Blog.RelatedBlogsMapping_tenant.RelatedBlogsMapping.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.RelatedBlogsMapping_tenant_Blog.RelatedBlogsMapping_tenant.RelatedBlogsMapping.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.RelatedBlogsMapping_tenant_Blog.RelatedBlogsMapping_tenant.RelatedBlogsMapping.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.RelatedBlogsMapping_tenant_Blog.RelatedBlogsMapping_tenant.RelatedBlogsMapping.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.RelatedBlogsMapping_tenant_Blog.RelatedBlogsMapping_tenant.RelatedBlogsMapping.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.RelatedBlogsMapping_tenant_Blog.RelatedBlogsMapping_tenant.RelatedBlogsMapping.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.RelatedBlogsMapping_tenant_Blog.RelatedBlogsMapping_tenant.RelatedBlogsMapping.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.RelatedBlogsMapping_tenant_Blog.RelatedBlogsMapping_tenant.RelatedBlogsMapping.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.RelatedBlogsMappingIndexViewModel 
                    {
                        ID = x.RelatedBlogsMapping_tenant_Blog.RelatedBlogsMapping_tenant.RelatedBlogsMapping.ID,
                        BlogTitle = x.RelatedBlogsMapping_tenant_Blog.Blog.BlogTitle,
                        Related_Blog_Id = x.RelatedBlogsMapping_tenant_Blog.RelatedBlogsMapping_tenant.RelatedBlogsMapping.Related_Blog_Id,
                        RelatedBlogTitle=x.RelatedBlog.BlogTitle,
                        Url = x.RelatedBlogsMapping_tenant_Blog.RelatedBlogsMapping_tenant.RelatedBlogsMapping.Url.ToString(),
                        Metadata= x.RelatedBlogsMapping_tenant_Blog.RelatedBlogsMapping_tenant.RelatedBlogsMapping.Metadata.ToString(),
                        MetaDescription= x.RelatedBlogsMapping_tenant_Blog.RelatedBlogsMapping_tenant.RelatedBlogsMapping.MetaDescription.ToString(),
                        Keyword= x.RelatedBlogsMapping_tenant_Blog.RelatedBlogsMapping_tenant.RelatedBlogsMapping.Keyword.ToString(),
                        TotalViews= x.RelatedBlogsMapping_tenant_Blog.RelatedBlogsMapping_tenant.RelatedBlogsMapping.TotalViews,
                        IsActive = x.RelatedBlogsMapping_tenant_Blog.RelatedBlogsMapping_tenant.RelatedBlogsMapping.IsActive,
                        TenantName = x.RelatedBlogsMapping_tenant_Blog.RelatedBlogsMapping_tenant.RelatedBlogsMapping.Tenant.Name,
                        CreatedBy = x.RelatedBlogsMapping_tenant_Blog.RelatedBlogsMapping_tenant.RelatedBlogsMapping.CreatedBy,
                        UpdatedBy = x.RelatedBlogsMapping_tenant_Blog.RelatedBlogsMapping_tenant.RelatedBlogsMapping.UpdatedBy,
                        CreatedOn= x.RelatedBlogsMapping_tenant_Blog.RelatedBlogsMapping_tenant.RelatedBlogsMapping.CreatedOn,
                        UpdatedOn= x.RelatedBlogsMapping_tenant_Blog.RelatedBlogsMapping_tenant.RelatedBlogsMapping.UpdatedOn
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.RelatedBlogsMappingIndexViewModel>
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





        public EntityModel.RelatedBlogsMapping Create(EntityModel.RelatedBlogsMapping entity)
        {
            try
            {
                return unitOfWork.RelatedBlogsMappingRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.RelatedBlogsMapping GetById(long Id)
        {
            try
            {
                EntityModel.RelatedBlogsMapping entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.RelatedBlogsMappingRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.RelatedBlogsMapping Update(EntityModel.RelatedBlogsMapping entity)
        {
            try
            {
                return unitOfWork.RelatedBlogsMappingRepository.Update(entity);
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
                unitOfWork.RelatedBlogsMappingRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.RelatedBlogsMapping> GetAll()
        {
            try
            {
                return unitOfWork.RelatedBlogsMappingRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.RelatedBlogsMapping> FindBy(Expression<Func<EntityModel.RelatedBlogsMapping, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.RelatedBlogsMapping> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.RelatedBlogsMappingRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.RelatedBlogsMappingRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.RelatedBlogsMapping, bool>> filter = null)
        {
            try
            {
                unitOfWork.RelatedBlogsMappingRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.RelatedBlogsMapping, bool>> filter = null)
        {
            try
            {
                return unitOfWork.RelatedBlogsMappingRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
