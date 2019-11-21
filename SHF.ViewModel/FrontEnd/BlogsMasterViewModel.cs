using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SHF.ViewModel.FrontEnd
{
    public class BlogMasterViewModel : BaseViewModel
    {


        public System.String BannerImagePath { get; set; }

        public System.String BannerDescription1 { get; set; }

        public System.String BannerDescription2 { get; set; }

        public System.String BlogTitle { get; set; }

        public System.String Section1ImagePath { get; set; }

        public System.String Section2Heading { get; set; }

        public System.String Section2Description { get; set; }

        public System.String Section3Heading { get; set; }

        public System.String Section3Description { get; set; }
        public System.Boolean? IsActive { get; set; }
        public System.Int32 TotalViews { get; set; }
        public string Url { get; set; }
        public string Metadata { get; set; }
        public string Keyword { get; set; }
        public string MetaDescription { get; set; }
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
    }
    public class RelatedBlogsMappingViewModel : BaseViewModel
    {

        public System.String BlogTitle { get; set; }
        public System.Int64? Blog_Id { get; set; }
        public System.String RelatedBlogTitle { get; set; }
        public System.Int64? Related_Blog_Id { get; set; }
        public System.Int32 DisplayIndex { get; set; }
        public System.Boolean? IsActive { get; set; }
        public System.Int32 TotalViews { get; set; }
        public string Url { get; set; }
        public string Metadata { get; set; }
        public string Keyword { get; set; }
        public string MetaDescription { get; set; }
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
    }

    public class BlogsBannerNavigationsDetailsViewModel : BaseViewModel
    {

        public System.String BlogTitle { get; set; }
        public System.Int64? Blog_Id { get; set; }
        public System.String AncharTagTitle { get; set; }
        public System.String AncharTagUrl { get; set; }
        public System.Boolean? IsActive { get; set; }
        public System.Int32 TotalViews { get; set; }
        public string Url { get; set; }
        public string Metadata { get; set; }
        public string Keyword { get; set; }
        public string MetaDescription { get; set; }
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
    }

    public class BlogCommentsDetailsViewModel : BaseViewModel
    {
        
        public System.Int64? Blog_Id { get; set; }
      
        public System.String Name { get; set; }
    
        public System.String EmailId { get; set; }
        
        public System.String Comment { get; set; }
       
        public System.Int32 DisplayIndex { get; set; }
      
        public System.Boolean? IsActive { get; set; }
        public System.Boolean? IsAdminApproved { get; set; }

        public System.Int32 TotalViews { get; set; }
        
        public string Url { get; set; }

       
        public string Metadata { get; set; }

       
        public string Keyword { get; set; }

        
        public string MetaDescription { get; set; }
        public System.String TenantName { get; set; }
        public System.Int64? Tenant_ID { get; set; }
        public List<CommentsReplyViewModel> CommentsReplyViewModel { get; set; }
    }

    public class CommentsReplyViewModel : BaseViewModel
    {
        
        public System.Int64? Blog_Id { get; set; }
       
        public System.Int64? BCD_Id { get; set; }
       
        public System.String Name { get; set; }
       
        public System.String EmailId { get; set; }
     
        public System.String Comment { get; set; }
     
        public System.Int32 DisplayIndex { get; set; }
        
        public System.Boolean? IsActive { get; set; }
        public System.Boolean? IsAdminApproved { get; set; }

        public System.Int32 TotalViews { get; set; }
        
        public string Url { get; set; }

        
        public string Metadata { get; set; }

      
        public string Keyword { get; set; }

      
        public string MetaDescription { get; set; }

        public System.String TenantName { get; set; }
        public System.Int64? Tenant_ID { get; set; }
    }
}

