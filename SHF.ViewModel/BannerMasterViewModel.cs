using SHF.Helper;
using System.ComponentModel.DataAnnotations;



namespace SHF.ViewModel
{
    public sealed class BannerMasterIndexViewModel : BaseViewModel
    {
        public System.String BannerName { get; set; }
        public System.String BannerPath { get; set; }
        public System.String AlternativeText { get; set; }
        public System.String Title { get; set; }
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
    }
    public sealed class BannerMasterCreateOrEditViewModel : BaseViewModel
    {
        public System.String BannerPath { get; set; }
        public System.String AlternativeText { get; set; }
        public System.String Title { get; set; }
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
    }
    public class BannerMasterViewModel : BaseViewModel
    {


        public System.String BannerPath { get; set; }
        public System.String AlternativeText { get; set; }
        public System.String Title { get; set; }
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
    }
    public class BannerMasterDropdownListViewModel
    {
        public System.String BannerPath { get; set; }
        public System.Int64 ID { get; set; }

    }
}
