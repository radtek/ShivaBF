﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SHF.EntityModel
{
    [Table("Tbl_FAQMaster", Schema = "dbo")]
    public class FAQMaster : BaseEntity
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public virtual long ID { get; set; }
        [Column("Title")]
        public System.String Title { get; set; }
        [Column("Description")]
        public System.String Description { get; set; }
        [Column("IsActive")]
        public System.Boolean? IsActive { get; set; }

    }
}