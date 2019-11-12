using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.ViewModel.FrontEnd
{
   public class ServiceType4ViewModel : BaseViewModel
    {

        public System.Int64? Service_Id { get; set; }

        public System.Int64? Cat_Id { get; set; }

        public System.Int64? SubCat_Id { get; set; }

        public System.Int64? SubSubCat_Id { get; set; }

        public System.String SubSubCategoryName { get; set; }

        public System.String BannerImagePath { get; set; }

        public System.String BannerOnHeading { get; set; }

        public System.String BannerHeadingDescription { get; set; }
        public System.String Section1Description { get; set; }
        public System.String Section2PriceingHeading { get; set; }
        public System.String Section2PriceingDescription { get; set; }
        public System.String Section3PriceingHeading { get; set; }
        public System.String Section3PriceingDescription { get; set; }
        public System.String Section4PriceingHeading { get; set; }
        public System.String Section4PriceingDescription { get; set; }
        public System.String Section5PriceingHeading { get; set; }
        public System.String Section6PriceingHeading { get; set; }
        public System.String Section7PriceingHeading { get; set; }
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

    public class ServiceType4Section345MasterViewModel : BaseViewModel
    {

        public System.Int64? Service_Id { get; set; }
        public System.Int64? SubSubCat_Id { get; set; }
        public System.String SubSubCategoryName { get; set; }
        public System.String SectionTypeValue { get; set; }
        public System.Int64 SectionType_ID { get; set; }
        public System.String Heading { get; set; }
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

        public List<Services4Section345MasterFeaturesDetailsViewModel> Services4Section345MasterFeaturesDetailsViewModel { get; set; }
        public List<Services4Section345MasterButtonsChildViewModel> Services4Section345MasterButtonsChildViewModel { get; set; }
        
    }

    public class Services4Section345MasterFeaturesDetailsViewModel : BaseViewModel
    {

        public System.Int64? Service_Id { get; set; }
        public System.Int64 SubSubCat_Id { get; set; }
        public System.String SubSubCategory_Name { get; set; }
        public System.Int64? S4S345M_id { get; set; }
        public System.String ShortDescription { get; set; }

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
    public class Services4Section345MasterButtonsChildViewModel : BaseViewModel
    {
        public System.Int64? Service_Id { get; set; }
        public System.Int64 SubSubCat_Id { get; set; }
        public System.String SubSubCategory_Name { get; set; }
        public System.Int64? S4S345M_id { get; set; }
        public System.String FeatureDescription { get; set; }
        public System.Int64 Price { get; set; }
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

    public class ServiceType4Section678FieldMasterViewModel : BaseViewModel
    {

        public System.Int64? Service_Id { get; set; }
        public System.Int64? SubSubCat_Id { get; set; }
        public System.String SubSubCategoryName { get; set; }
        public System.String FieldName { get; set; }
        public System.String SectionType { get; set; }
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
        public int maxfieldvalue { get; set; }
        public List<ServiceType4Section678FieldValuesViewModel> ServiceType4Section678FieldValuesViewModel { get; set; }
    }

    public class ServiceType4Section678FieldValuesViewModel : BaseViewModel
    {

        public System.Int64? Service_Id { get; set; }
        public System.Int64? SubSubCat_Id { get; set; }
        public System.String SubSubCategoryName { get; set; }
        public System.Int64? S4S678FM_Id { get; set; }
        public System.Int32 RowNumber { get; set; }
        public System.String DisplayText { get; set; }
        public System.String DownloadFilePath { get; set; }
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
    public class Services4Section2FAQMappingViewModel : BaseViewModel
    {
        public System.Int64? Service_Id { get; set; }
        public System.Int64 SubSubCat_Id { get; set; }
        public System.String SubSubCategory_Name { get; set; }
        public System.Int64 FAQMaster_Id { get; set; }
        public System.String Title { get; set; }
        public System.String Description { get; set; }

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
