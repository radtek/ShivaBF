using SHF.Helper;
using System.ComponentModel.DataAnnotations;



namespace SHF.ViewModel
{
    public sealed class CustomerServiceOrderIndexViewModel : BaseViewModel
    {
        public System.Int64 CustomerMaster_ID { get; set; }
        public System.String FirstName { get; set; }
        public System.String LastName { get; set; }
        public System.String FullStreetAddress { get; set; }
        public System.String PostalCode { get; set; }
        public System.String EmailID { get; set; }
        public System.String Telephone { get; set; }
        public System.String Fax { get; set; }
        public System.Int64? Service_Id { get; set; }
        public System.String ServiceName { get; set; }
        public System.Int64? Plan_Id { get; set; }
        public System.String PlanName { get; set; }
        public System.Int64 Amount { get; set; }
        public System.String PaymentMethod { get; set; }
        public System.DateTime DatePurchased { get; set; }
        public System.String OrdersStatus { get; set; }
        
        public System.DateTime OrdersDateFinished { get; set; }
        public System.String Comments { get; set; }
        public System.Boolean? IsActive { get; set; }
        
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
    }
    public sealed class CustomerServiceOrderCreateOrEditViewModel : BaseViewModel
    {
        public System.Int64 CustomerMaster_ID { get; set; }
        public System.String FirstName { get; set; }
        public System.String LastName { get; set; }
        public System.String FullStreetAddress { get; set; }
        public System.String PostalCode { get; set; }
        public System.String EmailID { get; set; }
        public System.String Telephone { get; set; }
        public System.String Fax { get; set; }
        public System.Int64? Service_Id { get; set; }
        public System.String ServiceName { get; set; }
        public System.Int64? Plan_Id { get; set; }
        public System.String PlanName { get; set; }
        public System.Int64 Amount { get; set; }
        public System.String PaymentMethod { get; set; }
        public System.DateTime DatePurchased { get; set; }
        public System.String OrdersStatus { get; set; }

        public System.DateTime OrdersDateFinished { get; set; }
        public System.String Comments { get; set; }
        public System.Boolean? IsActive { get; set; }

        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
    }
    public class CustomerServiceOrderViewModel : BaseViewModel
    {
        public System.Int64 CustomerMaster_ID { get; set; }
        public System.String FirstName { get; set; }
        public System.String LastName { get; set; }
        public System.String FullStreetAddress { get; set; }
        public System.String PostalCode { get; set; }
        public System.String EmailID { get; set; }
        public System.String Telephone { get; set; }
        public System.String Fax { get; set; }
        public System.Int64? Service_Id { get; set; }
        public System.String ServiceName { get; set; }
        public System.Int64? Plan_Id { get; set; }
        public System.String PlanName { get; set; }
        public System.Int64 Amount { get; set; }
        public System.String PaymentMethod { get; set; }
        public System.DateTime DatePurchased { get; set; }
        public System.String OrdersStatus { get; set; }

        public System.DateTime OrdersDateFinished { get; set; }
        public System.String Comments { get; set; }
        public System.Boolean? IsActive { get; set; }

        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
    }
    public class CustomerServiceOrderDropdownListViewModel
    {
        public System.String FirstName { get; set; }
        public System.Int64 ID { get; set; }

    }
}
