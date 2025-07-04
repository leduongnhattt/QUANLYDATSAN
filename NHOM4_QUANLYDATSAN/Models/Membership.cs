using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NHOM4_QUANLYDATSAN.Models
{
    public class Membership
    {
        [Key]
        public int MemberID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string Email { get; set; }
        public string MembershipType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal DiscountRate { get; set; }
        public string Note { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
} 