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
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserRoles", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.AspNetRoles", "Tenant_ID", "dbo.Tbl_Tenant");
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
            DropIndex("dbo.AspNetUserRoles", new[] { "Tenant_ID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetRoles", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_Message", new[] { "Message_Code" });
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
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Tbl_Message");
            DropTable("dbo.ExceptionLog");
            DropTable("dbo.Tbl_CodeValue");
            DropTable("dbo.Tbl_Code");
            DropTable("dbo.Tbl_Tenant");
            DropTable("dbo.Tbl_SubMenu");
            DropTable("dbo.Tbl_AspNetRoles_SubMenu");
        }
    }
}
