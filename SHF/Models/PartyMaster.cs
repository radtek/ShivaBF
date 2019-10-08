using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Models
{
    public class PartyMaster
    { 
        [Key]
        public int PartyMasterId { get; set; }
        public string PartyName { get; set; }
        public string GSTNo { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }


        public int PartyTypeId { get; set; }
        public virtual PartyType PartyType { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual ICollection<AddToStock> AddToStocks { get; set; }

        public virtual ICollection<PartyItems> PartyItems { get; set; }
    }
}