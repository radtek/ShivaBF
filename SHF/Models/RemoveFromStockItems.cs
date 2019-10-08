using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Models
{
    public class RemoveFromStockItems
    {
        [Key]
        public int RemoveFromStockItemsId { get; set; }
        public int RemoveFromStockId { get; set; }
        public int PartyItemId { get; set; } 
        public float Weight { get; set; } 
        public int Quantity { get; set; }
        public int CustomerId { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}