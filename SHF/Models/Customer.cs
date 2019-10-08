using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string ContactPerson { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string GST { get; set; }
        public int NoOfLocations { get; set; }
        public int NoOfInventoryItems { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }




        public virtual ICollection<AddToStock> AddToStocks { get; set; }
        public virtual ICollection<AddToStockItems> AddToStockItems { get; set; }
        public virtual ICollection<PartyItems> PartyItems { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<SubCategory> SubCategories { get; set; }
        public virtual ICollection<AddToStockTransaction> AddToStockTransactions { get; set; }











    }
}