using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Models
{
    public class PartyType
    {   [Key]
        public int PartyTypeId { get; set; }
        public string PartyTypeName { get; set; }        
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }



        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual ICollection<PartyMaster> Parties { get; set; }
    }
}