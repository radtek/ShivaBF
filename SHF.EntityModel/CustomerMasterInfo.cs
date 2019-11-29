using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.EntityModel
{
    [Table("Tbl_CustomerMasterInfo", Schema = "dbo")]
    public class CustomerMasterInfo : BaseEntity
    {

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public virtual long ID { get; set; }
        [ForeignKey("CustomerMaster_ID")]
        public virtual CustomerMaster CustomerMaster { get; set; }
        public System.Int64 CustomerMaster_ID { get; set; }
        [Column("InfoDateOfLastLogon")]
        public System.DateTime InfoDateOfLastLogon { get; set; }
        [Column("InfoNumberOfLogons")]
        public System.Int64 InfoNumberOfLogons { get; set; }
        [Column("InfoDateAccountCreated")]
        public System.DateTime InfoDateAccountCreated { get; set; }
        [Column("InfoDateAccountLastModified")]
        public System.DateTime InfoDateAccountLastModified { get; set; }
        [ForeignKey("Tenant_ID")]
        public virtual Tenant Tenant { get; set; }
        public System.Int64? Tenant_ID { get; set; }

    }
}