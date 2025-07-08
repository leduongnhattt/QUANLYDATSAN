using System;

namespace NHOM4_QUANLYDATSAN.Models
{
    public class Booking
    {
        public int BookingID { get; set; }
        public int CourtID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public int? MemberID { get; set; }
        public DateTime BookingDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Status { get; set; }
        public int CreatedByUserID { get; set; }
        public string Note { get; set; }
        public virtual Court Court { get; set; }
        public virtual Membership Membership { get; set; }
        public virtual User CreatedBy { get; set; }
    }
}