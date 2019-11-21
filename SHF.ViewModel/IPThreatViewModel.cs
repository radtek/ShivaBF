using SHF.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.ViewModel
{
   public class IP_ThreatIndexViewModel : BaseViewModel
    {

        public bool is_tor { get; set; }
        public bool is_proxy { get; set; }
        public bool is_anonymous { get; set; }
        public bool is_known_attacker { get; set; }
        public bool is_known_abuser { get; set; }
        public bool is_threat { get; set; }
        public bool is_bogon { get; set; }
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
    }

    public sealed class IP_ThreatCreateOrEditViewModel : BaseViewModel
    {
        public bool is_tor { get; set; }
        public bool is_proxy { get; set; }
        public bool is_anonymous { get; set; }
        public bool is_known_attacker { get; set; }
        public bool is_known_abuser { get; set; }
        public bool is_threat { get; set; }
        public bool is_bogon { get; set; }
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }

    }
   
    public class IP_ThreatDropdownListViewModel
    {
        public System.String SubSubCategoryName { get; set; }
        public System.Int64 ID { get; set; }

    }
}
