
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using SHF.Helper;
using SHF.ViewModel.FrontEnd;
using SHF.Web.Filters;

namespace SHF.Controllers.Front
{

    public class BlogsController : ApiController
    {

        #region [Field & Contructor]

        private Business.Interface.IMessage businessMessage;
        private Business.Interface.ICategoriesMaster businessCategoriesMaster;
        private Business.Interface.ISubCategoriesMaster businessSubCategoriesMaster;
        private Business.Interface.ISubSubCategoriesMaster businessSubSubCategoriesMaster;
        protected SHF.DataAccess.Implementations.UnitOfWork UnitOfWork;
        public BlogsController()
        {
            this.UnitOfWork = new SHF.DataAccess.Implementations.UnitOfWork();
        }
        public BlogsController(SHF.DataAccess.Implementations.UnitOfWork unitOfWork, Business.Interface.IMessage Imessage, Business.Interface.ICategoriesMaster ICategoriesMaster, Business.Interface.ISubCategoriesMaster ISubCategoriesMaster, Business.Interface.ISubSubCategoriesMaster ISubSubCategoriesMaster)
        {
            this.UnitOfWork = unitOfWork;
            this.businessMessage = Imessage;
            this.businessCategoriesMaster = ICategoriesMaster;
            this.businessSubCategoriesMaster = ISubCategoriesMaster;
            this.businessSubSubCategoriesMaster = ISubSubCategoriesMaster;

        }

        //GET: api/GetAllActiveBlogsByTenantId? tenantId = 1
        // [EnableCors]
        [Route("api/Blogs/GetBlogsByTenantIdAndUrl/{tenantId}/{url}")]
        [HttpGet]
        public BlogMasterViewModel GetBlogsByTenantIdAndUrl(string tenantId, string url)
        {
            // string tenantId = "1";
            var blogMasterViewModel = new BlogMasterViewModel();
            var Blogs = UnitOfWork.BlogMasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.Url == url && x.IsActive == true).FirstOrDefault();
            if (Blogs != null)
            {
                blogMasterViewModel.ID = Blogs.ID;
                blogMasterViewModel.BannerImagePath = ConfigurationManager.AppSettings[busConstant.Settings.DataBase.SqlServer.Connections.AdminUrlString.ADMINUrl] + String.Concat(busConstant.Settings.CMSPath.TENANAT_UPLOAD_DIRECTORY, Blogs.Tenant_ID) + "/" + Blogs.BannerImagePath;
                blogMasterViewModel.BannerDescription1 = Blogs.BannerDescription1;
                blogMasterViewModel.BannerDescription2 = Blogs.BannerDescription2;
                blogMasterViewModel.BlogTitle = Blogs.BlogTitle;
                blogMasterViewModel.Section1ImagePath = ConfigurationManager.AppSettings[busConstant.Settings.DataBase.SqlServer.Connections.AdminUrlString.ADMINUrl] + String.Concat(busConstant.Settings.CMSPath.TENANAT_UPLOAD_DIRECTORY, Blogs.Tenant_ID) + "/" + Blogs.Section1ImagePath;
                blogMasterViewModel.Section2Heading = Blogs.Section2Heading;
                blogMasterViewModel.Section2Description = Blogs.Section2Description;
                blogMasterViewModel.Section3Heading = Blogs.Section3Heading;
                blogMasterViewModel.Section3Description = Blogs.Section3Description;
                blogMasterViewModel.Url = Blogs.Url.ToString();
                blogMasterViewModel.Metadata = Blogs.Metadata.ToString();
                blogMasterViewModel.MetaDescription = Blogs.MetaDescription.ToString();
                blogMasterViewModel.Keyword = Blogs.Keyword.ToString();
                blogMasterViewModel.TotalViews = Blogs.TotalViews;
                blogMasterViewModel.IsActive = Blogs.IsActive;
                blogMasterViewModel.Url = Blogs.Url;
                blogMasterViewModel.Metadata = Blogs.Metadata;
                blogMasterViewModel.Keyword = Blogs.Keyword;
                blogMasterViewModel.MetaDescription = Blogs.MetaDescription;
                blogMasterViewModel.Tenant_ID = Convert.ToInt64(Blogs.Tenant_ID);
                blogMasterViewModel.CreatedBy = Blogs.CreatedBy;
                blogMasterViewModel.CreatedOn = Blogs.CreatedOn;
                blogMasterViewModel.UpdatedBy = Blogs.UpdatedBy;
                blogMasterViewModel.UpdatedOn = Blogs.UpdatedOn;
                blogMasterViewModel.IsDeleted = Blogs.IsDeleted;
            }
            /*some db operation*/
            // return Json("ajs");
            return blogMasterViewModel;
        }

        [Route("api/Blogs/GetRelatedBlogsMappingByTenantIdAndAndBlogId/{tenantId}/{Id}")]
        [HttpGet]
        public List<RelatedBlogsMappingViewModel> GetRelatedBlogsMappingByTenantIdAndAndBlogId(string tenantId, string Id)
        {
            // string tenantId = "1";
            var lstRelatedBlogsMappingViewModel = new List<RelatedBlogsMappingViewModel>();
            var RelatedBlogsMapping = UnitOfWork.RelatedBlogsMappingRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.Blog_Id == Convert.ToInt64(Id) && x.IsActive == true).OrderBy(x => x.DisplayIndex);
            foreach (var tempRelatedBlogsMapping in RelatedBlogsMapping)
            {
                if (tempRelatedBlogsMapping.Related_Blog_Id != null)
                {
                    var relatedBlogsMappingViewModel = new RelatedBlogsMappingViewModel();
                    relatedBlogsMappingViewModel.ID = tempRelatedBlogsMapping.ID;
                    relatedBlogsMappingViewModel.Related_Blog_Id = tempRelatedBlogsMapping.Related_Blog_Id;
                    relatedBlogsMappingViewModel.Blog_Id = tempRelatedBlogsMapping.Blog_Id;
                    relatedBlogsMappingViewModel.RelatedBlogTitle = UnitOfWork.BlogMasterRepository.GetByID(tempRelatedBlogsMapping.Related_Blog_Id).BlogTitle;
                    relatedBlogsMappingViewModel.Url = tempRelatedBlogsMapping.Url.ToString();
                    relatedBlogsMappingViewModel.Metadata = tempRelatedBlogsMapping.Metadata.ToString();
                    relatedBlogsMappingViewModel.MetaDescription = tempRelatedBlogsMapping.MetaDescription.ToString();
                    relatedBlogsMappingViewModel.Keyword = tempRelatedBlogsMapping.Keyword.ToString();
                    relatedBlogsMappingViewModel.TotalViews = tempRelatedBlogsMapping.TotalViews;
                    relatedBlogsMappingViewModel.IsActive = tempRelatedBlogsMapping.IsActive;
                    relatedBlogsMappingViewModel.Metadata = tempRelatedBlogsMapping.Metadata;
                    relatedBlogsMappingViewModel.Keyword = tempRelatedBlogsMapping.Keyword;
                    relatedBlogsMappingViewModel.MetaDescription = tempRelatedBlogsMapping.MetaDescription;
                    relatedBlogsMappingViewModel.Tenant_ID = Convert.ToInt64(tempRelatedBlogsMapping.Tenant_ID);
                    lstRelatedBlogsMappingViewModel.Add(relatedBlogsMappingViewModel);
                }
            }
            /*some db operation*/
            // return Json("ajs");
            return lstRelatedBlogsMappingViewModel;
        }

        [Route("api/Blogs/GetBlogsBannerNavigationsDetailsByTenantIdAndAndBlogId/{tenantId}/{Id}")]
        [HttpGet]
        public List<BlogsBannerNavigationsDetailsViewModel> GetBlogsBannerNavigationsDetailsByTenantIdAndAndBlogId(string tenantId, string Id)
        {
            // string tenantId = "1";
            var lstBlogsBannerNavigationsDetailsViewModel = new List<BlogsBannerNavigationsDetailsViewModel>();
            var blogsBannerNavigationsDetails = UnitOfWork.BannerNavigationsDetailsRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.Blog_Id == Convert.ToInt64(Id) && x.IsActive == true).OrderBy(x => x.DisplayIndex);
            foreach (var tempBannerNavigationsDetails in blogsBannerNavigationsDetails)
            {
                var blogsBannerNavigationsDetailsViewModel = new BlogsBannerNavigationsDetailsViewModel();
                blogsBannerNavigationsDetailsViewModel.ID = tempBannerNavigationsDetails.ID;
                blogsBannerNavigationsDetailsViewModel.AncharTagUrl = tempBannerNavigationsDetails.AncharTagUrl;
                blogsBannerNavigationsDetailsViewModel.AncharTagTitle = tempBannerNavigationsDetails.AncharTagTitle;
                blogsBannerNavigationsDetailsViewModel.Blog_Id = tempBannerNavigationsDetails.Blog_Id;
                blogsBannerNavigationsDetailsViewModel.Url = tempBannerNavigationsDetails.Url.ToString();
                blogsBannerNavigationsDetailsViewModel.Metadata = tempBannerNavigationsDetails.Metadata.ToString();
                blogsBannerNavigationsDetailsViewModel.MetaDescription = tempBannerNavigationsDetails.MetaDescription.ToString();
                blogsBannerNavigationsDetailsViewModel.Keyword = tempBannerNavigationsDetails.Keyword.ToString();
                blogsBannerNavigationsDetailsViewModel.TotalViews = tempBannerNavigationsDetails.TotalViews;
                blogsBannerNavigationsDetailsViewModel.IsActive = tempBannerNavigationsDetails.IsActive;
                blogsBannerNavigationsDetailsViewModel.Url = tempBannerNavigationsDetails.Url;
                blogsBannerNavigationsDetailsViewModel.Metadata = tempBannerNavigationsDetails.Metadata;
                blogsBannerNavigationsDetailsViewModel.Keyword = tempBannerNavigationsDetails.Keyword;
                blogsBannerNavigationsDetailsViewModel.MetaDescription = tempBannerNavigationsDetails.MetaDescription;
                blogsBannerNavigationsDetailsViewModel.Tenant_ID = Convert.ToInt64(tempBannerNavigationsDetails.Tenant_ID);
                lstBlogsBannerNavigationsDetailsViewModel.Add(blogsBannerNavigationsDetailsViewModel);
            }
            /*some db operation*/
            // return Json("ajs");
            return lstBlogsBannerNavigationsDetailsViewModel;
        }

        [Route("api/Blogs/GetBlogCommentsDetailsByTenantIdAndBlogId/{tenantId}/{Id}")]
        [HttpGet]
        public List<BlogCommentsDetailsViewModel> GetBlogCommentsDetailsByTenantIdAndBlogId(string tenantId, string Id)
        {
            // string tenantId = "1";
            var lstBlogCommentsDetailsViewModel = new List<BlogCommentsDetailsViewModel>();
            var BlogCommentsDetails = UnitOfWork.BlogCommentsDetailsRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.Blog_Id == Convert.ToInt64(Id) && x.IsActive == true).OrderBy(x => x.DisplayIndex).Take(10);

            foreach (var tempBlogCommentsDetails in BlogCommentsDetails)
            {
                var blogCommentsDetailsViewModel = new BlogCommentsDetailsViewModel();
                blogCommentsDetailsViewModel.ID = tempBlogCommentsDetails.ID;
                blogCommentsDetailsViewModel.Blog_Id = Convert.ToInt64(tempBlogCommentsDetails.Blog_Id);
                blogCommentsDetailsViewModel.Name = tempBlogCommentsDetails.Name;
                blogCommentsDetailsViewModel.EmailId = tempBlogCommentsDetails.EmailId;
                blogCommentsDetailsViewModel.Comment = tempBlogCommentsDetails.Comment;
                blogCommentsDetailsViewModel.DisplayIndex = tempBlogCommentsDetails.DisplayIndex;
                blogCommentsDetailsViewModel.IsActive = tempBlogCommentsDetails.IsActive;
                blogCommentsDetailsViewModel.TotalViews = tempBlogCommentsDetails.TotalViews;
                blogCommentsDetailsViewModel.Url = tempBlogCommentsDetails.Url;
                blogCommentsDetailsViewModel.Metadata = tempBlogCommentsDetails.Metadata;
                blogCommentsDetailsViewModel.Keyword = tempBlogCommentsDetails.Keyword;
                blogCommentsDetailsViewModel.MetaDescription = tempBlogCommentsDetails.MetaDescription;
                blogCommentsDetailsViewModel.Tenant_ID = Convert.ToInt64(tempBlogCommentsDetails.Tenant_ID);
                blogCommentsDetailsViewModel.CreatedOn = tempBlogCommentsDetails.CreatedOn;

                var objCommentsReply = UnitOfWork.CommentsReplyRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.BCD_Id == Convert.ToInt64(tempBlogCommentsDetails.ID) && x.IsActive == true).OrderBy(x => x.DisplayIndex).Take(10);
                var lstcommentsReplyViewModel = new List<CommentsReplyViewModel>();

                foreach (var tempobjCommentsReply in objCommentsReply)
                {
                    var commentsReplyViewModel = new CommentsReplyViewModel();
                    commentsReplyViewModel.ID = tempobjCommentsReply.ID;
                    commentsReplyViewModel.BCD_Id = tempobjCommentsReply.BCD_Id;
                    commentsReplyViewModel.Name = tempobjCommentsReply.Name;
                    commentsReplyViewModel.EmailId = tempobjCommentsReply.EmailId;
                    commentsReplyViewModel.Comment = tempobjCommentsReply.Comment;
                    commentsReplyViewModel.DisplayIndex = tempobjCommentsReply.DisplayIndex;
                    commentsReplyViewModel.IsActive = tempobjCommentsReply.IsActive;
                    commentsReplyViewModel.TotalViews = tempobjCommentsReply.TotalViews;
                    commentsReplyViewModel.Url = tempobjCommentsReply.Url;
                    commentsReplyViewModel.Metadata = tempobjCommentsReply.Metadata;
                    commentsReplyViewModel.Keyword = tempobjCommentsReply.Keyword;
                    commentsReplyViewModel.MetaDescription = tempobjCommentsReply.MetaDescription;
                    commentsReplyViewModel.Tenant_ID = Convert.ToInt64(tempobjCommentsReply.Tenant_ID);
                    commentsReplyViewModel.CreatedOn = tempobjCommentsReply.CreatedOn;
                    lstcommentsReplyViewModel.Add(commentsReplyViewModel);
                }
                blogCommentsDetailsViewModel.CommentsReplyViewModel = lstcommentsReplyViewModel;
                lstBlogCommentsDetailsViewModel.Add(blogCommentsDetailsViewModel);
            }

            /*some db operation*/
            // return Json("ajs");
            return lstBlogCommentsDetailsViewModel;
        }

        [Route("api/Blogs/AddBlogCommentsDetails/{tenantId}/{BlogId}/{Name}/{EmailId}/{Comment}")]
        [HttpPost]
        public string AddBlogCommentsDetails(string tenantId, string BlogId, string Name, string EmailId, string Comment)
        {
            // string tenantId = "1";
            var response = "error";
            var entity = new EntityModel.BlogCommentsDetails();
            entity.Blog_Id = Convert.ToInt64(BlogId);
            entity.Name = Name;
            entity.EmailId = EmailId;
            entity.Comment = Comment;
            entity.DisplayIndex = 0;
            entity.IsActive = false;
            entity.TotalViews = 1;
            entity.Tenant_ID = Convert.ToInt64(tenantId);
            entity.Tenant = null;
            UnitOfWork.BlogCommentsDetailsRepository.Add(entity);
            response = "success";
            /*some db operation*/
            // return Json("ajs");
            return response;
        }

        [Route("api/Blogs/AddCommentsReply/{tenantId}/{BlogId}/{BCD_Id}/{Name}/{EmailId}/{Comment}")]
        [HttpPost]
        public string AddCommentsReply(string tenantId, string BlogId, string BCD_Id, string Name, string EmailId, string Comment)
        {
            // string tenantId = "1";
            var response = "error";
            var entity = new EntityModel.CommentsReply();
            entity.Blog_Id = Convert.ToInt64(BlogId);
            entity.BCD_Id = Convert.ToInt64(BCD_Id);
            entity.Name = Name;
            entity.EmailId = EmailId;
            entity.Comment = Comment;
            entity.DisplayIndex = 0;
            entity.IsActive = false;
            entity.TotalViews = 1;
            entity.Tenant_ID = Convert.ToInt64(tenantId);
            entity.Tenant = null;
            UnitOfWork.CommentsReplyRepository.Add(entity);
            response = "success";
            /*some db operation*/
            // return Json("ajs");
            return response;
        }

        #endregion
    }

}