namespace SHF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_HomePageSection2", "PageTitle", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_HomePageSection2", "PageTitle");
        }
    }
}
