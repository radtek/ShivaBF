using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Inventory.Models
{
    public class UnitOfMeasure
    {
        [Key]
        public int UnitOfMeasureId { get; set; }
        public string UnitName { get; set; }
        public string Type { get; set; }
        public bool IsSerialTracked { get; set;}
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }


        public virtual ICollection<Item> Items { get; set; }

    }
}