namespace SHF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chnagesn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_Services8Master", "Section2BannerPath", c => c.String());
            DropColumn("dbo.Tbl_Services8Master", "Section2BannerHeading");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tbl_Services8Master", "Section2BannerHeading", c => c.String());
            DropColumn("dbo.Tbl_Services8Master", "Section2BannerPath");
        }
    }
}
