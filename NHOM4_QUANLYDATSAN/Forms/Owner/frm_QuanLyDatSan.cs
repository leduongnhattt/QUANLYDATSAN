using System;
using System.Linq;
using System.Windows.Forms;
using NHOM4_QUANLYDATSAN.Data;
using NHOM4_QUANLYDATSAN.Models;

namespace NHOM4_QUANLYDATSAN.Forms.Owner
{
    public partial class frm_QuanLyDatSan : Form
    {
        private string _userName;
        private string _email;
        public frm_QuanLyDatSan(string userName, string email)
        {
            InitializeComponent();
            txt_TimKiem.TextChanged += Txt_TimKiem_TextChanged;
            _userName = userName;
            _email = email;
        }

        private void Txt_TimKiem_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_TimKiem.Text))
            {
                LoadData(date_NgayDat.Value);
            }
        }

        private void frm_QuanLyDatSan_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
            LoadData(date_NgayDat.Value);
        }

        private void LoadData(DateTime selectedDate)
        {
            using (var context = new SportsBookingContext())
            {
                // Lấy userId của chủ sân
                var user = context.Users.FirstOrDefault(u => u.Username == _userName && u.Email == _email && u.RoleID == 2);
                if (user == null) return;
                int userId = user.UserID;
                // Chỉ lấy các booking của sân do user này quản lý
                var rawData = context.Bookings
                    .Where(b => b.BookingDate == selectedDate.Date && b.Court.UserID == userId)
                    .Select(b => new
                    {
                        b.BookingID,
                        b.CustomerName,
                        b.CustomerPhone,
                        b.StartTime,
                        b.EndTime,
                        CourtName = b.Court.CourtName,
                        b.Status,
                        b.MemberID,
                        PricePerHour = b.Court.PricePerHour
                    })
                    .ToList();

                grid_DatSan.Rows.Clear();

                foreach (var b in rawData)
                {
                    decimal total = (decimal)(b.EndTime - b.StartTime).TotalHours * b.PricePerHour;
                    bool isMember = b.MemberID.HasValue;
                    if (isMember)
                    {
                        // Lấy giảm giá từ Membership đúng chủ sân
                        var membership = context.Users
                            .Where(u => u.Username == _userName && u.Email == _email && u.RoleID == 2)
                            .Join(context.Memberships,
                                  u => u.UserID,
                                  m => m.UserID,
                                  (u, m) => m)
                            .FirstOrDefault(m => m.MemberID == b.MemberID);
                        if (membership != null)
                        {
                            total = total * (1 - (membership.DiscountRate));
                        }
                    }
                    string startStr = b.StartTime.ToString().Length > 5 ? b.StartTime.ToString().Substring(0,5) : b.StartTime.ToString();
                    string endStr = b.EndTime.ToString().Length > 5 ? b.EndTime.ToString().Substring(0,5) : b.EndTime.ToString();
                    string timeRange = $"{startStr} - {endStr}";
                    grid_DatSan.Rows.Add(
                        b.BookingID,
                        b.CustomerName,
                        b.CustomerPhone,
                        timeRange,
                        b.EndTime - b.StartTime,
                        b.CourtName,
                        b.Status,
                        isMember,
                        total
                    );
                }
            }
        }

        private void Date_NgayDat_ValueChanged(object sender, EventArgs e)
        {
            LoadData(date_NgayDat.Value);
        }

        private void btn_Tim_Click(object sender, EventArgs e)
        {
            string searchText = txt_TimKiem.Text.Trim();
            if (string.IsNullOrEmpty(searchText))
            {
                LoadData(date_NgayDat.Value); // Reload all data if search text is empty
                return;
            }

            using (var context = new SportsBookingContext())
            {
                var filteredData = context.Bookings
                    .Where(b => b.CustomerName.Contains(searchText))
                    .Select(b => new
                    {
                        b.BookingID,
                        b.CustomerName,
                        b.CustomerPhone,
                        b.StartTime,
                        b.EndTime,
                        CourtName = b.Court.CourtName,
                        b.Status,
                        IsMember = b.MemberID.HasValue,
                        PricePerHour = b.Court.PricePerHour
                    })
                    .ToList();

                grid_DatSan.Rows.Clear();

                foreach (var b in filteredData)
                {
                    grid_DatSan.Rows.Add(
                        b.BookingID,
                        b.CustomerName,
                        b.CustomerPhone,
                        $"{b.StartTime:hh\\:mm} - {b.EndTime:hh\\:mm}",
                        b.EndTime - b.StartTime,
                        b.CourtName,
                        b.Status,
                        b.IsMember,
                        (decimal)(b.EndTime - b.StartTime).TotalHours * b.PricePerHour
                    );
                }

                if (filteredData.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // Cho phép form khác gọi reload data (ví dụ sau khi thêm đặt sân)
        public void ReloadData()
        {
            LoadData(date_NgayDat.Value);
        }

        private void grid_DatSan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = grid_DatSan.Rows[e.RowIndex];

                if (grid_DatSan.Columns[e.ColumnIndex].Name == "col_Edit")
                {
                    // Edit logic
                    int bookingId = Convert.ToInt32(selectedRow.Cells[0].Value);
                    using (var context = new SportsBookingContext())
                    {
                        var booking = context.Bookings.FirstOrDefault(b => b.BookingID == bookingId);
                        if (booking != null)
                        {
                            booking.CustomerName = selectedRow.Cells[1].Value.ToString();
                            booking.CustomerPhone = selectedRow.Cells[2].Value.ToString();
                            // Parse time safely
                            string timeRange = selectedRow.Cells[3].Value.ToString();
                            var timeParts = timeRange.Split('-');
                            if (timeParts.Length == 2 &&
                                TimeSpan.TryParse(timeParts[0].Trim(), out TimeSpan startTime) &&
                                TimeSpan.TryParse(timeParts[1].Trim(), out TimeSpan endTime))
                            {
                                booking.StartTime = startTime;
                                booking.EndTime = endTime;
                            }
                            else
                            {
                                MessageBox.Show("Thời gian không hợp lệ. Định dạng phải là 'hh:mm - hh:mm'", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            booking.Status = selectedRow.Cells[6].Value.ToString();
                            booking.MemberID = (bool)selectedRow.Cells[7].Value ? booking.MemberID : null;

                            context.SaveChanges();
                            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else if (grid_DatSan.Columns[e.ColumnIndex].Name == "col_Delete")
                {
                    // Delete logic with confirmation
                    var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa đặt sân này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirm == DialogResult.Yes)
                    {
                        int bookingId = Convert.ToInt32(selectedRow.Cells[0].Value);
                        using (var context = new SportsBookingContext())
                        {
                            var booking = context.Bookings.FirstOrDefault(b => b.BookingID == bookingId);
                            if (booking != null)
                            {
                                context.Bookings.Remove(booking);
                                context.SaveChanges();
                                grid_DatSan.Rows.RemoveAt(e.RowIndex);
                                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
        }
    }
}
