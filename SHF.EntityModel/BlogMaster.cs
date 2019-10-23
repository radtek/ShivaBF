using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.EntityModel
{
    [Table("Tbl_BlogMaster", Schema = "dbo")]
    public class BlogMaster : BaseEntity
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public virtual long ID { get; set; }
        [Column("BannerImagePath")]
        public System.String BannerImagePath { get; set; }
        [Column("BannerDescription1")]
        public System.String BannerDescription1 { get; set; }
        [Column("BannerDescription2")]
        public System.String BannerDescription2 { get; set; }
        [Column("BlogTitle")]
        public System.String BlogTitle { get; set; }
        [Column("Section1ImagePath")]
        public System.String Section1ImagePath { get; set; }
        [Column("Section2Heading")]
        public System.String Section2Heading { get; set; }
        [Column("Section2Description")]
        public System.String Section2Description { get; set; }
        [Column("Section3Heading")]
        public System.String Section3Heading { get; set; }
        [Column("Section3Description")]
        public System.String Section3Description { get; set; }
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

    }
}

