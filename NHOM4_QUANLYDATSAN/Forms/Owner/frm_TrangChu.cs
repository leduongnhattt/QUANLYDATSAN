using NHOM4_QUANLYDATSAN.Helpers;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;

using OxyPlot.WindowsForms;
using NHOM4_QUANLYDATSAN.Models;


namespace NHOM4_QUANLYDATSAN.Forms.Owner
{
    public partial class frm_TrangChu : Form
    {
        private enum ThongKeType { Tuan, Thang, Nam }
        private string _userName;
        private string _email;
        public frm_TrangChu(string userName, string email)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            if (cbb_LuaChon != null) cbb_LuaChon.SelectedIndex = 1;
            if (cbb_LuaChon != null) cbb_LuaChon.SelectedIndexChanged += cbb_LuaChon_SelectedIndexChanged;
            _userName = userName;
            _email = email;

        }

        // Sự kiện Load của form (được gọi từ Designer)
        private void frm_TrangChu_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
            this.LoadData();
            LoadOxyPlotChart(GetThongKeType());
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate();
        }
        /// <summary>
        /// Load số lượt đặt sân và số hội viên do user (role = 2) quản lý
        /// </summary>
        /// <param name="username">Tên đăng nhập của chủ sân</param>
        public void LoadData()
        {
            // Nếu không truyền username hoặc email thì không load
            if (string.IsNullOrEmpty(_userName) || string.IsNullOrEmpty(_email))
            {
                lbl_LuotDatSan.Text = "0";
                lbl_DemNguoiDung.Text = "0";
                return;
            }

            using (var context = new Data.SportsBookingContext())
            {
                // Lấy userId của chủ sân
                var user = context.Users.FirstOrDefault(u => u.Username == _userName && u.Email == _email && u.RoleID == 2);
                if (user == null)
                {
                    lbl_LuotDatSan.Text = "0";
                    lbl_DemNguoiDung.Text = "0";
                    return;
                }
                int userId = user.UserID;

                // Đếm số lượt đặt sân do user này quản lý
                int bookingCount = context.Bookings.Count(b => b.CreatedByUserID == userId);
                lbl_LuotDatSan.Text = bookingCount.ToString();

                // Đếm số hội viên do user này quản lý
                int memberCount = context.Memberships.Count(m => m.UserID == userId);
                lbl_DemNguoiDung.Text = memberCount.ToString();
            }
        }

        /// <summary>
        /// Load dữ liệu cho biểu đồ cột OxyPlot theo tuần/tháng/năm
        /// </summary>
        private void LoadOxyPlotChart(ThongKeType thongKeType)
        {
            var model = new PlotModel();
            
            // Lấy userId của chủ sân
            int userId = -1;
            using (var context = new Data.SportsBookingContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == _userName && u.Email == _email && u.RoleID == 2);
                if (user != null)
                {
                    userId = user.UserID;
                }
            }

            if (userId == -1) return;

            // Thiết lập trục và dữ liệu theo loại thống kê
            var categoryAxis = new CategoryAxis { Position = AxisPosition.Left };
            
            // Trục X: Số lượng
            var valueAxis = new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Số lượng",
                Minimum = 0,
                Maximum = 100,
                MajorStep = 5,
                MinorStep = 1,
                AbsoluteMinimum = 0,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
                StringFormat = "0"
            };

            // BarSeries cho biểu đồ ghép
            var bookingSeries = new BarSeries
            {
                Title = "Đặt sân",
                StrokeThickness = 1,
                LabelPlacement = LabelPlacement.Inside,
                LabelFormatString = "{0}",
                FillColor = OxyColor.FromRgb(52, 152, 219),
                StrokeColor = OxyColor.FromRgb(41, 128, 185)
            };
            var memberSeries = new BarSeries
            {
                Title = "Hội viên",
                StrokeThickness = 1,
                LabelPlacement = LabelPlacement.Inside,
                LabelFormatString = "{0}",
                FillColor = OxyColor.FromRgb(46, 204, 113),
                StrokeColor = OxyColor.FromRgb(39, 174, 96)
            };

            if (thongKeType == ThongKeType.Tuan)
            {
                model.Title = $"Thống kê theo tuần (tháng {DateTime.Now.Month}/{DateTime.Now.Year})";
                // Lấy tất cả booking và membership của user trong năm hiện tại
                List<Booking> bookings;
                List<Membership> members;
                using (var context = new Data.SportsBookingContext())
                {
                    bookings = context.Bookings
                        .Where(b => b.CreatedByUserID == userId && b.BookingDate.Year == DateTime.Now.Year)
                        .ToList();
                    members = context.Memberships
                        .Where(m => m.UserID == userId && m.StartDate.Year == DateTime.Now.Year)
                        .ToList();
                }
                // Group theo tuần
                var weekBookingGroups = bookings
                    .GroupBy(b => NHOM4_QUANLYDATSAN.Helpers.DateTimeHelper.GetWeekOfYear(b.BookingDate))
                    .OrderBy(g => g.Key)
                    .ToList();
                var weekMemberGroups = members
                    .GroupBy(m => NHOM4_QUANLYDATSAN.Helpers.DateTimeHelper.GetWeekOfYear(m.StartDate))
                    .OrderBy(g => g.Key)
                    .ToList();
                // Lấy 4 tuần gần nhất
                var allWeeks = weekBookingGroups.Select(g => g.Key)
                    .Union(weekMemberGroups.Select(g => g.Key))
                    .OrderByDescending(x => x).Take(4).OrderBy(x => x).ToList();
                foreach (var week in allWeeks)
                {
                    categoryAxis.Labels.Add($"Tuần {week}");
                    int datSanCount = weekBookingGroups.FirstOrDefault(g => g.Key == week)?.Count() ?? 0;
                    int memberCount = weekMemberGroups.FirstOrDefault(g => g.Key == week)?.Count() ?? 0;
                    bookingSeries.Items.Add(new BarItem(datSanCount));
                    memberSeries.Items.Add(new BarItem(memberCount));
                }
            }
            else if (thongKeType == ThongKeType.Thang)
            {
                model.Title = $"Thống kê theo tháng ({DateTime.Now.Year})";
                List<Booking> bookings;
                List<Membership> members;
                using (var context = new Data.SportsBookingContext())
                {
                    bookings = context.Bookings
                        .Where(b => b.CreatedByUserID == userId && b.BookingDate.Year == DateTime.Now.Year)
                        .ToList();
                    members = context.Memberships
                        .Where(m => m.UserID == userId && m.StartDate.Year == DateTime.Now.Year)
                        .ToList();
                }
                for (int thang = 1; thang <= 12; thang++)
                {
                    categoryAxis.Labels.Add($"Tháng {thang}");
                    int datSanCount = bookings.Count(b => b.BookingDate.Month == thang);
                    int memberCount = members.Count(m => m.StartDate.Month == thang);
                    bookingSeries.Items.Add(new BarItem(datSanCount));
                    memberSeries.Items.Add(new BarItem(memberCount));
                }
            }
            else if (thongKeType == ThongKeType.Nam)
            {
                model.Title = "Thống kê theo năm";
                List<Booking> bookings;
                List<Membership> members;
                using (var context = new Data.SportsBookingContext())
                {
                    bookings = context.Bookings
                        .Where(b => b.CreatedByUserID == userId)
                        .ToList();
                    members = context.Memberships
                        .Where(m => m.UserID == userId)
                        .ToList();
                }
                int currentYear = DateTime.Now.Year;
                for (int nam = currentYear - 4; nam <= currentYear; nam++)
                {
                    categoryAxis.Labels.Add($"Năm {nam}");
                    int datSanCount = bookings.Count(b => b.BookingDate.Year == nam);
                    int memberCount = members.Count(m => m.StartDate.Year == nam);
                    bookingSeries.Items.Add(new BarItem(datSanCount));
                    memberSeries.Items.Add(new BarItem(memberCount));
                }
            }

            model.Axes.Add(categoryAxis);
            model.Axes.Add(valueAxis);
            model.Series.Add(bookingSeries);
            model.Series.Add(memberSeries);
            plotView.Model = model;
        }

        private ThongKeType GetThongKeType()
        {
            if (cbb_LuaChon == null || cbb_LuaChon.SelectedIndex < 0) return ThongKeType.Thang;
            switch (cbb_LuaChon.SelectedIndex)
            {
                case 0: return ThongKeType.Tuan;
                case 1: return ThongKeType.Thang;
                case 2: return ThongKeType.Nam;
                default: return ThongKeType.Thang;
            }
        }

        // Sự kiện Tick của timerAutoRefresh (tạo trong Designer)
        private void timerAutoRefresh_Tick(object sender, EventArgs e)
        {
            LoadData();
            LoadOxyPlotChart(GetThongKeType());
        }

        private void cbb_LuaChon_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadOxyPlotChart(GetThongKeType());
        }

        // Lấy số người dùng mới theo tuần trong tháng/năm hiện tại
        private Dictionary<int, int> GetUserRegistrationsPerWeek(int year, int month)
        {
            var result = new Dictionary<int, int>();
            string query = @"SELECT DATEPART(WEEK, CreatedAt) AS Tuan, COUNT(*) AS SoNguoi FROM Users WHERE YEAR(CreatedAt) = @Year AND MONTH(CreatedAt) = @Month GROUP BY DATEPART(WEEK, CreatedAt)";
            using (SqlConnection connection = DatabaseHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Year", year);
                cmd.Parameters.AddWithValue("@Month", month);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int tuan = reader.GetInt32(0);
                        int soNguoi = reader.GetInt32(1);
                        result[tuan] = soNguoi;
                    }
                }
            }
            // Chuẩn hóa: tuần trong tháng có thể không bắt đầu từ 1
            if (result.Count > 0)
            {
                int minWeek = result.Keys.Min();
                var newResult = new Dictionary<int, int>();
                int idx = 1;
                foreach (var k in result.Keys.OrderBy(x => x))
                {
                    newResult[idx++] = result[k];
                }
                return newResult;
            }
            return result;
        }

        // Lấy số người dùng mới theo năm
        private Dictionary<int, int> GetUserRegistrationsPerYear()
        {
            var result = new Dictionary<int, int>();
            string query = @"SELECT YEAR(CreatedAt) AS Nam, COUNT(*) AS SoNguoi FROM Users GROUP BY YEAR(CreatedAt)";
            using (SqlConnection connection = DatabaseHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int nam = reader.GetInt32(0);
                        int soNguoi = reader.GetInt32(1);
                        result[nam] = soNguoi;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Lấy số người dùng mới đăng ký theo từng tháng trong năm hiện tại
        /// </summary>
        private Dictionary<int, int> GetUserRegistrationsPerMonth()
        {
            var result = new Dictionary<int, int>();
            string query = @"SELECT MONTH(CreatedAt) AS Thang, COUNT(*) AS SoNguoi FROM Users WHERE YEAR(CreatedAt) = @Year GROUP BY MONTH(CreatedAt)";
            using (SqlConnection connection = DatabaseHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Year", DateTime.Now.Year);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int thang = reader.GetInt32(0);
                        int soNguoi = reader.GetInt32(1);
                        result[thang] = soNguoi;
                    }
                }
            }
            return result;
        }
    }
}
