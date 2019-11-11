namespace SHF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cha : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Tbl_Services4Section2Master", newName: "Tbl_Services4Section345Master");
            RenameTable(name: "dbo.Tbl_Services4Section2MasterChild", newName: "Tbl_Services4Section345MasterButtonsChild");
            RenameTable(name: "dbo.Tbl_Services4Section3", newName: "Tbl_Services4Section345MasterFeaturesDetails");
            RenameTable(name: "dbo.Tbl_Services4Section3DownloadMaster", newName: "Tbl_Services4Section678FieldMaster");
            RenameTable(name: "dbo.Tbl_Services4Section3Master", newName: "Tbl_Services4Section678FieldValues");
            DropForeignKey("dbo.Tbl_Services4Section3MasterChild", "S4S3M_id", "dbo.Tbl_Services4Section3Master");
            DropForeignKey("dbo.Tbl_Services4Section567FieldValues", "S4S567FM_Id", "dbo.Tbl_Services4Section567FieldMaster");
            DropIndex("dbo.Tbl_Services4Section3MasterChild", new[] { "Service_Id" });
            DropIndex("dbo.Tbl_Services4Section3MasterChild", new[] { "SubSubCat_Id" });
            DropIndex("dbo.Tbl_Services4Section3MasterChild", new[] { "S4S3M_id" });
            DropIndex("dbo.Tbl_Services4Section3MasterChild", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_Services4Section567FieldMaster", new[] { "Service_Id" });
            DropIndex("dbo.Tbl_Services4Section567FieldMaster", new[] { "SubSubCat_Id" });
            DropIndex("dbo.Tbl_Services4Section567FieldMaster", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_Services4Section567FieldValues", new[] { "Service_Id" });
            DropIndex("dbo.Tbl_Services4Section567FieldValues", new[] { "S4S567FM_Id" });
            DropIndex("dbo.Tbl_Services4Section567FieldValues", new[] { "SubSubCat_Id" });
            DropIndex("dbo.Tbl_Services4Section567FieldValues", new[] { "Tenant_ID" });
            RenameColumn(table: "dbo.Tbl_Services4Section345MasterButtonsChild", name: "S4S2M_id", newName: "S4S345M_id");
            RenameIndex(table: "dbo.Tbl_Services4Section345MasterButtonsChild", name: "IX_S4S2M_id", newName: "IX_S4S345M_id");
            AddColumn("dbo.Tbl_Services4Section345Master", "SectionType_ID", c => c.Long(nullable: false));
            AddColumn("dbo.Tbl_Services4Section345Master", "SectionTypeValue", c => c.String());
            AddColumn("dbo.Tbl_Services4Section345MasterFeaturesDetails", "S4S345M_id", c => c.Long());
            AddColumn("dbo.Tbl_Services4Section678FieldMaster", "FieldName", c => c.String());
            AddColumn("dbo.Tbl_Services4Section678FieldMaster", "SectionType", c => c.String());
            AddColumn("dbo.Tbl_Services4Section678FieldValues", "S4S678FM_Id", c => c.Long());
            AddColumn("dbo.Tbl_Services4Section678FieldValues", "RowNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Tbl_Services4Section678FieldValues", "DisplayText", c => c.String());
            AddColumn("dbo.Tbl_Services4Section678FieldValues", "DownloadFilePath", c => c.String());
            CreateIndex("dbo.Tbl_Services4Section345Master", "SectionType_ID");
            CreateIndex("dbo.Tbl_Services4Section345MasterFeaturesDetails", "S4S345M_id");
            CreateIndex("dbo.Tbl_Services4Section678FieldValues", "S4S678FM_Id");
            AddForeignKey("dbo.Tbl_Services4Section345Master", "SectionType_ID", "dbo.Tbl_Code", "ID", cascadeDelete: false);
            AddForeignKey("dbo.Tbl_Services4Section345MasterFeaturesDetails", "S4S345M_id", "dbo.Tbl_Services4Section345Master", "ID");
            AddForeignKey("dbo.Tbl_Services4Section678FieldValues", "S4S678FM_Id", "dbo.Tbl_Services4Section678FieldMaster", "ID");
            DropColumn("dbo.Tbl_Services4Section345Master", "Description");
            DropColumn("dbo.Tbl_Services4Section345MasterFeaturesDetails", "Heading");
            DropColumn("dbo.Tbl_Services4Section678FieldMaster", "AncharTagTitle");
            DropColumn("dbo.Tbl_Services4Section678FieldMaster", "AncharTagUrl");
            DropColumn("dbo.Tbl_Services4Section678FieldMaster", "DownloadFilePath");
            DropColumn("dbo.Tbl_Services4Section678FieldValues", "Heading");
            DropColumn("dbo.Tbl_Services4Section678FieldValues", "Description");
            DropTable("dbo.Tbl_Services4Section3MasterChild");
            DropTable("dbo.Tbl_Services4Section567FieldMaster");
            DropTable("dbo.Tbl_Services4Section567FieldValues");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Tbl_Services4Section567FieldValues",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Service_Id = c.Long(),
                        S4S567FM_Id = c.Long(),
                        SubSubCat_Id = c.Long(),
                        RowNumber = c.Int(nullable: false),
                        DisplayText = c.String(),
                        DownloadFilePath = c.String(),
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
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tbl_Services4Section567FieldMaster",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Service_Id = c.Long(),
                        SubSubCat_Id = c.Long(),
                        FieldName = c.String(),
                        SectionType = c.String(),
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
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tbl_Services4Section3MasterChild",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Service_Id = c.Long(),
                        SubSubCat_Id = c.Long(),
                        S4S3M_id = c.Long(),
                        FeatureDescription = c.String(),
                        Price = c.Long(nullable: false),
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
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Tbl_Services4Section678FieldValues", "Description", c => c.String());
            AddColumn("dbo.Tbl_Services4Section678FieldValues", "Heading", c => c.String());
            AddColumn("dbo.Tbl_Services4Section678FieldMaster", "DownloadFilePath", c => c.String());
            AddColumn("dbo.Tbl_Services4Section678FieldMaster", "AncharTagUrl", c => c.String());
            AddColumn("dbo.Tbl_Services4Section678FieldMaster", "AncharTagTitle", c => c.String());
            AddColumn("dbo.Tbl_Services4Section345MasterFeaturesDetails", "Heading", c => c.String());
            AddColumn("dbo.Tbl_Services4Section345Master", "Description", c => c.String());
            DropForeignKey("dbo.Tbl_Services4Section678FieldValues", "S4S678FM_Id", "dbo.Tbl_Services4Section678FieldMaster");
            DropForeignKey("dbo.Tbl_Services4Section345MasterFeaturesDetails", "S4S345M_id", "dbo.Tbl_Services4Section345Master");
            DropForeignKey("dbo.Tbl_Services4Section345Master", "SectionType_ID", "dbo.Tbl_Code");
            DropIndex("dbo.Tbl_Services4Section678FieldValues", new[] { "S4S678FM_Id" });
            DropIndex("dbo.Tbl_Services4Section345MasterFeaturesDetails", new[] { "S4S345M_id" });
            DropIndex("dbo.Tbl_Services4Section345Master", new[] { "SectionType_ID" });
            DropColumn("dbo.Tbl_Services4Section678FieldValues", "DownloadFilePath");
            DropColumn("dbo.Tbl_Services4Section678FieldValues", "DisplayText");
            DropColumn("dbo.Tbl_Services4Section678FieldValues", "RowNumber");
            DropColumn("dbo.Tbl_Services4Section678FieldValues", "S4S678FM_Id");
            DropColumn("dbo.Tbl_Services4Section678FieldMaster", "SectionType");
            DropColumn("dbo.Tbl_Services4Section678FieldMaster", "FieldName");
            DropColumn("dbo.Tbl_Services4Section345MasterFeaturesDetails", "S4S345M_id");
            DropColumn("dbo.Tbl_Services4Section345Master", "SectionTypeValue");
            DropColumn("dbo.Tbl_Services4Section345Master", "SectionType_ID");
            RenameIndex(table: "dbo.Tbl_Services4Section345MasterButtonsChild", name: "IX_S4S345M_id", newName: "IX_S4S2M_id");
            RenameColumn(table: "dbo.Tbl_Services4Section345MasterButtonsChild", name: "S4S345M_id", newName: "S4S2M_id");
            CreateIndex("dbo.Tbl_Services4Section567FieldValues", "Tenant_ID");
            CreateIndex("dbo.Tbl_Services4Section567FieldValues", "SubSubCat_Id");
            CreateIndex("dbo.Tbl_Services4Section567FieldValues", "S4S567FM_Id");
            CreateIndex("dbo.Tbl_Services4Section567FieldValues", "Service_Id");
            CreateIndex("dbo.Tbl_Services4Section567FieldMaster", "Tenant_ID");
            CreateIndex("dbo.Tbl_Services4Section567FieldMaster", "SubSubCat_Id");
            CreateIndex("dbo.Tbl_Services4Section567FieldMaster", "Service_Id");
            CreateIndex("dbo.Tbl_Services4Section3MasterChild", "Tenant_ID");
            CreateIndex("dbo.Tbl_Services4Section3MasterChild", "S4S3M_id");
            CreateIndex("dbo.Tbl_Services4Section3MasterChild", "SubSubCat_Id");
            CreateIndex("dbo.Tbl_Services4Section3MasterChild", "Service_Id");
            AddForeignKey("dbo.Tbl_Services4Section567FieldValues", "S4S567FM_Id", "dbo.Tbl_Services4Section567FieldMaster", "ID");
            AddForeignKey("dbo.Tbl_Services4Section3MasterChild", "S4S3M_id", "dbo.Tbl_Services4Section3Master", "ID");
            RenameTable(name: "dbo.Tbl_Services4Section678FieldValues", newName: "Tbl_Services4Section3Master");
            RenameTable(name: "dbo.Tbl_Services4Section678FieldMaster", newName: "Tbl_Services4Section3DownloadMaster");
            RenameTable(name: "dbo.Tbl_Services4Section345MasterFeaturesDetails", newName: "Tbl_Services4Section3");
            RenameTable(name: "dbo.Tbl_Services4Section345MasterButtonsChild", newName: "Tbl_Services4Section2MasterChild");
            RenameTable(name: "dbo.Tbl_Services4Section345Master", newName: "Tbl_Services4Section2Master");
        }
    }
}
