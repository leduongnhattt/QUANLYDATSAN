namespace NHOM4_QUANLYDATSAN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateFieldsForInvoice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Memberships", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.Memberships", "UserID");
            AddForeignKey("dbo.Memberships", "UserID", "dbo.Users", "UserID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Memberships", "UserID", "dbo.Users");
            DropIndex("dbo.Memberships", new[] { "UserID" });
            DropColumn("dbo.Memberships", "UserID");
        }
    }
}
