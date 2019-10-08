using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.EntityModel
{
    [Table("Tbl_CodeValue", Schema = "dbo")]
    public class CodeValue : BaseEntity
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public virtual long ID { get; set; }

        [ForeignKey("Code_ID")]
        public virtual Code Code { get; set; }
        [Column("Code_ID")]
        [Index(name: "IX_CodeVale_CodeIDAndValue", Order = 1, IsUnique = SHF.Helper.busConstant.Misc.TRUE)]
        public System.Int64 Code_ID { get; set; }

        [Column("CodeValue")]
        [MaxLength(4)]
        [Index(name: "IX_CodeVale_CodeIDAndValue", Order = 2, IsUnique = SHF.Helper.busConstant.Misc.TRUE)]
        public System.String Value { get; set; }

        [Column("Description")]
        [MaxLength(100)]
        public string Description { get; set; }

        [Column("Data_1_Type")]
        [MaxLength(4)]
        public string Data1Type { get; set; }

        [Column("Data_2_Caption")]
        [MaxLength(100)]
        public string Data2Caption { get; set; }

        [Column("Data_2_Type")]
        [MaxLength(4)]
        public string Data2Type { get; set; }

        [Column("Data_3_Caption")]
        [MaxLength(100)]
        public string Data3Caption { get; set; }

        [Column("Data_3_Type")]
        [MaxLength(4)]
        public string Data3Type { get; set; }

        [Column("Comments")]
        [MaxLength(5000)]
        public string Comments { get; set; }

        [Column("Is_Active")]
        public System.Boolean? IsActive { get; set; }

        [Column("Update_Seq")]
        [System.ComponentModel.DefaultValue(SHF.Helper.busConstant.Numbers.Integer.ZERO)]
        public System.Int32 UpdateSeq { get; set; }
    }
}
