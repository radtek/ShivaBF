namespace SHF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tbl_IPInfo",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Status = c.String(),
                        Country = c.String(),
                        CountryCode = c.String(),
                        Region = c.String(),
                        RegionName = c.String(),
                        City = c.String(),
                        Zip = c.String(),
                        Lat = c.String(),
                        Lon = c.String(),
                        TimeZone = c.String(),
                        ISP = c.String(),
                        ORG = c.String(),
                        AS = c.String(),
                        Query = c.String(),
                        Tenant_ID = c.Long(),
                        Created_By = c.String(),
                        Created_On = c.DateTime(),
                        Modified_By = c.String(),
                        Modified_On = c.DateTime(),
                        Is_Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Tenant_ID);
            
            AddColumn("dbo.Tbl_Services4Section567FieldValues", "Service_Id", c => c.Long());
            CreateIndex("dbo.Tbl_Services4Section567FieldValues", "Service_Id");
            AddForeignKey("dbo.Tbl_Services4Section567FieldValues", "Service_Id", "dbo.Tbl_Services4Master", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tbl_Services4Section567FieldValues", "Service_Id", "dbo.Tbl_Services4Master");
            DropForeignKey("dbo.Tbl_IPInfo", "Tenant_ID", "dbo.Tbl_Tenant");
            DropIndex("dbo.Tbl_Services4Section567FieldValues", new[] { "Service_Id" });
            DropIndex("dbo.Tbl_IPInfo", new[] { "Tenant_ID" });
            DropColumn("dbo.Tbl_Services4Section567FieldValues", "Service_Id");
            DropTable("dbo.Tbl_IPInfo");
        }
    }
}
