using SHF.Helper;
using System.ComponentModel.DataAnnotations;



namespace SHF.ViewModel
{
    public sealed class CustomerMasterIndexViewModel : BaseViewModel
    {
        public System.String Gender { get; set; }
       
        public System.String FirstName { get; set; }
       
        public System.String LastName { get; set; }
       
        public System.DateTime DOB { get; set; }
       
        public System.String EmailID { get; set; }
        
        public System.String FullStreetAddress { get; set; }
       
        public System.String Telephone { get; set; }
       
        public System.String Fax { get; set; }

        public System.String Newsletter { get; set; }
        public System.Boolean? IsActive { get; set; }
        
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
    }
    public sealed class CustomerMasterCreateOrEditViewModel : BaseViewModel
    {
        public System.String Gender { get; set; }

        public System.String FirstName { get; set; }

        public System.String LastName { get; set; }

        public System.DateTime DOB { get; set; }

        public System.String EmailID { get; set; }

        public System.String FullStreetAddress { get; set; }

        public System.String Telephone { get; set; }

        public System.String Fax { get; set; }

        public System.String Newsletter { get; set; }
        public System.Boolean? IsActive { get; set; }

        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
    }
    public class CustomerMasterViewModel : BaseViewModel
    {
        public System.String Gender { get; set; }

        public System.String FirstName { get; set; }

        public System.String LastName { get; set; }

        public System.DateTime DOB { get; set; }

        public System.String EmailID { get; set; }

        public System.String FullStreetAddress { get; set; }

        public System.String Telephone { get; set; }

        public System.String Fax { get; set; }

        public System.String Newsletter { get; set; }
        public System.Boolean? IsActive { get; set; }

        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
    }
    public class CustomerMasterDropdownListViewModel
    {
        public System.String FirstName { get; set; }
        public System.Int64 ID { get; set; }

    }
}
