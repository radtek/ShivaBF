namespace SHF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_BlogMaster", "PageTitle", c => c.String());
            AddColumn("dbo.Tbl_Services1Master", "PageTitle", c => c.String());
            AddColumn("dbo.Tbl_Services2Master", "PageTitle", c => c.String());
            AddColumn("dbo.Tbl_Services3Master", "PageTitle", c => c.String());
            AddColumn("dbo.Tbl_Services4Master", "PageTitle", c => c.String());
            AddColumn("dbo.Tbl_Services5Master", "PageTitle", c => c.String());
            AddColumn("dbo.Tbl_Services6Master", "PageTitle", c => c.String());
            AddColumn("dbo.Tbl_Services7Master", "PageTitle", c => c.String());
            AddColumn("dbo.Tbl_Services8Master", "PageTitle", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_Services8Master", "PageTitle");
            DropColumn("dbo.Tbl_Services7Master", "PageTitle");
            DropColumn("dbo.Tbl_Services6Master", "PageTitle");
            DropColumn("dbo.Tbl_Services5Master", "PageTitle");
            DropColumn("dbo.Tbl_Services4Master", "PageTitle");
            DropColumn("dbo.Tbl_Services3Master", "PageTitle");
            DropColumn("dbo.Tbl_Services2Master", "PageTitle");
            DropColumn("dbo.Tbl_Services1Master", "PageTitle");
            DropColumn("dbo.Tbl_BlogMaster", "PageTitle");
        }
    }
}
