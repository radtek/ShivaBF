using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;



namespace SHF.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Helper.RequiredField(ErrorMessage = Helper.busConstant.Messages.Type.Validations.REQUIRED)]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Helper.RequiredField(ErrorMessage = Helper.busConstant.Messages.Type.Validations.REQUIRED)]
        public string Provider { get; set; }

        [Helper.RequiredField(ErrorMessage = Helper.busConstant.Messages.Type.Validations.REQUIRED)]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Helper.RequiredField(ErrorMessage = Helper.busConstant.Messages.Type.Validations.REQUIRED)]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Helper.RequiredField(ErrorMessage = Helper.busConstant.Messages.Type.Validations.REQUIRED)]
        [Display(Name = "Username")]        
        public string Username { get; set; }
                
        [Helper.RequiredField(ErrorMessage = Helper.busConstant.Messages.Type.Validations.REQUIRED)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class UserRegisterViewModel : RegisterViewModel
    {
        [Helper.RequiredField(ErrorMessage = Helper.busConstant.Messages.Type.Validations.REQUIRED)]
        [Display(Name = "User Role")]
        public string RoleName { get; set; }
    }

    public class RegisterViewModel
    {
        [Display(Name = "Tenant")]
        public long? Tenant_ID { get; set; }
                

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
        public string MobileNo { get; set; }

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
       
    }

    public class ResetPasswordViewModel
    {
        [Helper.RequiredField(ErrorMessage = Helper.busConstant.Messages.Type.Validations.REQUIRED)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Helper.RequiredField(ErrorMessage = Helper.busConstant.Messages.Type.Validations.REQUIRED)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Helper.RequiredField(ErrorMessage = Helper.busConstant.Messages.Type.Validations.REQUIRED)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
        
}
