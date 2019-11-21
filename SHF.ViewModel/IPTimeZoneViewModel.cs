using SHF.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.ViewModel
{
   public class IP_TimeZoneIndexViewModel : BaseViewModel
    {

        public string name { get; set; }
        public string abbr { get; set; }
        public string offset { get; set; }
        public bool is_dst { get; set; }
        public DateTime current_time { get; set; }
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
    }

    public sealed class IP_TimeZoneCreateOrEditViewModel : BaseViewModel
    {
        public string name { get; set; }
        public string abbr { get; set; }
        public string offset { get; set; }
        public bool is_dst { get; set; }
        public DateTime current_time { get; set; }
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }

    }
   
    public class IP_TimeZoneDropdownListViewModel
    {
        public System.String SubSubCategoryName { get; set; }
        public System.Int64 ID { get; set; }

    }
}
