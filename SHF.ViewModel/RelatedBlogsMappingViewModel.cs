using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.ViewModel
{
   public class RelatedBlogsMappingIndexViewModel : BaseViewModel
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

    public sealed class RelatedBlogsMappingCreateOrEditViewModel : BaseViewModel
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

    public class RelatedBlogsMappingDropdownListViewModel
    {
        public System.String RelatedBlogTitle { get; set; }
        public System.Int64 ID { get; set; }

    }
}
