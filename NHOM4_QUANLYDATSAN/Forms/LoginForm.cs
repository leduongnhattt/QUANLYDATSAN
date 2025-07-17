using NHOM4_QUANLYDATSAN.Forms.Admin;
using NHOM4_QUANLYDATSAN.Forms.Owner;
using NHOM4_QUANLYDATSAN.Services;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NHOM4_QUANLYDATSAN.Forms
{
    public partial class LoginForm : Form
    {
        private const string ADMIN = "Admin";
        private bool isPasswordVisible = false;
        private readonly string usernamePlaceholder = "Tên đăng nhập";
        private readonly string passwordPlaceholder = "Mật khẩu";
        private bool isTextChangedRegistered = false;
        private AuthenticationService _authenticationService;


        public LoginForm()
        {
            InitializeComponent();
            _authenticationService = new AuthenticationService();
            // Cho phép kéo form bằng title bar custom
            panelTitleBar.MouseDown += PanelTitleBar_MouseDown;
            if (!isTextChangedRegistered)
            {
                txtPassword.TextChanged += TxtPassword_TextChanged;
                isTextChangedRegistered = true;
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

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void PanelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {


            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (username == usernamePlaceholder || string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password == passwordPlaceholder || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_authenticationService.ValidatePassword(password))
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự, bao gồm ít nhất một ký tự đặc biệt và một chữ số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string role;
            if (!_authenticationService.Authenticate(username, password, out role))
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearForm();
                return;
            }

            if (role == ADMIN)
            {
                AdminMainForm adminForm = new AdminMainForm();
                adminForm.Show();
                this.Hide();
                return;
            }
            OwnerMainForm ownerForm = new OwnerMainForm(username);
            ownerForm.Show();
            this.Hide();
        }
        private void ClearForm()
        {
            txtUsername.Text = usernamePlaceholder;
            txtUsername.ForeColor = Color.Gray;
            txtPassword.Text = passwordPlaceholder;
            txtPassword.ForeColor = Color.Gray;
        }
    }
}