using SHF.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.ViewModel
{
   public class Services1MasterIndexViewModel : BaseViewModel
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

    public sealed class Services1MasterCreateOrEditViewModel : BaseViewModel
    {
        public System.Int64? Service_Id { get; set; }

        public System.Int64? Cat_Id { get; set; }

        public System.Int64? SubCat_Id { get; set; }

        public System.Int64? SubSubCat_Id { get; set; }

        public System.String SubSubCategoryName { get; set; }
        [RequiredField(ErrorMessage = busConstant.Messages.Type.Validations.REQUIRED)]
        public System.String BannerImagePath { get; set; }
        [RequiredField(ErrorMessage = busConstant.Messages.Type.Validations.REQUIRED)]
        public System.String BannerOnHeading { get; set; }
        [RequiredField(ErrorMessage = busConstant.Messages.Type.Validations.REQUIRED)]
        public System.String BannerHeadingDescription { get; set; }

        public System.String BannerAncharTagTitle { get; set; }

        public System.String BannerAncharTagUrl { get; set; }

        public System.String Section1AfterBannerHeading { get; set; }

        public System.String Section1AfterBannerDescription { get; set; }
        [RequiredField(ErrorMessage = busConstant.Messages.Type.Validations.REQUIRED)]
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
        [RequiredField(ErrorMessage = busConstant.Messages.Type.Validations.REQUIRED)]
        public string Url { get; set; }
        [RequiredField(ErrorMessage = busConstant.Messages.Type.Validations.REQUIRED)]
        public string Metadata { get; set; }
        [RequiredField(ErrorMessage = busConstant.Messages.Type.Validations.REQUIRED)]
        public string Keyword { get; set; }
        [RequiredField(ErrorMessage = busConstant.Messages.Type.Validations.REQUIRED)]
        public string MetaDescription { get; set; }
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
       public Array[] ImageProperty{ get; set; }
    }
    public class ImageProperty
    {
        public object file { get; set; }
    }
    public class Services1MasterDropdownListViewModel
    {
        public System.String SubSubCategoryName { get; set; }
        public System.Int64 ID { get; set; }

    }
}
