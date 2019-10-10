using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.ViewModel
{
    public class FAQMasterViewModel : BaseViewModel
    {
        public System.String Title { get; set; }
        public System.String Description { get; set; }
        public System.Boolean? IsActive { get; set; }
    }
}
