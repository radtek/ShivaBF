using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.EntityModel
{
    [Table("Tbl_Services4Section345Master", Schema = "dbo")]
    public class Services4Section345Master : BaseEntity
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public virtual long ID { get; set; }
        [ForeignKey("Service_Id")]
        public virtual Services4Master Services4Master { get; set; }
        public System.Int64? Service_Id { get; set; }
        [ForeignKey("SubSubCat_Id")]
        public virtual SubSubCategoriesMaster SubSubCategoriesMaster { get; set; }
        public System.Int64? SubSubCat_Id { get; set; }
        [ForeignKey("SectionType_ID")]
        public virtual Code SectionType { get; set; }
        [System.ComponentModel.DefaultValue(SHF.Helper.busConstant.Code.SECTION_TYPE)]
        public System.Int64 SectionType_ID { get; set; }
        [Column("SectionTypeValue")]
        public System.String SectionTypeValue { get; set; }
        [Column("Heading")]
        public System.String Heading { get; set; }

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
