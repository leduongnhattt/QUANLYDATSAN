using System;
using System.Collections.Generic;

namespace NHOM4_QUANLYDATSAN.Models
{
    public class Tournament
    {
        public int TournamentID { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public string VenueName { get; set; }
    }
}