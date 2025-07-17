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

namespace NHOM4_QUANLYDATSAN.Forms.Owner
{
    public partial class frm_ThemThongTinDatSan : Form
    {
        private int CourtID;

        public frm_ThemThongTinDatSan(int courtID)
        {
            InitializeComponent();
            CourtID = courtID;
        }

        private void btn_Gui_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ form
            string customerName = txt_TenKhachHang.Text.Trim();
            string phoneNumber = txt_Sdt.Text.Trim();
            string note = textBox1.Text.Trim();
            string selectedTime = cbb_Gio.SelectedItem?.ToString();

            // Validate các trường
            if (string.IsNullOrEmpty(customerName))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(phoneNumber))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!phoneNumber.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại phải là số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (phoneNumber.Length < 9 || phoneNumber.Length > 11)
            {
                MessageBox.Show("Số điện thoại phải từ 9-11 số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(selectedTime))
            {
                MessageBox.Show("Vui lòng chọn giờ đặt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var context = new SportsBookingContext())
            {
                var timeParts = selectedTime.Split('-');
                TimeSpan startTime = TimeSpan.Parse(timeParts[0].Trim());
                TimeSpan endTime = TimeSpan.Parse(timeParts[1].Trim());

                DateTime bookingDate = DateTime.Now.Date;
                string status = "Đã đặt";

                // Lấy UserID từ Court
                var court = context.Courts.FirstOrDefault(c => c.CourtID == CourtID);
                if (court == null)
                {
                    MessageBox.Show("Không tìm thấy sân.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int createdByUserID = court.UserID;

                // Kiểm tra sân đã được đặt chưa
                var existingBooking = context.Bookings.FirstOrDefault(b => b.CourtID == CourtID && b.BookingDate == bookingDate && b.StartTime == startTime && b.EndTime == endTime);

                if (existingBooking != null)
                {
                    MessageBox.Show("Sân đã được đặt vào giờ này.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra khách hàng có trong membership không (theo tên hoặc số điện thoại)
                var membership = context.Memberships.FirstOrDefault(m => m.CustomerName == customerName || m.CustomerPhone == phoneNumber);
                int? membershipID = membership?.MemberID;

                // Thêm thông tin vào database
                var newBooking = new Booking
                {
                    CustomerName = customerName,
                    CustomerPhone = phoneNumber,
                    Note = note,
                    BookingDate = bookingDate,
                    StartTime = startTime,
                    EndTime = endTime,
                    Status = status,
                    CourtID = CourtID,
                    CreatedByUserID = createdByUserID,
                    MemberID = membershipID ?? null
                };

                context.Bookings.Add(newBooking);
                context.SaveChanges();

                MessageBox.Show("Đặt sân thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void LoadGioDatSan(int courtID)
        {
            using (var context = new SportsBookingContext())
            {
                var court = context.Courts.FirstOrDefault(c => c.CourtID == courtID);
                if (court != null)
                {
                    cbb_Gio.Items.Clear();

                    TimeSpan currentTime = court.TimeOpen;
                    while (currentTime.Add(TimeSpan.FromHours(court.CountTime)) <= court.TimeClose)
                    {
                        cbb_Gio.Items.Add(currentTime.ToString(@"hh\:mm") + " - " + currentTime.Add(TimeSpan.FromHours(court.CountTime)).ToString(@"hh\:mm"));
                        currentTime = currentTime.Add(TimeSpan.FromHours(court.CountTime));
                    }

                    if (cbb_Gio.Items.Count > 0)
                    {
                        cbb_Gio.SelectedIndex = 0; 
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sân.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadGioDatSan(CourtID);
        }
    }
}
