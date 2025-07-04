using System;

namespace NHOM4_QUANLYDATSAN.Models
{
    public class Schedule
    {
        public int ScheduleID { get; set; }
        public int CourtID { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool IsBlocked { get; set; }
        public string BlockReason { get; set; }
        public string Note { get; set; }

        public virtual Court Court { get; set; }
    }
} 