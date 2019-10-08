using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Models
{
    public class TransactionStatusMaster
    {
        [Key]
        public int TransactionStatusId { get; set; }
        public string TransactionStatus { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }




        public virtual ICollection<AddToStock> AddToStocks { get; set; }
    }
}