using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.EntityModel
{
    [Table("Tbl_SubCategoriesMaster", Schema = "dbo")]
    public class SubCategoriesMaster : BaseEntity
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public virtual long ID { get; set; }
        [ForeignKey("Cat_Id")]
        public virtual CategoriesMaster CategoriesMaster { get; set; }
        public System.Int64? Cat_Id { get; set; }
        [Column("SubCategoryName")]
        public System.String SubCategoryName { get; set; }
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

        public virtual IEnumerable<SubCategoriesMaster> SubCategoriesMasters { get; set; }
    }
}