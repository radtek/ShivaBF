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
    public class BlogCommentsDetails : BaseBusiness, IBlogCommentsDetails
    {
        public ViewModel.BusinessResultViewModel<ViewModel.BlogCommentsDetailsIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.BlogCommentsDetailsIndexViewModel> collection;
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
                totalRecords = unitOfWork.BlogCommentsDetailsRepository.Get().Join(unitOfWork.TenantRepository.Get(), BlogCommentsDetails => BlogCommentsDetails.Tenant_ID, tenant => tenant.ID, (BlogCommentsDetails, tenant) => new { BlogCommentsDetails, tenant })
                    .Join(unitOfWork.BlogMasterRepository.Get(), BlogCommentsDetails_tenant => BlogCommentsDetails_tenant.BlogCommentsDetails.Blog_Id, Blog => Blog.ID, (BlogCommentsDetails_tenant, Blog) => new { BlogCommentsDetails_tenant, Blog })
                    .Count(x => (tenant_Id == null || x.BlogCommentsDetails_tenant.BlogCommentsDetails.Tenant_ID == tenant_Id)
                            && (x.BlogCommentsDetails_tenant.BlogCommentsDetails.ID.ToString().Contains(searchValue)
                        || x.Blog.BlogTitle.CaseInsensitiveContains(searchValue)
                        || x.BlogCommentsDetails_tenant.BlogCommentsDetails.Name.ToString().CaseInsensitiveContains(searchValue)
                        || x.BlogCommentsDetails_tenant.BlogCommentsDetails.EmailId.ToString().CaseInsensitiveContains(searchValue)
                        || x.BlogCommentsDetails_tenant.BlogCommentsDetails.Comment.ToString().CaseInsensitiveContains(searchValue)
                        || x.BlogCommentsDetails_tenant.BlogCommentsDetails.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.BlogCommentsDetails_tenant.BlogCommentsDetails.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.BlogCommentsDetails_tenant.BlogCommentsDetails.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.BlogCommentsDetails_tenant.BlogCommentsDetails.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.BlogCommentsDetails_tenant.BlogCommentsDetails.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.BlogCommentsDetails_tenant.BlogCommentsDetails.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.BlogCommentsDetails_tenant.BlogCommentsDetails.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.BlogCommentsDetails_tenant.BlogCommentsDetails.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.BlogCommentsDetails_tenant.BlogCommentsDetails.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.BlogCommentsDetails_tenant.BlogCommentsDetails.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.BlogCommentsDetailsRepository.Get().Join(unitOfWork.TenantRepository.Get(), BlogCommentsDetails => BlogCommentsDetails.Tenant_ID, tenant => tenant.ID, (BlogCommentsDetails, tenant) => new { BlogCommentsDetails, tenant })
                    .Join(unitOfWork.BlogMasterRepository.Get(), BlogCommentsDetails_tenant => BlogCommentsDetails_tenant.BlogCommentsDetails.Blog_Id, Blog => Blog.ID, (BlogCommentsDetails_tenant, Blog) => new { BlogCommentsDetails_tenant, Blog })
                    .Where(x => (tenant_Id == null || x.BlogCommentsDetails_tenant.BlogCommentsDetails.Tenant_ID == tenant_Id)
                            && (x.BlogCommentsDetails_tenant.BlogCommentsDetails.ID.ToString().Contains(searchValue)
                        || x.Blog.BlogTitle.CaseInsensitiveContains(searchValue)
                        || x.BlogCommentsDetails_tenant.BlogCommentsDetails.Name.ToString().CaseInsensitiveContains(searchValue)
                        || x.BlogCommentsDetails_tenant.BlogCommentsDetails.EmailId.ToString().CaseInsensitiveContains(searchValue)
                        || x.BlogCommentsDetails_tenant.BlogCommentsDetails.Comment.ToString().CaseInsensitiveContains(searchValue)
                        || x.BlogCommentsDetails_tenant.BlogCommentsDetails.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.BlogCommentsDetails_tenant.BlogCommentsDetails.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.BlogCommentsDetails_tenant.BlogCommentsDetails.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.BlogCommentsDetails_tenant.BlogCommentsDetails.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.BlogCommentsDetails_tenant.BlogCommentsDetails.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.BlogCommentsDetails_tenant.BlogCommentsDetails.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.BlogCommentsDetails_tenant.BlogCommentsDetails.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.BlogCommentsDetails_tenant.BlogCommentsDetails.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.BlogCommentsDetails_tenant.BlogCommentsDetails.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.BlogCommentsDetails_tenant.BlogCommentsDetails.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.BlogCommentsDetailsIndexViewModel 
                    {
                        ID = x.BlogCommentsDetails_tenant.BlogCommentsDetails.ID,
                        BlogTitle = x.Blog.BlogTitle,
                        Name = x.BlogCommentsDetails_tenant.BlogCommentsDetails.Name,
                        EmailId=x.BlogCommentsDetails_tenant.BlogCommentsDetails.EmailId,
                        Comment = x.BlogCommentsDetails_tenant.BlogCommentsDetails.Comment,
                        Url = x.BlogCommentsDetails_tenant.BlogCommentsDetails.Url.ToString(),
                        Metadata= x.BlogCommentsDetails_tenant.BlogCommentsDetails.Metadata.ToString(),
                        MetaDescription= x.BlogCommentsDetails_tenant.BlogCommentsDetails.MetaDescription.ToString(),
                        Keyword= x.BlogCommentsDetails_tenant.BlogCommentsDetails.Keyword.ToString(),
                        TotalViews= x.BlogCommentsDetails_tenant.BlogCommentsDetails.TotalViews,
                        IsActive = x.BlogCommentsDetails_tenant.BlogCommentsDetails.IsActive,
                        TenantName = x.BlogCommentsDetails_tenant.BlogCommentsDetails.Tenant.Name,
                        CreatedBy = x.BlogCommentsDetails_tenant.BlogCommentsDetails.CreatedBy,
                        UpdatedBy = x.BlogCommentsDetails_tenant.BlogCommentsDetails.UpdatedBy,
                        CreatedOn= x.BlogCommentsDetails_tenant.BlogCommentsDetails.CreatedOn,
                        UpdatedOn= x.BlogCommentsDetails_tenant.BlogCommentsDetails.UpdatedOn,
                        ServiceUrl = x.Blog.Url
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.BlogCommentsDetailsIndexViewModel>
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





        public EntityModel.BlogCommentsDetails Create(EntityModel.BlogCommentsDetails entity)
        {
            try
            {
                return unitOfWork.BlogCommentsDetailsRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.BlogCommentsDetails GetById(long Id)
        {
            try
            {
                EntityModel.BlogCommentsDetails entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.BlogCommentsDetailsRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.BlogCommentsDetails Update(EntityModel.BlogCommentsDetails entity)
        {
            try
            {
                return unitOfWork.BlogCommentsDetailsRepository.Update(entity);
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
                unitOfWork.BlogCommentsDetailsRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.BlogCommentsDetails> GetAll()
        {
            try
            {
                return unitOfWork.BlogCommentsDetailsRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.BlogCommentsDetails> FindBy(Expression<Func<EntityModel.BlogCommentsDetails, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.BlogCommentsDetails> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.BlogCommentsDetailsRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.BlogCommentsDetailsRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.BlogCommentsDetails, bool>> filter = null)
        {
            try
            {
                unitOfWork.BlogCommentsDetailsRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.BlogCommentsDetails, bool>> filter = null)
        {
            try
            {
                return unitOfWork.BlogCommentsDetailsRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
