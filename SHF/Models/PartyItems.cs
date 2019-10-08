using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Models
{
    public class PartyItems
    {
        [Key]
        public int PartyItemsId { get; set; }
        public string PartyPartCode { get; set; }
        public string PartyPartName { get; set; }
        public string PartyPartDescription { get; set; }
        public string CustomerPartCode { get; set; }
        
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }



        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public int ItemId { get; set; }
        public virtual Item Item { get; set; }

        public int PartyMasterId { get; set; }
        public virtual PartyMaster PartyMaster { get; set; }

        public virtual ICollection<AddToStockItems> AddToStockItems { get; set; }

        //public virtual ICollection<AddToStockTransaction> AddToStockTransactions { get; set; }
    }
}