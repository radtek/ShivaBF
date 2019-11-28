using SHF.Helper;
using System.ComponentModel.DataAnnotations;



namespace SHF.ViewModel
{
    public sealed class PageViewsReportIndexViewModel : BaseViewModel
    {
        public System.String Url { get; set; }
        public System.Int64 Count { get; set; }
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
        public System.Int64 TotalCount { get; set; }
    }
    public sealed class PageViewsReportCreateOrEditViewModel : BaseViewModel
    {
        public System.String Url { get; set; }
        public System.Int64 Count { get; set; }
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
    }
    public class PageViewsReportViewModel : BaseViewModel
    {


        public System.String Url { get; set; }
        public System.Int64 Count { get; set; }
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
    }
    public class PageViewsReportDropdownListViewModel
    {
        public System.String Url { get; set; }
        public System.Int64 ID { get; set; }

    }
}
