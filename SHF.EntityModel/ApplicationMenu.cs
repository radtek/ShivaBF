using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.EntityModel
{
    [Table("Tbl_Application_Menu", Schema = "dbo")]
    public class ApplicationMenu : BaseEntity
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column("Id", Order = 1)]
        public virtual long ID { get; set; }

        [Column("Name_Or_Title")]
        public System.String NameOrTitle { get; set; }

        [Column("Url")]
        public System.String Url { get; set; }

        public System.String MyProperty { get; set; }


    }
}
