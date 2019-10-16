using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.ViewModel
{
    public class FAQMasterViewModel : BaseViewModel
    {
        public System.String Title { get; set; }
        public System.String Description { get; set; }
        public System.Boolean? IsActive { get; set; }
        public System.Int32 TotalViews { get; set; }
        public System.Int32 DisplayIndex { get; set; }
        public string Url { get; set; }
        public string Metadata { get; set; }
        public string Keyword { get; set; }
        public string MetaDescription { get; set; }
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
    }
    public sealed class FAQMasterCreateOrEditViewModel : BaseViewModel
    {
        public System.String Title { get; set; }
        public System.String Description { get; set; }
        public System.Boolean? IsActive { get; set; }
        public System.Int32 TotalViews { get; set; }
        public System.Int32 DisplayIndex { get; set; }
        public string Url { get; set; }
        public string Metadata { get; set; }
        public string Keyword { get; set; }
        public string MetaDescription { get; set; }
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
    }
   
    public class FAQDropdownListViewModel
    {
        public System.String Title { get; set; }
        public System.Int64 ID { get; set; }

    }
}