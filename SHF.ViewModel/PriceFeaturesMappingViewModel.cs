using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.ViewModel
{
   public class PriceFeaturesMappingViewModel : BaseViewModel
    {
        public System.Int64? Service_Id { get; set; }
        public System.Int64? S1S6PM_Id { get; set; }
        public System.Int64? PriceFeaturesMaster_Id { get; set; }
        public System.Int32 DisplayIndex { get; set; }
    }
}
