using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.EntityModel
{
    [Table("Tbl_HomePageSection2", Schema = "dbo")]
    public class HomePageSection2 : BaseEntity
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public virtual long ID { get; set; }
        [Column("BannerImagePath")]
        public System.String BannerImagePath { get; set; }
        [Column("Heading1")]
        public System.String Heading1 { get; set; }
        [Column("Heading2")]
        public System.String Heading2 { get; set; }
        [Column("Heading3")]
        public System.String Heading3 { get; set; }
        [Column("Description1")]
        public System.String Description1 { get; set; }
        [Column("Description2")]
        public System.String Description2 { get; set; }
        [Column("DisplayIndex")]
        public System.Int32 DisplayIndex { get; set; }
        [Column("DisplayOnHome")]
        public System.Boolean? DisplayOnHome { get; set; }
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