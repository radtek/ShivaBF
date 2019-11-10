namespace SHF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tbl_Services7Section6PriceMaster", "State_Id", "dbo.Tbl_StateMaster");
            DropIndex("dbo.Tbl_Services7Section6PriceMaster", new[] { "State_Id" });
            DropColumn("dbo.Tbl_Services7Section6PriceMaster", "State_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tbl_Services7Section6PriceMaster", "State_Id", c => c.Long());
            CreateIndex("dbo.Tbl_Services7Section6PriceMaster", "State_Id");
            AddForeignKey("dbo.Tbl_Services7Section6PriceMaster", "State_Id", "dbo.Tbl_StateMaster", "ID");
        }
    }
}
