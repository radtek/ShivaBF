using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.EntityModel
{
    [Table("Tbl_Services4Master", Schema = "dbo")]
    public class Services4Master : BaseEntity
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
        [ForeignKey("SubSubCat_Id")]
        public virtual SubSubCategoriesMaster SubSubCategoriesMaster { get; set; }
        public System.Int64? SubSubCat_Id { get; set; }
        [Column("SubSubCategoryName")]
        public System.String SubSubCategoryName { get; set; }
        [Column("BannerImagePath")]
        public System.String BannerImagePath { get; set; }
        [Column("BannerOnHeading")]
        public System.String BannerOnHeading { get; set; }
        [Column("BannerHeadingDescription")]
        public System.String BannerHeadingDescription { get; set; }
        [Column("Section1Description")]
        public System.String Section1Description { get; set; }
        [Column("Section2PriceingHeading")]
        public System.String Section2PriceingHeading { get; set; }
        [Column("Section2PriceingDescription")]
        public System.String Section2PriceingDescription { get; set; }
        [Column("Section3PriceingHeading")]
        public System.String Section3PriceingHeading { get; set; }
        [Column("Section3PriceingDescription")]
        public System.String Section3PriceingDescription { get; set; }
        [Column("Section4PriceingHeading")]
        public System.String Section4PriceingHeading { get; set; }
        [Column("Section4PriceingDescription")]
        public System.String Section4PriceingDescription { get; set; }
        [Column("Section5PriceingHeading")]
        public System.String Section5PriceingHeading { get; set; }
        [Column("Section6PriceingHeading")]
        public System.String Section6PriceingHeading { get; set; }
        [Column("Section7PriceingHeading")]
        public System.String Section7PriceingHeading { get; set; }
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
        [ForeignKey("Tenant_ID")]
        public virtual Tenant Tenant { get; set; }
        public System.Int64? Tenant_ID { get; set; }
    }
}