using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.EntityModel
{
    [Table("Tbl_CustomerMaster", Schema = "dbo")]
    public class CustomerMaster : BaseEntity
    {
 
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public virtual long ID { get; set; }

        [Column("Gender")]
        public System.String Gender { get; set; }
        [Column("FirstName")]
        public System.String FirstName { get; set; }
        [Column("LastName")]
        public System.String LastName { get; set; }
        [Column("DOB")]
        public System.DateTime DOB { get; set; }
        [Column("EmailID")]
        public System.String EmailID { get; set; }
        [Column("FullStreetAddress")]
        public System.String FullStreetAddress { get; set; }
        [Column("Telephone")]
        public System.String Telephone { get; set; }
        [Column("Fax")]
        public System.String Fax { get; set; }

        [Column("Password")]
        public System.String Password { get; set; }
        [Column("Newsletter")]
        public System.String Newsletter { get; set; }
     
        [Column("IsActive")]
        public System.Boolean? IsActive { get; set; }
      
        [ForeignKey("Tenant_ID")]
        public virtual Tenant Tenant { get; set; }
        public System.Int64? Tenant_ID { get; set; }

    }
}