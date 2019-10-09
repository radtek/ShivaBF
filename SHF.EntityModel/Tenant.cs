
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHF.Helper;

namespace SHF.EntityModel
{
    [Table("Tbl_Tenant", Schema = "dbo")]
    public class Tenant : BaseEntity
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public virtual long ID { get; set; }

        [Column("Name")]
        public System.String Name { get; set; }

        [Column("Storage_Directory")]
        public System.String StorageDirectory { get; set; }


        [NotMapped]
        public System.String BillingAddress
        {
            get
            {
                string _str = string.Empty;
                if (this.BillingAddressAttention.IsNotNullOrEmpty())
                {
                    _str = this.BillingAddressAttention;
                }
                if (this.BillingAddressStreet1.IsNotNullOrEmpty())
                {
                    if (_str.IsNotNullOrEmpty())
                    {
                        _str = busGlobalFunction.AppendStringWithChar(_str, this.BillingAddressStreet1, enmAppendCharacter.CommaSpace);
                    }
                    else
                    {
                        _str = this.BillingAddressStreet1;
                    }
                }
                if (this.BillingAddressStreet2.IsNotNullOrEmpty())
                {
                    if (_str.IsNotNullOrEmpty())
                    {
                        _str = busGlobalFunction.AppendStringWithChar(_str, this.BillingAddressStreet2, enmAppendCharacter.CommaSpace);
                    }
                    else
                    {
                        _str = this.BillingAddressStreet2;
                    }
                }
                if (this.BillingAddressCityOrDistrictValue.IsNotNullOrEmpty())
                {
                    if (_str.IsNotNullOrEmpty())
                    {
                        _str = busGlobalFunction.AppendStringWithChar(_str, this.BillingAddressCityOrDistrictDescription, enmAppendCharacter.CommaSpace);
                    }
                    else
                    {
                        _str = this.BillingAddressCityOrDistrictDescription;
                    }
                }
                if (this.BillingAddressZipCode.IsNotNullOrEmpty())
                {
                    if (_str.IsNotNullOrEmpty())
                    {
                        _str = busGlobalFunction.AppendStringWithChar(_str, this.BillingAddressZipCode, enmAppendCharacter.Dash);
                    }
                    else
                    {
                        _str = this.BillingAddressZipCode;
                    }
                }
                if (this.BillingAddressStateValue.IsNotNullOrEmpty())
                {
                    if (_str.IsNotNullOrEmpty())
                    {
                        _str = busGlobalFunction.AppendStringWithChar(_str, this.BillingAddressStateDescription, enmAppendCharacter.Newline);
                    }
                    else
                    {
                        _str = this.BillingAddressStateDescription;
                    }
                }
                if (this.BillingAddressCountryValue.IsNotNullOrEmpty())
                {
                    if (_str.IsNotNullOrEmpty())
                    {
                        _str = busGlobalFunction.AppendStringWithChar(_str, this.BillingAddressCountryDescription, enmAppendCharacter.Newline);
                    }
                    else
                    {
                        _str = this.BillingAddressCountryDescription;
                    }
                }
                //if (this.BillingAddressPhone.IsNotNullOrEmpty())
                //{
                //    if (_str.IsNotNullOrEmpty())
                //    {
                //        _str = busGlobalFunction.AppendStringWithChar(_str, this.BillingAddressPhone, enmAppendCharacter.Newline);
                //    }
                //    else
                //    {
                //        _str = this.BillingAddressZipCode;
                //    }
                //}
                //if (this.BillingAddressFax.IsNotNullOrEmpty())
                //{
                //    if (_str.IsNotNullOrEmpty())
                //    {
                //        _str = busGlobalFunction.AppendStringWithChar(_str, this.BillingAddressFax, enmAppendCharacter.Newline);
                //    }
                //    else
                //    {
                //        _str = this.BillingAddressFax;
                //    }
                //}
                return _str;
            }
        }

        [NotMapped]
        public System.String ShippingAddress
        {
            get
            {
                string _str = string.Empty;
                if (this.ShippingAddressAttention.IsNotNullOrEmpty())
                {
                    _str = this.ShippingAddressAttention;
                }
                if (this.ShippingAddressStreet1.IsNotNullOrEmpty())
                {
                    if (_str.IsNotNullOrEmpty())
                    {
                        _str = busGlobalFunction.AppendStringWithChar(_str, this.ShippingAddressStreet1, enmAppendCharacter.CommaSpace);
                    }
                    else
                    {
                        _str = this.ShippingAddressStreet1;
                    }
                }
                if (this.ShippingAddressStreet2.IsNotNullOrEmpty())
                {
                    if (_str.IsNotNullOrEmpty())
                    {
                        _str = busGlobalFunction.AppendStringWithChar(_str, this.ShippingAddressStreet2, enmAppendCharacter.CommaSpace);
                    }
                    else
                    {
                        _str = this.ShippingAddressStreet2;
                    }
                }
                if (this.ShippingAddressCityOrDistrictValue.IsNotNullOrEmpty())
                {
                    if (_str.IsNotNullOrEmpty())
                    {
                        _str = busGlobalFunction.AppendStringWithChar(_str, this.ShippingAddressCityOrDistrictDescription, enmAppendCharacter.CommaSpace);
                    }
                    else
                    {
                        _str = this.ShippingAddressCityOrDistrictDescription;
                    }
                }
                if (this.ShippingAddressZipCode.IsNotNullOrEmpty())
                {
                    if (_str.IsNotNullOrEmpty())
                    {
                        _str = busGlobalFunction.AppendStringWithChar(_str, this.ShippingAddressZipCode, enmAppendCharacter.Dash);
                    }
                    else
                    {
                        _str = this.ShippingAddressZipCode;
                    }
                }
                if (this.ShippingAddressStateValue.IsNotNullOrEmpty())
                {
                    if (_str.IsNotNullOrEmpty())
                    {
                        _str = busGlobalFunction.AppendStringWithChar(_str, this.ShippingAddressStateDescription, enmAppendCharacter.Newline);
                    }
                    else
                    {
                        _str = this.ShippingAddressStateDescription;
                    }
                }
                if (this.ShippingAddressCountryValue.IsNotNullOrEmpty())
                {
                    if (_str.IsNotNullOrEmpty())
                    {
                        _str = busGlobalFunction.AppendStringWithChar(_str, this.ShippingAddressCountryDescription, enmAppendCharacter.Newline);
                    }
                    else
                    {
                        _str = this.ShippingAddressCountryDescription;
                    }
                }
                //if (this.ShippingAddressPhone.IsNotNullOrEmpty())
                //{
                //    if (_str.IsNotNullOrEmpty())
                //    {
                //        _str = busGlobalFunction.AppendStringWithChar(_str, this.ShippingAddressPhone, enmAppendCharacter.Newline);
                //    }
                //    else
                //    {
                //        _str = this.ShippingAddressZipCode;
                //    }
                //}
                //if (this.ShippingAddressFax.IsNotNullOrEmpty())
                //{
                //    if (_str.IsNotNullOrEmpty())
                //    {
                //        _str = busGlobalFunction.AppendStringWithChar(_str, this.ShippingAddressFax, enmAppendCharacter.Newline);
                //    }
                //    else
                //    {
                //        _str = this.ShippingAddressFax;
                //    }
                //}
                return _str;
            }
        }


        /// <Billing_Address>
        [Column("Billing_Address_Attention")]
        public System.String BillingAddressAttention { get; set; }

        [Column("Billing_Address_Street_1")]
        public System.String BillingAddressStreet1 { get; set; }

        [Column("Billing_Address_Street_2")]
        public System.String BillingAddressStreet2 { get; set; }


        [ForeignKey("BillingAddressCountry_ID")]
        public virtual Code BillingAddressCountry { get; set; }

        [System.ComponentModel.DefaultValue(SHF.Helper.busConstant.Code.COUNTRY)]
        public System.Int64 BillingAddressCountry_ID { get; set; }

        [Column("Billing_Address_Country_Value")]
        public System.String BillingAddressCountryValue { get; set; }

        [NotMapped]
        public System.String BillingAddressCountryDescription
        {
            get
            {
                string _str = string.Empty;
                if (this.BillingAddressCountry.IsNotNull() && this.BillingAddressCountry.CodeValues.IsNotNull())
                {
                    _str = this.BillingAddressCountry.CodeValues.FirstOrDefault(x => x.Value == this.BillingAddressCountryValue).Description;
                }
                return _str;
            }
        }


        [ForeignKey("BillingAddressState_ID")]
        public virtual Code BillingAddressState { get; set; }

        [System.ComponentModel.DefaultValue(SHF.Helper.busConstant.Code.STATE)]
        public System.Int64 BillingAddressState_ID { get; set; }

        [Column("Billing_Address_State_Value")]
        public System.String BillingAddressStateValue { get; set; }

        [NotMapped]
        public System.String BillingAddressStateDescription
        {
            get
            {
                string _str = string.Empty;
                if (this.BillingAddressState.IsNotNull() && this.BillingAddressState.CodeValues.IsNotNull())
                {
                    _str = this.BillingAddressState.CodeValues.FirstOrDefault(x => x.Value == this.BillingAddressStateValue).Description;
                }
                return _str;
            }
          
        }


        [ForeignKey("BillingAddressCityOrDistrict_ID")]
        public virtual Code BillingAddressCityOrDistrict { get; set; }

        [System.ComponentModel.DefaultValue(SHF.Helper.busConstant.Code.CITY_OR_DISTRICT)]
        public System.Int64 BillingAddressCityOrDistrict_ID { get; set; }

        [Column("Billing_Address_CityOrDistrict_Value")]
        public System.String BillingAddressCityOrDistrictValue { get; set; }

        [NotMapped]
        public System.String BillingAddressCityOrDistrictDescription
        {
            get
            {
                string _str = string.Empty;
                if (this.BillingAddressCityOrDistrict.IsNotNull() && this.BillingAddressCityOrDistrict.CodeValues.IsNotNull())
                {
                    _str = this.BillingAddressCityOrDistrict.CodeValues.FirstOrDefault(x => x.Value == this.BillingAddressCityOrDistrictValue).Description;
                }
                return _str;
            }
            
        }



        [Column("Billing_Address_Zip_Code")]
        public System.String BillingAddressZipCode { get; set; }

        [Column("Billing_Address_Phone")]
        public System.String BillingAddressPhone { get; set; }

        [Column("Billing_Address_Fax")]
        public System.String BillingAddressFax { get; set; }
        /// </Billing_Address>


        /// <Shipping_Address>

        [Column("Shipping_Address_Attention")]
        public System.String ShippingAddressAttention { get; set; }

        [Column("Shipping_Address_Street_1")]
        public System.String ShippingAddressStreet1 { get; set; }

        [Column("Shipping_Address_Street_2")]
        public System.String ShippingAddressStreet2 { get; set; }


        [ForeignKey("ShippingAddressCountry_ID")]
        public virtual Code ShippingAddressCountry { get; set; }

        [System.ComponentModel.DefaultValue(SHF.Helper.busConstant.Code.COUNTRY)]
        public System.Int64 ShippingAddressCountry_ID { get; set; }

        [Column("Shipping_Address_Country_Value")]
        public System.String ShippingAddressCountryValue { get; set; }

        [NotMapped]
        public System.String ShippingAddressCountryDescription
        {
            get
            {
                string _str = string.Empty;
                if (this.ShippingAddressCountry.IsNotNull() && this.ShippingAddressCountry.CodeValues.IsNotNull())
                {
                    _str = this.ShippingAddressCountry.CodeValues.FirstOrDefault(x => x.Value == this.ShippingAddressCountryValue).Description;
                }
                return _str;
            }            
        }





        [ForeignKey("ShippingAddressState_ID")]
        public virtual Code ShippingAddressState { get; set; }

        [System.ComponentModel.DefaultValue(SHF.Helper.busConstant.Code.STATE)]
        public System.Int64 ShippingAddressState_ID { get; set; }

        [Column("Shipping_Address_State_Value")]
        public System.String ShippingAddressStateValue { get; set; }

        [NotMapped]
        public System.String ShippingAddressStateDescription
        {
            get
            {
                string _str = string.Empty;
                if (this.ShippingAddressState.IsNotNull() && this.ShippingAddressState.CodeValues.IsNotNull())
                {
                    _str = this.ShippingAddressState.CodeValues.FirstOrDefault(x => x.Value == this.ShippingAddressStateValue).Description;
                }
                return _str;
            }
           
        }




        [ForeignKey("ShippingAddressCityOrDistrict_ID")]
        public virtual Code ShippingAddressCityOrDistrict { get; set; }

        [System.ComponentModel.DefaultValue(SHF.Helper.busConstant.Code.CITY_OR_DISTRICT)]
        public System.Int64 ShippingAddressCityOrDistrict_ID { get; set; }

        [Column("Shipping_Address_CityOrDistrict_Value")]
        public System.String ShippingAddressCityOrDistrictValue { get; set; }

        [NotMapped]
        public System.String ShippingAddressCityOrDistrictDescription
        {
            get
            {
                string _str = string.Empty;
                if (this.ShippingAddressCityOrDistrict.IsNotNull() && this.ShippingAddressCityOrDistrict.CodeValues.IsNotNull())
                {
                    _str = this.ShippingAddressCityOrDistrict.CodeValues.FirstOrDefault(x => x.Value == this.ShippingAddressCityOrDistrictValue).Description;
                }
                return _str;
            }
           
        }




        [Column("Shipping_Address_Zip_Code")]
        public System.String ShippingAddressZipCode { get; set; }

        [Column("Shipping_Address_Phone")]
        public System.String ShippingAddressPhone { get; set; }

        [Column("Shipping_Address_Fax")]
        public System.String ShippingAddressFax { get; set; }
        /// </Billing_Address>









        [Column("Contact_Person")]
        public System.String ContactPerson { get; set; }

        [Column("Contact_Number")]
        public System.String ContactNumber { get; set; }

        [Column("Email")]
        public System.String Email { get; set; }

        [Column("GST")]
        public System.String GST { get; set; }

        [Column("No_Of_Locations")]
        public System.Int32 NoOfLocations { get; set; }

        [Column("No_Of_SHF_Items")]
        public System.Int32 NoOfSHFItems { get; set; }

        [Column("Is_Active")]
        public System.Boolean? IsActive { get; set; }

        [Column("Update_Seq")]
        public System.Int32 UpdateSeq { get; set; }


        public virtual ICollection<ExceptionLog> ExceptionLogs { get; set; }
        //public virtual ICollection<AspNetRole> AspNetRoles { get; set; }
        //public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
        //public virtual ICollection<AspNetUserRole> AspNetUserRoles { get; set; }

        //public virtual ICollection<Tax> Taxes { get; set; }
        //public virtual ICollection<Product> Products { get; set; }
        //  public virtual ICollection<Vendor> Vendors { get; set; }
        //public virtual ICollection<VendorProduct> VendorProducts { get; set; }
        //public virtual ICollection<SerialNumber> SerialNumbers { get; set; }

    }
}
