using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.ViewModel
{
   public class Services4Section2MasterIndexViewModel : BaseViewModel
    {
       
        public System.Int64? Service_Id { get; set; }
        public System.Int64? SubSubCat_Id { get; set; }
        public System.String SubSubCategoryName { get; set; }
        public System.String Heading { get; set; }
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

    public sealed class Services4Section2MasterCreateOrEditViewModel : BaseViewModel
    {
        public System.Int64? Service_Id { get; set; }
        public System.Int64? SubSubCat_Id { get; set; }
        public System.String SubSubCategoryName { get; set; }
        public System.String Heading { get; set; }
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

    public class Services4Section2MasterDropdownListViewModel
    {
        
        public System.Int64 ID { get; set; }
        public System.String Heading { get; set; }

    }
}
