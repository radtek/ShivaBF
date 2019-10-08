using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.ViewModel
{
    public class AspNetUserIndexViewModel : BaseViewModel
    {
        public System.String FirstName { get; set; }
        public System.String LastName { get; set; }
        public System.String Email { get; set; }
        public System.Boolean? EmailConfirmed { get; set; }
        public System.String PasswordHash { get; set; }
        public System.String SecurityStamp { get; set; }
        public System.String PhoneNumber { get; set; }
        public System.Boolean? PhoneNumberConfirmed { get; set; }
        public System.Boolean? TwoFactorEnabled { get; set; }
        public System.DateTime? LockoutEndDateUtc { get; set; }
        public System.Boolean LockoutEnabled { get; set; }
        public System.Int32 AccessFailedCount { get; set; }
        public System.String UserName { get; set; }
        public System.Boolean IsActive { get; set; }
        public System.Int32 UpdateSeq { get; set; }        
        public System.String RoleName { get; set; }
        public System.String TenantName { get; set; }
        public System.Int64? Tenant_ID { get; set; }

    }

    public sealed class AspNetUserCreateOrEditViewModel : BaseViewModel
    {
        public System.String FirstName { get; set; }
        public System.String LastName { get; set; }
        public System.String Email { get; set; }

        public System.Boolean? EmailConfirmed { get; set; }

        public System.String PasswordHash { get; set; }

        public System.String SecurityStamp { get; set; }

        public System.String PhoneNumber { get; set; }

        public System.Boolean? PhoneNumberConfirmed { get; set; }

        public System.Boolean? TwoFactorEnabled { get; set; }

        public System.DateTime? LockoutEndDateUtc { get; set; }

        public System.Boolean LockoutEnabled { get; set; }

        public System.Int32 AccessFailedCount { get; set; }

        public System.String UserName { get; set; }

        public System.Boolean IsActive { get; set; }

        public System.Int32 UpdateSeq { get; set; }

        public System.Int64? Tenant_ID { get; set; }


        public IEnumerable<long> AssignedRoles { get; set; }
        public IEnumerable<AspNetRoleDropDownListViewModel> AspNetRolesViewModel { get; set; }
        
    }

    public class RegisterOrEditViewModel : BaseViewModel
    {
        [Display(Name = "Tenant")]
        public long Tenant_ID { get; set; }

        [Display(Name = "First Name")]
        [Helper.RequiredField(ErrorMessage = Helper.busConstant.Messages.Type.Validations.REQUIRED)]
        public System.String FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Helper.RequiredField(ErrorMessage = Helper.busConstant.Messages.Type.Validations.REQUIRED)]
        public System.String LastName { get; set; }

        [Helper.RequiredField(ErrorMessage = Helper.busConstant.Messages.Type.Validations.REQUIRED)]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Helper.RequiredField(ErrorMessage = Helper.busConstant.Messages.Type.Validations.REQUIRED)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Helper.RequiredField(ErrorMessage = Helper.busConstant.Messages.Type.Validations.REQUIRED)]
        [MinLength(10, ErrorMessage = "Please enter 10-digit valid mobile number.")]
        [MaxLength(10, ErrorMessage = "Please enter 10-digit valid mobile number.")]
        [DataType(dataType: DataType.PhoneNumber, ErrorMessage = "Please enter digits only.")]
        [Display(Name = "Mobile No")]
        public string PhoneNumber { get; set; }

        [Helper.RequiredField(ErrorMessage = Helper.busConstant.Messages.Type.Validations.REQUIRED)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Helper.RequiredField(ErrorMessage = Helper.busConstant.Messages.Type.Validations.REQUIRED)]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }





        public System.Boolean? EmailConfirmed { get; set; }

        public System.String PasswordHash { get; set; }

        public System.String SecurityStamp { get; set; }

        

        public System.Boolean? PhoneNumberConfirmed { get; set; }

        public System.Boolean? TwoFactorEnabled { get; set; }

        public System.DateTime? LockoutEndDateUtc { get; set; }

        public System.Boolean LockoutEnabled { get; set; }

        public System.Int32 AccessFailedCount { get; set; }

        

        public System.Boolean IsActive { get; set; }

        public System.Int32 UpdateSeq { get; set; }

        


        public IEnumerable<long> AssignedRoles { get; set; }
        public virtual ICollection<ViewModel.AspNetRoleDropDownListViewModel> AspNetRolesViewModel { get; set; }
    }
}
