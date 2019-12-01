using SHF.Helper;
using System.ComponentModel.DataAnnotations;



namespace SHF.ViewModel
{
    public sealed class CustomerIPInfoMappingIndexViewModel : BaseViewModel
    {
        public System.String Session_ID { get; set; }
        public System.String FirstName { get; set; }
        public System.String LastName { get; set; }
        public System.DateTime DOB { get; set; }
        public System.String EmailID { get; set; }
        public System.String FullStreetAddress { get; set; }
        public System.Int64 IPInfo_ID { get; set; }
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
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
    }
    public sealed class CustomerIPInfoMappingCreateOrEditViewModel : BaseViewModel
    {
        public System.String Session_ID { get; set; }
        public System.String FirstName { get; set; }
        public System.String LastName { get; set; }
        public System.DateTime DOB { get; set; }
        public System.String EmailID { get; set; }
        public System.String FullStreetAddress { get; set; }
        public System.Int64 IPInfo_ID { get; set; }
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
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
    }
    public class CustomerIPInfoMappingViewModel : BaseViewModel
    {
        public System.String Session_ID { get; set; }
        public System.String FirstName { get; set; }
        public System.String LastName { get; set; }
        public System.DateTime DOB { get; set; }
        public System.String EmailID { get; set; }
        public System.String FullStreetAddress { get; set; }
        public System.Int64 IPInfo_ID { get; set; }
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
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
    }
    public class CustomerIPInfoMappingDropdownListViewModel
    {
        public System.String Session_ID { get; set; }
        public System.Int64 ID { get; set; }

    }
}
