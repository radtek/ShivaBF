using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.EntityModel
{
    [Table("Tbl_SubMenu", Schema = "dbo")]
    public class SubMenu : BaseEntity
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public virtual long ID { get; set; }

        [Column("Name")]        
        public System.String Name { get; set; }

        [Column("Url")]
        public System.String Url { get; set; }

        [Column("IconClass")]
        public System.String IconClass { get; set; }

        [Column("UseOnlyFor")]
        public System.String UseOnlyFor { get; set; }

        [Column("IsActive")]
        public System.Boolean? IsActive { get; set; }

        [Column("UpdateSeq")]
        public System.Int32 UpdateSeq { get; set; }

        [Column("OrderBy")]        
        public System.Int32 OrderBy { get; set; }

        [ForeignKey("ParrentMenu_ID")]
        public virtual SubMenu ParrentMenu { get; set; }
        public System.Int64? ParrentMenu_ID { get; set; }





        public virtual IEnumerable<SubMenu> SubMenus { get; set; }
    }
}
