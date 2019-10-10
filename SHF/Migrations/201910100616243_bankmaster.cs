namespace SHF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bankmaster : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankMasters",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        IconPath = c.String(),
                        Description = c.String(),
                        IsActive = c.Boolean(),
                        Created_By = c.String(),
                        Created_On = c.DateTime(),
                        Modified_By = c.String(),
                        Modified_On = c.DateTime(),
                        Is_Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BankMasters");
        }
    }
}
