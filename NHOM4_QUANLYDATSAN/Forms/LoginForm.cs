using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace NHOM4_QUANLYDATSAN.Forms
{
    public partial class LoginForm : Form
    {
        private bool isPasswordVisible = false;
        private readonly string usernamePlaceholder = "Tên đăng nhập";
        private readonly string passwordPlaceholder = "Mật khẩu";
        private bool isTextChangedRegistered = false;

        public LoginForm()
        {
            InitializeComponent();
            // Cho phép kéo form bằng title bar custom
            panelTitleBar.MouseDown += PanelTitleBar_MouseDown;
            if (!isTextChangedRegistered)
            {
                txtPassword.TextChanged += TxtPassword_TextChanged;
                isTextChangedRegistered = true;
            }
        }

        // Vẽ gradient nền hiện đại cho panelGradient
        private void panelGradient_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = panelGradient.ClientRectangle;
            // Gradient nhiều màu: xanh dương - tím - xanh lá
            Color[] colors = { Color.FromArgb(0, 180, 220), Color.FromArgb(120, 60, 220), Color.FromArgb(0, 220, 180) };
            float[] positions = { 0f, 0.5f, 1f };
            using (LinearGradientBrush brush = new LinearGradientBrush(rect, colors[0], colors[2], 45F))
            {
                ColorBlend blend = new ColorBlend();
                blend.Colors = colors;
                blend.Positions = positions;
                brush.InterpolationColors = blend;
                e.Graphics.FillRectangle(brush, rect);
            }
            // Vẽ các ellipse mờ làm điểm nhấn
            using (SolidBrush ellipseBrush = new SolidBrush(Color.FromArgb(40, 255, 255, 255)))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.FillEllipse(ellipseBrush, rect.Width - 300, 60, 200, 120);
                e.Graphics.FillEllipse(ellipseBrush, rect.Width - 500, rect.Height - 200, 250, 120);
                e.Graphics.FillEllipse(ellipseBrush, rect.Width - 150, rect.Height - 150, 120, 80);
            }
            // Vẽ bóng mờ cho chữ lớn
            string text = "HỆ THỐNG QUẢN LÝ ĐẶT SÂN";
            Font font = new Font("Segoe UI", 28F, FontStyle.Bold);
            SizeF textSize = e.Graphics.MeasureString(text, font);
            float x = (rect.Width - textSize.Width) / 2;
            float y = (rect.Height - textSize.Height) / 2;
            for (int i = 1; i <= 8; i++)
            {
                e.Graphics.DrawString(text, font, new SolidBrush(Color.FromArgb(30, 0, 0, 0)), x + i, y + i);
            }
            e.Graphics.DrawString(text, font, Brushes.White, x, y);

            // Vẽ dòng chữ nhỏ ở góc dưới bên phải
            string subText = "PHẦN MỀM ĐẶT SÂN BÓNG - NHÓM 4";
            Font subFont = new Font("Segoe UI", 14F, FontStyle.Italic);
            SizeF subSize = e.Graphics.MeasureString(subText, subFont);
            float subX = rect.Width - subSize.Width - 30;
            float subY = rect.Height - subSize.Height - 20;
            using (SolidBrush subBrush = new SolidBrush(Color.FromArgb(180, 255, 255, 255)))
            {
                e.Graphics.DrawString(subText, subFont, subBrush, subX, subY);
            }
        }

        // Placeholder cho Username
        private void txtUsername_GotFocus(object sender, EventArgs e)
        {
            if (txtUsername.Text == usernamePlaceholder)
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = Color.Black;
            }
        }
        private void txtUsername_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                txtUsername.Text = usernamePlaceholder;
                txtUsername.ForeColor = Color.Gray;
            }
        }

        // Placeholder cho Password
        private void txtPassword_GotFocus(object sender, EventArgs e)
        {
            if (txtPassword.Text == passwordPlaceholder)
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
                txtPassword.UseSystemPasswordChar = !isPasswordVisible ? true : false;
            }
        }
        private void txtPassword_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.Text = passwordPlaceholder;
                txtPassword.ForeColor = Color.Gray;
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        // Khi nhập password, luôn che ký tự nếu không phải placeholder và chưa bấm hiện
        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text != passwordPlaceholder && !isPasswordVisible)
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        // Ẩn/hiện mật khẩu
        private void btnShowHidePassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == passwordPlaceholder) return;
            isPasswordVisible = !isPasswordVisible;
            txtPassword.UseSystemPasswordChar = !isPasswordVisible;
            btnShowHidePassword.Text = isPasswordVisible ? "🙈" : "👁";
            txtPassword.Focus();
        }

        // Xử lý nút thu nhỏ
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // Xử lý nút phóng to/khôi phục
        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        // Xử lý nút đóng
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Cho phép kéo form khi không có viền
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void PanelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        // Xử lý đăng nhập (bạn bổ sung logic thực tế ở đây)
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            if (username == usernamePlaceholder || string.IsNullOrWhiteSpace(username) ||
                password == passwordPlaceholder || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // TODO: Thêm logic xác thực tài khoản ở đây
            MessageBox.Show($"Đăng nhập với user: {username}", "Thông báo");
        }
    }
} 