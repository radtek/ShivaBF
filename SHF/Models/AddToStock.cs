using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Inventory.Models
{
    public class AddToStock
    {
        [Key]
        public int AddToStockId { get; set; }
        
        public string ReferenceNo { get; set; }
        public string Remark { get; set; }
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        //public DateTime AddDate { get; set; }
        //public int Addedby { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }


        public int TypeId { get; set; }
        public virtual TypeMaster Type { get; set; }

        public int PartyMasterId { get; set; }
        public virtual PartyMaster PartyMaster { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public int TransactionStatusId { get; set; }
        public virtual TransactionStatusMaster TransactionStatus { get; set; }

        public virtual ICollection<AddToStockItems> AddToStockItems { get; set; }
        public List<AddToStockDetails> AddToStockDetails { get; set; }
        public List<InventoryMaster> InventoryMaster { get; set; }

    }
}