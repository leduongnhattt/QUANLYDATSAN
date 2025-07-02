using System.Data.Entity;

namespace NHOM4_QUANLYDATSAN.Data
{
    public class SportsBookingContext : DbContext
    {
        public SportsBookingContext()
            : base("name=SportsBookingContext")
        {
        }
    }

}
