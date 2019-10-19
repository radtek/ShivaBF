namespace SHF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatefiled : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Tbl_SubSubCategoriesMaster", name: "ServiceType", newName: "ServiceTypeValue");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Tbl_SubSubCategoriesMaster", name: "ServiceTypeValue", newName: "ServiceType");
        }
    }
}
