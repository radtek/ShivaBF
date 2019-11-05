using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SHF.ViewModel
{
   public class Services2MasterIndexViewModel : BaseViewModel
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
        public System.String Section2FAQDescription { get; set; }
        public System.String Section3DownloadDescription { get; set; }
       
        public System.String Section4PriceingHeading { get; set; }
        public System.String Section4PriceingDescription { get; set; }
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

    public sealed class Services2MasterCreateOrEditViewModel : BaseViewModel
    {
        public System.Int64? Service_Id { get; set; }

        public System.Int64? Cat_Id { get; set; }

        public System.Int64? SubCat_Id { get; set; }

        public System.Int64? SubSubCat_Id { get; set; }

        public System.String SubSubCategoryName { get; set; }

        public HttpPostedFileBase BannerImageFile { get; set; }
       

        public System.String BannerImagePath { get; set; }

        public System.String BannerOnHeading { get; set; }

        public System.String BannerHeadingDescription { get; set; }

        public System.String Section1Description { get; set; }
        public System.String Section2FAQDescription { get; set; }
        public System.String Section3DownloadDescription { get; set; }

        public System.String Section4PriceingHeading { get; set; }
        public System.String Section4PriceingDescription { get; set; }
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

    public class Services2MasterDropdownListViewModel
    {
        public System.String SubSubCategoryName { get; set; }
        public System.Int64 ID { get; set; }

    }
}
