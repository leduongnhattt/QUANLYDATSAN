using NHOM4_QUANLYDATSAN.Data;
using NHOM4_QUANLYDATSAN.Forms.Admin;
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

namespace NHOM4_QUANLYDATSAN.Forms.Owner
{
    public partial class OwnerMainForm : Form
    {
        frm_TrangChu trangChu;
        frm_HoiVien hoiVien;
        frm_CaiDat caiDat;
        frm_DatSan datSan;
        frm_QuanLySan quanLySan;
        frm_QuanLyDatSan quanLyDatSan;

        private Form activeForm = null;
        private string _username;
        string email = "";
        public OwnerMainForm(string username)
        {
            InitializeComponent();
            mdiProp();
            _username = username;
            using (var context = new SportsBookingContext())
            {
                email = context.Users
                    .Where(u => u.Username == _username && u.RoleID == 2)
                    .Select(u => u.Email)
                    .FirstOrDefault();
            }
            // Khởi tạo cấu hình sidebar đúng
            ConfigureSidebarAndButtons();
            this.lbl_ChaoMung.Text = $"CHÀO MỪNG {_username.ToLower()} ĐẾN VỚI HỆ THỐNG QUẢN LÝ SÂN THỂ THAO!";

            // Đăng ký sự kiện resize
            this.Resize += new EventHandler(OwnerMainForm_Resize);
                // Mặc định mở trang chủ khi khởi động
                if (trangChu == null || trangChu.IsDisposed)
                {
                    trangChu = new frm_TrangChu(_username, email);
                    trangChu.FormClosed += TrangChu_FormClosed;
                    trangChu.MdiParent = this;
                }
            OpenChildForm(trangChu);
        }

        private void OwnerMainForm_Resize(object sender, EventArgs e)
        {
            // Cập nhật kích thước cho tất cả form con
            foreach (Form childForm in this.MdiChildren)
            {
                if (childForm.Visible)
                {
                    childForm.Width = this.ClientSize.Width - sidebar.Width;
                    childForm.Height = this.ClientSize.Height;
                    childForm.Left = sidebar.Width;
                    childForm.Top = 0;
                }
            }
        }

        private void mdiProp()
        {
            this.SetBevel(false);
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.FromArgb(232, 234, 237);
        }

        // Phương thức để ẩn tất cả các form con đang mở
        private void HideAllOpenForms()
        {
            foreach (Form childForm in this.MdiChildren)
            {
                childForm.Hide();
            }
        }

        // Phương thức để mở một form con
        private void OpenChildForm(Form childForm)
        {
            // Ẩn tất cả các form con đang mở
            HideAllOpenForms();

            // Cập nhật form đang hoạt động
            activeForm = childForm;

            // Đặt form làm MDI child nếu chưa được đặt
            if (childForm.MdiParent == null)
                childForm.MdiParent = this;

            // Hiển thị form
            childForm.Show();
            childForm.BringToFront();
            childForm.Dock = DockStyle.Fill;
        }

        private void btn_TrangChu_Click(object sender, EventArgs e)
        {
            if (trangChu == null || trangChu.IsDisposed)
            {
                trangChu = new frm_TrangChu(_username, email);
                trangChu.FormClosed += TrangChu_FormClosed;
                trangChu.MdiParent = this;
            }
            OpenChildForm(trangChu);
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

                    // Điều chỉnh kích thước của các panel và button
                    foreach (Control panel in sidebar.Controls)
                    {
                        if (panel is Panel)
                        {
                            panel.Width = sidebar.Width - 6;
                            foreach (Control btn in panel.Controls)
                            {
                                if (btn is Button)
                                {
                                    btn.Width = sidebar.Width + 10;

                                    Button button = btn as Button;
                                    if (button != null)
                                    {
                                        button.TextAlign = ContentAlignment.MiddleCenter;
                                        button.ImageAlign = ContentAlignment.MiddleCenter;
                                        button.Text = "";
                                        button.Padding = new Padding(0);
                                        button.TextImageRelation = TextImageRelation.ImageBeforeText;
                                    }
                                }
                            }
                        }
                    }

                    // Cập nhật lại vị trí và kích thước của form con khi sidebar thu hẹp
                    OwnerMainForm_Resize(this, EventArgs.Empty);
                }
            }
            else
            {
                sidebar.Width += 5;
                if (sidebar.Width >= 336)
                {
                    sidebarExpanded = true;
                    sidebarTransition.Stop();

                    // Điều chỉnh kích thước của các panel và button
                    foreach (Control panel in sidebar.Controls)
                    {
                        if (panel is Panel)
                        {
                            panel.Width = sidebar.Width - 8;
                            foreach (Control btn in panel.Controls)
                            {
                                if (btn is Button)
                                {
                                    btn.Width = sidebar.Width + 8;
                                    Button button = btn as Button;
                                    if (button != null)
                                    {
                                        // Khôi phục lại text cho các button
                                        if (button == btn_TrangChu) button.Text = "Trang chủ";
                                        else if (button == btn_CaiDat) button.Text = "Cài Đặt";
                                        else if (button == btn_DangXuat) button.Text = "Đăng Xuất";
                                        else if (button == btn_DatSan) button.Text = "Đặt Sân";
                                        else if (button == btn_HoiVien) button.Text = "Hội viên";
                                        else if (button == btn_QuanLySan) button.Text = "Quản lý sân";
                                        else if (button == btn_QuanLyDatSan) button.Text = "Quản lý đặt sân";

                                        button.TextAlign = ContentAlignment.MiddleLeft;
                                        button.ImageAlign = ContentAlignment.MiddleLeft;
                                        button.Padding = new Padding(15, 0, 0, 0);
                                        button.TextImageRelation = TextImageRelation.ImageBeforeText;
                                    }
                                }
                            }
                        }
                    }

                    // Cập nhật lại vị trí và kích thước của form con khi sidebar mở rộng
                    OwnerMainForm_Resize(this, EventArgs.Empty);
                }
            }
        }

        private void btn_Ham_Click(object sender, EventArgs e)
        {
            sidebarTransition.Start();
        }

        private void ConfigureSidebarAndButtons()
        {
            // Đặt lại kích thước panel và button
            foreach (Control panel in sidebar.Controls)
            {
                if (panel is Panel)
                {
                    panel.Width = sidebar.Width - 8;
                    foreach (Control btn in panel.Controls)
                    {
                        if (btn is Button)
                        {
                            btn.Width = panel.Width;
                            btn.Height = panel.Height;
                            btn.Location = new Point(0, 0);

                            Button button = btn as Button;
                            if (button != null)
                            {
                                button.TextAlign = ContentAlignment.MiddleLeft;
                                button.ImageAlign = ContentAlignment.MiddleLeft;
                                button.Padding = new Padding(15, 0, 0, 0);
                                button.TextImageRelation = TextImageRelation.ImageBeforeText;

                                int spacing = 20;
                                button.Padding = new Padding(15, 0, 0, 0);
                                button.ImageAlign = ContentAlignment.MiddleLeft;
                            }
                            btn.Dock = DockStyle.Fill;
                        }
                    }
                }
            }
        }


        private void btn_CaiDat_Click(object sender, EventArgs e)
        {
            if (caiDat == null || caiDat.IsDisposed)
            {
                caiDat = new frm_CaiDat();
                caiDat.FormClosed += CaiDat_FormClosed;
                caiDat.MdiParent = this;
            }
            OpenChildForm(caiDat);
        }

        private void CaiDat_FormClosed(object sender, FormClosedEventArgs e)
        {
            caiDat = null;
        }

        private void btn_DangXuat_Click(object sender, EventArgs e)
        {
            // Xử lý sự kiện đăng xuất
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Đóng tất cả form con
                foreach (Form childForm in this.MdiChildren)
                {
                    childForm.Close();
                }
                this.Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
        }

        private void btn_DatSan_Click(object sender, EventArgs e)
        {
            if (datSan == null || datSan.IsDisposed)
            {
                datSan = new frm_DatSan(_username, email);
                datSan.FormClosed += DatSan_FormClosed;
                datSan.MdiParent = this;
            }
            OpenChildForm(datSan);
        }
        private void DatSan_FormClosed(object sender, FormClosedEventArgs e)
        {
            caiDat = null;
        }

        private void btn_QuanLyDatSan_Click(object sender, EventArgs e)
        {
            if (quanLyDatSan == null || quanLyDatSan.IsDisposed)
            {
                quanLyDatSan = new frm_QuanLyDatSan(_username, email);
                quanLyDatSan.FormClosed += quanLyDatSan_FormClosed;
                quanLyDatSan.MdiParent = this;
            }
            OpenChildForm(quanLyDatSan);
        }

        private void btn_QuanLySan_Click(object sender, EventArgs e)
        {
            if (quanLySan == null || quanLySan.IsDisposed)
            {
                quanLySan = new frm_QuanLySan(_username, email);
                quanLySan.FormClosed += QuanLySan_FormClosed;
                quanLySan.MdiParent = this;
            }
            OpenChildForm(quanLySan);
        }

        private void QuanLySan_FormClosed(object sender, FormClosedEventArgs e)
        {
            quanLySan = null;
        }
        private void quanLyDatSan_FormClosed(object sender, FormClosedEventArgs e)
        {
            quanLyDatSan = null;
        }

        private void btn_HoiVien_Click(object sender, EventArgs e)
        {
            if (hoiVien == null || hoiVien.IsDisposed)
            {
                hoiVien = new frm_HoiVien(_username, email);
                hoiVien.FormClosed += HoiVien_FormClosed;
                hoiVien.MdiParent = this;
            }
            OpenChildForm(hoiVien);
        }
        private void HoiVien_FormClosed(object sender, FormClosedEventArgs e)
        {
            hoiVien = null;
        }
    }
}
