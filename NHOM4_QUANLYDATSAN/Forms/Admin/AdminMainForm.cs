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
    public partial class AdminMainForm : Form
    {
        frm_TrangChu trangChu;
        frm_NguoiDung nguoiDung;
        frm_CaiDat caiDat;
        private Form activeForm = null;

        public AdminMainForm()
        {
            InitializeComponent();
            mdiProp();
            
            // Khởi tạo cấu hình sidebar đúng
            ConfigureSidebarAndButtons();
            
            // Đăng ký sự kiện resize
            this.Resize += new EventHandler(AdminMainForm_Resize);
            
            // Mặc định mở trang chủ khi khởi động
            btn_TrangChu_Click(this, EventArgs.Empty);
        }
        
        private void AdminMainForm_Resize(object sender, EventArgs e)
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
                trangChu = new frm_TrangChu();
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
                    AdminMainForm_Resize(this, EventArgs.Empty);
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
                                        else if (button == btn_NguoiDung) button.Text = "Người dùng";
                                        
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
                    AdminMainForm_Resize(this, EventArgs.Empty);
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

        private void btn_NguoiDung_Click(object sender, EventArgs e)
        {
            if (nguoiDung == null || nguoiDung.IsDisposed)
            {
                nguoiDung = new frm_NguoiDung();
                nguoiDung.FormClosed += NguoiDung_FormClosed;
                nguoiDung.MdiParent = this;
            }
            OpenChildForm(nguoiDung);
        }

        private void NguoiDung_FormClosed(object sender, FormClosedEventArgs e)
        {
            nguoiDung = null;
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
    }
}
