using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.ViewModel
{
    public class CodeValueIndexViewModel : BaseViewModel
    {
    }

    public class CodeValueDropDownListViewModel : BaseViewModel
    {
        public System.String Value { get; set; }
        public System.String Description { get; set; }
    }

    public class CodeDropDownListViewModel : BaseViewModel
    {
        public System.String Value { get; set; }
        public System.String Description { get; set; }
    }

}
