using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.ViewModel
{
   public class BankMasterViewModel : BaseViewModel
    {

       
        public System.String IconPath { get; set; }
        public System.String Description { get; set; }
        public System.Boolean? IsActive { get; set; }
}
}
