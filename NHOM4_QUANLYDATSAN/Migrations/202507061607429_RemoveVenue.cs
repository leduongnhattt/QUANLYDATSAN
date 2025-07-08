using System;
using System.Data.Entity.Migrations;

namespace NHOM4_QUANLYDATSAN.Migrations
{

    public partial class RemoveVenue : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courts", "VenueID", "dbo.Venues");
            DropForeignKey("dbo.Venues", "OwnerUserID", "dbo.Users");
            DropForeignKey("dbo.Tournaments", "VenueID", "dbo.Venues");
            DropIndex("dbo.Courts", new[] { "VenueID" });
            DropIndex("dbo.Venues", new[] { "OwnerUserID" });
            DropIndex("dbo.Tournaments", new[] { "VenueID" });
            AddColumn("dbo.Courts", "VenueName", c => c.String());
            AddColumn("dbo.Tournaments", "VenueName", c => c.String());
            DropColumn("dbo.Courts", "VenueID");
            DropColumn("dbo.Tournaments", "VenueID");
            DropTable("dbo.Venues");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Venues",
                c => new
                    {
                        VenueID = c.Int(nullable: false, identity: true),
                        OwnerUserID = c.Int(nullable: false),
                        Name = c.String(),
                        Address = c.String(),
                        LocationLat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LocationLng = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        ImagePath = c.String(),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.VenueID);
            
            AddColumn("dbo.Tournaments", "VenueID", c => c.Int(nullable: false));
            AddColumn("dbo.Courts", "VenueID", c => c.Int(nullable: false));
            DropColumn("dbo.Tournaments", "VenueName");
            DropColumn("dbo.Courts", "VenueName");
            CreateIndex("dbo.Tournaments", "VenueID");
            CreateIndex("dbo.Venues", "OwnerUserID");
            CreateIndex("dbo.Courts", "VenueID");
            AddForeignKey("dbo.Tournaments", "VenueID", "dbo.Venues", "VenueID", cascadeDelete: true);
            AddForeignKey("dbo.Venues", "OwnerUserID", "dbo.Users", "UserID");
            AddForeignKey("dbo.Courts", "VenueID", "dbo.Venues", "VenueID", cascadeDelete: true);
        }
    }
}
