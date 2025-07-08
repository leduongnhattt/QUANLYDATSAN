using System;
using System.Data.Entity.Migrations;
namespace NHOM4_QUANLYDATSAN.Migrations
{
    
    public partial class UpdateCourtAndUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courts", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.Courts", "UserID");
            AddForeignKey("dbo.Courts", "UserID", "dbo.Users", "UserID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courts", "UserID", "dbo.Users");
            DropIndex("dbo.Courts", new[] { "UserID" });
            DropColumn("dbo.Courts", "UserID");
        }
    }
}
