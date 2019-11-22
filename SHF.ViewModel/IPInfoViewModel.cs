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
        public string Asn_asn { get; set; }
        public string Asn_name { get; set; }
        public string Asn_domain { get; set; }
        public string Asn_route { get; set; }
        public string Asn_type { get; set; }
        public System.Int64? Carrier_ID { get; set; }
        public string Carrier_name { get; set; }
        public string Carrier_mcc { get; set; }
        public string Carrier_mnc { get; set; }

        public System.Int64? Language_ID { get; set; }
        public string Language_name { get; set; }
        public string Language_native { get; set; }
        public System.Int64? Currency_ID { get; set; }
        public string Currency_name { get; set; }
        public string Currency_code { get; set; }
        public string Currency_symbol { get; set; }
        public string Currency_native { get; set; }
        public string Currency_plural { get; set; }
        public System.Int64? TimeZone_ID { get; set; }
        public string TimeZone_name { get; set; }
        public string TimeZone_abbr { get; set; }
        public string TimeZone_offset { get; set; }
        public bool TimeZone_is_dst { get; set; }
        public DateTime TimeZone_current_time { get; set; }
        public System.Int64? Threat_ID { get; set; }
        public bool Threat_is_tor { get; set; }
        public bool Threat_is_proxy { get; set; }
        public bool Threat_is_anonymous { get; set; }
        public bool Threat_is_known_attacker { get; set; }
        public bool Threat_is_known_abuser { get; set; }
        public bool Threat_is_threat { get; set; }
        public bool Threat_is_bogon { get; set; }
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
        public IP_AsnCreateOrEditViewModel Asn { get; set; }
        public System.Int64? Carrier_ID { get; set; }
        public IP_CarrierCreateOrEditViewModel carrier { get; set; }
        public System.Int64? Language_ID { get; set; }
        public List<IP_LanguageCreateOrEditViewModel> languages { get; set; }
        public System.Int64? Currency_ID { get; set; }
        public IP_CurrencyCreateOrEditViewModel currency { get; set; }
        public System.Int64? TimeZone_ID { get; set; }
        public IP_TimeZoneCreateOrEditViewModel time_zone { get; set; }
        public System.Int64? Threat_ID { get; set; }
        public IP_ThreatCreateOrEditViewModel threat { get; set; }
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
