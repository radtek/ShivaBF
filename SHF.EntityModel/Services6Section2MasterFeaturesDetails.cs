﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.EntityModel
{
    [Table("Tbl_Services6Section2MasterFeaturesDetails", Schema = "dbo")]
    public class Services6Section2MasterFeaturesDetails : BaseEntity
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public virtual long ID { get; set; }
        [ForeignKey("Service_Id")]
        public virtual Services6Master Services6Master { get; set; }
        public System.Int64? Service_Id { get; set; }
        [ForeignKey("S6S2M_Id")]
        public virtual Services6Section2Master Services6Section2Master { get; set; }
        public System.Int64? S6S2M_Id { get; set; }
        [Column("Price")]
        public System.Int64 Price { get; set; }
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
        //public virtual IEnumerable<Services1Section1Master> Services1Section1Masters { get; set; }
    }
}
