namespace SHF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setup1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_CategoriesMaster", "Tenant_ID", c => c.Long());
            AddColumn("dbo.Tbl_FAQMaster", "Tenant_ID", c => c.Long());
            AddColumn("dbo.Tbl_PriceFeaturesMapping", "Tenant_ID", c => c.Long());
            AddColumn("dbo.Tbl_PriceFeaturesMaster", "Tenant_ID", c => c.Long());
            AddColumn("dbo.Tbl_Services1Master", "Tenant_ID", c => c.Long());
            AddColumn("dbo.Tbl_SubCategoriesMaster", "Tenant_ID", c => c.Long());
            AddColumn("dbo.Tbl_SubSubCategoriesMaster", "Tenant_ID", c => c.Long());
            AddColumn("dbo.Tbl_Services1Section6PriceMaster", "Tenant_ID", c => c.Long());
            AddColumn("dbo.Tbl_StateMaster", "Tenant_ID", c => c.Long());
            AddColumn("dbo.Tbl_Services1Section10BankMapping", "Tenant_ID", c => c.Long());
            AddColumn("dbo.Tbl_Services1Section1Master", "Tenant_ID", c => c.Long());
            AddColumn("dbo.Tbl_Services1Section4Master", "Tenant_ID", c => c.Long());
            AddColumn("dbo.Tbl_Services1Section5Master", "Tenant_ID", c => c.Long());
            CreateIndex("dbo.Tbl_CategoriesMaster", "Tenant_ID");
            CreateIndex("dbo.Tbl_FAQMaster", "Tenant_ID");
            CreateIndex("dbo.Tbl_PriceFeaturesMapping", "Tenant_ID");
            CreateIndex("dbo.Tbl_PriceFeaturesMaster", "Tenant_ID");
            CreateIndex("dbo.Tbl_Services1Master", "Tenant_ID");
            CreateIndex("dbo.Tbl_SubCategoriesMaster", "Tenant_ID");
            CreateIndex("dbo.Tbl_SubSubCategoriesMaster", "Tenant_ID");
            CreateIndex("dbo.Tbl_Services1Section6PriceMaster", "Tenant_ID");
            CreateIndex("dbo.Tbl_StateMaster", "Tenant_ID");
            CreateIndex("dbo.Tbl_Services1Section10BankMapping", "Tenant_ID");
            CreateIndex("dbo.Tbl_Services1Section1Master", "Tenant_ID");
            CreateIndex("dbo.Tbl_Services1Section4Master", "Tenant_ID");
            CreateIndex("dbo.Tbl_Services1Section5Master", "Tenant_ID");
            AddForeignKey("dbo.Tbl_CategoriesMaster", "Tenant_ID", "dbo.Tbl_Tenant", "ID");
            AddForeignKey("dbo.Tbl_FAQMaster", "Tenant_ID", "dbo.Tbl_Tenant", "ID");
            AddForeignKey("dbo.Tbl_PriceFeaturesMaster", "Tenant_ID", "dbo.Tbl_Tenant", "ID");
            AddForeignKey("dbo.Tbl_SubCategoriesMaster", "Tenant_ID", "dbo.Tbl_Tenant", "ID");
            AddForeignKey("dbo.Tbl_SubSubCategoriesMaster", "Tenant_ID", "dbo.Tbl_Tenant", "ID");
            AddForeignKey("dbo.Tbl_Services1Master", "Tenant_ID", "dbo.Tbl_Tenant", "ID");
            AddForeignKey("dbo.Tbl_StateMaster", "Tenant_ID", "dbo.Tbl_Tenant", "ID");
            AddForeignKey("dbo.Tbl_Services1Section6PriceMaster", "Tenant_ID", "dbo.Tbl_Tenant", "ID");
            AddForeignKey("dbo.Tbl_PriceFeaturesMapping", "Tenant_ID", "dbo.Tbl_Tenant", "ID");
            AddForeignKey("dbo.Tbl_Services1Section10BankMapping", "Tenant_ID", "dbo.Tbl_Tenant", "ID");
            AddForeignKey("dbo.Tbl_Services1Section1Master", "Tenant_ID", "dbo.Tbl_Tenant", "ID");
            AddForeignKey("dbo.Tbl_Services1Section4Master", "Tenant_ID", "dbo.Tbl_Tenant", "ID");
            AddForeignKey("dbo.Tbl_Services1Section5Master", "Tenant_ID", "dbo.Tbl_Tenant", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tbl_Services1Section5Master", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_Services1Section4Master", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_Services1Section1Master", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_Services1Section10BankMapping", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_PriceFeaturesMapping", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_Services1Section6PriceMaster", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_StateMaster", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_Services1Master", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_SubSubCategoriesMaster", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_SubCategoriesMaster", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_PriceFeaturesMaster", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_FAQMaster", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_CategoriesMaster", "Tenant_ID", "dbo.Tbl_Tenant");
            DropIndex("dbo.Tbl_Services1Section5Master", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_Services1Section4Master", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_Services1Section1Master", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_Services1Section10BankMapping", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_StateMaster", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_Services1Section6PriceMaster", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_SubSubCategoriesMaster", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_SubCategoriesMaster", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_Services1Master", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_PriceFeaturesMaster", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_PriceFeaturesMapping", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_FAQMaster", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_CategoriesMaster", new[] { "Tenant_ID" });
            DropColumn("dbo.Tbl_Services1Section5Master", "Tenant_ID");
            DropColumn("dbo.Tbl_Services1Section4Master", "Tenant_ID");
            DropColumn("dbo.Tbl_Services1Section1Master", "Tenant_ID");
            DropColumn("dbo.Tbl_Services1Section10BankMapping", "Tenant_ID");
            DropColumn("dbo.Tbl_StateMaster", "Tenant_ID");
            DropColumn("dbo.Tbl_Services1Section6PriceMaster", "Tenant_ID");
            DropColumn("dbo.Tbl_SubSubCategoriesMaster", "Tenant_ID");
            DropColumn("dbo.Tbl_SubCategoriesMaster", "Tenant_ID");
            DropColumn("dbo.Tbl_Services1Master", "Tenant_ID");
            DropColumn("dbo.Tbl_PriceFeaturesMaster", "Tenant_ID");
            DropColumn("dbo.Tbl_PriceFeaturesMapping", "Tenant_ID");
            DropColumn("dbo.Tbl_FAQMaster", "Tenant_ID");
            DropColumn("dbo.Tbl_CategoriesMaster", "Tenant_ID");
        }
    }
}
