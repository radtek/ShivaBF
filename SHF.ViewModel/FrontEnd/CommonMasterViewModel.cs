using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SHF.ViewModel.FrontEnd
{
    public class LoginCustomerMaster : BaseViewModel
    {
        public System.String tenantId { get; set; }
        public System.String UserName { get; set; }
        public string Password { get; set; }
    }
    public class CustomerMasterInfo : BaseViewModel
    {
        public System.String tenantId { get; set; }

        public System.Int64 CustomerMaster_ID { get; set; }
     
        public System.DateTime InfoDateOfLastLogon { get; set; }
       
        public System.Int64 InfoNumberOfLogons { get; set; }
       
        public System.DateTime InfoDateAccountCreated { get; set; }
      
        public System.DateTime InfoDateAccountLastModified { get; set; }
    }
    public class CustomerMaster : BaseViewModel
    {
        public System.String tenantId { get; set; }
        public System.String FirstName { get; set; }
        public System.String LastName { get; set; }
        public System.String EmailID { get; set; }
        public string Password { get; set; }
    }
    public class CustomerIPInfoMapping : BaseViewModel
    {
        public System.String tenantId { get; set; }
        public string CustomerMaster_ID { get; set; }
        public string Session_ID { get; set; }
        public string IPInfo_ID { get; set; }
    }
    public class CustomerSurfingViewModel : BaseViewModel
    {
        public System.String tenantId { get; set; }
        public string CustomerMaster_ID { get; set; }
        public string Session_ID { get; set; }
        public string PageUrl { get; set; }
    }
    public class ServiceInfoViewModel : BaseViewModel
    {
        public System.String tenantId { get; set; }
        public string url { get; set; }
        public string page_type { get; set; }
    }


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

