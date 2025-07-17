using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using NHOM4_QUANLYDATSAN.Helpers;
using NHOM4_QUANLYDATSAN.Data;
using NHOM4_QUANLYDATSAN.Models;

namespace NHOM4_QUANLYDATSAN.Forms.Admin
{
    public partial class frm_ThemNguoiDung : Form
    {
        private static User _currentUser;
        public frm_ThemNguoiDung()
        {
            InitializeComponent();
        }

        private bool IsAllFieldsFilled()
        {
            return !string.IsNullOrWhiteSpace(txt_TenDangNhap.Text)
                && !string.IsNullOrWhiteSpace(txt_HoVaTen.Text)
                && !string.IsNullOrWhiteSpace(txt_Email.Text)
                && !string.IsNullOrWhiteSpace(txt_Sdt.Text)
                && !string.IsNullOrWhiteSpace(txt_DiaChi.Text)
                && !string.IsNullOrWhiteSpace(txt_MatKhau.Text)
                && !string.IsNullOrEmpty(pic_Avatar.ImageLocation);
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            string username = txt_TenDangNhap.Text.Trim();
            string fullName = txt_HoVaTen.Text.Trim();
            string email = txt_Email.Text.Trim();
            string phoneNumber = txt_Sdt.Text.Trim();
            string address = txt_DiaChi.Text.Trim();
            string password = txt_MatKhau.Text.Trim();

            // Lấy đường dẫn ảnh từ PictureBox
            string avatarPath = pic_Avatar.ImageLocation ?? "default-avatar.png";

            if (!ValidateInputs(username, fullName, email, phoneNumber, address, password))
            {
                return;
            }

            if (IsUsernameExists(username))
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AddUser(username, fullName, email, phoneNumber, address, password, avatarPath);
        }


        private void btn_Chon_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFile = openFileDialog.FileName;
                    if (!Regex.IsMatch(selectedFile, @"\.(jpg|jpeg|png|bmp)$", RegexOptions.IgnoreCase))
                    {
                        MessageBox.Show("Định dạng file không hợp lệ. Vui lòng chọn file ảnh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    pic_Avatar.ImageLocation = selectedFile;
                    pic_Avatar.Image = Image.FromFile(selectedFile);
                    btn_Them.Enabled = IsAllFieldsFilled();
                }
            }
        }

        private bool ValidateInputs(string username, string fullName, string email, string phoneNumber, string address, string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Tên đăng nhập không được bỏ trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (username.Length < 6)
            {
                MessageBox.Show("Tên đăng nhập phải có ít nhất 6 ký tự.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(fullName))
            {
                MessageBox.Show("Họ và tên không được bỏ trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Email không được bỏ trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!Regex.IsMatch(email, "^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$"))
            {
                MessageBox.Show("Email không đúng định dạng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(phoneNumber))
            {
                MessageBox.Show("Số điện thoại không được bỏ trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!Regex.IsMatch(phoneNumber, "^\\d{11}$"))
            {
                MessageBox.Show("Số điện thoại phải đủ 11 số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(address))
            {
                MessageBox.Show("Địa chỉ không được bỏ trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Mật khẩu không được bỏ trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (password.Length < 6 || !Regex.IsMatch(password, "[!@#$%^&*(),.?\":{}|<>]") || !Regex.IsMatch(password, "\\d"))
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự, bao gồm ít nhất 1 ký tự đặc biệt và 1 số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(pic_Avatar.ImageLocation))
            {
                MessageBox.Show("Bạn phải chọn ảnh đại diện.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool IsUsernameExists(string username)
        {
            using (var context = new SportsBookingContext())
            {
                return context.Users.Any(u => u.Username == username);
            }
        }

        private void AddUser(string username, string fullName, string email, string phoneNumber, string address, string password, string avatarPath)
        {
            using (var context = new SportsBookingContext())
            {
                var newUser = new User
                {
                    Username = username,
                    FullName = fullName,
                    Email = email,
                    Phone = phoneNumber,
                    RoleID = 2,
                    CreatedAt = DateTime.Now,
                    IsActive = true,
                    Address = address,
                    AvatarPath = avatarPath,
                    Password = password
                };

                context.Users.Add(newUser);
                context.SaveChanges();

                MessageBox.Show("Thêm người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        public void SetEditMode(string username, string fullName, string email, string phone, string address, string password, string avatarPath)
        {
            txt_TenDangNhap.Text = username;
            txt_HoVaTen.Text = fullName;
            txt_Email.Text = email;
            txt_Sdt.Text = phone;
            txt_DiaChi.Text = address;
            txt_MatKhau.Text = password;

            if (!string.IsNullOrEmpty(avatarPath) && System.IO.File.Exists(avatarPath))
            {
                try
                {
                    using (var fs = new System.IO.FileStream(avatarPath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                    {
                        pic_Avatar.Image = Image.FromStream(fs);
                    }
                    pic_Avatar.ImageLocation = avatarPath;
                }
                catch
                {
                    pic_Avatar.Image = Properties.Resources.icons8_user_30;
                    pic_Avatar.ImageLocation = null;
                }
            }
            else
            {
                pic_Avatar.Image = Properties.Resources.icons8_user_30;
                pic_Avatar.ImageLocation = null;
            }

            bigLabel1.Text = "Sửa Người Dùng";
            btn_Them.Text = "Sửa";
            btn_Them.Click -= btn_Them_Click;
            btn_Them.Click -= btn_Sua_Click;
            btn_Them.Click += btn_Sua_Click;
            txt_TenDangNhap.Enabled = true;

            using (var context = new SportsBookingContext())
            {
                _currentUser = context.Users.FirstOrDefault(u => u.Username == username);
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            UpdateUser();
        }
        
        private void UpdateUser()
        {
            string originalUsername = txt_TenDangNhap.Text.Trim(); 
            string username = txt_TenDangNhap.Text.Trim();
            string fullName = txt_HoVaTen.Text.Trim();
            string email = txt_Email.Text.Trim();
            string phoneNumber = txt_Sdt.Text.Trim();
            string address = txt_DiaChi.Text.Trim();
            string password = txt_MatKhau.Text.Trim();
            string avatarPath = pic_Avatar.ImageLocation ?? "default-avatar.png";

            if (!ValidateInputs(username, fullName, email, phoneNumber, address, password))
            {
                return;
            }

            using (var context = new SportsBookingContext())
            {
                var user = context.Users.FirstOrDefault(u => u.RoleID == _currentUser.RoleID);
                if (user == null)
                {
                    MessageBox.Show("Người dùng không tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (context.Users.Any(u => u.Username == username && u.UserID != user.UserID))
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                user.Username = username;
                user.FullName = fullName;
                user.Email = email;
                user.Phone = phoneNumber;
                user.Address = address;
                user.Password = password;
                user.AvatarPath = avatarPath;

                context.SaveChanges();

                MessageBox.Show("Cập nhật người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
