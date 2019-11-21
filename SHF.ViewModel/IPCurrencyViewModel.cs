using SHF.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.ViewModel
{
   public class IP_CurrencyIndexViewModel : BaseViewModel
    {

        public string name { get; set; }
        public string code { get; set; }
        public string symbol { get; set; }
        public string native { get; set; }
        public string plural { get; set; }
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
    }

    public sealed class IP_CurrencyCreateOrEditViewModel : BaseViewModel
    {
        public string name { get; set; }
        public string code { get; set; }
        public string symbol { get; set; }
        public string native { get; set; }
        public string plural { get; set; }
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }

    }
   
    public class IP_CurrencyDropdownListViewModel
    {
        public System.String SubSubCategoryName { get; set; }
        public System.Int64 ID { get; set; }

    }
}
