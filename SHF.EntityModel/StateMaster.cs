﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.EntityModel
{
    [Table("Tbl_StateMaster", Schema = "dbo")]
    public class StateMaster : BaseEntity
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public virtual long ID { get; set; }
        [Column("StateFullName")]
        public System.String StateFullName { get; set; }
        [Column("StateShortName")]
        public System.String StateShortName { get; set; }
        [Column("IsActive")]
        public System.Boolean? IsActive { get; set; }
        [Column("Url")]
        public string Url { get; set; }

        [Column("Metadata")]
        public string Metadata { get; set; }

        [Column("Keyword")]
        public string Keyword { get; set; }

        [Column("MetaDescription")]
        public string MetaDescription { get; set; }

    }
}