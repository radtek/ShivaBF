namespace SHF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tbl_PageViewsReport",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Url = c.String(),
                        Count = c.Long(nullable: false),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tbl_PageViewsReport", "Tenant_ID", "dbo.Tbl_Tenant");
            DropIndex("dbo.Tbl_PageViewsReport", new[] { "Tenant_ID" });
            DropTable("dbo.Tbl_PageViewsReport");
        }
    }
}
