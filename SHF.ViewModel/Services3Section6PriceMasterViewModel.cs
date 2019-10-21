using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.ViewModel
{
   public class Services3Section6PriceMasterIndexViewModel : BaseViewModel
    {
       
        public System.Int64? Service_Id { get; set; }
        public System.Int64? SubSubCat_Id { get; set; }
        public System.String SubSubCategoryName { get; set; }
        public System.String AncharTagTitle { get; set; }
        public System.String AncharTagUrl { get; set; }
        public System.String Heading { get; set; }
        public System.Int32 Price { get; set; }
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

    public sealed class Services3Section6PriceMasterCreateOrEditViewModel : BaseViewModel
    {
        public System.Int64? Service_Id { get; set; }
        public System.Int64? SubSubCat_Id { get; set; }
        public System.String SubSubCategoryName { get; set; }
        public System.String AncharTagTitle { get; set; }
        public System.String AncharTagUrl { get; set; }
        public System.String Heading { get; set; }
        public System.Int32 Price { get; set; }
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

    public class Services3Section6PriceMasterDropdownListViewModel
    {
        public System.String AncharTagTitle { get; set; }
        public System.Int64 ID { get; set; }

    }
}
