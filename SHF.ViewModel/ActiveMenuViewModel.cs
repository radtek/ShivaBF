using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.ViewModel
{
   public class ActiveMenuViewModel: BaseViewModel
    {
       
        public string MenuName { get; set; }
        public string Url { get; set; }
        public int ParrentMenuID { get; set; }
        public int Level { get; set; }
       
    }
}
