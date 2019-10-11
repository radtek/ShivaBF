using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.EntityModel
{
    [Table("Tbl_PriceFeaturesMapping", Schema = "dbo")]
    public class PriceFeaturesMapping : BaseEntity
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public virtual long ID { get; set; }
        [ForeignKey("Service_Id")]
        public virtual Services1Master Services1Master { get; set; }
        public System.Int64? Service_Id { get; set; }
        [ForeignKey("S1S6PM_Id")]
        public virtual Services1Section6PriceMaster Services1Section6PriceMaster { get; set; }
        public System.Int64? S1S6PM_Id { get; set; }
        [ForeignKey("PriceFeaturesMaster_Id")]
        public virtual PriceFeaturesMaster PriceFeaturesMaster { get; set; }
        public System.Int64? PriceFeaturesMaster_Id { get; set; }
        [Column("DisplayIndex")]
        public System.Int32 DisplayIndex { get; set; }
        [Column("IsActive")]
        public System.Boolean? IsActive { get; set; }
        [Column("TotalViews")]
        public System.Int32 TotalViews { get; set; }
        public virtual IEnumerable<PriceFeaturesMapping> PriceFeaturesMappings { get; set; }
    }
}
