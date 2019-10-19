namespace SHF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatefiled1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_Services1Section1Master", "SubSubCat_Id", c => c.Long());
            CreateIndex("dbo.Tbl_Services1Section1Master", "SubSubCat_Id");
            AddForeignKey("dbo.Tbl_Services1Section1Master", "SubSubCat_Id", "dbo.Tbl_SubSubCategoriesMaster", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tbl_Services1Section1Master", "SubSubCat_Id", "dbo.Tbl_SubSubCategoriesMaster");
            DropIndex("dbo.Tbl_Services1Section1Master", new[] { "SubSubCat_Id" });
            DropColumn("dbo.Tbl_Services1Section1Master", "SubSubCat_Id");
        }
    }
}
