using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Models
{
    public class InventoryMaster
    {
        [Key]
        public int InventoryId { get; set; }
        public int CustomerId { get; set; }
        public int PartyItemId { get; set; }
        public int StatusId { get; set; }
        public int LocationId { get; set; }
        public string Shelf { get; set; }
        public string Bin { get; set; }
        public int OpeningQuantity { get; set; }
        public int AddedQuantity { get; set; }
        public int RemovedQuantity { get; set; }
        public int OpeningWeight { get; set; }
        public int AddedWeight { get; set; }
        public int RemovedWeight { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public virtual ICollection<AddToStock> AddToStock { get; set; }
    }
}