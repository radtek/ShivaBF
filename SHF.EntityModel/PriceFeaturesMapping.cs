﻿using System;
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
        [ForeignKey("SubSubCat_Id")]
        public virtual SubSubCategoriesMaster SubSubCategoriesMaster { get; set; }
        public System.Int64? SubSubCat_Id { get; set; }
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
        [Column("Url")]
        public string Url { get; set; }

        [Column("Metadata")]
        public string Metadata { get; set; }

        [Column("Keyword")]
        public string Keyword { get; set; }

        [Column("MetaDescription")]
        public string MetaDescription { get; set; }
        [ForeignKey("Tenant_ID")]
        public virtual Tenant Tenant { get; set; }
        public System.Int64? Tenant_ID { get; set; }
        public virtual IEnumerable<PriceFeaturesMapping> PriceFeaturesMappings { get; set; }
    }
}
