using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory.Models
{
    public class RemoveFromStockVeiwModel
    {
        public int RemoveFromStockId { get; set; }
        public int Removedby { get; set; }
        public DateTime RemovedDate { get; set; }
        public int PartyItemId { get; set; }
        public int SerialNo { get; set; }
        public float Weight { get; set; }
        public int Quantity { get; set; }
        public int Status { get; set; }
        public string ReferenceNo { get; set; }
        public int CustomerId { get; set; }
        public int TransactionStatusId { get; set; }  
        public string Remark { get; set; } 
        public string ProductName { get; set; }
        public int PartyId { get; set; }
        public int ItemId { get; set; }
        public int TypeId { get; set; } 
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public List<RemoveFromStock> RemoveFromStock { get; set; }
        public List<RemoveFromStockItems> RemoveFromStockItems { get; set; }
    }
}