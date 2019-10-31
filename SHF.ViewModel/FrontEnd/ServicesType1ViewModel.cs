using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.ViewModel
{
   public class ServiceType1ViewModel : BaseViewModel
    {
       
        public System.Int64? Service_Id { get; set; }
      
        public System.Int64? Cat_Id { get; set; }
       
        public System.Int64? SubCat_Id { get; set; }
       
        public System.Int64? SubSubCat_Id { get; set; }
       
        public System.String SubSubCategoryName { get; set; }
      
        public System.String BannerImagePath { get; set; }
       
        public System.String BannerOnHeading { get; set; }
     
        public System.String BannerHeadingDescription { get; set; }
      
        public System.String BannerAncharTagTitle { get; set; }
        
        public System.String BannerAncharTagUrl { get; set; }
       
        public System.String Section1AfterBannerHeading { get; set; }
        
        public System.String Section1AfterBannerDescription { get; set; }
      
        public System.String Section1AfterBannerImagePath { get; set; }
       
        public System.String Section1AfterBannerImageOnDescription { get; set; }
      
        public System.String Section2Heading { get; set; }
       
        public System.String Section2Description { get; set; }
       
        public System.String Section3Heading { get; set; }
     
        public System.String Section3Description { get; set; }
       
        public System.String Section3TextboxMaskedText { get; set; }
       
        public System.String Section4Heading { get; set; }
        
        public System.String Section5Heading { get; set; }
      
        public System.String Section6Heading { get; set; }
       
        public System.String Section6Description { get; set; }
     
        public System.String Section7Description { get; set; }
       
        public System.String Section8Description { get; set; }
        
        public System.String Section96Heading { get; set; }
    
        public System.String Section9Description { get; set; }
        public System.Boolean Section10MappingBankFlag { get; set; }
        public System.Int32 DisplayIndex { get; set; }
        public System.Boolean? DisplayOnHome { get; set; }
        public System.Boolean? IsActive { get; set; }
        public System.Int32 TotalViews { get; set; }
        public string Url { get; set; }
        public string Metadata { get; set; }
        public string Keyword { get; set; }
        public string MetaDescription { get; set; }
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
    }
    public class ServiceType1Section1MasterViewModel : BaseViewModel
    {
        public System.Int64? Service_Id { get; set; }
        public System.Int64? SubSubCat_Id { get; set; }
        public System.String SubSubCategoryName { get; set; }
        public System.String AncharTagTitle { get; set; }
        public System.String AncharTagUrl { get; set; }
        public System.Int32 DisplayIndex { get; set; }
        public System.Boolean? DisplayOnHome { get; set; }
        public System.Boolean? IsActive { get; set; }
        public System.Int32 TotalViews { get; set; }
        public string Url { get; set; }
        public string Metadata { get; set; }
        public string Keyword { get; set; }
        public string MetaDescription { get; set; }
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
    }
    public class ServiceType1Section4MasterViewModel : BaseViewModel
    {
        public System.Int64? Service_Id { get; set; }
        public System.Int64? SubSubCat_Id { get; set; }
        public System.String SubSubCategoryName { get; set; }
        public System.String HeadingText { get; set; }
        public System.String ShortDescription { get; set; }
        public System.String AncharTagTitle { get; set; }
        public System.String AncharTagUrl { get; set; }
        public System.Int32 DisplayIndex { get; set; }
        public System.Boolean? DisplayOnHome { get; set; }
        public System.Boolean? IsActive { get; set; }
        public System.Int32 TotalViews { get; set; }
        public string Url { get; set; }
        public string Metadata { get; set; }
        public string Keyword { get; set; }
        public string MetaDescription { get; set; }
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
    }

    public class ServiceType1Section5MasterViewModel : BaseViewModel
    {
        public System.Int64? Service_Id { get; set; }
        public System.Int64? SubSubCat_Id { get; set; }
        public System.String SubSubCategoryName { get; set; }
        public System.String HeadingText { get; set; }
        public System.String ShortDescription { get; set; }
        public System.String AncharTagTitle { get; set; }
        public System.String AncharTagUrl { get; set; }
        public System.Int32 DisplayIndex { get; set; }
        public System.Boolean? DisplayOnHome { get; set; }
        public System.Boolean? IsActive { get; set; }
        public System.Int32 TotalViews { get; set; }
        public string Url { get; set; }
        public string Metadata { get; set; }
        public string Keyword { get; set; }
        public string MetaDescription { get; set; }
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
    }
}
