using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SHF.ViewModel
{
    public sealed class TenantDeleteViewModel : BaseViewModel
    {
        [DisplayName("Customer Name")]
        [Helper.RequiredField(ErrorMessage = Helper.busConstant.Messages.Type.Validations.REQUIRED)]
        //[RegularExpression(@"([a-zA-Z ]+) (\d+)", ErrorMessage = Helper.busConstant.Messages.Type.Validations.OnlyCharaters)]
        public System.String Name { get; set; }

        [DisplayName("Address")]
        [DataType(DataType.MultilineText)]
        [Helper.RequiredField(ErrorMessage = Helper.busConstant.Messages.Type.Validations.REQUIRED)]
        public System.String Address { get; set; }

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
