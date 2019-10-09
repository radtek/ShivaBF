using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; 

namespace Inventory.Models
{
    public class PRItems
    {
        [Key]
        public int PRId { get; set; }
        public int ItemId { get; set; }
        public int PurchaseRequisitionItemId { get; set; }
        public int PurchaseRequisitionId { get; set; }
        public int SupplierItemId { get; set; }
        public int Quantity { get; set; }
        public decimal Weight { get; set; }
        //public decimal Price { get; set; }
        public int CustomerId { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public virtual PurchaseRequisition PurchaseRequisition { get; set; }
    }
}