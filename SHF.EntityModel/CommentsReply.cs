﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.EntityModel
{
    [Table("Tbl_CommentsReply", Schema = "dbo")]
    public class CommentsReply : BaseEntity
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public virtual long ID { get; set; }
        [ForeignKey("Blog_Id")]
        public virtual BlogMaster BlogMaster { get; set; }
        public System.Int64? Blog_Id { get; set; }
        [ForeignKey("BCD_Id")]
        public virtual BlogCommentsDetails BlogCommentsDetails { get; set; }
        public System.Int64? BCD_Id { get; set; }
        [Column("Name")]
        public System.String Name { get; set; }
        [Column("EmailId")]
        public System.String EmailId { get; set; }
        [Column("Comment")]
        public System.String Comment { get; set; }
        [Column("DisplayIndex")]
        public System.Int32 DisplayIndex { get; set; }
        [Column("IsActive")]
        public System.Boolean? IsActive { get; set; }
        [Column("IsAdminApproved")]
        public System.Boolean? IsAdminApproved { get; set; }
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