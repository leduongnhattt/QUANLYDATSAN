using NHOM4_QUANLYDATSAN.Data;
using NHOM4_QUANLYDATSAN.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace NHOM4_QUANLYDATSAN.Forms.Owner
{
    public partial class frm_HoiVien : Form
    {
        // DTO/ViewModel for DataGridView binding
        private class MembershipViewModel
        {
            public int dataGridViewTextBoxColumn1 { get; set; } // MemberID
            public string col_TenKhachHang { get; set; }
            public string col_Sdt { get; set; }
            public string col_Email { get; set; }
            public string col_NgayBD { get; set; }
            public string col_NgayKT { get; set; }
            public string col_GiamGia { get; set; }
            public string col_GhiChu { get; set; }
        }
        private string _userName;
        private string _email;
        public frm_HoiVien(string username, string email)
        {
            InitializeComponent();
            _userName = username;
            _email = email;
        }

        private void frm_HoiVien_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

            // Mặc định chọn item đầu tiên trong ComboBox
            if (cbb_HoiVien.Items.Count > 0)
            {
                cbb_HoiVien.SelectedIndex = 0;
            }

            LoadData();
        }

        private void LoadData()
        {
            using (var context = new SportsBookingContext())
            {
                // Lấy userId từ username và email
                var user = context.Users.FirstOrDefault(u => u.Username == _userName && u.Email == _email && u.RoleID == 2);
                if (user == null) return;
                int userId = user.UserID;
                var membershipsRaw = context.Memberships.Where(m => m.UserID == userId).ToList();
                var memberships = membershipsRaw
                    .Select((m, idx) => new MembershipViewModel
                    {
                        dataGridViewTextBoxColumn1 = m.MemberID,
                        col_TenKhachHang = m.CustomerName,
                        col_Sdt = m.CustomerPhone,
                        col_Email = m.Email,
                        col_NgayBD = m.StartDate.ToString("dd/MM/yyyy"),
                        col_NgayKT = m.EndDate.ToString("dd/MM/yyyy"),
                        col_GiamGia = (m.DiscountRate * 100).ToString("0") + "%",
                        col_GhiChu = m.Note
                    })
                    .ToList();

                grid_HoiVien.AutoGenerateColumns = false;
                grid_HoiVien.DataSource = null;
                grid_HoiVien.Rows.Clear();
                grid_HoiVien.DataSource = memberships;
            }
        }

        private void cbb_HoiVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = cbb_HoiVien.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedItem))
            {
                string[] parts = selectedItem.Split('-');
                string membershipType = parts[0].Trim();

                if (membershipType == "Theo Tuần")
                {
                    label5.Text = "Số Tuần";
                    txt_Tuan.Name = "txt_SoTuan";
                    txt_Tuan.Visible = true;
                    txt_Tuan.Text = "";
                }
                else if (membershipType == "Theo Tháng")
                {
                    label5.Text = "Số Tháng";
                    txt_Tuan.Name = "txt_SoThang";
                    txt_Tuan.Visible = true;
                    txt_Tuan.Text = "";
                }
                else if (membershipType == "Theo Năm")
                {
                    label5.Text = "Số Năm";
                    txt_Tuan.Name = "txt_SoNam";
                    txt_Tuan.Visible = true;
                    txt_Tuan.Text = "";
                }
                else
                {
                    label5.Text = "";
                    txt_Tuan.Visible = false;
                }
            }
            else
            {
                label5.Text = "";
                txt_Tuan.Visible = false;
            }
        }
        private void clear_Fields()
        {
            txt_GhiChu.Text = "";
            txt_HoiVien.Text = "";
            txt_Sdt.Text = "";
            txt_TenKhachHang.Text = "";
            txt_Tuan.Text = "";
        }
        private void txt_Them_Click(object sender, EventArgs e)
        {
            string email = txt_HoiVien.Text.Trim();
            string phone = txt_Sdt.Text.Trim();
            string customerName = txt_TenKhachHang.Text.Trim();
            string selectedItem = cbb_HoiVien.SelectedItem?.ToString();


            // Validate các trường
            if (string.IsNullOrEmpty(customerName))
            {
                MessageBox.Show("Tên khách hàng không được bỏ trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Số điện thoại không được bỏ trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!phone.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại phải là số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(email) || !System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Email không đúng định dạng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(selectedItem))
            {
                MessageBox.Show("Vui lòng chọn gói hội viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra trùng tên khách hàng hoặc email
            using (var context = new SportsBookingContext())
            {
                // Lấy userId từ username và email
                var user = context.Users.FirstOrDefault(u => u.Username == _userName && u.Email == _email && u.RoleID == 2);
                if (user == null)
                {
                    MessageBox.Show("Không tìm thấy người dùng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int userId = user.UserID;
                var existed = context.Memberships.Any(m => m.CustomerName == customerName && m.Email == email && m.UserID == userId);
                if (existed)
                {
                    MessageBox.Show("Tên khách hàng hoặc email đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            string[] parts = selectedItem.Split('-');
            string membershipType = parts[0].Trim();
            string discountRateString = parts.Length > 1 ? parts[1].Replace("Giảm", "").Replace("%", "").Trim() : "";

            if (string.IsNullOrEmpty(discountRateString) || !decimal.TryParse(discountRateString, out decimal discountRate))
            {
                MessageBox.Show($"Không thể phân tích tỷ lệ giảm giá từ '{discountRateString}'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            discountRate /= 100;

            // Tính toán StartDate và EndDate
            DateTime startDate = DateTime.Now;
            DateTime endDate = startDate;

            if (membershipType == "Theo Tuần")
            {
                if (!int.TryParse(txt_Tuan.Text.Trim(), out int weeks))
                {
                    MessageBox.Show("Số tuần không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                endDate = startDate.AddDays(weeks * 7);
            }
            else if (membershipType == "Theo Tháng")
            {
                if (!int.TryParse(txt_Tuan.Text.Trim(), out int months))
                {
                    MessageBox.Show("Số tháng không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                endDate = startDate.AddMonths(months);
            }
            else if (membershipType == "Theo Năm")
            {
                if (!int.TryParse(txt_Tuan.Text.Trim(), out int years))
                {
                    MessageBox.Show("Số năm không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                endDate = startDate.AddYears(years);
            }

            // Lấy UserID từ username và email
            using (var context = new SportsBookingContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == _userName && u.Email == _email && u.RoleID == 2);
                if (user == null)
                {
                    MessageBox.Show("Không tìm thấy người dùng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Thêm hội viên vào cơ sở dữ liệu
                var membership = new Membership
                {
                    CustomerName = customerName,
                    CustomerPhone = phone,
                    Email = email,
                    MembershipType = membershipType,
                    StartDate = startDate,
                    EndDate = endDate,
                    DiscountRate = discountRate,
                    Note = txt_GhiChu.Text.Trim(),
                    UserID = user.UserID
                };

                context.Memberships.Add(membership);
                context.SaveChanges();

                MessageBox.Show("Thêm hội viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Gọi hàm LoadData để làm mới DataGridView
                LoadData();
                clear_Fields();
            }
        }

        private void grid_HoiVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = grid_HoiVien.Rows[e.RowIndex];
                int memberId = Convert.ToInt32(selectedRow.Cells[0].Value);

                if (grid_HoiVien.Columns[e.ColumnIndex].Name == "col_Edit")
                {
                    using (var context = new SportsBookingContext())
                    {
                        // Lấy userId từ username và email
                        var user = context.Users.FirstOrDefault(u => u.Username == _userName && u.Email == _email && u.RoleID == 2);
                        if (user == null) return;
                        int userId = user.UserID;
                        var membership = context.Memberships.FirstOrDefault(m => m.MemberID == memberId && m.UserID == userId);
                        if (membership != null)
                        {
                            // Lấy dữ liệu mới từ lưới
                            membership.CustomerName = selectedRow.Cells[1].Value?.ToString();
                            membership.CustomerPhone = selectedRow.Cells[2].Value?.ToString();
                            membership.Email = selectedRow.Cells[3].Value?.ToString();
                            // Chuyển đổi ngày tháng
                            if (DateTime.TryParse(selectedRow.Cells[4].Value?.ToString(), out DateTime startDate))
                                membership.StartDate = startDate;
                            if (DateTime.TryParse(selectedRow.Cells[5].Value?.ToString(), out DateTime endDate))
                                membership.EndDate = endDate;
                            // Chuyển đổi giảm giá (dạng "5%")
                            string giamGiaStr = selectedRow.Cells[6].Value?.ToString().Replace("%", "");
                            if (decimal.TryParse(giamGiaStr, out decimal giamGia))
                                membership.DiscountRate = giamGia / 100;
                            membership.Note = selectedRow.Cells[7].Value?.ToString();

                            context.SaveChanges();
                            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                    }
                }
                else if (grid_HoiVien.Columns[e.ColumnIndex].Name == "col_Delete")
                {
                    var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa hội viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirm == DialogResult.Yes)
                    {
                        using (var context = new SportsBookingContext())
                        {
                            // Lấy userId từ username và email
                            var user = context.Users.FirstOrDefault(u => u.Username == _userName && u.Email == _email && u.RoleID == 2);
                            if (user == null) return;
                            int userId = user.UserID;
                            var membership = context.Memberships.FirstOrDefault(m => m.MemberID == memberId && m.UserID == userId);
                            if (membership != null)
                            {
                                context.Memberships.Remove(membership);
                                context.SaveChanges();
                                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadData();
                            }
                        }
                    }
                }
            }
        }

        private void grid_HoiVien_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = grid_HoiVien.Rows[e.RowIndex];
                int memberId = Convert.ToInt32(selectedRow.Cells[0].Value);

                using (var context = new SportsBookingContext())
                {
                    // Lấy userId từ username và email
                    var user = context.Users.FirstOrDefault(u => u.Username == _userName && u.Email == _email && u.RoleID == 2);
                    if (user == null) return;
                    int userId = user.UserID;
                    var membership = context.Memberships.FirstOrDefault(m => m.MemberID == memberId && m.UserID == userId);
                    if (membership != null)
                    {
                        membership.CustomerName = selectedRow.Cells[1].Value.ToString();
                        membership.CustomerPhone = selectedRow.Cells[2].Value.ToString();
                        membership.Email = selectedRow.Cells[3].Value.ToString();
                        membership.StartDate = DateTime.Parse(selectedRow.Cells[4].Value.ToString());
                        membership.EndDate = DateTime.Parse(selectedRow.Cells[5].Value.ToString());
                        membership.DiscountRate = Convert.ToDecimal(selectedRow.Cells[6].Value);
                        membership.Note = selectedRow.Cells[7].Value.ToString();

                        context.SaveChanges();
                        MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}
