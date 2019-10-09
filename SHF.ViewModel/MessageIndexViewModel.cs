using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.ViewModel
{
    public class MessageIndexViewModel : BaseViewModel
    {       
        public System.String Description { get; set; }
        public System.String Title { get; set; }
        public System.String Type { get; set; }
        public System.String Icon { get; set; }
        public System.Boolean IsActive { get; set; }
        public System.Int32 UpdateSeq { get; set; }
        public System.Int32 MessageCode { get; set; }
    }
    public class MessageCreateOrEditViewModel : BaseViewModel
    {
        [Helper.RequiredField(ErrorMessage = Helper.busConstant.Messages.Type.Validations.REQUIRED)]
        public System.Int32 MessageCode { get; set; }

        [Display(Name = "Description")]
        [Helper.RequiredField(ErrorMessage = Helper.busConstant.Messages.Type.Validations.REQUIRED)]
        public System.String Description { get; set; }

        [Display(Name = "Title")]
        [Helper.RequiredField(ErrorMessage = Helper.busConstant.Messages.Type.Validations.REQUIRED)]
        public System.String Title { get; set; }

        [Display(Name = "Type")]
        [Helper.RequiredField(ErrorMessage = Helper.busConstant.Messages.Type.Validations.REQUIRED)]
        public System.String Type { get; set; }

        [Display(Name = "Icon")]
        [Helper.RequiredField(ErrorMessage = Helper.busConstant.Messages.Type.Validations.REQUIRED)]
        public System.String Icon { get; set; }

        public System.Boolean IsActive { get; set; }
        public System.Int32 UpdateSeq { get; set; }

    }
}
