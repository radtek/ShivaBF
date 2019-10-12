using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.EntityModel
{
    [Table("Tbl_Services1Section10BankMapping", Schema = "dbo")]
    public class Services1Section10BankMapping : BaseEntity
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public virtual long ID { get; set; }
        [ForeignKey("Service_Id")]
        public virtual Services1Master Services1Master { get; set; }
        public System.Int64? Service_Id { get; set; }
        [ForeignKey("BankMaster_Id")]
        public virtual BankMaster BankMaster { get; set; }
        public System.Int64? BankMaster_Id { get; set; }
        [Column("DisplayIndex")]
        public System.Int32 DisplayIndex { get; set; }
        [Column("IsActive")]
        public System.Boolean? IsActive { get; set; }
        [Column("TotalViews")]
        public System.Int32 TotalViews { get; set; }
        [Column("Url")]
        public string Url { get; set; }

        [Column("Metadata")]
        public string Metadata { get; set; }

        [Column("Keyword")]
        public string Keyword { get; set; }

        [Column("MetaDescription")]
        public string MetaDescription { get; set; }
        public virtual IEnumerable<Services1Section6PriceMaster> Services1Section6PriceMasters { get; set; }
    }
}
