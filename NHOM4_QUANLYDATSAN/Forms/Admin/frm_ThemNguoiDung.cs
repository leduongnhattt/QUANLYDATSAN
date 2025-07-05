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

namespace NHOM4_QUANLYDATSAN.Forms.Admin
{
    public partial class frm_ThemNguoiDung : Form
    {
        private const string CheckUsernameQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
        private const string InsertUserQuery = "INSERT INTO Users (Username, FullName, Email, Phone, RoleID, CreatedAt, IsActive, Address, AvatarPath, Password) " +
                                               "VALUES (@Username, @FullName, @Email, @Phone, @RoleID, @CreatedAt, @IsActive, @Address, @AvatarPath, @Password)";

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
            if (!Regex.IsMatch(phoneNumber, "^\\d{12}$"))
            {
                MessageBox.Show("Số điện thoại phải đủ 12 số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                try
                {
                    using (SqlCommand checkCommand = new SqlCommand(CheckUsernameQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@Username", username);
                        int count = (int)checkCommand.ExecuteScalar();
                        return count > 0;
                    }
                }
                finally
                {
                    DatabaseHelper.CloseConnection(connection);
                }
            }
        }

        private void AddUser(string username, string fullName, string email, string phoneNumber, string address, string password, string avatarPath)
        {
            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                try
                {
                    using (SqlCommand insertCommand = new SqlCommand(InsertUserQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@Username", username);
                        insertCommand.Parameters.AddWithValue("@FullName", fullName);
                        insertCommand.Parameters.AddWithValue("@Email", email);
                        insertCommand.Parameters.AddWithValue("@Phone", phoneNumber);
                        insertCommand.Parameters.AddWithValue("@RoleID", 2); 
                        insertCommand.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                        insertCommand.Parameters.AddWithValue("@IsActive", true);
                        insertCommand.Parameters.AddWithValue("@Address", address);
                        insertCommand.Parameters.AddWithValue("@AvatarPath", avatarPath);
                        insertCommand.Parameters.AddWithValue("@Password", password);

                        insertCommand.ExecuteNonQuery();
                    }

                    MessageBox.Show("Thêm người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    DatabaseHelper.CloseConnection(connection);
                }
            }
        }

        // Chế độ sửa: truyền dữ liệu lên form, đổi label và nút
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
            // Chỉ gán lại event handler một lần, không cần foreach (sẽ lỗi biên dịch)
            btn_Them.Click -= btn_Sua_Click;
            btn_Them.Click += btn_Sua_Click;
            txt_TenDangNhap.Enabled = true;

        }

        // Sự kiện sửa (dùng cho nút Sửa khi ở chế độ sửa)
        private void btn_Sua_Click(object sender, EventArgs e)
        {
            UpdateUser();
        }
        // Hàm update user (lấy giá trị mới nhất từ textbox)
        private void UpdateUser()
        {
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

            int userId = -1;
            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                try
                {
                    // Lấy userId dựa vào username
                    string getIdQuery = "SELECT UserId FROM Users WHERE Username = @Username";
                    using (SqlCommand getIdCmd = new SqlCommand(getIdQuery, connection))
                    {
                        getIdCmd.Parameters.AddWithValue("@Username", username);
                        var result = getIdCmd.ExecuteScalar();
                        if (result == null || result == DBNull.Value)
                        {
                            MessageBox.Show("Không tìm thấy người dùng để cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        userId = Convert.ToInt32(result);
                    }
                    // Update theo userId
                    string query = "UPDATE Users SET FullName=@FullName, Email=@Email, Phone=@Phone, Address=@Address, Password=@Password, AvatarPath=@AvatarPath WHERE UserId=@UserId";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@FullName", fullName);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Phone", phoneNumber);
                        cmd.Parameters.AddWithValue("@Address", address);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@AvatarPath", avatarPath);
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Cập nhật người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                finally
                {
                    DatabaseHelper.CloseConnection(connection);
                }
            }
        }
    }
}
