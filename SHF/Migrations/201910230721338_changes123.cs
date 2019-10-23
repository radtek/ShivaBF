namespace SHF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes123 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tbl_BannerNavigationsDetails",
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
                "dbo.Tbl_RelatedBlogsMapping",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Blog_Id = c.Long(),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tbl_RelatedBlogsMapping", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_RelatedBlogsMapping", "Blog_Id", "dbo.Tbl_BlogMaster");
            DropForeignKey("dbo.Tbl_CommentsReply", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_CommentsReply", "Blog_Id", "dbo.Tbl_BlogMaster");
            DropForeignKey("dbo.Tbl_CommentsReply", "BCD_Id", "dbo.Tbl_BlogCommentsDetails");
            DropForeignKey("dbo.Tbl_BlogCommentsDetails", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_BlogCommentsDetails", "Blog_Id", "dbo.Tbl_BlogMaster");
            DropForeignKey("dbo.Tbl_BannerNavigationsDetails", "Tenant_ID", "dbo.Tbl_Tenant");
            DropForeignKey("dbo.Tbl_BannerNavigationsDetails", "Blog_Id", "dbo.Tbl_BlogMaster");
            DropForeignKey("dbo.Tbl_BlogMaster", "Tenant_ID", "dbo.Tbl_Tenant");
            DropIndex("dbo.Tbl_RelatedBlogsMapping", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_RelatedBlogsMapping", new[] { "Blog_Id" });
            DropIndex("dbo.Tbl_CommentsReply", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_CommentsReply", new[] { "BCD_Id" });
            DropIndex("dbo.Tbl_CommentsReply", new[] { "Blog_Id" });
            DropIndex("dbo.Tbl_BlogCommentsDetails", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_BlogCommentsDetails", new[] { "Blog_Id" });
            DropIndex("dbo.Tbl_BlogMaster", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_BannerNavigationsDetails", new[] { "Tenant_ID" });
            DropIndex("dbo.Tbl_BannerNavigationsDetails", new[] { "Blog_Id" });
            DropTable("dbo.Tbl_RelatedBlogsMapping");
            DropTable("dbo.Tbl_CommentsReply");
            DropTable("dbo.Tbl_BlogCommentsDetails");
            DropTable("dbo.Tbl_BlogMaster");
            DropTable("dbo.Tbl_BannerNavigationsDetails");
        }
    }
}
