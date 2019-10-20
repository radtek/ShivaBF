using SHF.Helper;
using System.ComponentModel.DataAnnotations;



namespace SHF.ViewModel
{
    public sealed class BankMasterIndexViewModel : BaseViewModel
    {
        public System.String IconPath { get; set; }
        public System.String Description { get; set; }
        public System.Boolean? IsActive { get; set; }
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
    }
    public sealed class BankMasterCreateOrEditViewModel : BaseViewModel
    {
        [Display(Name = "Icon Path")]
        //[RequiredField(ErrorMessage = busConstant.Messages.Type.Validations.REQUIRED)]
        public System.String IconPath { get; set; }

        [Display(Name = "Description")]
        [RequiredField(ErrorMessage = busConstant.Messages.Type.Validations.REQUIRED)]
        public System.String Description { get; set; }

        [Display(Name = "Tenant Name")]
        [RequiredField(ErrorMessage = busConstant.Messages.Type.Validations.REQUIRED)]
        public System.Int64 Tenant_ID { get; set; }

        public System.Boolean IsActive { get; set; }
    }
    public class BankMasterViewModel : BaseViewModel
    {

       
        public System.String IconPath { get; set; }
        public System.String Description { get; set; }
        public System.Boolean? IsActive { get; set; }
}
    public class BankMasterDropdownListViewModel
    {
        public System.String Description { get; set; }
        public System.Int64 ID { get; set; }

    }
}
