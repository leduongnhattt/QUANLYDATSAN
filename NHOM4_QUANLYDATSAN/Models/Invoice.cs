using System;

namespace NHOM4_QUANLYDATSAN.Models
{
    public class Invoice
    {
        public int InvoiceID { get; set; }
        public int BookingID { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string InvoiceFilePath { get; set; }
        public string Note { get; set; }

        public virtual Booking Booking { get; set; }
    }
} 