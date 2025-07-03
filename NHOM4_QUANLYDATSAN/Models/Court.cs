using System.Collections.Generic;

namespace NHOM4_QUANLYDATSAN.Models
{
    public class Court
    {
        public int CourtID { get; set; }
        public int VenueID { get; set; }
        public string CourtName { get; set; }
        public string SportType { get; set; }
        public decimal PricePerHour { get; set; }
        public string Status { get; set; }
        public string ImagePath { get; set; }
        public string Note { get; set; }

        public virtual Venue Venue { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
} 