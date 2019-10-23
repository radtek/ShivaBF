using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.ViewModel
{
   public class BannerNavigationsDetailsIndexViewModel : BaseViewModel
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

    public sealed class BannerNavigationsDetailsCreateOrEditViewModel : BaseViewModel
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

    public class BannerNavigationsDetailsDropdownListViewModel
    {
        public System.String BlogTitle { get; set; }
        public System.Int64 ID { get; set; }

    }
}
