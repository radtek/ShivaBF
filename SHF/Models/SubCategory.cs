using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Inventory.Models
{
    public class SubCategory
    {
        [Key]
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }



        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}