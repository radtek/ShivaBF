namespace SHF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatefiled2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_Services1Section6PriceMaster", "SubSubCat_Id", c => c.Long());
            AddColumn("dbo.Tbl_Services1Section4Master", "SubSubCat_Id", c => c.Long());
            AddColumn("dbo.Tbl_Services1Section5Master", "SubSubCat_Id", c => c.Long());
            AddColumn("dbo.Tbl_Services1Section8FAQMapping", "SubSubCat_Id", c => c.Long());
            CreateIndex("dbo.Tbl_Services1Section6PriceMaster", "SubSubCat_Id");
            CreateIndex("dbo.Tbl_Services1Section4Master", "SubSubCat_Id");
            CreateIndex("dbo.Tbl_Services1Section5Master", "SubSubCat_Id");
            CreateIndex("dbo.Tbl_Services1Section8FAQMapping", "SubSubCat_Id");
            AddForeignKey("dbo.Tbl_Services1Section6PriceMaster", "SubSubCat_Id", "dbo.Tbl_SubSubCategoriesMaster", "ID");
            AddForeignKey("dbo.Tbl_Services1Section4Master", "SubSubCat_Id", "dbo.Tbl_SubSubCategoriesMaster", "ID");
            AddForeignKey("dbo.Tbl_Services1Section5Master", "SubSubCat_Id", "dbo.Tbl_SubSubCategoriesMaster", "ID");
            AddForeignKey("dbo.Tbl_Services1Section8FAQMapping", "SubSubCat_Id", "dbo.Tbl_SubSubCategoriesMaster", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tbl_Services1Section8FAQMapping", "SubSubCat_Id", "dbo.Tbl_SubSubCategoriesMaster");
            DropForeignKey("dbo.Tbl_Services1Section5Master", "SubSubCat_Id", "dbo.Tbl_SubSubCategoriesMaster");
            DropForeignKey("dbo.Tbl_Services1Section4Master", "SubSubCat_Id", "dbo.Tbl_SubSubCategoriesMaster");
            DropForeignKey("dbo.Tbl_Services1Section6PriceMaster", "SubSubCat_Id", "dbo.Tbl_SubSubCategoriesMaster");
            DropIndex("dbo.Tbl_Services1Section8FAQMapping", new[] { "SubSubCat_Id" });
            DropIndex("dbo.Tbl_Services1Section5Master", new[] { "SubSubCat_Id" });
            DropIndex("dbo.Tbl_Services1Section4Master", new[] { "SubSubCat_Id" });
            DropIndex("dbo.Tbl_Services1Section6PriceMaster", new[] { "SubSubCat_Id" });
            DropColumn("dbo.Tbl_Services1Section8FAQMapping", "SubSubCat_Id");
            DropColumn("dbo.Tbl_Services1Section5Master", "SubSubCat_Id");
            DropColumn("dbo.Tbl_Services1Section4Master", "SubSubCat_Id");
            DropColumn("dbo.Tbl_Services1Section6PriceMaster", "SubSubCat_Id");
        }
    }
}
