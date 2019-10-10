using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.EntityModel
{
    [Table("Tbl_Services1Master", Schema = "dbo")]
    public class Services1Master : BaseEntity
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
        [Column("BannerAncharTagTitle")]
        public System.String BannerAncharTagTitle { get; set; }
        [Column("BannerAncharTagUrl")]
        public System.String BannerAncharTagUrl { get; set; }
        [Column("Section1AfterBannerHeading")]
        public System.String Section1AfterBannerHeading { get; set; }
        [Column("Section1AfterBannerDescription")]
        public System.String Section1AfterBannerDescription { get; set; }
        [Column("Section1AfterBannerImagePath")]
        public System.String Section1AfterBannerImagePath { get; set; }
        [Column("Section1AfterBannerImageOnDescription")]
        public System.String Section1AfterBannerImageOnDescription { get; set; }
        [Column("Section2Heading")]
        public System.String Section2Heading { get; set; }
        [Column("Section2Description")]
        public System.String Section2Description { get; set; }
        [Column("Section3Heading")]
        public System.String Section3Heading { get; set; }
        [Column("Section3Description")]
        public System.String Section3Description { get; set; }
        [Column("Section3TextboxMaskedText")]
        public System.String Section3TextboxMaskedText { get; set; }
        [Column("Section4Heading")]
        public System.String Section4Heading { get; set; }
        [Column("Section5Heading")]
        public System.String Section5Heading { get; set; }
        [Column("Section6Heading")]
        public System.String Section6Heading { get; set; }
        [Column("Section6Description")]
        public System.String Section6Description { get; set; }
        [Column("Section7Description")]
        public System.String Section7Description { get; set; }
        [Column("Section8Description")]
        public System.String Section8Description { get; set; }
        [Column("Section9Heading")]
        public System.String Section96Heading { get; set; }
        [Column("Section9Description")]
        public System.String Section9Description { get; set; }
        [Column("Section10MappingBankFlag")]
        public System.Boolean Section10MappingBankFlag { get; set; }
        [Column("DisplayIndex")]
        public System.Int32 DisplayIndex { get; set; }
        [Column("DisplayOnHome")]
        public System.Boolean? DisplayOnHome { get; set; }
        [Column("IsActive")]
        public System.Boolean? IsActive { get; set; }
        [Column("TotalViews")]
        public System.Int32 TotalViews { get; set; }
    }
}