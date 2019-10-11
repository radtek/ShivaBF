using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.EntityModel
{
    [Table("Tbl_Services1Section4Master", Schema = "dbo")]
    public class Services1Section4Master : BaseEntity
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public virtual long ID { get; set; }
        [ForeignKey("Service_Id")]
        public virtual Services1Master Services1Master { get; set; }
        public System.Int64? Service_Id { get; set; }
        [Column("HeadingText")]
        public System.String HeadingText { get; set; }
        [Column("ShortDescription")]
        public System.String ShortDescription { get; set; }
        [Column("AncharTagTitle")]
        public System.String AncharTagTitle { get; set; }
        [Column("AncharTagUrl")]
        public System.String AncharTagUrl { get; set; }
        [Column("DisplayIndex")]
        public System.Int32 DisplayIndex { get; set; }
        [Column("IsActive")]
        public System.Boolean? IsActive { get; set; }
        [Column("TotalViews")]
        public System.Int32 TotalViews { get; set; }
        public virtual IEnumerable<Services1Section4Master> Services1Section4Masters { get; set; }
    }
}
