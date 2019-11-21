using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.EntityModel
{
    [Table("Tbl_IP_Threat", Schema = "dbo")]
    public class Threat : BaseEntity
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public virtual long ID { get; set; }
        public bool is_tor { get; set; }
        public bool is_proxy { get; set; }
        public bool is_anonymous { get; set; }
        public bool is_known_attacker { get; set; }
        public bool is_known_abuser { get; set; }
        public bool is_threat { get; set; }
        public bool is_bogon { get; set; }
        [ForeignKey("Tenant_ID")]
        public virtual Tenant Tenant { get; set; }
        public System.Int64? Tenant_ID { get; set; }

    }
}
