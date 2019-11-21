using SHF.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.ViewModel
{
   public class IP_LanguageIndexViewModel : BaseViewModel
    {

        public string name { get; set; }
        public string native { get; set; }
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
    }

    public sealed class IP_LanguageCreateOrEditViewModel : BaseViewModel
    {
        public string name { get; set; }
        public string native { get; set; }
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }

    }
   
    public class IP_LanguageDropdownListViewModel
    {
        public System.String SubSubCategoryName { get; set; }
        public System.Int64 ID { get; set; }

    }
}
