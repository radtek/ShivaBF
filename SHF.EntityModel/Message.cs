using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHF.Helper;

namespace SHF.EntityModel
{
    [Table("Tbl_Message", Schema = "dbo")]
    public class Message : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id", Order = 1)]
        public virtual long ID { get; set; }

        [Index(IsUnique = busConstant.Misc.TRUE)]
        [Column("Message_Code")]
        public System.Int32 MessageCode { get; set; }

        [Column("Description")]
        public System.String Description { get; set; }

        [Column("Title")]
        public System.String Title { get; set; }

        [Column("Type")]
        public System.String Type { get; set; }

        [Column("Icon")]
        public System.String Icon { get; set; }

        [Column("Is_Active")]
        public System.Boolean IsActive { get; set; }

        [Column("Update_Seq")]
        public System.Int32 UpdateSeq { get; set; }


    }
}
