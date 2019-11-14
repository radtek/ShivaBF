using SHF.Helper;
using System.ComponentModel.DataAnnotations;



namespace SHF.ViewModel
{
    public sealed class FooterLinksIndexViewModel : BaseViewModel
    {
        public string Heading { get; set; }
        public System.Int64? FooterBlockMaster_Id { get; set; }

        public System.String AncharTagTitle { get; set; }

        public System.String AncharTagUrl { get; set; }
        public System.Int32 DisplayIndex { get; set; }
        public System.Boolean? IsActive { get; set; }
        public System.Int32 TotalViews { get; set; }
        public string Url { get; set; }
        public string Metadata { get; set; }
        public string Keyword { get; set; }
        public string MetaDescription { get; set; }
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
    }
    public sealed class FooterLinksCreateOrEditViewModel : BaseViewModel
    {
        public string Heading { get; set; }
        public System.Int64? FooterBlockMaster_Id { get; set; }

        public System.String AncharTagTitle { get; set; }

        public System.String AncharTagUrl { get; set; }
        public System.Int32 DisplayIndex { get; set; }
        public System.Boolean? IsActive { get; set; }
        public System.Int32 TotalViews { get; set; }
        public string Url { get; set; }
        public string Metadata { get; set; }
        public string Keyword { get; set; }
        public string MetaDescription { get; set; }
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
    }
    public class FooterLinksViewModel : BaseViewModel
    {


        public string Heading { get; set; }
        public System.Int64? FooterBlockMaster_Id { get; set; }

        public System.String AncharTagTitle { get; set; }

        public System.String AncharTagUrl { get; set; }
        public System.Int32 DisplayIndex { get; set; }
        public System.Boolean? IsActive { get; set; }
        public System.Int32 TotalViews { get; set; }
        public string Url { get; set; }
        public string Metadata { get; set; }
        public string Keyword { get; set; }
        public string MetaDescription { get; set; }
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
    }
    public class FooterLinksDropdownListViewModel
    {
        public System.String AncharTagTitle { get; set; }
        public System.Int64 ID { get; set; }

    }
}
