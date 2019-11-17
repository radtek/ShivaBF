using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.ViewModel
{
   public class BlogCommentsDetailsIndexViewModel : BaseViewModel
    {

        public System.Int64? Blog_Id { get; set; }
        public System.String BlogTitle { get; set; }
        public System.String Name { get; set; }
        public System.String EmailId { get; set; }
        public System.String Comment { get; set; }
        public System.Int32 DisplayIndex { get; set; }
        public System.Boolean? IsActive { get; set; }
        public System.Int32 TotalViews { get; set; }
        public string Url { get; set; }
        public string Metadata { get; set; }
        public string Keyword { get; set; }
        public string MetaDescription { get; set; }
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
        public string ServiceUrl { get; set; }
    }

    public sealed class BlogCommentsDetailsCreateOrEditViewModel : BaseViewModel
    {
        public System.Int64? Blog_Id { get; set; }
        public System.String BlogTitle { get; set; }

        public System.String Name { get; set; }

        public System.String EmailId { get; set; }

        public System.String Comment { get; set; }
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

    public class BlogCommentsDetailsDropdownListViewModel
    {
        public System.String BlogComment { get; set; }
        public System.Int64 ID { get; set; }

    }
}
