using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.ViewModel
{
    public sealed class TenantIndexViewModel : BaseViewModel
    {
        [DisplayName("Customer Name")]
        [DefaultValue("")]
        public System.String Name { get; set; }

        [DisplayName("User Name")]
        [DefaultValue("")]
        public System.String Username { get; set; }

        [DisplayName("Billing Address")]
        [DefaultValue("")]
        public System.String BillingAddress { get; set; }

        [DisplayName("Shipping Address")]
        [DefaultValue("")]
        public System.String ShippingAddress { get; set; }

        [DisplayName("Contact Person Name")]
        [DefaultValue("")]
        public System.String ContactPerson { get; set; }

        [DisplayName("Contact Number")]
        [DefaultValue("")]
        public System.String ContactNumber { get; set; }

        [DisplayName("Email")]
        [DefaultValue("")]
        public System.String Email { get; set; }

        [DisplayName("GST Number")]
        [DefaultValue("")]
        public System.String GST { get; set; }

        [DisplayName("No Of Locations")]        
        public System.Int32? NoOfLocations { get; set; }

        [DisplayName("No Of SHF Items")]
        public System.Int32? NoOfSHFItems { get; set; }

        
    }
}
