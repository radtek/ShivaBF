using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.ViewModel
{
   public class Services1Section6MasterPriceViewModel : BaseViewModel
    {
       
        public System.Int64? Service_Id { get; set; }
        public System.String ServiceName { get; set; }
        public System.String HeadingText { get; set; }
        public System.Int64 Price { get; set; }
        public System.String AncharTagTitle { get; set; }
        public System.String AncharTagUrl { get; set; }
        public System.Int32 DisplayIndex { get; set; }
        public System.Boolean? IsActive { get; set; }
        public System.Int32 TotalViews { get; set; }
    }
}
