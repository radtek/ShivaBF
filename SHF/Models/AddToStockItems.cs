using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Models
{
    public class AddToStockItems
    {
        [Key]
        public int AddToStockItemsId { get; set; }
      
       
        public float Weight { get; set; }
        public int Quantity { get; set; }
        
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }



        public int AddToStockId { get; set; }
        public virtual AddToStock AddToStock { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }


        public int PartyItemsId { get; set; }
        public virtual PartyItems PartyItems { get; set; }



        public virtual ICollection<AddToStockTransaction> AddToStockTransactions { get; set; }
    }
}