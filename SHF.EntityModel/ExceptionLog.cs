using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.EntityModel
{
    [Table("ExceptionLog", Schema = "dbo")]
    public class ExceptionLog : BaseEntity
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public virtual long ID { get; set; }

        [Column("Message")]
        public string Message { get; set; }

        [Column("Inner_Exception")]
        public string InnerException { get; set; }

        [Column("Source")]
        public string Source { get; set; }

        [Column("Stack_Trace")]
        public string StackTrace { get; set; }

        [Column("Target_Site")]
        public string TargetSite { get; set; }

        [Column("HResult")]
        public int HResult { get; set; }

        [Column("Help_Link")]
        public string HelpLink { get; set; }

        [Column("Controller_Name")]
        public string ControllerName { get; set; }

        [Column("Action_Name")]
        public string ActionName { get; set; }

        [Column("Url")]
        public string Url { get; set; }

        [ForeignKey("Tenant_ID")]
        public virtual Tenant Tenant { get; set; }
        public System.Int64? Tenant_ID { get; set; }
    }
}
