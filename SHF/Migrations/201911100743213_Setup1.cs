namespace SHF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Setup1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_Services7Section6PriceMaster", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_Services7Section6PriceMaster", "Description");
        }
    }
}
