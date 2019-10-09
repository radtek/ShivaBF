using SHF.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.ViewModel
{

    public class SubMenuIndexViewModel : BaseViewModel
    {
        public System.String Name { get; set; }

        public System.String Url { get; set; }

        public System.String IconClass { get; set; }

        public System.Boolean? IsActive { get; set; }

        public System.Int32 UpdateSeq { get; set; }

        public System.Int32 OrderBy { get; set; }

        public System.String ParrentMenuName { get; set; }

        public System.Int64? ParrentMenu_ID { get; set; }

    }

    public class SubMenuCreateOrEditViewModel : BaseViewModel
    {

        [Required(ErrorMessage = busConstant.Messages.Type.Validations.REQUIRED)]
        public System.String Name { get; set; }

        [Required(ErrorMessage = busConstant.Messages.Type.Validations.REQUIRED)]
        public System.String Url { get; set; }

        [Required(ErrorMessage = busConstant.Messages.Type.Validations.REQUIRED)]
        public System.String IconClass { get; set; }
        //public System.String UseOnlyFor { get; set; }
        public System.Boolean? IsActive { get; set; }

        public System.Int32 UpdateSeq { get; set; }

        [Required(ErrorMessage = busConstant.Messages.Type.Validations.REQUIRED)]
        public System.Int32 OrderBy { get; set; }

        public System.String ParrentMenuName { get; set; }

        public System.Int64? ParrentMenu_ID { get; set; }

    }

    public class SubMenuDropdownListViewModel : BaseViewModel
    {
        public System.String Name { get; set; }
    }

}
