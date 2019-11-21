using SHF.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.ViewModel
{
   public class IPInfoIndexViewModel : BaseViewModel
    {

        public string ip { get; set; }
        public bool is_eu { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public string region_code { get; set; }
        public string country_name { get; set; }
        public string country_code { get; set; }
        public string continent_name { get; set; }
        public string continent_code { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string postal { get; set; }
        public string calling_code { get; set; }
        public string flag { get; set; }
        public string emoji_flag { get; set; }
        public string emoji_unicode { get; set; }
       
        public System.Int64? Asn_ID { get; set; }
        
        public System.Int64? Carrier_ID { get; set; }
        
        public System.Int64? Language_ID { get; set; }
      
        public System.Int64? Currency_ID { get; set; }
       
        public System.Int64? TimeZone_ID { get; set; }
       
        public System.Int64? Threat_ID { get; set; }
        public string count { get; set; }
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
    }

    public sealed class IPInfoCreateOrEditViewModel : BaseViewModel
    {
        public string ip { get; set; }
        public bool is_eu { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public string region_code { get; set; }
        public string country_name { get; set; }
        public string country_code { get; set; }
        public string continent_name { get; set; }
        public string continent_code { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string postal { get; set; }
        public string calling_code { get; set; }
        public string flag { get; set; }
        public string emoji_flag { get; set; }
        public string emoji_unicode { get; set; }

        public System.Int64? Asn_ID { get; set; }

        public System.Int64? Carrier_ID { get; set; }

        public System.Int64? Language_ID { get; set; }

        public System.Int64? Currency_ID { get; set; }

        public System.Int64? TimeZone_ID { get; set; }

        public System.Int64? Threat_ID { get; set; }
        public string count { get; set; }
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }

    }
   
    public class IPInfoDropdownListViewModel
    {
        public System.String SubSubCategoryName { get; set; }
        public System.Int64 ID { get; set; }

    }
}
