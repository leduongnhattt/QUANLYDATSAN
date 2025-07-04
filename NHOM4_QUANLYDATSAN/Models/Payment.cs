using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NHOM4_QUANLYDATSAN.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }
        [ForeignKey("Booking")]
        public int BookingID { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }

        public virtual Booking Booking { get; set; }
    }
} 