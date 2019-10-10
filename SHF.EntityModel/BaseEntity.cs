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
    public class BaseEntity
    {
        #region [Fields]
        private readonly System.DateTime _dateTime = System.DateTime.Now;
        #endregion
        [Column("Url")]
        public string Url { get; set; }

        [Column("Metadata")]
        public string Metadata { get; set; }

        [Column("Keyword")]
        public string Keyword { get; set; }

        [Column("MetaDescription")]
        public string MetaDescription { get; set; }
        [Column("Created_By")]
        public string CreatedBy { get; set; }

        [Column("Created_On")]
        public DateTime? CreatedOn { get; set; }

        [Column("Modified_By")]
        public string UpdatedBy { get; set; }

        [Column("Modified_On")]
        public DateTime? UpdatedOn { get; set; }

        [Column("Is_Deleted")]
        public bool IsDeleted { get; set; }


    }
}
