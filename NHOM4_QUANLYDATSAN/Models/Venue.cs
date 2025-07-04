using System;
using System.Collections.Generic;

namespace NHOM4_QUANLYDATSAN.Models
{
    public class Venue
    {
        public int VenueID { get; set; }
        public int OwnerUserID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal LocationLat { get; set; }
        public decimal LocationLng { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ImagePath { get; set; }
        public string Note { get; set; }

        public virtual User Owner { get; set; }
        public virtual ICollection<Court> Courts { get; set; }
        public virtual ICollection<Tournament> Tournaments { get; set; }
    }
} 