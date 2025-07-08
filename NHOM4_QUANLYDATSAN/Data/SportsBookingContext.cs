using NHOM4_QUANLYDATSAN.Models;
using System.Data.Entity;

namespace NHOM4_QUANLYDATSAN.Data
{
    public class SportsBookingContext : DbContext
    {
        public SportsBookingContext()
            : base("name=SportsBookingContext")
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Court> Courts { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }

        // Configuring the relationship between Court and User to avoid cascading issues
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Court>()
                .HasRequired(c => c.User)
                .WithMany(u => u.CourtsManaged)
                .HasForeignKey(c => c.UserID)
                .WillCascadeOnDelete(false); 

            base.OnModelCreating(modelBuilder);
        }
    }
}
