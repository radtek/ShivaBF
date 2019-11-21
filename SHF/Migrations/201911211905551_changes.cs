namespace SHF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_BlogCommentsDetails", "IsAdminApproved", c => c.Boolean());
            AddColumn("dbo.Tbl_CommentsReply", "IsAdminApproved", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_CommentsReply", "IsAdminApproved");
            DropColumn("dbo.Tbl_BlogCommentsDetails", "IsAdminApproved");
        }
    }
}
