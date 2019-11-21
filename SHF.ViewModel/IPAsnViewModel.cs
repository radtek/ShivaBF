using SHF.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.ViewModel
{
   public class IP_AsnIndexViewModel : BaseViewModel
    {

        public string asn { get; set; }
        public string name { get; set; }
        public string domain { get; set; }
        public string route { get; set; }
        public string type { get; set; }
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
    }

    public sealed class IP_AsnCreateOrEditViewModel : BaseViewModel
    {
        public string asn { get; set; }
        public string name { get; set; }
        public string domain { get; set; }
        public string route { get; set; }
        public string type { get; set; }
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }

    }
   
    public class IP_AsnDropdownListViewModel
    {
        public System.String SubSubCategoryName { get; set; }
        public System.Int64 ID { get; set; }

    }
}
