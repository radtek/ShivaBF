using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SHF.EntityModel
{
    [Table("Tbl_AspNetRoles_SubMenu", Schema = "dbo")]
    public class AspNetRoleSubMenu : SHF.EntityModel.BaseEntity
    {

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public virtual long ID { get; set; }


        [ForeignKey("SubMenu_ID")]
        public virtual EntityModel.SubMenu SubMenu { get; set; }

        [Key]
        [Column(name: "SubMenu_ID", Order = 2)]
        public System.Int64 SubMenu_ID { get; set; }       


        [Key]
        [Column(name: "AspNetRole_ID", Order = 3)]
        public System.Int64 AspNetRole_ID { get; set; }



        [Column("HasAccess")]
        public System.Boolean HasAccess { get; set; }

        [Column("IsActive")]
        public System.Boolean? IsActive { get; set; }

        [Column("UpdateSeq")]
        public System.Int32 UpdateSeq { get; set; }


        [ForeignKey("Tenant_ID")]
        public virtual Tenant Tenant { get; set; }
        public System.Int64? Tenant_ID { get; set; }
    }
}