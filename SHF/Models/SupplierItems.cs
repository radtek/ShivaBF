using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Models
{
    public class SupplierItems
    {
        [Key]
        public int SupplierItemsId { get; set; }
        public string SupplierItemsName { get; set; }
        public int SupplierId { get; set; }
        public string SupplierPartCode { get; set; }
        public string SupplierPartName { get; set; }
        public string SupplierPartDescription { get; set; }
        public string CustomerPartCode { get; set; }
        public int CustomerId { get; set; }
        public int ItemId { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

    }
}