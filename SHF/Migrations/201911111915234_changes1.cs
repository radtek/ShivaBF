namespace SHF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_Services4Section678FieldMaster", "SectionType_ID", c => c.Long(nullable: false));
            AddColumn("dbo.Tbl_Services4Section678FieldMaster", "SectionTypeValue", c => c.String());
            CreateIndex("dbo.Tbl_Services4Section678FieldMaster", "SectionType_ID");
            AddForeignKey("dbo.Tbl_Services4Section678FieldMaster", "SectionType_ID", "dbo.Tbl_Code", "ID", cascadeDelete: false);
            DropColumn("dbo.Tbl_Services4Section678FieldMaster", "SectionType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tbl_Services4Section678FieldMaster", "SectionType", c => c.String());
            DropForeignKey("dbo.Tbl_Services4Section678FieldMaster", "SectionType_ID", "dbo.Tbl_Code");
            DropIndex("dbo.Tbl_Services4Section678FieldMaster", new[] { "SectionType_ID" });
            DropColumn("dbo.Tbl_Services4Section678FieldMaster", "SectionTypeValue");
            DropColumn("dbo.Tbl_Services4Section678FieldMaster", "SectionType_ID");
        }
    }
}
