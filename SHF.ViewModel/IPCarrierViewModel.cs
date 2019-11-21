using SHF.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.ViewModel
{
   public class IP_CarrierIndexViewModel : BaseViewModel
    {

        public string name { get; set; }
        public string mcc { get; set; }
        public string mnc { get; set; }
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
    }

    public sealed class IP_CarrierCreateOrEditViewModel : BaseViewModel
    {
        public string name { get; set; }
        public string mcc { get; set; }
        public string mnc { get; set; }
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }

    }
   
    public class IP_CarrierDropdownListViewModel
    {
        public System.String SubSubCategoryName { get; set; }
        public System.Int64 ID { get; set; }

    }
}
