namespace SHF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Setup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tbl_Services7Section4",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Service_Id = c.Long(),
                        SubSubCat_Id = c.Long(),
                        Heading = c.String(),
                        ShortDescription = c.String(),
                        AncharTagTitle = c.String(),
                        AncharTagUrl = c.String(),
                        DisplayIndex = c.Int(nullable: false),
                        IsActive = c.Boolean(),
                        TotalViews = c.Int(nullable: false),
                        Url = c.String(),
                        Metadata = c.String(),
                        Keyword = c.String(),
                        MetaDescription = c.String(),
                        Tenant_ID = c.Long(),
                        Created_By = c.String(),
                        Created_On = c.DateTime(),
                        Modified_By = c.String(),
                        Modified_On = c.DateTime(),
                        Is_Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tbl_Services7Master", t => t.Service_Id)
                .ForeignKey("dbo.Tbl_SubSubCategoriesMaster", t => t.SubSubCat_Id)
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Service_Id)
                .Index(t => t.SubSubCat_Id)
                .Index(t => t.Tenant_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tbl_Services7Section4", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_Services7Section4", "SubSubCat_Id", "dbo.Tbl_SubSubCategoriesMaster");
            DropForeignKey("dbo.Tbl_Services7Section4", "Service_Id", "dbo.Tbl_Services7Master");
            DropIndex("dbo.Tbl_Services7Section4", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_Services7Section4", new[] { "SubSubCat_Id" });
            DropIndex("dbo.Tbl_Services7Section4", new[] { "Service_Id" });
            DropTable("dbo.Tbl_Services7Section4");
        }
    }
}
