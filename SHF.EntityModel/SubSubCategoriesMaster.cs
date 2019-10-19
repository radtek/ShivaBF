using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.EntityModel
{
    [Table("Tbl_SubSubCategoriesMaster", Schema = "dbo")]
    public class SubSubCategoriesMaster : BaseEntity
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public virtual long ID { get; set; }
        [ForeignKey("Cat_Id")]
        public virtual CategoriesMaster CategoriesMaster { get; set; }
        public System.Int64? Cat_Id { get; set; }
        [ForeignKey("SubCat_Id")]
        public virtual SubCategoriesMaster SubCategoriesMaster { get; set; }
        public System.Int64? SubCat_Id { get; set; }
        [Column("SubSubCategoryName")]
        public System.String SubSubCategoryName { get; set; }
        [Column("DisplayIndex")]
        public System.Int32 DisplayIndex { get; set; }
        [Column("DisplayOnHome")]
        public System.Boolean? DisplayOnHome { get; set; }
        [Column("IsActive")]
        public System.Boolean? IsActive { get; set; }
        [ForeignKey("ServiceType_ID")]
        public virtual Code ServiceType { get; set; }

        [System.ComponentModel.DefaultValue(SHF.Helper.busConstant.Code.SERVICE_TYPE)]
        public System.Int64 ServiceType_ID { get; set; }
        [Column("ServiceTypeValue")]
        public System.String ServiceTypeValue { get; set; }
       
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
        public virtual IEnumerable<SubSubCategoriesMaster> SubSubCategoriesMasters { get; set; }
    }
}