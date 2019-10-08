using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.EntityModel
{
    [Table("AspNetUsers", Schema = "dbo")]
    public class AspNetUser : BaseEntity
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column("Id", Order = 1)]
        public virtual long ID { get; set; }

        [Column("First_Name")]
        public System.String FirstName { get; set; }

        [Column("Last_Name")]
        public System.String LastName { get; set; }        

        [Column("Email")]
        public System.String Email { get; set; }        

        [Column("EmailConfirmed")]
        public System.Boolean? EmailConfirmed { get; set; }

        [Column("PasswordHash")]
        public System.String PasswordHash { get; set; }

        [Column("SecurityStamp")]
        public System.String SecurityStamp { get; set; }

        [Column("PhoneNumber")]
        public System.String PhoneNumber { get; set; }

        [Column("PhoneNumberConfirmed")]
        public System.Boolean? PhoneNumberConfirmed { get; set; }

        [Column("TwoFactorEnabled")]
        public System.Boolean? TwoFactorEnabled { get; set; }

        [Column("LockoutEndDateUtc")]
        public System.DateTime? LockoutEndDateUtc { get; set; }

        [Column("LockoutEnabled")]
        public System.Boolean LockoutEnabled { get; set; }

        [Column("AccessFailedCount")]
        public System.Int32 AccessFailedCount { get; set; }

        [Column("UserName")]
        public System.String UserName { get; set; }

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
