namespace SHF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setup1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_RelatedBlogsMapping", "Related_Blog_Id", c => c.Long());
            CreateIndex("dbo.Tbl_RelatedBlogsMapping", "Related_Blog_Id");
            AddForeignKey("dbo.Tbl_RelatedBlogsMapping", "Related_Blog_Id", "dbo.Tbl_BlogMaster", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tbl_RelatedBlogsMapping", "Related_Blog_Id", "dbo.Tbl_BlogMaster");
            DropIndex("dbo.Tbl_RelatedBlogsMapping", new[] { "Related_Blog_Id" });
            DropColumn("dbo.Tbl_RelatedBlogsMapping", "Related_Blog_Id");
        }
    }
}
