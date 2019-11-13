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
    public class CommentsReply : BaseBusiness, ICommentsReply
    {
        public ViewModel.BusinessResultViewModel<ViewModel.CommentsReplyIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.CommentsReplyIndexViewModel> collection;
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
                totalRecords = unitOfWork.CommentsReplyRepository.Get().Join(unitOfWork.TenantRepository.Get(), CommentsReply => CommentsReply.Tenant_ID, tenant => tenant.ID, (CommentsReply, tenant) => new { CommentsReply, tenant })
                     .Join(unitOfWork.BlogCommentsDetailsRepository.Get(), CommentsReply_tenant => CommentsReply_tenant.CommentsReply.BCD_Id, BlogCommentsDetails => BlogCommentsDetails.ID, (CommentsReply_tenant, BlogCommentsDetails) => new { CommentsReply_tenant, BlogCommentsDetails })
                    .Join(unitOfWork.BlogMasterRepository.Get(), CommentsReply_tenant_BlogCommentsDetails => CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.Blog_Id, BlogMaster => BlogMaster.ID, (CommentsReply_tenant_BlogCommentsDetails, BlogMaster) => new { CommentsReply_tenant_BlogCommentsDetails, BlogMaster })
                    .Count(x => (tenant_Id == null || x.CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.Tenant_ID == tenant_Id)
                            && (x.CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.ID.ToString().Contains(searchValue)
                        || x.BlogMaster.BlogTitle.CaseInsensitiveContains(searchValue)
                        || x.CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.Name.ToString().CaseInsensitiveContains(searchValue)
                        || x.CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.EmailId.ToString().CaseInsensitiveContains(searchValue)
                        || x.CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.Comment.ToString().CaseInsensitiveContains(searchValue)
                        || x.CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.CommentsReplyRepository.Get().Join(unitOfWork.TenantRepository.Get(), CommentsReply => CommentsReply.Tenant_ID, tenant => tenant.ID, (CommentsReply, tenant) => new { CommentsReply, tenant })
                     .Join(unitOfWork.BlogCommentsDetailsRepository.Get(), CommentsReply_tenant => CommentsReply_tenant.CommentsReply.BCD_Id, BlogCommentsDetails => BlogCommentsDetails.ID, (CommentsReply_tenant, BlogCommentsDetails) => new { CommentsReply_tenant, BlogCommentsDetails })
                    .Join(unitOfWork.BlogMasterRepository.Get(), CommentsReply_tenant_BlogCommentsDetails => CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.Blog_Id, BlogMaster => BlogMaster.ID, (CommentsReply_tenant_BlogCommentsDetails, BlogMaster) => new { CommentsReply_tenant_BlogCommentsDetails, BlogMaster })
                    .Where(x => (tenant_Id == null || x.CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.Tenant_ID == tenant_Id)
                            && (x.CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.ID.ToString().Contains(searchValue)
                        || x.BlogMaster.BlogTitle.CaseInsensitiveContains(searchValue)
                        || x.CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.Name.ToString().CaseInsensitiveContains(searchValue)
                        || x.CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.EmailId.ToString().CaseInsensitiveContains(searchValue)
                        || x.CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.Comment.ToString().CaseInsensitiveContains(searchValue)
                        || x.CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.CommentsReplyIndexViewModel 
                    {
                        ID = x.CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.ID,
                        BlogTitle = x.BlogMaster.BlogTitle,
                        BlogComment = x.CommentsReply_tenant_BlogCommentsDetails.BlogCommentsDetails.Comment,
                        Name = x.CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.Name,
                        EmailId= x.CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.EmailId,
                        Comment = x.CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.Comment,
                        Url = x.CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.Url.ToString(),
                        Metadata= x.CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.Metadata.ToString(),
                        MetaDescription= x.CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.MetaDescription.ToString(),
                        Keyword= x.CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.Keyword.ToString(),
                        TotalViews= x.CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.TotalViews,
                        IsActive = x.CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.IsActive,
                        TenantName = x.CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.Tenant.Name,
                        CreatedBy = x.CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.CreatedBy,
                        UpdatedBy = x.CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.UpdatedBy,
                        CreatedOn= x.CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.CreatedOn,
                        UpdatedOn= x.CommentsReply_tenant_BlogCommentsDetails.CommentsReply_tenant.CommentsReply.UpdatedOn
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.CommentsReplyIndexViewModel>
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





        public EntityModel.CommentsReply Create(EntityModel.CommentsReply entity)
        {
            try
            {
                return unitOfWork.CommentsReplyRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.CommentsReply GetById(long Id)
        {
            try
            {
                EntityModel.CommentsReply entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.CommentsReplyRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.CommentsReply Update(EntityModel.CommentsReply entity)
        {
            try
            {
                return unitOfWork.CommentsReplyRepository.Update(entity);
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
                unitOfWork.CommentsReplyRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.CommentsReply> GetAll()
        {
            try
            {
                return unitOfWork.CommentsReplyRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.CommentsReply> FindBy(Expression<Func<EntityModel.CommentsReply, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.CommentsReply> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.CommentsReplyRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.CommentsReplyRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.CommentsReply, bool>> filter = null)
        {
            try
            {
                unitOfWork.CommentsReplyRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.CommentsReply, bool>> filter = null)
        {
            try
            {
                return unitOfWork.CommentsReplyRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
