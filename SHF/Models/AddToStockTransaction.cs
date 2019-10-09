using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Inventory.Models
{
    public class AddToStockTransaction
    {
        [Key]
        public int AddToStockTransactionId { get; set; }
       
        public string SerialNo { get; set; }
        public float Weight { get; set; }
        public int Quantity { get; set; }
        public int Status { get; set; }
        public string ShelfCode { get; set; }
        public string BinCode { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }





        public int AddToStockItemsId { get; set; }
        public virtual AddToStockItems AddToStockItems { get; set; }


        //public int PartyItemsId { get; set; }
        //public virtual PartyItems PartyItems { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}