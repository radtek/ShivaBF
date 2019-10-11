namespace SHF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setup : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BankMasters", newName: "Tbl_BankMaster");
            CreateTable(
                "dbo.Tbl_CategoriesMaster",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        CategoryName = c.String(),
                        DisplayIndex = c.Int(nullable: false),
                        DisplayOnHome = c.Boolean(),
                        IsActive = c.Boolean(),
                        TotalViews = c.Int(nullable: false),
                        Url = c.String(),
                        Metadata = c.String(),
                        Keyword = c.String(),
                        MetaDescription = c.String(),
                        Created_By = c.String(),
                        Created_On = c.DateTime(),
                        Modified_By = c.String(),
                        Modified_On = c.DateTime(),
                        Is_Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tbl_FAQMaster",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        IsActive = c.Boolean(),
                        Url = c.String(),
                        Metadata = c.String(),
                        Keyword = c.String(),
                        MetaDescription = c.String(),
                        Created_By = c.String(),
                        Created_On = c.DateTime(),
                        Modified_By = c.String(),
                        Modified_On = c.DateTime(),
                        Is_Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tbl_PriceFeaturesMapping",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Service_Id = c.Long(),
                        S1S6PM_Id = c.Long(),
                        PriceFeaturesMaster_Id = c.Long(),
                        DisplayIndex = c.Int(nullable: false),
                        IsActive = c.Boolean(),
                        TotalViews = c.Int(nullable: false),
                        Url = c.String(),
                        Metadata = c.String(),
                        Keyword = c.String(),
                        MetaDescription = c.String(),
                        Created_By = c.String(),
                        Created_On = c.DateTime(),
                        Modified_By = c.String(),
                        Modified_On = c.DateTime(),
                        Is_Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tbl_PriceFeaturesMaster", t => t.PriceFeaturesMaster_Id)
                .ForeignKey("dbo.Tbl_Services1Master", t => t.Service_Id)
                .ForeignKey("dbo.Tbl_Services1Section6PriceMaster", t => t.S1S6PM_Id)
                .Index(t => t.Service_Id)
                .Index(t => t.S1S6PM_Id)
                .Index(t => t.PriceFeaturesMaster_Id);
            
            CreateTable(
                "dbo.Tbl_PriceFeaturesMaster",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Description = c.String(),
                        IsActive = c.Boolean(),
                        Url = c.String(),
                        Metadata = c.String(),
                        Keyword = c.String(),
                        MetaDescription = c.String(),
                        Created_By = c.String(),
                        Created_On = c.DateTime(),
                        Modified_By = c.String(),
                        Modified_On = c.DateTime(),
                        Is_Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tbl_Services1Master",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Cat_Id = c.Long(),
                        SubCat_Id = c.Long(),
                        SubSubCat_Id = c.Long(),
                        SubSubCategoryName = c.String(),
                        BannerImagePath = c.String(),
                        BannerOnHeading = c.String(),
                        BannerHeadingDescription = c.String(),
                        BannerAncharTagTitle = c.String(),
                        BannerAncharTagUrl = c.String(),
                        Section1AfterBannerHeading = c.String(),
                        Section1AfterBannerDescription = c.String(),
                        Section1AfterBannerImagePath = c.String(),
                        Section1AfterBannerImageOnDescription = c.String(),
                        Section2Heading = c.String(),
                        Section2Description = c.String(),
                        Section3Heading = c.String(),
                        Section3Description = c.String(),
                        Section3TextboxMaskedText = c.String(),
                        Section4Heading = c.String(),
                        Section5Heading = c.String(),
                        Section6Heading = c.String(),
                        Section6Description = c.String(),
                        Section7Description = c.String(),
                        Section8Description = c.String(),
                        Section9Heading = c.String(),
                        Section9Description = c.String(),
                        Section10MappingBankFlag = c.Boolean(nullable: false),
                        DisplayIndex = c.Int(nullable: false),
                        DisplayOnHome = c.Boolean(),
                        IsActive = c.Boolean(),
                        TotalViews = c.Int(nullable: false),
                        Url = c.String(),
                        Metadata = c.String(),
                        Keyword = c.String(),
                        MetaDescription = c.String(),
                        Created_By = c.String(),
                        Created_On = c.DateTime(),
                        Modified_By = c.String(),
                        Modified_On = c.DateTime(),
                        Is_Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tbl_CategoriesMaster", t => t.Cat_Id)
                .ForeignKey("dbo.Tbl_SubCategoriesMaster", t => t.SubCat_Id)
                .ForeignKey("dbo.Tbl_SubSubCategoriesMaster", t => t.SubSubCat_Id)
                .Index(t => t.Cat_Id)
                .Index(t => t.SubCat_Id)
                .Index(t => t.SubSubCat_Id);
            
            CreateTable(
                "dbo.Tbl_SubCategoriesMaster",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Cat_Id = c.Long(),
                        SubCategoryName = c.String(),
                        DisplayIndex = c.Int(nullable: false),
                        DisplayOnHome = c.Boolean(),
                        IsActive = c.Boolean(),
                        TotalViews = c.Int(nullable: false),
                        Url = c.String(),
                        Metadata = c.String(),
                        Keyword = c.String(),
                        MetaDescription = c.String(),
                        Created_By = c.String(),
                        Created_On = c.DateTime(),
                        Modified_By = c.String(),
                        Modified_On = c.DateTime(),
                        Is_Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tbl_CategoriesMaster", t => t.Cat_Id)
                .Index(t => t.Cat_Id);
            
            CreateTable(
                "dbo.Tbl_SubSubCategoriesMaster",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Cat_Id = c.Long(),
                        SubCat_Id = c.Long(),
                        SubSubCategoryName = c.String(),
                        DisplayIndex = c.Int(nullable: false),
                        DisplayOnHome = c.Boolean(),
                        IsActive = c.Boolean(),
                        ServiceType = c.String(),
                        TotalViews = c.Int(nullable: false),
                        Url = c.String(),
                        Metadata = c.String(),
                        Keyword = c.String(),
                        MetaDescription = c.String(),
                        Created_By = c.String(),
                        Created_On = c.DateTime(),
                        Modified_By = c.String(),
                        Modified_On = c.DateTime(),
                        Is_Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tbl_CategoriesMaster", t => t.Cat_Id)
                .ForeignKey("dbo.Tbl_SubCategoriesMaster", t => t.SubCat_Id)
                .Index(t => t.Cat_Id)
                .Index(t => t.SubCat_Id);
            
            CreateTable(
                "dbo.Tbl_Services1Section6PriceMaster",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Service_Id = c.Long(),
                        State_Id = c.Long(),
                        HeadingText = c.String(),
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
                        Created_By = c.String(),
                        Created_On = c.DateTime(),
                        Modified_By = c.String(),
                        Modified_On = c.DateTime(),
                        Is_Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tbl_Services1Master", t => t.Service_Id)
                .ForeignKey("dbo.Tbl_StateMaster", t => t.State_Id)
                .Index(t => t.Service_Id)
                .Index(t => t.State_Id);
            
            CreateTable(
                "dbo.Tbl_StateMaster",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        StateFullName = c.String(),
                        StateShortName = c.String(),
                        IsActive = c.Boolean(),
                        Url = c.String(),
                        Metadata = c.String(),
                        Keyword = c.String(),
                        MetaDescription = c.String(),
                        Created_By = c.String(),
                        Created_On = c.DateTime(),
                        Modified_By = c.String(),
                        Modified_On = c.DateTime(),
                        Is_Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tbl_Services1Section10BankMapping",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Service_Id = c.Long(),
                        BankMaster_Id = c.Long(),
                        DisplayIndex = c.Int(nullable: false),
                        IsActive = c.Boolean(),
                        TotalViews = c.Int(nullable: false),
                        Url = c.String(),
                        Metadata = c.String(),
                        Keyword = c.String(),
                        MetaDescription = c.String(),
                        Created_By = c.String(),
                        Created_On = c.DateTime(),
                        Modified_By = c.String(),
                        Modified_On = c.DateTime(),
                        Is_Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tbl_BankMaster", t => t.BankMaster_Id)
                .ForeignKey("dbo.Tbl_Services1Master", t => t.Service_Id)
                .Index(t => t.Service_Id)
                .Index(t => t.BankMaster_Id);
            
            CreateTable(
                "dbo.Tbl_Services1Section1Master",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Service_Id = c.Long(),
                        AncharTagTitle = c.String(),
                        AncharTagUrl = c.String(),
                        DisplayIndex = c.Int(nullable: false),
                        IsActive = c.Boolean(),
                        TotalViews = c.Int(nullable: false),
                        Url = c.String(),
                        Metadata = c.String(),
                        Keyword = c.String(),
                        MetaDescription = c.String(),
                        Created_By = c.String(),
                        Created_On = c.DateTime(),
                        Modified_By = c.String(),
                        Modified_On = c.DateTime(),
                        Is_Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tbl_Services1Master", t => t.Service_Id)
                .Index(t => t.Service_Id);
            
            CreateTable(
                "dbo.Tbl_Services1Section4Master",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Service_Id = c.Long(),
                        HeadingText = c.String(),
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
                        Created_By = c.String(),
                        Created_On = c.DateTime(),
                        Modified_By = c.String(),
                        Modified_On = c.DateTime(),
                        Is_Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tbl_Services1Master", t => t.Service_Id)
                .Index(t => t.Service_Id);
            
            CreateTable(
                "dbo.Tbl_Services1Section5Master",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Service_Id = c.Long(),
                        HeadingText = c.String(),
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
                        Created_By = c.String(),
                        Created_On = c.DateTime(),
                        Modified_By = c.String(),
                        Modified_On = c.DateTime(),
                        Is_Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tbl_Services1Master", t => t.Service_Id)
                .Index(t => t.Service_Id);
            
            AddColumn("dbo.Tbl_AspNetRoles_SubMenu", "Url", c => c.String());
            AddColumn("dbo.Tbl_AspNetRoles_SubMenu", "Metadata", c => c.String());
            AddColumn("dbo.Tbl_AspNetRoles_SubMenu", "Keyword", c => c.String());
            AddColumn("dbo.Tbl_AspNetRoles_SubMenu", "MetaDescription", c => c.String());
            AddColumn("dbo.Tbl_SubMenu", "Metadata", c => c.String());
            AddColumn("dbo.Tbl_SubMenu", "Keyword", c => c.String());
            AddColumn("dbo.Tbl_SubMenu", "MetaDescription", c => c.String());
            AddColumn("dbo.Tbl_Tenant", "Url", c => c.String());
            AddColumn("dbo.Tbl_Tenant", "Metadata", c => c.String());
            AddColumn("dbo.Tbl_Tenant", "Keyword", c => c.String());
            AddColumn("dbo.Tbl_Tenant", "MetaDescription", c => c.String());
            AddColumn("dbo.Tbl_Code", "Url", c => c.String());
            AddColumn("dbo.Tbl_Code", "Metadata", c => c.String());
            AddColumn("dbo.Tbl_Code", "Keyword", c => c.String());
            AddColumn("dbo.Tbl_Code", "MetaDescription", c => c.String());
            AddColumn("dbo.Tbl_CodeValue", "Url", c => c.String());
            AddColumn("dbo.Tbl_CodeValue", "Metadata", c => c.String());
            AddColumn("dbo.Tbl_CodeValue", "Keyword", c => c.String());
            AddColumn("dbo.Tbl_CodeValue", "MetaDescription", c => c.String());
            AddColumn("dbo.ExceptionLog", "Metadata", c => c.String());
            AddColumn("dbo.ExceptionLog", "Keyword", c => c.String());
            AddColumn("dbo.ExceptionLog", "MetaDescription", c => c.String());
            AddColumn("dbo.Tbl_BankMaster", "Url", c => c.String());
            AddColumn("dbo.Tbl_BankMaster", "Metadata", c => c.String());
            AddColumn("dbo.Tbl_BankMaster", "Keyword", c => c.String());
            AddColumn("dbo.Tbl_BankMaster", "MetaDescription", c => c.String());
            AddColumn("dbo.Tbl_Message", "Url", c => c.String());
            AddColumn("dbo.Tbl_Message", "Metadata", c => c.String());
            AddColumn("dbo.Tbl_Message", "Keyword", c => c.String());
            AddColumn("dbo.Tbl_Message", "MetaDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tbl_Services1Section5Master", "Service_Id", "dbo.Tbl_Services1Master");
            DropForeignKey("dbo.Tbl_Services1Section4Master", "Service_Id", "dbo.Tbl_Services1Master");
            DropForeignKey("dbo.Tbl_Services1Section1Master", "Service_Id", "dbo.Tbl_Services1Master");
            DropForeignKey("dbo.Tbl_Services1Section10BankMapping", "Service_Id", "dbo.Tbl_Services1Master");
            DropForeignKey("dbo.Tbl_Services1Section10BankMapping", "BankMaster_Id", "dbo.Tbl_BankMaster");
            DropForeignKey("dbo.Tbl_PriceFeaturesMapping", "S1S6PM_Id", "dbo.Tbl_Services1Section6PriceMaster");
            DropForeignKey("dbo.Tbl_Services1Section6PriceMaster", "State_Id", "dbo.Tbl_StateMaster");
            DropForeignKey("dbo.Tbl_Services1Section6PriceMaster", "Service_Id", "dbo.Tbl_Services1Master");
            DropForeignKey("dbo.Tbl_PriceFeaturesMapping", "Service_Id", "dbo.Tbl_Services1Master");
            DropForeignKey("dbo.Tbl_Services1Master", "SubSubCat_Id", "dbo.Tbl_SubSubCategoriesMaster");
            DropForeignKey("dbo.Tbl_SubSubCategoriesMaster", "SubCat_Id", "dbo.Tbl_SubCategoriesMaster");
            DropForeignKey("dbo.Tbl_SubSubCategoriesMaster", "Cat_Id", "dbo.Tbl_CategoriesMaster");
            DropForeignKey("dbo.Tbl_Services1Master", "SubCat_Id", "dbo.Tbl_SubCategoriesMaster");
            DropForeignKey("dbo.Tbl_SubCategoriesMaster", "Cat_Id", "dbo.Tbl_CategoriesMaster");
            DropForeignKey("dbo.Tbl_Services1Master", "Cat_Id", "dbo.Tbl_CategoriesMaster");
            DropForeignKey("dbo.Tbl_PriceFeaturesMapping", "PriceFeaturesMaster_Id", "dbo.Tbl_PriceFeaturesMaster");
            DropIndex("dbo.Tbl_Services1Section5Master", new[] { "Service_Id" });
            DropIndex("dbo.Tbl_Services1Section4Master", new[] { "Service_Id" });
            DropIndex("dbo.Tbl_Services1Section1Master", new[] { "Service_Id" });
            DropIndex("dbo.Tbl_Services1Section10BankMapping", new[] { "BankMaster_Id" });
            DropIndex("dbo.Tbl_Services1Section10BankMapping", new[] { "Service_Id" });
            DropIndex("dbo.Tbl_Services1Section6PriceMaster", new[] { "State_Id" });
            DropIndex("dbo.Tbl_Services1Section6PriceMaster", new[] { "Service_Id" });
            DropIndex("dbo.Tbl_SubSubCategoriesMaster", new[] { "SubCat_Id" });
            DropIndex("dbo.Tbl_SubSubCategoriesMaster", new[] { "Cat_Id" });
            DropIndex("dbo.Tbl_SubCategoriesMaster", new[] { "Cat_Id" });
            DropIndex("dbo.Tbl_Services1Master", new[] { "SubSubCat_Id" });
            DropIndex("dbo.Tbl_Services1Master", new[] { "SubCat_Id" });
            DropIndex("dbo.Tbl_Services1Master", new[] { "Cat_Id" });
            DropIndex("dbo.Tbl_PriceFeaturesMapping", new[] { "PriceFeaturesMaster_Id" });
            DropIndex("dbo.Tbl_PriceFeaturesMapping", new[] { "S1S6PM_Id" });
            DropIndex("dbo.Tbl_PriceFeaturesMapping", new[] { "Service_Id" });
            DropColumn("dbo.Tbl_Message", "MetaDescription");
            DropColumn("dbo.Tbl_Message", "Keyword");
            DropColumn("dbo.Tbl_Message", "Metadata");
            DropColumn("dbo.Tbl_Message", "Url");
            DropColumn("dbo.Tbl_BankMaster", "MetaDescription");
            DropColumn("dbo.Tbl_BankMaster", "Keyword");
            DropColumn("dbo.Tbl_BankMaster", "Metadata");
            DropColumn("dbo.Tbl_BankMaster", "Url");
            DropColumn("dbo.ExceptionLog", "MetaDescription");
            DropColumn("dbo.ExceptionLog", "Keyword");
            DropColumn("dbo.ExceptionLog", "Metadata");
            DropColumn("dbo.Tbl_CodeValue", "MetaDescription");
            DropColumn("dbo.Tbl_CodeValue", "Keyword");
            DropColumn("dbo.Tbl_CodeValue", "Metadata");
            DropColumn("dbo.Tbl_CodeValue", "Url");
            DropColumn("dbo.Tbl_Code", "MetaDescription");
            DropColumn("dbo.Tbl_Code", "Keyword");
            DropColumn("dbo.Tbl_Code", "Metadata");
            DropColumn("dbo.Tbl_Code", "Url");
            DropColumn("dbo.Tbl_Tenant", "MetaDescription");
            DropColumn("dbo.Tbl_Tenant", "Keyword");
            DropColumn("dbo.Tbl_Tenant", "Metadata");
            DropColumn("dbo.Tbl_Tenant", "Url");
            DropColumn("dbo.Tbl_SubMenu", "MetaDescription");
            DropColumn("dbo.Tbl_SubMenu", "Keyword");
            DropColumn("dbo.Tbl_SubMenu", "Metadata");
            DropColumn("dbo.Tbl_AspNetRoles_SubMenu", "MetaDescription");
            DropColumn("dbo.Tbl_AspNetRoles_SubMenu", "Keyword");
            DropColumn("dbo.Tbl_AspNetRoles_SubMenu", "Metadata");
            DropColumn("dbo.Tbl_AspNetRoles_SubMenu", "Url");
            DropTable("dbo.Tbl_Services1Section5Master");
            DropTable("dbo.Tbl_Services1Section4Master");
            DropTable("dbo.Tbl_Services1Section1Master");
            DropTable("dbo.Tbl_Services1Section10BankMapping");
            DropTable("dbo.Tbl_StateMaster");
            DropTable("dbo.Tbl_Services1Section6PriceMaster");
            DropTable("dbo.Tbl_SubSubCategoriesMaster");
            DropTable("dbo.Tbl_SubCategoriesMaster");
            DropTable("dbo.Tbl_Services1Master");
            DropTable("dbo.Tbl_PriceFeaturesMaster");
            DropTable("dbo.Tbl_PriceFeaturesMapping");
            DropTable("dbo.Tbl_FAQMaster");
            DropTable("dbo.Tbl_CategoriesMaster");
            RenameTable(name: "dbo.Tbl_BankMaster", newName: "BankMasters");
        }
    }
}
