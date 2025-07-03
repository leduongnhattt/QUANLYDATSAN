using System;
using System.Collections.Generic;

namespace NHOM4_QUANLYDATSAN.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int RoleID { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public string Address { get; set; }
        public string AvatarPath { get; set; }
        public string Note { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Venue> Venues { get; set; }
        public virtual ICollection<Booking> BookingsCreated { get; set; }
    }
} 