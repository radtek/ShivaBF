namespace SHF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tbl_IP_Asn",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        asn = c.String(),
                        name = c.String(),
                        domain = c.String(),
                        route = c.String(),
                        type = c.String(),
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
                "dbo.Tbl_IP_Carrier",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        name = c.String(),
                        mcc = c.String(),
                        mnc = c.String(),
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
                "dbo.Tbl_IP_Currency",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        name = c.String(),
                        code = c.String(),
                        symbol = c.String(),
                        native = c.String(),
                        plural = c.String(),
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
                "dbo.Tbl_IP_Language",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        name = c.String(),
                        native = c.String(),
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
                "dbo.Tbl_IP_Threat",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        is_tor = c.Boolean(nullable: false),
                        is_proxy = c.Boolean(nullable: false),
                        is_anonymous = c.Boolean(nullable: false),
                        is_known_attacker = c.Boolean(nullable: false),
                        is_known_abuser = c.Boolean(nullable: false),
                        is_threat = c.Boolean(nullable: false),
                        is_bogon = c.Boolean(nullable: false),
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
                "dbo.Tbl_IP_TimeZone",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        name = c.String(),
                        abbr = c.String(),
                        offset = c.String(),
                        is_dst = c.Boolean(nullable: false),
                        current_time = c.DateTime(nullable: false),
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
            
            AddColumn("dbo.Tbl_BlogCommentsDetails", "IsAdminApproved", c => c.Boolean());
            AddColumn("dbo.Tbl_CommentsReply", "IsAdminApproved", c => c.Boolean());
            AddColumn("dbo.Tbl_IPInfo", "ip", c => c.String());
            AddColumn("dbo.Tbl_IPInfo", "is_eu", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tbl_IPInfo", "region_code", c => c.String());
            AddColumn("dbo.Tbl_IPInfo", "country_name", c => c.String());
            AddColumn("dbo.Tbl_IPInfo", "country_code", c => c.String());
            AddColumn("dbo.Tbl_IPInfo", "continent_name", c => c.String());
            AddColumn("dbo.Tbl_IPInfo", "continent_code", c => c.String());
            AddColumn("dbo.Tbl_IPInfo", "latitude", c => c.Double(nullable: false));
            AddColumn("dbo.Tbl_IPInfo", "longitude", c => c.Double(nullable: false));
            AddColumn("dbo.Tbl_IPInfo", "postal", c => c.String());
            AddColumn("dbo.Tbl_IPInfo", "calling_code", c => c.String());
            AddColumn("dbo.Tbl_IPInfo", "flag", c => c.String());
            AddColumn("dbo.Tbl_IPInfo", "emoji_flag", c => c.String());
            AddColumn("dbo.Tbl_IPInfo", "emoji_unicode", c => c.String());
            AddColumn("dbo.Tbl_IPInfo", "Asn_ID", c => c.Long());
            AddColumn("dbo.Tbl_IPInfo", "Carrier_ID", c => c.Long());
            AddColumn("dbo.Tbl_IPInfo", "Language_ID", c => c.Long());
            AddColumn("dbo.Tbl_IPInfo", "Currency_ID", c => c.Long());
            AddColumn("dbo.Tbl_IPInfo", "TimeZone_ID", c => c.Long());
            AddColumn("dbo.Tbl_IPInfo", "Threat_ID", c => c.Long());
            AddColumn("dbo.Tbl_IPInfo", "count", c => c.String());
            CreateIndex("dbo.Tbl_IPInfo", "Asn_ID");
            CreateIndex("dbo.Tbl_IPInfo", "Carrier_ID");
            CreateIndex("dbo.Tbl_IPInfo", "Language_ID");
            CreateIndex("dbo.Tbl_IPInfo", "Currency_ID");
            CreateIndex("dbo.Tbl_IPInfo", "TimeZone_ID");
            CreateIndex("dbo.Tbl_IPInfo", "Threat_ID");
            AddForeignKey("dbo.Tbl_IPInfo", "Asn_ID", "dbo.Tbl_IP_Asn", "ID");
            AddForeignKey("dbo.Tbl_IPInfo", "Carrier_ID", "dbo.Tbl_IP_Carrier", "ID");
            AddForeignKey("dbo.Tbl_IPInfo", "Currency_ID", "dbo.Tbl_IP_Currency", "ID");
            AddForeignKey("dbo.Tbl_IPInfo", "Language_ID", "dbo.Tbl_IP_Language", "ID");
            AddForeignKey("dbo.Tbl_IPInfo", "Threat_ID", "dbo.Tbl_IP_Threat", "ID");
            AddForeignKey("dbo.Tbl_IPInfo", "TimeZone_ID", "dbo.Tbl_IP_TimeZone", "ID");
            DropColumn("dbo.Tbl_IPInfo", "Status");
            DropColumn("dbo.Tbl_IPInfo", "Country");
            DropColumn("dbo.Tbl_IPInfo", "CountryCode");
            DropColumn("dbo.Tbl_IPInfo", "RegionName");
            DropColumn("dbo.Tbl_IPInfo", "Zip");
            DropColumn("dbo.Tbl_IPInfo", "Lat");
            DropColumn("dbo.Tbl_IPInfo", "Lon");
            DropColumn("dbo.Tbl_IPInfo", "TimeZone");
            DropColumn("dbo.Tbl_IPInfo", "ISP");
            DropColumn("dbo.Tbl_IPInfo", "ORG");
            DropColumn("dbo.Tbl_IPInfo", "AS");
            DropColumn("dbo.Tbl_IPInfo", "Query");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tbl_IPInfo", "Query", c => c.String());
            AddColumn("dbo.Tbl_IPInfo", "AS", c => c.String());
            AddColumn("dbo.Tbl_IPInfo", "ORG", c => c.String());
            AddColumn("dbo.Tbl_IPInfo", "ISP", c => c.String());
            AddColumn("dbo.Tbl_IPInfo", "TimeZone", c => c.String());
            AddColumn("dbo.Tbl_IPInfo", "Lon", c => c.String());
            AddColumn("dbo.Tbl_IPInfo", "Lat", c => c.String());
            AddColumn("dbo.Tbl_IPInfo", "Zip", c => c.String());
            AddColumn("dbo.Tbl_IPInfo", "RegionName", c => c.String());
            AddColumn("dbo.Tbl_IPInfo", "CountryCode", c => c.String());
            AddColumn("dbo.Tbl_IPInfo", "Country", c => c.String());
            AddColumn("dbo.Tbl_IPInfo", "Status", c => c.String());
            DropForeignKey("dbo.Tbl_IPInfo", "TimeZone_ID", "dbo.Tbl_IP_TimeZone");
            DropForeignKey("dbo.Tbl_IP_TimeZone", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_IPInfo", "Threat_ID", "dbo.Tbl_IP_Threat");
            DropForeignKey("dbo.Tbl_IP_Threat", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_IPInfo", "Language_ID", "dbo.Tbl_IP_Language");
            DropForeignKey("dbo.Tbl_IP_Language", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_IPInfo", "Currency_ID", "dbo.Tbl_IP_Currency");
            DropForeignKey("dbo.Tbl_IPInfo", "Carrier_ID", "dbo.Tbl_IP_Carrier");
            DropForeignKey("dbo.Tbl_IPInfo", "Asn_ID", "dbo.Tbl_IP_Asn");
            DropForeignKey("dbo.Tbl_IP_Currency", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_IP_Carrier", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_IP_Asn", "Tenant_ID", "dbo.Tbl_Tenant");
            DropIndex("dbo.Tbl_IP_TimeZone", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_IP_Threat", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_IP_Language", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_IPInfo", new[] { "Threat_ID" });
            DropIndex("dbo.Tbl_IPInfo", new[] { "TimeZone_ID" });
            DropIndex("dbo.Tbl_IPInfo", new[] { "Currency_ID" });
            DropIndex("dbo.Tbl_IPInfo", new[] { "Language_ID" });
            DropIndex("dbo.Tbl_IPInfo", new[] { "Carrier_ID" });
            DropIndex("dbo.Tbl_IPInfo", new[] { "Asn_ID" });
            DropIndex("dbo.Tbl_IP_Currency", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_IP_Carrier", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_IP_Asn", new[] { "Tenant_ID" });
            DropColumn("dbo.Tbl_IPInfo", "count");
            DropColumn("dbo.Tbl_IPInfo", "Threat_ID");
            DropColumn("dbo.Tbl_IPInfo", "TimeZone_ID");
            DropColumn("dbo.Tbl_IPInfo", "Currency_ID");
            DropColumn("dbo.Tbl_IPInfo", "Language_ID");
            DropColumn("dbo.Tbl_IPInfo", "Carrier_ID");
            DropColumn("dbo.Tbl_IPInfo", "Asn_ID");
            DropColumn("dbo.Tbl_IPInfo", "emoji_unicode");
            DropColumn("dbo.Tbl_IPInfo", "emoji_flag");
            DropColumn("dbo.Tbl_IPInfo", "flag");
            DropColumn("dbo.Tbl_IPInfo", "calling_code");
            DropColumn("dbo.Tbl_IPInfo", "postal");
            DropColumn("dbo.Tbl_IPInfo", "longitude");
            DropColumn("dbo.Tbl_IPInfo", "latitude");
            DropColumn("dbo.Tbl_IPInfo", "continent_code");
            DropColumn("dbo.Tbl_IPInfo", "continent_name");
            DropColumn("dbo.Tbl_IPInfo", "country_code");
            DropColumn("dbo.Tbl_IPInfo", "country_name");
            DropColumn("dbo.Tbl_IPInfo", "region_code");
            DropColumn("dbo.Tbl_IPInfo", "is_eu");
            DropColumn("dbo.Tbl_IPInfo", "ip");
            DropColumn("dbo.Tbl_CommentsReply", "IsAdminApproved");
            DropColumn("dbo.Tbl_BlogCommentsDetails", "IsAdminApproved");
            DropTable("dbo.Tbl_IP_TimeZone");
            DropTable("dbo.Tbl_IP_Threat");
            DropTable("dbo.Tbl_IP_Language");
            DropTable("dbo.Tbl_IP_Currency");
            DropTable("dbo.Tbl_IP_Carrier");
            DropTable("dbo.Tbl_IP_Asn");
        }
    }
}
