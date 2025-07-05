using NHOM4_QUANLYDATSAN.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NHOM4_QUANLYDATSAN.Forms.Admin
{
    public partial class FormTmp : Form
    {
        frm_TrangChu trangChu;
        frm_NguoiDung nguoiDung;
        frm_CaiDat caiDat;

        public FormTmp()
        {
            InitializeComponent();
            mdiProp();
        }
        private void mdiProp()
        {
            this.SetBevel(false);
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.FromArgb(232, 234, 237);
        }
        private void btn_TrangChu_Click(object sender, EventArgs e)
        {
            if (trangChu == null || trangChu.IsDisposed)
            {
                trangChu = new frm_TrangChu();
                trangChu.FormClosed += TrangChu_FormClosed;
                trangChu.MdiParent = this;
                trangChu.Show();
            }
            else
            {
                trangChu.Activate();
            }
        }

        private void TrangChu_FormClosed(object sender, FormClosedEventArgs e)
        {
            trangChu = null;
        }

        bool sidebarExpanded = true;
        private void sidebarTransition_Tick(object sender, EventArgs e)
        {
            if (sidebarExpanded)
            {
                sidebar.Width -= 5;
                if (sidebar.Width <= 80)
                {
                    sidebarExpanded = false;
                    sidebarTransition.Stop();

                    pn_TrangChu.Width = sidebar.Width;
                    pn_NguoiDung.Width = sidebar.Width;
                    pn_CaiDat.Width = sidebar.Width;
                    pn_DangXuat.Width = sidebar.Width;
                }
            }
            else
            {
                sidebar.Width += 5;
                if (sidebar.Width >= 340)
                {
                    sidebarExpanded = true;
                    sidebarTransition.Stop();

                    pn_TrangChu.Width = sidebar.Width;
                    pn_NguoiDung.Width = sidebar.Width;
                    pn_CaiDat.Width = sidebar.Width;
                    pn_DangXuat.Width = sidebar.Width;
                }
            }
        }

        private void btn_Ham_Click(object sender, EventArgs e)
        {
            sidebarTransition.Start();
        }
    }
}
