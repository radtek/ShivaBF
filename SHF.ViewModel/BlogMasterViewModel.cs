using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.ViewModel
{
   public class BlogMasterIndexViewModel : BaseViewModel
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

    public sealed class BlogMasterCreateOrEditViewModel : BaseViewModel
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

    public class BlogMasterDropdownListViewModel
    {
        public System.String BlogTitle { get; set; }
        public System.Int64 ID { get; set; }

    }
}
