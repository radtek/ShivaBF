using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Inventory.Models
{
    public class RemoveFromStock
    {
        [Key]
        public int RemoveFromStockId { get; set; }
        public string ReferenceNo { get; set; } 
        public int TypeId { get; set; }        
        public string Remark { get; set; }
        public DateTime RemovedDate { get; set; }
        public int Removedby { get; set; }
        public int TransactionStatusId { get; set; }
        public int PartyId { get; set; }
        public int CustomerId { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public virtual ICollection<RemoveFromStockItems> RemoveFromStockItems { get; set; } 
    }
}