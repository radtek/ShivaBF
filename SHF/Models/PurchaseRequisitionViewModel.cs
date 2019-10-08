using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory.Models
{
    public class PurchaseRequisitionViewModel
    {
        public int PRNo { get; set; }
        public DateTime PRIssueDate { get; set; }
        public DateTime PRDeliveryDate { get; set; }
        public int Status { get; set; }
        public string PurchaseRequisitionName { get; set; }
        public int SupplierId { get; set; }
        public int PRRaisedBy { get; set; }
        public int CustomerId { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        
        public List<PRItems> PRItems { get; set; }
    }
}