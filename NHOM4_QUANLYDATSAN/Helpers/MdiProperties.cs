﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NHOM4_QUANLYDATSAN.Helpers
{
    public static class MdiProperties
    {
        [DllImport("user32.dll")]

        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        private static extern int SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        private const int GWL_STYLE = -20;
        private const int WS_EX_CLIENTEDGE = 0x0200;
        private const uint SWP_NOSIZE = 0x0001;
        private const uint SWP_NOMOVE = 0x0002;
        private const uint SWP_NOZORDER = 0x0004;
        private const uint SWO_NOACTIVATE = 0x0010;
        private const uint SWP_FRAMECHANGED = 0x0020;
        private const uint SWO_NOOWNERZORDER = 0x0200;

        public static bool SetBevel(this Form form, bool show)
        {
            foreach (Control control in form.Controls)
            {
                MdiClient mdiClient = control as MdiClient;
                if (mdiClient != null)
                {
                    int windowLong = GetWindowLong(control.Handle, GWL_STYLE);
                    if (show)
                    {
                        windowLong |= WS_EX_CLIENTEDGE;
                    }
                    else
                    {
                        windowLong &= WS_EX_CLIENTEDGE;
                    }
                    SetWindowLong(control.Handle, GWL_STYLE, windowLong);
                    SetWindowPos(mdiClient.Handle, IntPtr.Zero, 0, 0, 0, 0, SWP_NOSIZE | SWP_NOMOVE | SWP_NOZORDER | SWO_NOACTIVATE | SWP_FRAMECHANGED | SWO_NOOWNERZORDER);

                    return true;
                }
            }
            return false;
        }
    }
}
