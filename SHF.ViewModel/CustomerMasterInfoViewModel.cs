using SHF.Helper;
using System.ComponentModel.DataAnnotations;



namespace SHF.ViewModel
{
    public sealed class CustomerMasterInfoIndexViewModel : BaseViewModel
    {
      
        public System.String FirstName { get; set; }
       
        public System.String LastName { get; set; }
       
        public System.DateTime DOB { get; set; }
       
        public System.String EmailID { get; set; }
        
        public System.String FullStreetAddress { get; set; }

        public System.DateTime InfoDateOfLastLogon { get; set; }
      
        public System.Int64 InfoNumberOfLogons { get; set; }
       
        public System.DateTime InfoDateAccountCreated { get; set; }
       
        public System.DateTime InfoDateAccountLastModified { get; set; }
        public System.Boolean? IsActive { get; set; }
        
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
    }
    public sealed class CustomerMasterInfoCreateOrEditViewModel : BaseViewModel
    {
        public System.String FirstName { get; set; }

        public System.String LastName { get; set; }

        public System.DateTime DOB { get; set; }

        public System.String EmailID { get; set; }

        public System.String FullStreetAddress { get; set; }

        public System.DateTime InfoDateOfLastLogon { get; set; }

        public System.Int64 InfoNumberOfLogons { get; set; }

        public System.DateTime InfoDateAccountCreated { get; set; }

        public System.DateTime InfoDateAccountLastModified { get; set; }
        public System.Boolean? IsActive { get; set; }

        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
    }
    public class CustomerMasterInfoViewModel : BaseViewModel
    {
        public System.String FirstName { get; set; }

        public System.String LastName { get; set; }

        public System.DateTime DOB { get; set; }

        public System.String EmailID { get; set; }

        public System.String FullStreetAddress { get; set; }

        public System.DateTime InfoDateOfLastLogon { get; set; }

        public System.Int64 InfoNumberOfLogons { get; set; }

        public System.DateTime InfoDateAccountCreated { get; set; }

        public System.DateTime InfoDateAccountLastModified { get; set; }
        public System.Boolean? IsActive { get; set; }

        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
    }
    public class CustomerMasterInfoDropdownListViewModel
    {
        public System.String FirstName { get; set; }
        public System.Int64 ID { get; set; }

    }
}
