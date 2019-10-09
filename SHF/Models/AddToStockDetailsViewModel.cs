using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory.Models
{
    public class AddToStockDetailsViewModel
    {
        public int ATSId { get; set; }
        public int SupplierItemId { get; set; }
        public int SerialNo { get; set; }
        public float Weight { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int Status { get; set; } 
        public string PRReferenceNo { get; set; }
        public int CustomerId { get; set; } 
        public int PurchaseRequisition_PRNo { get; set; }
        public string PurchaseRequisitionName { get; set; }
        public string SupplierName { get; set; }
        public DateTime PRIssueDate { get; set; }
        public DateTime PRDeliveryDate { get; set; } 
        public string ProductName { get; set; }
        public string SupplierPartName { get; set; } 
        public int PRNo { get; set; }
        public int ItemId { get; set; }
        public int TypeId { get; set; }
        public int AddToStockId { get; set; }
        public List<AddToStockItems> AddToStockItems { get; set; }
        public List<AddToStockTransaction> AddToStockTransactions { get; set; }
        public List<AddToStockDetails> AddToStockDetails { get; set; }
        public List<InventoryMaster> InventoryMaster { get; set; }
    }
}