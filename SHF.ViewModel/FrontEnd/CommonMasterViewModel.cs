using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SHF.ViewModel.FrontEnd
{

    public class CommonSEOViewModel : BaseViewModel
    {
        public System.String PageTitle { get; set; }
        public string Url { get; set; }
        public string Metadata { get; set; }
        public string Keyword { get; set; }
        public string MetaDescription { get; set; }
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
    }

    public class StateMasterViewModel : BaseViewModel
    {
        public System.String StateFullName { get; set; }
        public System.String StateShortName { get; set; }
        public System.Boolean? IsActive { get; set; }
        public System.Int32 TotalViews { get; set; }
        public string Url { get; set; }
        public string Metadata { get; set; }
        public string Keyword { get; set; }
        public string MetaDescription { get; set; }
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
    }
    public sealed class FooterBlockMasterViewModel : BaseViewModel
    {
        public string Heading { get; set; }
        public System.Int32 DisplayIndex { get; set; }
        public System.Boolean? IsActive { get; set; }
        public System.Int32 TotalViews { get; set; }
        public string Url { get; set; }
        public string Metadata { get; set; }
        public string Keyword { get; set; }
        public string MetaDescription { get; set; }
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }

        public List<FooterLinksViewModel> FooterLinksViewModel { get; set; }
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
}

