namespace SHF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_BlogMaster", "TotalViews", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_BlogMaster", "TotalViews");
        }
    }
}
