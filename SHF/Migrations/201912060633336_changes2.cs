namespace SHF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_CustomerServiceOrder", "FullStreetAddress", c => c.String());
            AddColumn("dbo.Tbl_CustomerServiceOrder", "Plan_Id", c => c.Long());
            AddColumn("dbo.Tbl_CustomerServiceOrder", "PlanName", c => c.String());
            DropColumn("dbo.Tbl_CustomerServiceOrder", "SreetAddress");
            DropColumn("dbo.Tbl_CustomerServiceOrder", "City");
            DropColumn("dbo.Tbl_CustomerServiceOrder", "State");
            DropColumn("dbo.Tbl_CustomerServiceOrder", "Country");
            DropColumn("dbo.Tbl_CustomerServiceOrder", "DefaultAddressID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tbl_CustomerServiceOrder", "DefaultAddressID", c => c.Int(nullable: false));
            AddColumn("dbo.Tbl_CustomerServiceOrder", "Country", c => c.String());
            AddColumn("dbo.Tbl_CustomerServiceOrder", "State", c => c.String());
            AddColumn("dbo.Tbl_CustomerServiceOrder", "City", c => c.String());
            AddColumn("dbo.Tbl_CustomerServiceOrder", "SreetAddress", c => c.String());
            DropColumn("dbo.Tbl_CustomerServiceOrder", "PlanName");
            DropColumn("dbo.Tbl_CustomerServiceOrder", "Plan_Id");
            DropColumn("dbo.Tbl_CustomerServiceOrder", "FullStreetAddress");
        }
    }
}
