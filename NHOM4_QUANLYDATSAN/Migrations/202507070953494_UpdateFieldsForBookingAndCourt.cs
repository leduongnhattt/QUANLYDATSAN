namespace NHOM4_QUANLYDATSAN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateFieldsForBookingAndCourt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courts", "TimeOpen", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.Courts", "TimeClose", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.Courts", "CountTime", c => c.Int(nullable: false));
            DropColumn("dbo.Bookings", "CreatedAt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bookings", "CreatedAt", c => c.DateTime(nullable: false));
            DropColumn("dbo.Courts", "CountTime");
            DropColumn("dbo.Courts", "TimeClose");
            DropColumn("dbo.Courts", "TimeOpen");
        }
    }
}
