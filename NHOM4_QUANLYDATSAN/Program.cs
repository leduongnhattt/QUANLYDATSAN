using NHOM4_QUANLYDATSAN.Forms;
using NHOM4_QUANLYDATSAN.Forms.Admin;
using NHOM4_QUANLYDATSAN.Forms.Owner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NHOM4_QUANLYDATSAN
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new OwnerMainForm("nhatle"));
            //Application.Run(new AdminMainForm());
        }
    }
}
