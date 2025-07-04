namespace NHOM4_QUANLYDATSAN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingID = c.Int(nullable: false, identity: true),
                        CourtID = c.Int(nullable: false),
                        CustomerName = c.String(),
                        CustomerPhone = c.String(),
                        MemberID = c.Int(),
                        BookingDate = c.DateTime(nullable: false),
                        StartTime = c.Time(nullable: false, precision: 7),
                        EndTime = c.Time(nullable: false, precision: 7),
                        Status = c.String(),
                        CreatedByUserID = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.BookingID)
                .ForeignKey("dbo.Courts", t => t.CourtID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.CreatedByUserID, cascadeDelete: true)
                .ForeignKey("dbo.Memberships", t => t.MemberID)
                .Index(t => t.CourtID)
                .Index(t => t.MemberID)
                .Index(t => t.CreatedByUserID);
            
            CreateTable(
                "dbo.Courts",
                c => new
                    {
                        CourtID = c.Int(nullable: false, identity: true),
                        VenueID = c.Int(nullable: false),
                        CourtName = c.String(),
                        SportType = c.String(),
                        PricePerHour = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.String(),
                        ImagePath = c.String(),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.CourtID)
                .ForeignKey("dbo.Venues", t => t.VenueID, cascadeDelete: true)
                .Index(t => t.VenueID);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        ScheduleID = c.Int(nullable: false, identity: true),
                        CourtID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        StartTime = c.Time(nullable: false, precision: 7),
                        EndTime = c.Time(nullable: false, precision: 7),
                        IsBlocked = c.Boolean(nullable: false),
                        BlockReason = c.String(),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.ScheduleID)
                .ForeignKey("dbo.Courts", t => t.CourtID, cascadeDelete: true)
                .Index(t => t.CourtID);
            
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
                .PrimaryKey(t => t.VenueID)
                .ForeignKey("dbo.Users", t => t.OwnerUserID)
                .Index(t => t.OwnerUserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        PasswordHash = c.String(),
                        FullName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        RoleID = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Address = c.String(),
                        AvatarPath = c.String(),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Roles", t => t.RoleID, cascadeDelete: true)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.Tournaments",
                c => new
                    {
                        TournamentID = c.Int(nullable: false, identity: true),
                        VenueID = c.Int(nullable: false),
                        Name = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.TournamentID)
                .ForeignKey("dbo.Venues", t => t.VenueID, cascadeDelete: true)
                .Index(t => t.VenueID);
            
            CreateTable(
                "dbo.Memberships",
                c => new
                    {
                        MemberID = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        CustomerPhone = c.String(),
                        Email = c.String(),
                        MembershipType = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        DiscountRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.MemberID);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceID = c.Int(nullable: false, identity: true),
                        BookingID = c.Int(nullable: false),
                        InvoiceDate = c.DateTime(nullable: false),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InvoiceFilePath = c.String(),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.InvoiceID)
                .ForeignKey("dbo.Bookings", t => t.BookingID, cascadeDelete: true)
                .Index(t => t.BookingID);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentID = c.Int(nullable: false, identity: true),
                        BookingID = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentMethod = c.String(),
                        PaymentDate = c.DateTime(nullable: false),
                        Status = c.String(),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.PaymentID)
                .ForeignKey("dbo.Bookings", t => t.BookingID, cascadeDelete: true)
                .Index(t => t.BookingID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "BookingID", "dbo.Bookings");
            DropForeignKey("dbo.Invoices", "BookingID", "dbo.Bookings");
            DropForeignKey("dbo.Bookings", "MemberID", "dbo.Memberships");
            DropForeignKey("dbo.Tournaments", "VenueID", "dbo.Venues");
            DropForeignKey("dbo.Venues", "OwnerUserID", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.Bookings", "CreatedByUserID", "dbo.Users");
            DropForeignKey("dbo.Courts", "VenueID", "dbo.Venues");
            DropForeignKey("dbo.Schedules", "CourtID", "dbo.Courts");
            DropForeignKey("dbo.Bookings", "CourtID", "dbo.Courts");
            DropIndex("dbo.Payments", new[] { "BookingID" });
            DropIndex("dbo.Invoices", new[] { "BookingID" });
            DropIndex("dbo.Tournaments", new[] { "VenueID" });
            DropIndex("dbo.Users", new[] { "RoleID" });
            DropIndex("dbo.Venues", new[] { "OwnerUserID" });
            DropIndex("dbo.Schedules", new[] { "CourtID" });
            DropIndex("dbo.Courts", new[] { "VenueID" });
            DropIndex("dbo.Bookings", new[] { "CreatedByUserID" });
            DropIndex("dbo.Bookings", new[] { "MemberID" });
            DropIndex("dbo.Bookings", new[] { "CourtID" });
            DropTable("dbo.Payments");
            DropTable("dbo.Invoices");
            DropTable("dbo.Memberships");
            DropTable("dbo.Tournaments");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Venues");
            DropTable("dbo.Schedules");
            DropTable("dbo.Courts");
            DropTable("dbo.Bookings");
        }
    }
}
