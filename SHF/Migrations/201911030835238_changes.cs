namespace SHF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_Services2Section4Master", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_Services2Section4Master", "Description");
        }
    }
}
