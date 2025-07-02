using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHOM4_QUANLYDATSAN.Services
{
    public interface IAuthenticationService
    {
        Task<bool> LoginAsync(string username, string password);
    }
}
