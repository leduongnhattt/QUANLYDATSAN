using System.Collections.Generic;

namespace NHOM4_QUANLYDATSAN.Models
{
    public class Role
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
} 