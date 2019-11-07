using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SHF.ViewModel
{
   public class HomePageSection4TestimonailsIndexViewModel : BaseViewModel
    {
        public System.String Description { get; set; }
        public System.String Name { get; set; }
        public System.String Designation { get; set; }
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

    public sealed class HomePageSection4TestimonailsCreateOrEditViewModel : BaseViewModel
    {
        public System.String Description { get; set; }
        public System.String Name { get; set; }
        public System.String Designation { get; set; }
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

    public class HomePageSection4TestimonailsDropdownListViewModel
    {
        public System.String BannerImagePath { get; set; }
        public System.Int64 ID { get; set; }

    }
}
