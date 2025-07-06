using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHOM4_QUANLYDATSAN.Data;
using NHOM4_QUANLYDATSAN.Models; 

namespace NHOM4_QUANLYDATSAN.Services
{
    public class AuthenticationService 
    {
        public bool ValidatePassword(string password)
        {
            if (password.Length < 6)
                return false;

            bool hasSpecialChar = password.Any(ch => !char.IsLetterOrDigit(ch));
            bool hasDigit = password.Any(ch => char.IsDigit(ch));

            return hasSpecialChar && hasDigit;
        }

        public bool Authenticate(string username, string password, out string role)
        {
            using (var context = new SportsBookingContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
                if (user != null)
                {
                    role = user.Role.RoleName; 
                    return true;
                }
                role = null;
                return false;
            }
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            await Task.Delay(100); // Simulate async operation
            return Authenticate(username, password, out _);
        }
    }
}
