using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SHF.ViewModel
{
    public sealed class TenantCreateOrEditViewModel : BaseViewModel
    {        
        [DisplayName("Customer Name")]
        [Helper.RequiredField(ErrorMessage = Helper.busConstant.Messages.Type.Validations.REQUIRED)]
        //[RegularExpression(@"([a-zA-Z ]+) (\d+)", ErrorMessage = Helper.busConstant.Messages.Type.Validations.OnlyCharaters)]
        public System.String Name { get; set; }

        [Helper.RequiredField(ErrorMessage = Helper.busConstant.Messages.Type.Validations.REQUIRED)]
        [Display(Name = "Username")]
        public System.String Username { get; set; }

        [Helper.RequiredField(ErrorMessage = Helper.busConstant.Messages.Type.Validations.REQUIRED)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public System.String Password { get; set; }

        [Helper.RequiredField(ErrorMessage = Helper.busConstant.Messages.Type.Validations.REQUIRED)]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public System.String ConfirmPassword { get; set; }

        //[DisplayName("Address")]
        //[DataType(DataType.MultilineText)]
        //[Helper.RequiredField(ErrorMessage = Helper.busConstant.Messages.Type.Validations.REQUIRED)]
        //public System.String Address { get; set; }

        /// <Billing_Address>
        [DisplayName("Billing Address Attention")]
        public System.String BillingAddressAttention { get; set; }

        [DisplayName("Billing Address Street 1")]
        public System.String BillingAddressStreet1 { get; set; }

        [DisplayName("Billing Address Street 2")]
        public System.String BillingAddressStreet2 { get; set; }      
      

        [System.ComponentModel.DefaultValue(SHF.Helper.busConstant.Code.COUNTRY)]
        public System.Int64 BillingAddressCountry_ID { get; set; }

        [DisplayName("Billing Address Country")]
        public System.String BillingAddressCountryValue { get; set; }
              
      

        [System.ComponentModel.DefaultValue(SHF.Helper.busConstant.Code.STATE)]
        public System.Int64 BillingAddressState_ID { get; set; }

        [DisplayName("Billing Address State")]
        public System.String BillingAddressStateValue { get; set; }
        

        [System.ComponentModel.DefaultValue(SHF.Helper.busConstant.Code.CITY_OR_DISTRICT)]
        public System.Int64 BillingAddressCityOrDistrict_ID { get; set; }

        [DisplayName("Billing Address City Or District")]
        public System.String BillingAddressCityOrDistrictValue { get; set; }


        [DisplayName("Billing Address Zip Code")]
        public System.String BillingAddressZipCode { get; set; }

        [DisplayName("Billing Address Phone")]
        public System.String BillingAddressPhone { get; set; }

        [DisplayName("Billing Address Fax")]
        public System.String BillingAddressFax { get; set; }
        /// </Billing_Address>


        /// <Shipping_Address>

        [DisplayName("Shipping Address Attention")]
        public System.String ShippingAddressAttention { get; set; }

        [DisplayName("Shipping Address Street 1")]
        public System.String ShippingAddressStreet1 { get; set; }

        [DisplayName("Shipping Address Street 2")]
        public System.String ShippingAddressStreet2 { get; set; }


      

        [System.ComponentModel.DefaultValue(SHF.Helper.busConstant.Code.COUNTRY)]
        public System.Int64 ShippingAddressCountry_ID { get; set; }

        [DisplayName("Shipping Address Country")]
        public System.String ShippingAddressCountryValue { get; set; }


       

        [System.ComponentModel.DefaultValue(SHF.Helper.busConstant.Code.STATE)]
        public System.Int64 ShippingAddressState_ID { get; set; }

        [DisplayName("Shipping Address State")]
        public System.String ShippingAddressStateValue { get; set; }
       

        [System.ComponentModel.DefaultValue(SHF.Helper.busConstant.Code.CITY_OR_DISTRICT)]
        public System.Int64 ShippingAddressCityOrDistrict_ID { get; set; }

        [DisplayName("Shipping Address CityOrDistrict")]
        public System.String ShippingAddressCityOrDistrictValue { get; set; }


        [DisplayName("Shipping Address Zip Code")]
        public System.String ShippingAddressZipCode { get; set; }

        [DisplayName("Shipping Address Phone")]
        public System.String ShippingAddressPhone { get; set; }

        [DisplayName("Shipping Address Fax")]
        public System.String ShippingAddressFax { get; set; }
        /// </Billing_Address>
        
        [DisplayName("Contact Person Name")]
        [Helper.RequiredField(ErrorMessage = Helper.busConstant.Messages.Type.Validations.REQUIRED)]
        //[RegularExpression(@"([a-zA-Z ]+) (\d+)", ErrorMessage = Helper.busConstant.Messages.Type.Validations.OnlyCharaters)]
        public System.String ContactPerson { get; set; }

        [DisplayName("Contact Number")]
        [Helper.RequiredField(ErrorMessage = Helper.busConstant.Messages.Type.Validations.REQUIRED)]
        public System.String ContactNumber { get; set; }

        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        [Helper.RequiredField(ErrorMessage = Helper.busConstant.Messages.Type.Validations.REQUIRED)]
        public System.String Email { get; set; }

        [DisplayName("GST Number")]
        [Helper.RequiredField(ErrorMessage = Helper.busConstant.Messages.Type.Validations.REQUIRED)]
        public System.String GST { get; set; }

        [DisplayName("No Of Locations")]
        [Helper.RequiredField(ErrorMessage = Helper.busConstant.Messages.Type.Validations.REQUIRED)]
        public System.Int32? NoOfLocations { get; set; }

        [DisplayName("No Of SHF Items")]
        [Helper.RequiredField(ErrorMessage = Helper.busConstant.Messages.Type.Validations.REQUIRED)]
        public System.Int32? NoOfSHFItems { get; set; }

    }
}
