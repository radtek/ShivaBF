using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.EntityModel
{
    [Table("AspNetRoles", Schema = "dbo")]
    public class AspNetRole : BaseEntity
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column("Id",Order = 1)]       
        public virtual long ID { get; set; }

        [Column("Name")]
        public System.String Name { get; set; }

        [Column("Display_Name")]
        public System.String DisplayName { get; set; }

        [Column("Is_Active")]
        public System.Boolean IsActive { get; set; }


        [Column("Update_Seq")]
        public System.Int32 UpdateSeq { get; set; }


        [ForeignKey("Tenant_ID")]
        public virtual Tenant Tenant { get; set; }
        public System.Int64? Tenant_ID { get; set; }




        public virtual ICollection<AspNetUserRole> AspNetUserRoles { get; set; }
    }
}
