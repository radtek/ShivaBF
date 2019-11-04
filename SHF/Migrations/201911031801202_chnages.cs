namespace SHF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chnages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_Services3Section4", "State_Id", c => c.Long());
            AddColumn("dbo.Tbl_Services3Section6PriceMaster", "Description", c => c.String());
            CreateIndex("dbo.Tbl_Services3Section4", "State_Id");
            AddForeignKey("dbo.Tbl_Services3Section4", "State_Id", "dbo.Tbl_StateMaster", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tbl_Services3Section4", "State_Id", "dbo.Tbl_StateMaster");
            DropIndex("dbo.Tbl_Services3Section4", new[] { "State_Id" });
            DropColumn("dbo.Tbl_Services3Section6PriceMaster", "Description");
            DropColumn("dbo.Tbl_Services3Section4", "State_Id");
        }
    }
}
