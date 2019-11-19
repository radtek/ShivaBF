namespace SHF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tbl_AspNetRoles_SubMenu",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        SubMenu_ID = c.Long(nullable: false),
                        AspNetRole_ID = c.Long(nullable: false),
                        HasAccess = c.Boolean(nullable: false),
                        IsActive = c.Boolean(),
                        UpdateSeq = c.Int(nullable: false),
                        Tenant_ID = c.Long(),
                        Created_By = c.String(),
                        Created_On = c.DateTime(),
                        Modified_By = c.String(),
                        Modified_On = c.DateTime(),
                        Is_Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.SubMenu_ID, t.AspNetRole_ID })
                .ForeignKey("dbo.Tbl_SubMenu", t => t.SubMenu_ID, cascadeDelete: false)
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.SubMenu_ID)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.Tbl_SubMenu",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                        IconClass = c.String(),
                        UseOnlyFor = c.String(),
                        IsActive = c.Boolean(),
                        UpdateSeq = c.Int(nullable: false),
                        OrderBy = c.Int(nullable: false),
                        ParrentMenu_ID = c.Long(),
                        Created_By = c.String(),
                        Created_On = c.DateTime(),
                        Modified_By = c.String(),
                        Modified_On = c.DateTime(),
                        Is_Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tbl_SubMenu", t => t.ParrentMenu_ID)
                .Index(t => t.ParrentMenu_ID);
            
            CreateTable(
                "dbo.Tbl_Tenant",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Storage_Directory = c.String(),
                        Billing_Address_Attention = c.String(),
                        Billing_Address_Street_1 = c.String(),
                        Billing_Address_Street_2 = c.String(),
                        BillingAddressCountry_ID = c.Long(nullable: false),
                        Billing_Address_Country_Value = c.String(),
                        BillingAddressState_ID = c.Long(nullable: false),
                        Billing_Address_State_Value = c.String(),
                        BillingAddressCityOrDistrict_ID = c.Long(nullable: false),
                        Billing_Address_CityOrDistrict_Value = c.String(),
                        Billing_Address_Zip_Code = c.String(),
                        Billing_Address_Phone = c.String(),
                        Billing_Address_Fax = c.String(),
                        Shipping_Address_Attention = c.String(),
                        Shipping_Address_Street_1 = c.String(),
                        Shipping_Address_Street_2 = c.String(),
                        ShippingAddressCountry_ID = c.Long(nullable: false),
                        Shipping_Address_Country_Value = c.String(),
                        ShippingAddressState_ID = c.Long(nullable: false),
                        Shipping_Address_State_Value = c.String(),
                        ShippingAddressCityOrDistrict_ID = c.Long(nullable: false),
                        Shipping_Address_CityOrDistrict_Value = c.String(),
                        Shipping_Address_Zip_Code = c.String(),
                        Shipping_Address_Phone = c.String(),
                        Shipping_Address_Fax = c.String(),
                        Contact_Person = c.String(),
                        Contact_Number = c.String(),
                        Email = c.String(),
                        GST = c.String(),
                        No_Of_Locations = c.Int(nullable: false),
                        No_Of_SHF_Items = c.Int(nullable: false),
                        Is_Active = c.Boolean(),
                        Update_Seq = c.Int(nullable: false),
                        Created_By = c.String(),
                        Created_On = c.DateTime(),
                        Modified_By = c.String(),
                        Modified_On = c.DateTime(),
                        Is_Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tbl_Code", t => t.BillingAddressCityOrDistrict_ID, cascadeDelete: false)
                .ForeignKey("dbo.Tbl_Code", t => t.BillingAddressCountry_ID, cascadeDelete: false)
                .ForeignKey("dbo.Tbl_Code", t => t.BillingAddressState_ID, cascadeDelete: false)
                .ForeignKey("dbo.Tbl_Code", t => t.ShippingAddressCityOrDistrict_ID, cascadeDelete: false)
                .ForeignKey("dbo.Tbl_Code", t => t.ShippingAddressCountry_ID, cascadeDelete: false)
                .ForeignKey("dbo.Tbl_Code", t => t.ShippingAddressState_ID, cascadeDelete: false)
                .Index(t => t.BillingAddressCountry_ID)
                .Index(t => t.BillingAddressState_ID)
                .Index(t => t.BillingAddressCityOrDistrict_ID)
                .Index(t => t.ShippingAddressCountry_ID)
                .Index(t => t.ShippingAddressState_ID)
                .Index(t => t.ShippingAddressCityOrDistrict_ID);
            
            CreateTable(
                "dbo.Tbl_Code",
                c => new
                    {
                        ID = c.Long(nullable: false),
                        Data_1_Caption = c.String(maxLength: 100),
                        Description = c.String(maxLength: 100),
                        Data_1_Type = c.String(maxLength: 4),
                        Data_2_Caption = c.String(maxLength: 100),
                        Data_2_Type = c.String(maxLength: 4),
                        Data_3_Caption = c.String(maxLength: 100),
                        Data_3_Type = c.String(maxLength: 4),
                        Comments = c.String(),
                        Is_Active = c.Boolean(),
                        Update_Seq = c.Int(nullable: false),
                        Created_By = c.String(),
                        Created_On = c.DateTime(),
                        Modified_By = c.String(),
                        Modified_On = c.DateTime(),
                        Is_Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tbl_CodeValue",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Code_ID = c.Long(nullable: false),
                        CodeValue = c.String(maxLength: 4),
                        Description = c.String(maxLength: 100),
                        Data_1_Type = c.String(maxLength: 4),
                        Data_2_Caption = c.String(maxLength: 100),
                        Data_2_Type = c.String(maxLength: 4),
                        Data_3_Caption = c.String(maxLength: 100),
                        Data_3_Type = c.String(maxLength: 4),
                        Comments = c.String(),
                        Is_Active = c.Boolean(),
                        Update_Seq = c.Int(nullable: false),
                        Created_By = c.String(),
                        Created_On = c.DateTime(),
                        Modified_By = c.String(),
                        Modified_On = c.DateTime(),
                        Is_Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tbl_Code", t => t.Code_ID, cascadeDelete: false)
                .Index(t => new { t.Code_ID, t.CodeValue }, unique: true, name: "IX_CodeVale_CodeIDAndValue");
            
            CreateTable(
                "dbo.ExceptionLog",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Message = c.String(),
                        Inner_Exception = c.String(),
                        Source = c.String(),
                        Stack_Trace = c.String(),
                        Target_Site = c.String(),
                        HResult = c.Int(nullable: false),
                        Help_Link = c.String(),
                        Controller_Name = c.String(),
                        Action_Name = c.String(),
                        Url = c.String(),
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
            
            CreateTable(
                "dbo.Tbl_BankMaster",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        IconPath = c.String(),
                        Description = c.String(),
                        IsActive = c.Boolean(),
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
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.Tbl_BannerMaster",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        BannerPath = c.String(),
                        AlternativeText = c.String(),
                        Title = c.String(),
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
            
            CreateTable(
                "dbo.Tbl_BlogBannerNavigationsDetails",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Blog_Id = c.Long(),
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
                .ForeignKey("dbo.Tbl_BlogMaster", t => t.Blog_Id)
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Blog_Id)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.Tbl_BlogMaster",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        BannerImagePath = c.String(),
                        BannerDescription1 = c.String(),
                        BannerDescription2 = c.String(),
                        BlogTitle = c.String(),
                        Section1ImagePath = c.String(),
                        Section2Heading = c.String(),
                        Section2Description = c.String(),
                        Section3Heading = c.String(),
                        Section3Description = c.String(),
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
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.Tbl_BlogCommentsDetails",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Blog_Id = c.Long(),
                        Name = c.String(),
                        EmailId = c.String(),
                        Comment = c.String(),
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
                .ForeignKey("dbo.Tbl_BlogMaster", t => t.Blog_Id)
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Blog_Id)
                .Index(t => t.Tenant_ID);
            
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
            
            CreateTable(
                "dbo.Tbl_CommentsReply",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Blog_Id = c.Long(),
                        BCD_Id = c.Long(),
                        Name = c.String(),
                        EmailId = c.String(),
                        Comment = c.String(),
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
                .ForeignKey("dbo.Tbl_BlogCommentsDetails", t => t.BCD_Id)
                .ForeignKey("dbo.Tbl_BlogMaster", t => t.Blog_Id)
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Blog_Id)
                .Index(t => t.BCD_Id)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.Tbl_FAQMaster",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
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
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.Tbl_FooterBlockMaster",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Heading = c.String(),
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
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.Tbl_FooterLinks",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        FooterBlockMaster_Id = c.Long(),
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
                .ForeignKey("dbo.Tbl_FooterBlockMaster", t => t.FooterBlockMaster_Id)
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.FooterBlockMaster_Id)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.Tbl_HomePageBanner",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        BannerImagePath = c.String(),
                        BannerOnHeading1 = c.String(),
                        BannerOnHeading2 = c.String(),
                        BannerHeadingDescription = c.String(),
                        AncharTagTitle = c.String(),
                        AncharTagUrl = c.String(),
                        DisplayIndex = c.Int(nullable: false),
                        DisplayOnHome = c.Boolean(),
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
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.Tbl_HomePageSection1",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        BannerImagePath = c.String(),
                        ShortDescription = c.String(),
                        LongtDescription = c.String(),
                        AncharTagTitle = c.String(),
                        AncharTagUrl = c.String(),
                        DisplayIndex = c.Int(nullable: false),
                        DisplayOnHome = c.Boolean(),
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
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.Tbl_HomePageSection2",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        BannerImagePath = c.String(),
                        Heading1 = c.String(),
                        Heading2 = c.String(),
                        Heading3 = c.String(),
                        Description1 = c.String(),
                        Description2 = c.String(),
                        DisplayIndex = c.Int(nullable: false),
                        DisplayOnHome = c.Boolean(),
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
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.Tbl_HomePageSection3",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        BannerImagePath = c.String(),
                        Heading1 = c.String(),
                        Heading2 = c.String(),
                        Heading3 = c.String(),
                        Heading4 = c.String(),
                        DisplayIndex = c.Int(nullable: false),
                        DisplayOnHome = c.Boolean(),
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
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.Tbl_HomePageSection3Features",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        HomePageSection3_Id = c.Long(),
                        ShortDescription = c.String(),
                        LongDescription = c.String(),
                        AncharTagTitle = c.String(),
                        AncharTagUrl = c.String(),
                        DisplayIndex = c.Int(nullable: false),
                        DisplayOnHome = c.Boolean(),
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
                .ForeignKey("dbo.Tbl_HomePageSection3", t => t.HomePageSection3_Id)
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.HomePageSection3_Id)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.Tbl_HomePageSection4",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        BannerImagePath = c.String(),
                        Heading1 = c.String(),
                        Heading2 = c.String(),
                        DisplayIndex = c.Int(nullable: false),
                        DisplayOnHome = c.Boolean(),
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
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.Tbl_HomePageSection4Testimonails",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Description = c.String(),
                        Name = c.String(),
                        Designation = c.String(),
                        DisplayIndex = c.Int(nullable: false),
                        DisplayOnHome = c.Boolean(),
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
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.Tbl_HomePageSection5",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        ImageFilePath = c.String(),
                        ShortDescription = c.String(),
                        LongDescription = c.String(),
                        AncharTagTitle = c.String(),
                        AncharTagUrl = c.String(),
                        DisplayIndex = c.Int(nullable: false),
                        DisplayOnHome = c.Boolean(),
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
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Tenant_ID);
            
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
            
            CreateTable(
                "dbo.Tbl_Message",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Message_Code = c.Int(nullable: false),
                        Description = c.String(),
                        Title = c.String(),
                        Type = c.String(),
                        Icon = c.String(),
                        Is_Active = c.Boolean(nullable: false),
                        Update_Seq = c.Int(nullable: false),
                        Created_By = c.String(),
                        Created_On = c.DateTime(),
                        Modified_By = c.String(),
                        Modified_On = c.DateTime(),
                        Is_Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Message_Code, unique: true);
            
            CreateTable(
                "dbo.Tbl_PriceFeaturesMapping",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Service_Id = c.Long(),
                        SubSubCat_Id = c.Long(),
                        S1S6PM_Id = c.Long(),
                        PriceFeaturesMaster_Id = c.Long(),
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
                .ForeignKey("dbo.Tbl_PriceFeaturesMaster", t => t.PriceFeaturesMaster_Id)
                .ForeignKey("dbo.Tbl_Services1Master", t => t.Service_Id)
                .ForeignKey("dbo.Tbl_Services1Section6PriceMaster", t => t.S1S6PM_Id)
                .ForeignKey("dbo.Tbl_SubSubCategoriesMaster", t => t.SubSubCat_Id)
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Service_Id)
                .Index(t => t.SubSubCat_Id)
                .Index(t => t.S1S6PM_Id)
                .Index(t => t.PriceFeaturesMaster_Id)
                .Index(t => t.Tenant_ID);
            
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
                        Tenant_ID = c.Long(),
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
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Cat_Id)
                .Index(t => t.SubCat_Id)
                .Index(t => t.SubSubCat_Id)
                .Index(t => t.Tenant_ID);
            
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
                        Tenant_ID = c.Long(),
                        Created_By = c.String(),
                        Created_On = c.DateTime(),
                        Modified_By = c.String(),
                        Modified_On = c.DateTime(),
                        Is_Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tbl_CategoriesMaster", t => t.Cat_Id)
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Cat_Id)
                .Index(t => t.Tenant_ID);
            
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
                        ServiceType_ID = c.Long(nullable: false),
                        ServiceTypeValue = c.String(),
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
                .ForeignKey("dbo.Tbl_CategoriesMaster", t => t.Cat_Id)
                .ForeignKey("dbo.Tbl_Code", t => t.ServiceType_ID, cascadeDelete: false)
                .ForeignKey("dbo.Tbl_SubCategoriesMaster", t => t.SubCat_Id)
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Cat_Id)
                .Index(t => t.SubCat_Id)
                .Index(t => t.ServiceType_ID)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.Tbl_Services1Section6PriceMaster",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Service_Id = c.Long(),
                        SubSubCat_Id = c.Long(),
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
                        Tenant_ID = c.Long(),
                        Created_By = c.String(),
                        Created_On = c.DateTime(),
                        Modified_By = c.String(),
                        Modified_On = c.DateTime(),
                        Is_Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tbl_Services1Master", t => t.Service_Id)
                .ForeignKey("dbo.Tbl_StateMaster", t => t.State_Id)
                .ForeignKey("dbo.Tbl_SubSubCategoriesMaster", t => t.SubSubCat_Id)
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Service_Id)
                .Index(t => t.SubSubCat_Id)
                .Index(t => t.State_Id)
                .Index(t => t.Tenant_ID);
            
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
            
            CreateTable(
                "dbo.Tbl_RelatedBlogsMapping",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Blog_Id = c.Long(),
                        Related_Blog_Id = c.Long(),
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
                .ForeignKey("dbo.Tbl_BlogMaster", t => t.Blog_Id)
                .ForeignKey("dbo.Tbl_BlogMaster", t => t.Related_Blog_Id)
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Blog_Id)
                .Index(t => t.Related_Blog_Id)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Display_Name = c.String(),
                        Tenant_ID = c.Long(),
                        Created_By = c.String(),
                        Created_On = c.DateTime(),
                        Modified_By = c.String(),
                        Modified_On = c.DateTime(),
                        Is_Active = c.Boolean(),
                        Is_Deleted = c.Boolean(),
                        Update_Seq = c.Int(),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Tenant_ID)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.Long(nullable: false),
                        RoleId = c.Long(nullable: false),
                        Tenant_ID = c.Long(),
                        Created_By = c.String(),
                        Created_On = c.DateTime(),
                        Modified_By = c.String(),
                        Modified_On = c.DateTime(),
                        Is_Active = c.Boolean(),
                        Is_Deleted = c.Boolean(),
                        Update_Seq = c.Int(),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: false)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => t.RoleId)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.Tbl_Services1Section10BankMapping",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Service_Id = c.Long(),
                        SubSubCat_Id = c.Long(),
                        BankMaster_Id = c.Long(),
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
                .ForeignKey("dbo.Tbl_BankMaster", t => t.BankMaster_Id)
                .ForeignKey("dbo.Tbl_Services1Master", t => t.Service_Id)
                .ForeignKey("dbo.Tbl_SubSubCategoriesMaster", t => t.SubSubCat_Id)
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Service_Id)
                .Index(t => t.SubSubCat_Id)
                .Index(t => t.BankMaster_Id)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.Tbl_Services1Section1Master",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Service_Id = c.Long(),
                        SubSubCat_Id = c.Long(),
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
                .ForeignKey("dbo.Tbl_Services1Master", t => t.Service_Id)
                .ForeignKey("dbo.Tbl_SubSubCategoriesMaster", t => t.SubSubCat_Id)
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Service_Id)
                .Index(t => t.SubSubCat_Id)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.Tbl_Services1Section4Master",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Service_Id = c.Long(),
                        SubSubCat_Id = c.Long(),
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
                        Tenant_ID = c.Long(),
                        Created_By = c.String(),
                        Created_On = c.DateTime(),
                        Modified_By = c.String(),
                        Modified_On = c.DateTime(),
                        Is_Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tbl_Services1Master", t => t.Service_Id)
                .ForeignKey("dbo.Tbl_SubSubCategoriesMaster", t => t.SubSubCat_Id)
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Service_Id)
                .Index(t => t.SubSubCat_Id)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.Tbl_Services1Section5Master",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Service_Id = c.Long(),
                        SubSubCat_Id = c.Long(),
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
                        Tenant_ID = c.Long(),
                        Created_By = c.String(),
                        Created_On = c.DateTime(),
                        Modified_By = c.String(),
                        Modified_On = c.DateTime(),
                        Is_Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tbl_Services1Master", t => t.Service_Id)
                .ForeignKey("dbo.Tbl_SubSubCategoriesMaster", t => t.SubSubCat_Id)
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Service_Id)
                .Index(t => t.SubSubCat_Id)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.Tbl_Services1Section8FAQMapping",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Service_Id = c.Long(),
                        SubSubCat_Id = c.Long(),
                        FAQMaster_Id = c.Long(),
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
                .ForeignKey("dbo.Tbl_FAQMaster", t => t.FAQMaster_Id)
                .ForeignKey("dbo.Tbl_Services1Master", t => t.Service_Id)
                .ForeignKey("dbo.Tbl_SubSubCategoriesMaster", t => t.SubSubCat_Id)
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Service_Id)
                .Index(t => t.SubSubCat_Id)
                .Index(t => t.FAQMaster_Id)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.Tbl_Services2Master",
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
                        Section1Description = c.String(),
                        Section2FAQDescription = c.String(),
                        Section3DownloadDescription = c.String(),
                        Section4PriceingHeading = c.String(),
                        Section4PriceingDescription = c.String(),
                        DisplayIndex = c.Int(nullable: false),
                        DisplayOnHome = c.Boolean(),
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
                .ForeignKey("dbo.Tbl_CategoriesMaster", t => t.Cat_Id)
                .ForeignKey("dbo.Tbl_SubCategoriesMaster", t => t.SubCat_Id)
                .ForeignKey("dbo.Tbl_SubSubCategoriesMaster", t => t.SubSubCat_Id)
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Cat_Id)
                .Index(t => t.SubCat_Id)
                .Index(t => t.SubSubCat_Id)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.Tbl_Services2Section2FAQMapping",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Service_Id = c.Long(),
                        SubSubCat_Id = c.Long(),
                        FAQMaster_Id = c.Long(),
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
                .ForeignKey("dbo.Tbl_FAQMaster", t => t.FAQMaster_Id)
                .ForeignKey("dbo.Tbl_Services2Master", t => t.Service_Id)
                .ForeignKey("dbo.Tbl_SubSubCategoriesMaster", t => t.SubSubCat_Id)
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Service_Id)
                .Index(t => t.SubSubCat_Id)
                .Index(t => t.FAQMaster_Id)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.Tbl_Services2Section3DownloadMaster",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Service_Id = c.Long(),
                        SubSubCat_Id = c.Long(),
                        AncharTagTitle = c.String(),
                        AncharTagUrl = c.String(),
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tbl_Services2Master", t => t.Service_Id)
                .ForeignKey("dbo.Tbl_SubSubCategoriesMaster", t => t.SubSubCat_Id)
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Service_Id)
                .Index(t => t.SubSubCat_Id)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.Tbl_Services2Section4Master",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Service_Id = c.Long(),
                        SubSubCat_Id = c.Long(),
                        AncharTagTitle = c.String(),
                        AncharTagUrl = c.String(),
                        Heading = c.String(),
                        Description = c.String(),
                        Price = c.Int(nullable: false),
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
                .ForeignKey("dbo.Tbl_Services2Master", t => t.Service_Id)
                .ForeignKey("dbo.Tbl_SubSubCategoriesMaster", t => t.SubSubCat_Id)
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Service_Id)
                .Index(t => t.SubSubCat_Id)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.Tbl_Services3HeadingButtons",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Service_Id = c.Long(),
                        SubSubCat_Id = c.Long(),
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
                .ForeignKey("dbo.Tbl_Services3Master", t => t.Service_Id)
                .ForeignKey("dbo.Tbl_SubSubCategoriesMaster", t => t.SubSubCat_Id)
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Service_Id)
                .Index(t => t.SubSubCat_Id)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.Tbl_Services3Master",
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
                        Section1Heading = c.String(),
                        Section1Description = c.String(),
                        Section4Heading = c.String(),
                        Section5Heading = c.String(),
                        Section5Description = c.String(),
                        Section5TextboxMaskedText = c.String(),
                        Section6PriceingHeading = c.String(),
                        Section6PriceingDescription = c.String(),
                        DisplayIndex = c.Int(nullable: false),
                        DisplayOnHome = c.Boolean(),
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
                .ForeignKey("dbo.Tbl_CategoriesMaster", t => t.Cat_Id)
                .ForeignKey("dbo.Tbl_SubCategoriesMaster", t => t.SubCat_Id)
                .ForeignKey("dbo.Tbl_SubSubCategoriesMaster", t => t.SubSubCat_Id)
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Cat_Id)
                .Index(t => t.SubCat_Id)
                .Index(t => t.SubSubCat_Id)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.Tbl_Services3Section4",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Service_Id = c.Long(),
                        SubSubCat_Id = c.Long(),
                        State_Id = c.Long(),
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
                .ForeignKey("dbo.Tbl_Services3Master", t => t.Service_Id)
                .ForeignKey("dbo.Tbl_StateMaster", t => t.State_Id)
                .ForeignKey("dbo.Tbl_SubSubCategoriesMaster", t => t.SubSubCat_Id)
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Service_Id)
                .Index(t => t.SubSubCat_Id)
                .Index(t => t.State_Id)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.Tbl_Services3Section6PriceMaster",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Service_Id = c.Long(),
                        State_Id = c.Long(),
                        SubSubCat_Id = c.Long(),
                        HeadingText = c.String(),
                        Description = c.String(),
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tbl_Services3Master", t => t.Service_Id)
                .ForeignKey("dbo.Tbl_StateMaster", t => t.State_Id)
                .ForeignKey("dbo.Tbl_SubSubCategoriesMaster", t => t.SubSubCat_Id)
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Service_Id)
                .Index(t => t.State_Id)
                .Index(t => t.SubSubCat_Id)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.Tbl_Services4Master",
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
                        Section1Description = c.String(),
                        Section2PriceingHeading = c.String(),
                        Section2PriceingDescription = c.String(),
                        Section3PriceingHeading = c.String(),
                        Section3PriceingDescription = c.String(),
                        Section4PriceingHeading = c.String(),
                        Section4PriceingDescription = c.String(),
                        Section5PriceingHeading = c.String(),
                        Section6PriceingHeading = c.String(),
                        Section7PriceingHeading = c.String(),
                        DisplayIndex = c.Int(nullable: false),
                        DisplayOnHome = c.Boolean(),
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
                .ForeignKey("dbo.Tbl_CategoriesMaster", t => t.Cat_Id)
                .ForeignKey("dbo.Tbl_SubCategoriesMaster", t => t.SubCat_Id)
                .ForeignKey("dbo.Tbl_SubSubCategoriesMaster", t => t.SubSubCat_Id)
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Cat_Id)
                .Index(t => t.SubCat_Id)
                .Index(t => t.SubSubCat_Id)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.Tbl_Services4Section2FAQMapping",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Service_Id = c.Long(),
                        SubSubCat_Id = c.Long(),
                        FAQMaster_Id = c.Long(),
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
                .ForeignKey("dbo.Tbl_FAQMaster", t => t.FAQMaster_Id)
                .ForeignKey("dbo.Tbl_Services4Master", t => t.Service_Id)
                .ForeignKey("dbo.Tbl_SubSubCategoriesMaster", t => t.SubSubCat_Id)
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Service_Id)
                .Index(t => t.SubSubCat_Id)
                .Index(t => t.FAQMaster_Id)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.Tbl_Services4Section345Master",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Service_Id = c.Long(),
                        SubSubCat_Id = c.Long(),
                        SectionType_ID = c.Long(nullable: false),
                        SectionTypeValue = c.String(),
                        Heading = c.String(),
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
                .ForeignKey("dbo.Tbl_Code", t => t.SectionType_ID, cascadeDelete: false)
                .ForeignKey("dbo.Tbl_Services4Master", t => t.Service_Id)
                .ForeignKey("dbo.Tbl_SubSubCategoriesMaster", t => t.SubSubCat_Id)
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Service_Id)
                .Index(t => t.SubSubCat_Id)
                .Index(t => t.SectionType_ID)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.Tbl_Services4Section345MasterButtonsChild",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Service_Id = c.Long(),
                        S4S345M_id = c.Long(),
                        SubSubCat_Id = c.Long(),
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tbl_Services4Master", t => t.Service_Id)
                .ForeignKey("dbo.Tbl_Services4Section345Master", t => t.S4S345M_id)
                .ForeignKey("dbo.Tbl_SubSubCategoriesMaster", t => t.SubSubCat_Id)
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Service_Id)
                .Index(t => t.S4S345M_id)
                .Index(t => t.SubSubCat_Id)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.Tbl_Services4Section345MasterFeaturesDetails",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Service_Id = c.Long(),
                        S4S345M_id = c.Long(),
                        SubSubCat_Id = c.Long(),
                        ShortDescription = c.String(),
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
                .ForeignKey("dbo.Tbl_Services4Master", t => t.Service_Id)
                .ForeignKey("dbo.Tbl_Services4Section345Master", t => t.S4S345M_id)
                .ForeignKey("dbo.Tbl_SubSubCategoriesMaster", t => t.SubSubCat_Id)
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Service_Id)
                .Index(t => t.S4S345M_id)
                .Index(t => t.SubSubCat_Id)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.Tbl_Services4Section678FieldMaster",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Service_Id = c.Long(),
                        SubSubCat_Id = c.Long(),
                        FieldName = c.String(),
                        SectionType_ID = c.Long(nullable: false),
                        SectionTypeValue = c.String(),
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
                .ForeignKey("dbo.Tbl_Code", t => t.SectionType_ID, cascadeDelete: false)
                .ForeignKey("dbo.Tbl_Services4Master", t => t.Service_Id)
                .ForeignKey("dbo.Tbl_SubSubCategoriesMaster", t => t.SubSubCat_Id)
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Service_Id)
                .Index(t => t.SubSubCat_Id)
                .Index(t => t.SectionType_ID)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.Tbl_Services4Section678FieldValues",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Service_Id = c.Long(),
                        S4S678FM_Id = c.Long(),
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tbl_Services4Master", t => t.Service_Id)
                .ForeignKey("dbo.Tbl_Services4Section678FieldMaster", t => t.S4S678FM_Id)
                .ForeignKey("dbo.Tbl_SubSubCategoriesMaster", t => t.SubSubCat_Id)
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Service_Id)
                .Index(t => t.S4S678FM_Id)
                .Index(t => t.SubSubCat_Id)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.Tbl_Services5Master",
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
                        Section1Description = c.String(),
                        Section2Heading = c.String(),
                        Section2HeadingDescription = c.String(),
                        DisplayIndex = c.Int(nullable: false),
                        DisplayOnHome = c.Boolean(),
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
                .ForeignKey("dbo.Tbl_CategoriesMaster", t => t.Cat_Id)
                .ForeignKey("dbo.Tbl_SubCategoriesMaster", t => t.SubCat_Id)
                .ForeignKey("dbo.Tbl_SubSubCategoriesMaster", t => t.SubSubCat_Id)
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Cat_Id)
                .Index(t => t.SubCat_Id)
                .Index(t => t.SubSubCat_Id)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.Tbl_Services5Section2Master",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Service_Id = c.Long(),
                        SubSubCat_Id = c.Long(),
                        AncharTagTitle = c.String(),
                        AncharTagUrl = c.String(),
                        ImageFilePath = c.String(),
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
                .ForeignKey("dbo.Tbl_Services5Master", t => t.Service_Id)
                .ForeignKey("dbo.Tbl_SubSubCategoriesMaster", t => t.SubSubCat_Id)
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Service_Id)
                .Index(t => t.SubSubCat_Id)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.Tbl_Services5Section2MasterFeaturesDetails",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Service_Id = c.Long(),
                        SubSubCat_Id = c.Long(),
                        S5S2M_Id = c.Long(),
                        Text = c.String(),
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
                .ForeignKey("dbo.Tbl_Services5Master", t => t.Service_Id)
                .ForeignKey("dbo.Tbl_Services5Section2Master", t => t.S5S2M_Id)
                .ForeignKey("dbo.Tbl_SubSubCategoriesMaster", t => t.SubSubCat_Id)
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Service_Id)
                .Index(t => t.SubSubCat_Id)
                .Index(t => t.S5S2M_Id)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.Tbl_Services6Master",
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
                        Section1Description = c.String(),
                        Section2Heading = c.String(),
                        Section2HeadingDescription = c.String(),
                        DisplayIndex = c.Int(nullable: false),
                        DisplayOnHome = c.Boolean(),
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
                .ForeignKey("dbo.Tbl_CategoriesMaster", t => t.Cat_Id)
                .ForeignKey("dbo.Tbl_SubCategoriesMaster", t => t.SubCat_Id)
                .ForeignKey("dbo.Tbl_SubSubCategoriesMaster", t => t.SubSubCat_Id)
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Cat_Id)
                .Index(t => t.SubCat_Id)
                .Index(t => t.SubSubCat_Id)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.Tbl_Services6Section2Master",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Service_Id = c.Long(),
                        SubSubCat_Id = c.Long(),
                        Title = c.String(),
                        ImageFilePath = c.String(),
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
                .ForeignKey("dbo.Tbl_Services6Master", t => t.Service_Id)
                .ForeignKey("dbo.Tbl_SubSubCategoriesMaster", t => t.SubSubCat_Id)
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Service_Id)
                .Index(t => t.SubSubCat_Id)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.Tbl_Services6Section2MasterFeaturesDetails",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Service_Id = c.Long(),
                        SubSubCat_Id = c.Long(),
                        S6S2M_Id = c.Long(),
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tbl_Services6Master", t => t.Service_Id)
                .ForeignKey("dbo.Tbl_Services6Section2Master", t => t.S6S2M_Id)
                .ForeignKey("dbo.Tbl_SubSubCategoriesMaster", t => t.SubSubCat_Id)
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Service_Id)
                .Index(t => t.SubSubCat_Id)
                .Index(t => t.S6S2M_Id)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.Tbl_Services7HeadingButtons",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Service_Id = c.Long(),
                        SubSubCat_Id = c.Long(),
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
            
            CreateTable(
                "dbo.Tbl_Services7Master",
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
                        Section1Heading = c.String(),
                        Section1Description = c.String(),
                        Section4Heading = c.String(),
                        Section5Heading = c.String(),
                        Section5Description = c.String(),
                        Section5TextboxMaskedText = c.String(),
                        Section6PriceingHeading = c.String(),
                        Section6PriceingDescription = c.String(),
                        DisplayIndex = c.Int(nullable: false),
                        DisplayOnHome = c.Boolean(),
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
                .ForeignKey("dbo.Tbl_CategoriesMaster", t => t.Cat_Id)
                .ForeignKey("dbo.Tbl_SubCategoriesMaster", t => t.SubCat_Id)
                .ForeignKey("dbo.Tbl_SubSubCategoriesMaster", t => t.SubSubCat_Id)
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Cat_Id)
                .Index(t => t.SubCat_Id)
                .Index(t => t.SubSubCat_Id)
                .Index(t => t.Tenant_ID);
            
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
            
            CreateTable(
                "dbo.Tbl_Services7Section6PriceMaster",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Service_Id = c.Long(),
                        SubSubCat_Id = c.Long(),
                        HeadingText = c.String(),
                        Description = c.String(),
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tbl_Services7Master", t => t.Service_Id)
                .ForeignKey("dbo.Tbl_SubSubCategoriesMaster", t => t.SubSubCat_Id)
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Service_Id)
                .Index(t => t.SubSubCat_Id)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.Tbl_Services8HeadingButtons",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Service_Id = c.Long(),
                        SubSubCat_Id = c.Long(),
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
                .ForeignKey("dbo.Tbl_Services8Master", t => t.Service_Id)
                .ForeignKey("dbo.Tbl_SubSubCategoriesMaster", t => t.SubSubCat_Id)
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Service_Id)
                .Index(t => t.SubSubCat_Id)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.Tbl_Services8Master",
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
                        Section1Heading = c.String(),
                        Section1Description = c.String(),
                        Section2BannerPath = c.String(),
                        Section2BannerHeadingDescription = c.String(),
                        Section4Heading = c.String(),
                        Section5Heading = c.String(),
                        Section5Description = c.String(),
                        Section5TextboxMaskedText = c.String(),
                        DisplayIndex = c.Int(nullable: false),
                        DisplayOnHome = c.Boolean(),
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
                .ForeignKey("dbo.Tbl_CategoriesMaster", t => t.Cat_Id)
                .ForeignKey("dbo.Tbl_SubCategoriesMaster", t => t.SubCat_Id)
                .ForeignKey("dbo.Tbl_SubSubCategoriesMaster", t => t.SubSubCat_Id)
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Cat_Id)
                .Index(t => t.SubCat_Id)
                .Index(t => t.SubSubCat_Id)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.Tbl_Services8Section6Master",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Service_Id = c.Long(),
                        SubSubCat_Id = c.Long(),
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
                        Tenant_ID = c.Long(),
                        Created_By = c.String(),
                        Created_On = c.DateTime(),
                        Modified_By = c.String(),
                        Modified_On = c.DateTime(),
                        Is_Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tbl_Services8Master", t => t.Service_Id)
                .ForeignKey("dbo.Tbl_SubSubCategoriesMaster", t => t.SubSubCat_Id)
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Service_Id)
                .Index(t => t.SubSubCat_Id)
                .Index(t => t.Tenant_ID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Tenant_ID = c.Long(),
                        First_Name = c.String(),
                        Last_Name = c.String(),
                        Profile_Image = c.String(),
                        Created_By = c.String(),
                        Created_On = c.DateTime(),
                        Modified_By = c.String(),
                        Modified_On = c.DateTime(),
                        Is_Active = c.Boolean(),
                        Is_Deleted = c.Boolean(),
                        Update_Seq = c.Int(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .Index(t => t.Tenant_ID)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tenant_ID = c.Long(),
                        Created_By = c.String(),
                        Created_On = c.DateTime(),
                        Modified_By = c.String(),
                        Modified_On = c.DateTime(),
                        Is_Active = c.Boolean(),
                        Is_Deleted = c.Boolean(),
                        Update_Seq = c.Int(),
                        UserId = c.Long(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: false)
                .Index(t => t.Tenant_ID)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.Long(nullable: false),
                        Tenant_ID = c.Long(),
                        Created_By = c.String(),
                        Created_On = c.DateTime(),
                        Modified_By = c.String(),
                        Modified_On = c.DateTime(),
                        Is_Active = c.Boolean(),
                        Is_Deleted = c.Boolean(),
                        Update_Seq = c.Int(),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Tbl_Tenant", t => t.Tenant_ID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => t.Tenant_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_Services8Section6Master", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_Services8Section6Master", "SubSubCat_Id", "dbo.Tbl_SubSubCategoriesMaster");
            DropForeignKey("dbo.Tbl_Services8Section6Master", "Service_Id", "dbo.Tbl_Services8Master");
            DropForeignKey("dbo.Tbl_Services8HeadingButtons", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_Services8HeadingButtons", "SubSubCat_Id", "dbo.Tbl_SubSubCategoriesMaster");
            DropForeignKey("dbo.Tbl_Services8HeadingButtons", "Service_Id", "dbo.Tbl_Services8Master");
            DropForeignKey("dbo.Tbl_Services8Master", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_Services8Master", "SubSubCat_Id", "dbo.Tbl_SubSubCategoriesMaster");
            DropForeignKey("dbo.Tbl_Services8Master", "SubCat_Id", "dbo.Tbl_SubCategoriesMaster");
            DropForeignKey("dbo.Tbl_Services8Master", "Cat_Id", "dbo.Tbl_CategoriesMaster");
            DropForeignKey("dbo.Tbl_Services7Section6PriceMaster", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_Services7Section6PriceMaster", "SubSubCat_Id", "dbo.Tbl_SubSubCategoriesMaster");
            DropForeignKey("dbo.Tbl_Services7Section6PriceMaster", "Service_Id", "dbo.Tbl_Services7Master");
            DropForeignKey("dbo.Tbl_Services7Section4", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_Services7Section4", "SubSubCat_Id", "dbo.Tbl_SubSubCategoriesMaster");
            DropForeignKey("dbo.Tbl_Services7Section4", "Service_Id", "dbo.Tbl_Services7Master");
            DropForeignKey("dbo.Tbl_Services7HeadingButtons", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_Services7HeadingButtons", "SubSubCat_Id", "dbo.Tbl_SubSubCategoriesMaster");
            DropForeignKey("dbo.Tbl_Services7HeadingButtons", "Service_Id", "dbo.Tbl_Services7Master");
            DropForeignKey("dbo.Tbl_Services7Master", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_Services7Master", "SubSubCat_Id", "dbo.Tbl_SubSubCategoriesMaster");
            DropForeignKey("dbo.Tbl_Services7Master", "SubCat_Id", "dbo.Tbl_SubCategoriesMaster");
            DropForeignKey("dbo.Tbl_Services7Master", "Cat_Id", "dbo.Tbl_CategoriesMaster");
            DropForeignKey("dbo.Tbl_Services6Section2MasterFeaturesDetails", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_Services6Section2MasterFeaturesDetails", "SubSubCat_Id", "dbo.Tbl_SubSubCategoriesMaster");
            DropForeignKey("dbo.Tbl_Services6Section2MasterFeaturesDetails", "S6S2M_Id", "dbo.Tbl_Services6Section2Master");
            DropForeignKey("dbo.Tbl_Services6Section2MasterFeaturesDetails", "Service_Id", "dbo.Tbl_Services6Master");
            DropForeignKey("dbo.Tbl_Services6Section2Master", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_Services6Section2Master", "SubSubCat_Id", "dbo.Tbl_SubSubCategoriesMaster");
            DropForeignKey("dbo.Tbl_Services6Section2Master", "Service_Id", "dbo.Tbl_Services6Master");
            DropForeignKey("dbo.Tbl_Services6Master", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_Services6Master", "SubSubCat_Id", "dbo.Tbl_SubSubCategoriesMaster");
            DropForeignKey("dbo.Tbl_Services6Master", "SubCat_Id", "dbo.Tbl_SubCategoriesMaster");
            DropForeignKey("dbo.Tbl_Services6Master", "Cat_Id", "dbo.Tbl_CategoriesMaster");
            DropForeignKey("dbo.Tbl_Services5Section2MasterFeaturesDetails", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_Services5Section2MasterFeaturesDetails", "SubSubCat_Id", "dbo.Tbl_SubSubCategoriesMaster");
            DropForeignKey("dbo.Tbl_Services5Section2MasterFeaturesDetails", "S5S2M_Id", "dbo.Tbl_Services5Section2Master");
            DropForeignKey("dbo.Tbl_Services5Section2MasterFeaturesDetails", "Service_Id", "dbo.Tbl_Services5Master");
            DropForeignKey("dbo.Tbl_Services5Section2Master", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_Services5Section2Master", "SubSubCat_Id", "dbo.Tbl_SubSubCategoriesMaster");
            DropForeignKey("dbo.Tbl_Services5Section2Master", "Service_Id", "dbo.Tbl_Services5Master");
            DropForeignKey("dbo.Tbl_Services5Master", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_Services5Master", "SubSubCat_Id", "dbo.Tbl_SubSubCategoriesMaster");
            DropForeignKey("dbo.Tbl_Services5Master", "SubCat_Id", "dbo.Tbl_SubCategoriesMaster");
            DropForeignKey("dbo.Tbl_Services5Master", "Cat_Id", "dbo.Tbl_CategoriesMaster");
            DropForeignKey("dbo.Tbl_Services4Section678FieldValues", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_Services4Section678FieldValues", "SubSubCat_Id", "dbo.Tbl_SubSubCategoriesMaster");
            DropForeignKey("dbo.Tbl_Services4Section678FieldValues", "S4S678FM_Id", "dbo.Tbl_Services4Section678FieldMaster");
            DropForeignKey("dbo.Tbl_Services4Section678FieldValues", "Service_Id", "dbo.Tbl_Services4Master");
            DropForeignKey("dbo.Tbl_Services4Section678FieldMaster", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_Services4Section678FieldMaster", "SubSubCat_Id", "dbo.Tbl_SubSubCategoriesMaster");
            DropForeignKey("dbo.Tbl_Services4Section678FieldMaster", "Service_Id", "dbo.Tbl_Services4Master");
            DropForeignKey("dbo.Tbl_Services4Section678FieldMaster", "SectionType_ID", "dbo.Tbl_Code");
            DropForeignKey("dbo.Tbl_Services4Section345MasterFeaturesDetails", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_Services4Section345MasterFeaturesDetails", "SubSubCat_Id", "dbo.Tbl_SubSubCategoriesMaster");
            DropForeignKey("dbo.Tbl_Services4Section345MasterFeaturesDetails", "S4S345M_id", "dbo.Tbl_Services4Section345Master");
            DropForeignKey("dbo.Tbl_Services4Section345MasterFeaturesDetails", "Service_Id", "dbo.Tbl_Services4Master");
            DropForeignKey("dbo.Tbl_Services4Section345MasterButtonsChild", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_Services4Section345MasterButtonsChild", "SubSubCat_Id", "dbo.Tbl_SubSubCategoriesMaster");
            DropForeignKey("dbo.Tbl_Services4Section345MasterButtonsChild", "S4S345M_id", "dbo.Tbl_Services4Section345Master");
            DropForeignKey("dbo.Tbl_Services4Section345MasterButtonsChild", "Service_Id", "dbo.Tbl_Services4Master");
            DropForeignKey("dbo.Tbl_Services4Section345Master", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_Services4Section345Master", "SubSubCat_Id", "dbo.Tbl_SubSubCategoriesMaster");
            DropForeignKey("dbo.Tbl_Services4Section345Master", "Service_Id", "dbo.Tbl_Services4Master");
            DropForeignKey("dbo.Tbl_Services4Section345Master", "SectionType_ID", "dbo.Tbl_Code");
            DropForeignKey("dbo.Tbl_Services4Section2FAQMapping", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_Services4Section2FAQMapping", "SubSubCat_Id", "dbo.Tbl_SubSubCategoriesMaster");
            DropForeignKey("dbo.Tbl_Services4Section2FAQMapping", "Service_Id", "dbo.Tbl_Services4Master");
            DropForeignKey("dbo.Tbl_Services4Section2FAQMapping", "FAQMaster_Id", "dbo.Tbl_FAQMaster");
            DropForeignKey("dbo.Tbl_Services4Master", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_Services4Master", "SubSubCat_Id", "dbo.Tbl_SubSubCategoriesMaster");
            DropForeignKey("dbo.Tbl_Services4Master", "SubCat_Id", "dbo.Tbl_SubCategoriesMaster");
            DropForeignKey("dbo.Tbl_Services4Master", "Cat_Id", "dbo.Tbl_CategoriesMaster");
            DropForeignKey("dbo.Tbl_Services3Section6PriceMaster", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_Services3Section6PriceMaster", "SubSubCat_Id", "dbo.Tbl_SubSubCategoriesMaster");
            DropForeignKey("dbo.Tbl_Services3Section6PriceMaster", "State_Id", "dbo.Tbl_StateMaster");
            DropForeignKey("dbo.Tbl_Services3Section6PriceMaster", "Service_Id", "dbo.Tbl_Services3Master");
            DropForeignKey("dbo.Tbl_Services3Section4", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_Services3Section4", "SubSubCat_Id", "dbo.Tbl_SubSubCategoriesMaster");
            DropForeignKey("dbo.Tbl_Services3Section4", "State_Id", "dbo.Tbl_StateMaster");
            DropForeignKey("dbo.Tbl_Services3Section4", "Service_Id", "dbo.Tbl_Services3Master");
            DropForeignKey("dbo.Tbl_Services3HeadingButtons", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_Services3HeadingButtons", "SubSubCat_Id", "dbo.Tbl_SubSubCategoriesMaster");
            DropForeignKey("dbo.Tbl_Services3HeadingButtons", "Service_Id", "dbo.Tbl_Services3Master");
            DropForeignKey("dbo.Tbl_Services3Master", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_Services3Master", "SubSubCat_Id", "dbo.Tbl_SubSubCategoriesMaster");
            DropForeignKey("dbo.Tbl_Services3Master", "SubCat_Id", "dbo.Tbl_SubCategoriesMaster");
            DropForeignKey("dbo.Tbl_Services3Master", "Cat_Id", "dbo.Tbl_CategoriesMaster");
            DropForeignKey("dbo.Tbl_Services2Section4Master", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_Services2Section4Master", "SubSubCat_Id", "dbo.Tbl_SubSubCategoriesMaster");
            DropForeignKey("dbo.Tbl_Services2Section4Master", "Service_Id", "dbo.Tbl_Services2Master");
            DropForeignKey("dbo.Tbl_Services2Section3DownloadMaster", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_Services2Section3DownloadMaster", "SubSubCat_Id", "dbo.Tbl_SubSubCategoriesMaster");
            DropForeignKey("dbo.Tbl_Services2Section3DownloadMaster", "Service_Id", "dbo.Tbl_Services2Master");
            DropForeignKey("dbo.Tbl_Services2Section2FAQMapping", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_Services2Section2FAQMapping", "SubSubCat_Id", "dbo.Tbl_SubSubCategoriesMaster");
            DropForeignKey("dbo.Tbl_Services2Section2FAQMapping", "Service_Id", "dbo.Tbl_Services2Master");
            DropForeignKey("dbo.Tbl_Services2Section2FAQMapping", "FAQMaster_Id", "dbo.Tbl_FAQMaster");
            DropForeignKey("dbo.Tbl_Services2Master", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_Services2Master", "SubSubCat_Id", "dbo.Tbl_SubSubCategoriesMaster");
            DropForeignKey("dbo.Tbl_Services2Master", "SubCat_Id", "dbo.Tbl_SubCategoriesMaster");
            DropForeignKey("dbo.Tbl_Services2Master", "Cat_Id", "dbo.Tbl_CategoriesMaster");
            DropForeignKey("dbo.Tbl_Services1Section8FAQMapping", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_Services1Section8FAQMapping", "SubSubCat_Id", "dbo.Tbl_SubSubCategoriesMaster");
            DropForeignKey("dbo.Tbl_Services1Section8FAQMapping", "Service_Id", "dbo.Tbl_Services1Master");
            DropForeignKey("dbo.Tbl_Services1Section8FAQMapping", "FAQMaster_Id", "dbo.Tbl_FAQMaster");
            DropForeignKey("dbo.Tbl_Services1Section5Master", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_Services1Section5Master", "SubSubCat_Id", "dbo.Tbl_SubSubCategoriesMaster");
            DropForeignKey("dbo.Tbl_Services1Section5Master", "Service_Id", "dbo.Tbl_Services1Master");
            DropForeignKey("dbo.Tbl_Services1Section4Master", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_Services1Section4Master", "SubSubCat_Id", "dbo.Tbl_SubSubCategoriesMaster");
            DropForeignKey("dbo.Tbl_Services1Section4Master", "Service_Id", "dbo.Tbl_Services1Master");
            DropForeignKey("dbo.Tbl_Services1Section1Master", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_Services1Section1Master", "SubSubCat_Id", "dbo.Tbl_SubSubCategoriesMaster");
            DropForeignKey("dbo.Tbl_Services1Section1Master", "Service_Id", "dbo.Tbl_Services1Master");
            DropForeignKey("dbo.Tbl_Services1Section10BankMapping", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_Services1Section10BankMapping", "SubSubCat_Id", "dbo.Tbl_SubSubCategoriesMaster");
            DropForeignKey("dbo.Tbl_Services1Section10BankMapping", "Service_Id", "dbo.Tbl_Services1Master");
            DropForeignKey("dbo.Tbl_Services1Section10BankMapping", "BankMaster_Id", "dbo.Tbl_BankMaster");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserRoles", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.AspNetRoles", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_RelatedBlogsMapping", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_RelatedBlogsMapping", "Related_Blog_Id", "dbo.Tbl_BlogMaster");
            DropForeignKey("dbo.Tbl_RelatedBlogsMapping", "Blog_Id", "dbo.Tbl_BlogMaster");
            DropForeignKey("dbo.Tbl_PriceFeaturesMapping", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_PriceFeaturesMapping", "SubSubCat_Id", "dbo.Tbl_SubSubCategoriesMaster");
            DropForeignKey("dbo.Tbl_PriceFeaturesMapping", "S1S6PM_Id", "dbo.Tbl_Services1Section6PriceMaster");
            DropForeignKey("dbo.Tbl_Services1Section6PriceMaster", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_Services1Section6PriceMaster", "SubSubCat_Id", "dbo.Tbl_SubSubCategoriesMaster");
            DropForeignKey("dbo.Tbl_Services1Section6PriceMaster", "State_Id", "dbo.Tbl_StateMaster");
            DropForeignKey("dbo.Tbl_StateMaster", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_Services1Section6PriceMaster", "Service_Id", "dbo.Tbl_Services1Master");
            DropForeignKey("dbo.Tbl_PriceFeaturesMapping", "Service_Id", "dbo.Tbl_Services1Master");
            DropForeignKey("dbo.Tbl_Services1Master", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_Services1Master", "SubSubCat_Id", "dbo.Tbl_SubSubCategoriesMaster");
            DropForeignKey("dbo.Tbl_SubSubCategoriesMaster", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_SubSubCategoriesMaster", "SubCat_Id", "dbo.Tbl_SubCategoriesMaster");
            DropForeignKey("dbo.Tbl_SubSubCategoriesMaster", "ServiceType_ID", "dbo.Tbl_Code");
            DropForeignKey("dbo.Tbl_SubSubCategoriesMaster", "Cat_Id", "dbo.Tbl_CategoriesMaster");
            DropForeignKey("dbo.Tbl_Services1Master", "SubCat_Id", "dbo.Tbl_SubCategoriesMaster");
            DropForeignKey("dbo.Tbl_SubCategoriesMaster", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_SubCategoriesMaster", "Cat_Id", "dbo.Tbl_CategoriesMaster");
            DropForeignKey("dbo.Tbl_Services1Master", "Cat_Id", "dbo.Tbl_CategoriesMaster");
            DropForeignKey("dbo.Tbl_PriceFeaturesMapping", "PriceFeaturesMaster_Id", "dbo.Tbl_PriceFeaturesMaster");
            DropForeignKey("dbo.Tbl_PriceFeaturesMaster", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_IPInfo", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_HomePageSection5", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_HomePageSection4Testimonails", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_HomePageSection4", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_HomePageSection3Features", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_HomePageSection3Features", "HomePageSection3_Id", "dbo.Tbl_HomePageSection3");
            DropForeignKey("dbo.Tbl_HomePageSection3", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_HomePageSection2", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_HomePageSection1", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_HomePageBanner", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_FooterLinks", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_FooterLinks", "FooterBlockMaster_Id", "dbo.Tbl_FooterBlockMaster");
            DropForeignKey("dbo.Tbl_FooterBlockMaster", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_FAQMaster", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_CommentsReply", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_CommentsReply", "Blog_Id", "dbo.Tbl_BlogMaster");
            DropForeignKey("dbo.Tbl_CommentsReply", "BCD_Id", "dbo.Tbl_BlogCommentsDetails");
            DropForeignKey("dbo.Tbl_CategoriesMaster", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_BlogCommentsDetails", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_BlogCommentsDetails", "Blog_Id", "dbo.Tbl_BlogMaster");
            DropForeignKey("dbo.Tbl_BlogBannerNavigationsDetails", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_BlogBannerNavigationsDetails", "Blog_Id", "dbo.Tbl_BlogMaster");
            DropForeignKey("dbo.Tbl_BlogMaster", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_BannerMaster", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_BankMaster", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_AspNetRoles_SubMenu", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_Tenant", "ShippingAddressState_ID", "dbo.Tbl_Code");
            DropForeignKey("dbo.Tbl_Tenant", "ShippingAddressCountry_ID", "dbo.Tbl_Code");
            DropForeignKey("dbo.Tbl_Tenant", "ShippingAddressCityOrDistrict_ID", "dbo.Tbl_Code");
            DropForeignKey("dbo.ExceptionLog", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_Tenant", "BillingAddressState_ID", "dbo.Tbl_Code");
            DropForeignKey("dbo.Tbl_Tenant", "BillingAddressCountry_ID", "dbo.Tbl_Code");
            DropForeignKey("dbo.Tbl_Tenant", "BillingAddressCityOrDistrict_ID", "dbo.Tbl_Code");
            DropForeignKey("dbo.Tbl_CodeValue", "Code_ID", "dbo.Tbl_Code");
            DropForeignKey("dbo.Tbl_AspNetRoles_SubMenu", "SubMenu_ID", "dbo.Tbl_SubMenu");
            DropForeignKey("dbo.Tbl_SubMenu", "ParrentMenu_ID", "dbo.Tbl_SubMenu");
            DropIndex("dbo.AspNetUserLogins", new[] { "Tenant_ID" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "Tenant_ID" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_Services8Section6Master", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_Services8Section6Master", new[] { "SubSubCat_Id" });
            DropIndex("dbo.Tbl_Services8Section6Master", new[] { "Service_Id" });
            DropIndex("dbo.Tbl_Services8Master", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_Services8Master", new[] { "SubSubCat_Id" });
            DropIndex("dbo.Tbl_Services8Master", new[] { "SubCat_Id" });
            DropIndex("dbo.Tbl_Services8Master", new[] { "Cat_Id" });
            DropIndex("dbo.Tbl_Services8HeadingButtons", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_Services8HeadingButtons", new[] { "SubSubCat_Id" });
            DropIndex("dbo.Tbl_Services8HeadingButtons", new[] { "Service_Id" });
            DropIndex("dbo.Tbl_Services7Section6PriceMaster", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_Services7Section6PriceMaster", new[] { "SubSubCat_Id" });
            DropIndex("dbo.Tbl_Services7Section6PriceMaster", new[] { "Service_Id" });
            DropIndex("dbo.Tbl_Services7Section4", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_Services7Section4", new[] { "SubSubCat_Id" });
            DropIndex("dbo.Tbl_Services7Section4", new[] { "Service_Id" });
            DropIndex("dbo.Tbl_Services7Master", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_Services7Master", new[] { "SubSubCat_Id" });
            DropIndex("dbo.Tbl_Services7Master", new[] { "SubCat_Id" });
            DropIndex("dbo.Tbl_Services7Master", new[] { "Cat_Id" });
            DropIndex("dbo.Tbl_Services7HeadingButtons", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_Services7HeadingButtons", new[] { "SubSubCat_Id" });
            DropIndex("dbo.Tbl_Services7HeadingButtons", new[] { "Service_Id" });
            DropIndex("dbo.Tbl_Services6Section2MasterFeaturesDetails", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_Services6Section2MasterFeaturesDetails", new[] { "S6S2M_Id" });
            DropIndex("dbo.Tbl_Services6Section2MasterFeaturesDetails", new[] { "SubSubCat_Id" });
            DropIndex("dbo.Tbl_Services6Section2MasterFeaturesDetails", new[] { "Service_Id" });
            DropIndex("dbo.Tbl_Services6Section2Master", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_Services6Section2Master", new[] { "SubSubCat_Id" });
            DropIndex("dbo.Tbl_Services6Section2Master", new[] { "Service_Id" });
            DropIndex("dbo.Tbl_Services6Master", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_Services6Master", new[] { "SubSubCat_Id" });
            DropIndex("dbo.Tbl_Services6Master", new[] { "SubCat_Id" });
            DropIndex("dbo.Tbl_Services6Master", new[] { "Cat_Id" });
            DropIndex("dbo.Tbl_Services5Section2MasterFeaturesDetails", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_Services5Section2MasterFeaturesDetails", new[] { "S5S2M_Id" });
            DropIndex("dbo.Tbl_Services5Section2MasterFeaturesDetails", new[] { "SubSubCat_Id" });
            DropIndex("dbo.Tbl_Services5Section2MasterFeaturesDetails", new[] { "Service_Id" });
            DropIndex("dbo.Tbl_Services5Section2Master", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_Services5Section2Master", new[] { "SubSubCat_Id" });
            DropIndex("dbo.Tbl_Services5Section2Master", new[] { "Service_Id" });
            DropIndex("dbo.Tbl_Services5Master", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_Services5Master", new[] { "SubSubCat_Id" });
            DropIndex("dbo.Tbl_Services5Master", new[] { "SubCat_Id" });
            DropIndex("dbo.Tbl_Services5Master", new[] { "Cat_Id" });
            DropIndex("dbo.Tbl_Services4Section678FieldValues", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_Services4Section678FieldValues", new[] { "SubSubCat_Id" });
            DropIndex("dbo.Tbl_Services4Section678FieldValues", new[] { "S4S678FM_Id" });
            DropIndex("dbo.Tbl_Services4Section678FieldValues", new[] { "Service_Id" });
            DropIndex("dbo.Tbl_Services4Section678FieldMaster", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_Services4Section678FieldMaster", new[] { "SectionType_ID" });
            DropIndex("dbo.Tbl_Services4Section678FieldMaster", new[] { "SubSubCat_Id" });
            DropIndex("dbo.Tbl_Services4Section678FieldMaster", new[] { "Service_Id" });
            DropIndex("dbo.Tbl_Services4Section345MasterFeaturesDetails", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_Services4Section345MasterFeaturesDetails", new[] { "SubSubCat_Id" });
            DropIndex("dbo.Tbl_Services4Section345MasterFeaturesDetails", new[] { "S4S345M_id" });
            DropIndex("dbo.Tbl_Services4Section345MasterFeaturesDetails", new[] { "Service_Id" });
            DropIndex("dbo.Tbl_Services4Section345MasterButtonsChild", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_Services4Section345MasterButtonsChild", new[] { "SubSubCat_Id" });
            DropIndex("dbo.Tbl_Services4Section345MasterButtonsChild", new[] { "S4S345M_id" });
            DropIndex("dbo.Tbl_Services4Section345MasterButtonsChild", new[] { "Service_Id" });
            DropIndex("dbo.Tbl_Services4Section345Master", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_Services4Section345Master", new[] { "SectionType_ID" });
            DropIndex("dbo.Tbl_Services4Section345Master", new[] { "SubSubCat_Id" });
            DropIndex("dbo.Tbl_Services4Section345Master", new[] { "Service_Id" });
            DropIndex("dbo.Tbl_Services4Section2FAQMapping", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_Services4Section2FAQMapping", new[] { "FAQMaster_Id" });
            DropIndex("dbo.Tbl_Services4Section2FAQMapping", new[] { "SubSubCat_Id" });
            DropIndex("dbo.Tbl_Services4Section2FAQMapping", new[] { "Service_Id" });
            DropIndex("dbo.Tbl_Services4Master", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_Services4Master", new[] { "SubSubCat_Id" });
            DropIndex("dbo.Tbl_Services4Master", new[] { "SubCat_Id" });
            DropIndex("dbo.Tbl_Services4Master", new[] { "Cat_Id" });
            DropIndex("dbo.Tbl_Services3Section6PriceMaster", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_Services3Section6PriceMaster", new[] { "SubSubCat_Id" });
            DropIndex("dbo.Tbl_Services3Section6PriceMaster", new[] { "State_Id" });
            DropIndex("dbo.Tbl_Services3Section6PriceMaster", new[] { "Service_Id" });
            DropIndex("dbo.Tbl_Services3Section4", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_Services3Section4", new[] { "State_Id" });
            DropIndex("dbo.Tbl_Services3Section4", new[] { "SubSubCat_Id" });
            DropIndex("dbo.Tbl_Services3Section4", new[] { "Service_Id" });
            DropIndex("dbo.Tbl_Services3Master", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_Services3Master", new[] { "SubSubCat_Id" });
            DropIndex("dbo.Tbl_Services3Master", new[] { "SubCat_Id" });
            DropIndex("dbo.Tbl_Services3Master", new[] { "Cat_Id" });
            DropIndex("dbo.Tbl_Services3HeadingButtons", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_Services3HeadingButtons", new[] { "SubSubCat_Id" });
            DropIndex("dbo.Tbl_Services3HeadingButtons", new[] { "Service_Id" });
            DropIndex("dbo.Tbl_Services2Section4Master", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_Services2Section4Master", new[] { "SubSubCat_Id" });
            DropIndex("dbo.Tbl_Services2Section4Master", new[] { "Service_Id" });
            DropIndex("dbo.Tbl_Services2Section3DownloadMaster", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_Services2Section3DownloadMaster", new[] { "SubSubCat_Id" });
            DropIndex("dbo.Tbl_Services2Section3DownloadMaster", new[] { "Service_Id" });
            DropIndex("dbo.Tbl_Services2Section2FAQMapping", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_Services2Section2FAQMapping", new[] { "FAQMaster_Id" });
            DropIndex("dbo.Tbl_Services2Section2FAQMapping", new[] { "SubSubCat_Id" });
            DropIndex("dbo.Tbl_Services2Section2FAQMapping", new[] { "Service_Id" });
            DropIndex("dbo.Tbl_Services2Master", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_Services2Master", new[] { "SubSubCat_Id" });
            DropIndex("dbo.Tbl_Services2Master", new[] { "SubCat_Id" });
            DropIndex("dbo.Tbl_Services2Master", new[] { "Cat_Id" });
            DropIndex("dbo.Tbl_Services1Section8FAQMapping", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_Services1Section8FAQMapping", new[] { "FAQMaster_Id" });
            DropIndex("dbo.Tbl_Services1Section8FAQMapping", new[] { "SubSubCat_Id" });
            DropIndex("dbo.Tbl_Services1Section8FAQMapping", new[] { "Service_Id" });
            DropIndex("dbo.Tbl_Services1Section5Master", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_Services1Section5Master", new[] { "SubSubCat_Id" });
            DropIndex("dbo.Tbl_Services1Section5Master", new[] { "Service_Id" });
            DropIndex("dbo.Tbl_Services1Section4Master", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_Services1Section4Master", new[] { "SubSubCat_Id" });
            DropIndex("dbo.Tbl_Services1Section4Master", new[] { "Service_Id" });
            DropIndex("dbo.Tbl_Services1Section1Master", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_Services1Section1Master", new[] { "SubSubCat_Id" });
            DropIndex("dbo.Tbl_Services1Section1Master", new[] { "Service_Id" });
            DropIndex("dbo.Tbl_Services1Section10BankMapping", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_Services1Section10BankMapping", new[] { "BankMaster_Id" });
            DropIndex("dbo.Tbl_Services1Section10BankMapping", new[] { "SubSubCat_Id" });
            DropIndex("dbo.Tbl_Services1Section10BankMapping", new[] { "Service_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "Tenant_ID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetRoles", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_RelatedBlogsMapping", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_RelatedBlogsMapping", new[] { "Related_Blog_Id" });
            DropIndex("dbo.Tbl_RelatedBlogsMapping", new[] { "Blog_Id" });
            DropIndex("dbo.Tbl_StateMaster", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_Services1Section6PriceMaster", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_Services1Section6PriceMaster", new[] { "State_Id" });
            DropIndex("dbo.Tbl_Services1Section6PriceMaster", new[] { "SubSubCat_Id" });
            DropIndex("dbo.Tbl_Services1Section6PriceMaster", new[] { "Service_Id" });
            DropIndex("dbo.Tbl_SubSubCategoriesMaster", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_SubSubCategoriesMaster", new[] { "ServiceType_ID" });
            DropIndex("dbo.Tbl_SubSubCategoriesMaster", new[] { "SubCat_Id" });
            DropIndex("dbo.Tbl_SubSubCategoriesMaster", new[] { "Cat_Id" });
            DropIndex("dbo.Tbl_SubCategoriesMaster", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_SubCategoriesMaster", new[] { "Cat_Id" });
            DropIndex("dbo.Tbl_Services1Master", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_Services1Master", new[] { "SubSubCat_Id" });
            DropIndex("dbo.Tbl_Services1Master", new[] { "SubCat_Id" });
            DropIndex("dbo.Tbl_Services1Master", new[] { "Cat_Id" });
            DropIndex("dbo.Tbl_PriceFeaturesMaster", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_PriceFeaturesMapping", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_PriceFeaturesMapping", new[] { "PriceFeaturesMaster_Id" });
            DropIndex("dbo.Tbl_PriceFeaturesMapping", new[] { "S1S6PM_Id" });
            DropIndex("dbo.Tbl_PriceFeaturesMapping", new[] { "SubSubCat_Id" });
            DropIndex("dbo.Tbl_PriceFeaturesMapping", new[] { "Service_Id" });
            DropIndex("dbo.Tbl_Message", new[] { "Message_Code" });
            DropIndex("dbo.Tbl_IPInfo", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_HomePageSection5", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_HomePageSection4Testimonails", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_HomePageSection4", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_HomePageSection3Features", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_HomePageSection3Features", new[] { "HomePageSection3_Id" });
            DropIndex("dbo.Tbl_HomePageSection3", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_HomePageSection2", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_HomePageSection1", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_HomePageBanner", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_FooterLinks", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_FooterLinks", new[] { "FooterBlockMaster_Id" });
            DropIndex("dbo.Tbl_FooterBlockMaster", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_FAQMaster", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_CommentsReply", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_CommentsReply", new[] { "BCD_Id" });
            DropIndex("dbo.Tbl_CommentsReply", new[] { "Blog_Id" });
            DropIndex("dbo.Tbl_CategoriesMaster", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_BlogCommentsDetails", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_BlogCommentsDetails", new[] { "Blog_Id" });
            DropIndex("dbo.Tbl_BlogMaster", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_BlogBannerNavigationsDetails", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_BlogBannerNavigationsDetails", new[] { "Blog_Id" });
            DropIndex("dbo.Tbl_BannerMaster", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_BankMaster", new[] { "Tenant_ID" });
            DropIndex("dbo.ExceptionLog", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_CodeValue", "IX_CodeVale_CodeIDAndValue");
            DropIndex("dbo.Tbl_Tenant", new[] { "ShippingAddressCityOrDistrict_ID" });
            DropIndex("dbo.Tbl_Tenant", new[] { "ShippingAddressState_ID" });
            DropIndex("dbo.Tbl_Tenant", new[] { "ShippingAddressCountry_ID" });
            DropIndex("dbo.Tbl_Tenant", new[] { "BillingAddressCityOrDistrict_ID" });
            DropIndex("dbo.Tbl_Tenant", new[] { "BillingAddressState_ID" });
            DropIndex("dbo.Tbl_Tenant", new[] { "BillingAddressCountry_ID" });
            DropIndex("dbo.Tbl_SubMenu", new[] { "ParrentMenu_ID" });
            DropIndex("dbo.Tbl_AspNetRoles_SubMenu", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_AspNetRoles_SubMenu", new[] { "SubMenu_ID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Tbl_Services8Section6Master");
            DropTable("dbo.Tbl_Services8Master");
            DropTable("dbo.Tbl_Services8HeadingButtons");
            DropTable("dbo.Tbl_Services7Section6PriceMaster");
            DropTable("dbo.Tbl_Services7Section4");
            DropTable("dbo.Tbl_Services7Master");
            DropTable("dbo.Tbl_Services7HeadingButtons");
            DropTable("dbo.Tbl_Services6Section2MasterFeaturesDetails");
            DropTable("dbo.Tbl_Services6Section2Master");
            DropTable("dbo.Tbl_Services6Master");
            DropTable("dbo.Tbl_Services5Section2MasterFeaturesDetails");
            DropTable("dbo.Tbl_Services5Section2Master");
            DropTable("dbo.Tbl_Services5Master");
            DropTable("dbo.Tbl_Services4Section678FieldValues");
            DropTable("dbo.Tbl_Services4Section678FieldMaster");
            DropTable("dbo.Tbl_Services4Section345MasterFeaturesDetails");
            DropTable("dbo.Tbl_Services4Section345MasterButtonsChild");
            DropTable("dbo.Tbl_Services4Section345Master");
            DropTable("dbo.Tbl_Services4Section2FAQMapping");
            DropTable("dbo.Tbl_Services4Master");
            DropTable("dbo.Tbl_Services3Section6PriceMaster");
            DropTable("dbo.Tbl_Services3Section4");
            DropTable("dbo.Tbl_Services3Master");
            DropTable("dbo.Tbl_Services3HeadingButtons");
            DropTable("dbo.Tbl_Services2Section4Master");
            DropTable("dbo.Tbl_Services2Section3DownloadMaster");
            DropTable("dbo.Tbl_Services2Section2FAQMapping");
            DropTable("dbo.Tbl_Services2Master");
            DropTable("dbo.Tbl_Services1Section8FAQMapping");
            DropTable("dbo.Tbl_Services1Section5Master");
            DropTable("dbo.Tbl_Services1Section4Master");
            DropTable("dbo.Tbl_Services1Section1Master");
            DropTable("dbo.Tbl_Services1Section10BankMapping");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Tbl_RelatedBlogsMapping");
            DropTable("dbo.Tbl_StateMaster");
            DropTable("dbo.Tbl_Services1Section6PriceMaster");
            DropTable("dbo.Tbl_SubSubCategoriesMaster");
            DropTable("dbo.Tbl_SubCategoriesMaster");
            DropTable("dbo.Tbl_Services1Master");
            DropTable("dbo.Tbl_PriceFeaturesMaster");
            DropTable("dbo.Tbl_PriceFeaturesMapping");
            DropTable("dbo.Tbl_Message");
            DropTable("dbo.Tbl_IPInfo");
            DropTable("dbo.Tbl_HomePageSection5");
            DropTable("dbo.Tbl_HomePageSection4Testimonails");
            DropTable("dbo.Tbl_HomePageSection4");
            DropTable("dbo.Tbl_HomePageSection3Features");
            DropTable("dbo.Tbl_HomePageSection3");
            DropTable("dbo.Tbl_HomePageSection2");
            DropTable("dbo.Tbl_HomePageSection1");
            DropTable("dbo.Tbl_HomePageBanner");
            DropTable("dbo.Tbl_FooterLinks");
            DropTable("dbo.Tbl_FooterBlockMaster");
            DropTable("dbo.Tbl_FAQMaster");
            DropTable("dbo.Tbl_CommentsReply");
            DropTable("dbo.Tbl_CategoriesMaster");
            DropTable("dbo.Tbl_BlogCommentsDetails");
            DropTable("dbo.Tbl_BlogMaster");
            DropTable("dbo.Tbl_BlogBannerNavigationsDetails");
            DropTable("dbo.Tbl_BannerMaster");
            DropTable("dbo.Tbl_BankMaster");
            DropTable("dbo.ExceptionLog");
            DropTable("dbo.Tbl_CodeValue");
            DropTable("dbo.Tbl_Code");
            DropTable("dbo.Tbl_Tenant");
            DropTable("dbo.Tbl_SubMenu");
            DropTable("dbo.Tbl_AspNetRoles_SubMenu");
        }
    }
}
