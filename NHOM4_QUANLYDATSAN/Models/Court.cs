using System;
using System.Collections.Generic;

namespace NHOM4_QUANLYDATSAN.Models
{
    public class Court
    {
        public int CourtID { get; set; }
        public string CourtName { get; set; }
        public string SportType { get; set; }
        public decimal PricePerHour { get; set; }
        public string Status { get; set; }
        public string ImagePath { get; set; }
        public string Note { get; set; }
        public string VenueName { get; set; }
        public TimeSpan TimeOpen { get; set; } 
        public TimeSpan TimeClose { get; set; } 
        public int CountTime { get; set; } 
        public virtual ICollection<Schedule> Schedules { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }
    }
}