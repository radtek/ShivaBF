using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Models
{
    public class AddToStockDetails
    {
        [Key]
        public int ATSId { get; set; }
        public int? ItemId { get; set; }
        public int? SupplierItemId { get; set; }
        public string SerialNo { get; set; }
        public float? Weight { get; set; }
        public int? Quantity { get; set; }
        public int? Status { get; set; }
        public int? CustomerId { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? AddToStockId { get; set; }
        public virtual ICollection<AddToStock> AddToStock { get; set; }
        //public virtual ICollection<InventoryMaster> InventoryMaster { get; set; }
    }
}