using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Inventory.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        public string ProductName { get; set; }
        public string PartCode { get; set; }
        public string Description { get; set; }        
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }


        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public int UnitOfMeasureId { get; set; }
        public virtual UnitOfMeasure UnitOfMeasure { get; set; }

        public int SubCategoryId { get; set; }
        public virtual SubCategory SubCategory { get; set; }



        public virtual ICollection<PartyItems> PartyItems { get; set; }
    }
}