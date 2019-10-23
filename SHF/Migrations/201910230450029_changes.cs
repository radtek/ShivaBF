namespace SHF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tbl_Services8Section6Master", "Service_Id", "dbo.Tbl_Services7Master");
            AddForeignKey("dbo.Tbl_Services8Section6Master", "Service_Id", "dbo.Tbl_Services8Master", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tbl_Services8Section6Master", "Service_Id", "dbo.Tbl_Services8Master");
            AddForeignKey("dbo.Tbl_Services8Section6Master", "Service_Id", "dbo.Tbl_Services7Master", "ID");
        }
    }
}
