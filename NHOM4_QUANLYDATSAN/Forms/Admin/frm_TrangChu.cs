
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


namespace NHOM4_QUANLYDATSAN.Forms.Admin
{
    public partial class frm_TrangChu : Form
    {
        private enum ThongKeType { Tuan, Thang, Nam }
        private const string CountUsersQuery = "SELECT COUNT(*) FROM Users WHERE RoleID = 2";
        private const string CountUserActiveQuery = "SELECT COUNT(*) FROM Users WHERE RoleID = 2 AND IsActive = 1";
        public frm_TrangChu()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            if (cbb_LuaChon != null) cbb_LuaChon.SelectedIndex = 1;
            if (cbb_LuaChon != null) cbb_LuaChon.SelectedIndexChanged += cbb_LuaChon_SelectedIndexChanged;
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
        public void LoadData()
        {
            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                try
                {
                    using (SqlCommand countUsersCommand = new SqlCommand(CountUsersQuery, connection))
                    {
                        int userCount = (int)countUsersCommand.ExecuteScalar();
                        lbl_DemNguoiDung.Text = userCount.ToString();
                    }

                    using (SqlCommand countActiveUsersCommand = new SqlCommand(CountUserActiveQuery, connection))
                    {
                        int activeUserCount = (int)countActiveUsersCommand.ExecuteScalar();
                        lbl_DemActive.Text = activeUserCount.ToString() + " Người hoạt động";
                    }
                }
                finally
                {
                    DatabaseHelper.CloseConnection(connection);
                }
            }
        }

        /// <summary>
        /// Load dữ liệu cho biểu đồ cột OxyPlot: Số lượng người dùng mới theo từng tháng/tuần/năm
        /// </summary>
        private void LoadOxyPlotChart(ThongKeType thongKeType)
        {
            PlotModel model = new PlotModel();

            // Thiết lập các trục cho BarSeries (horizontal bars)
            // CategoryAxis phải ở trục Y khi dùng BarSeries trong OxyPlot.WindowsForms
            CategoryAxis categoryAxis = new CategoryAxis { Position = AxisPosition.Left, Title = "" };

            // Tìm giá trị lớn nhất để set Maximum cho trục giá trị
            int maxValue = 0;
            if (thongKeType == ThongKeType.Thang)
                maxValue = GetUserRegistrationsPerMonth().Values.DefaultIfEmpty(0).Max();
            else if (thongKeType == ThongKeType.Tuan)
                maxValue = GetUserRegistrationsPerWeek(DateTime.Now.Year, DateTime.Now.Month).Values.DefaultIfEmpty(0).Max();
            else if (thongKeType == ThongKeType.Nam)
                maxValue = GetUserRegistrationsPerYear().Values.DefaultIfEmpty(0).Max();

            double axisMax = maxValue <= 5 ? 5 : ((maxValue / 5) + 2) * 5;
            double majorStep = axisMax == 5 ? 5 : 5;
            LinearAxis valueAxis = new LinearAxis {
                Position = AxisPosition.Bottom,
                Title = "Số người dùng mới",
                Minimum = 0,
                Maximum = 200,
                MajorStep = 15,
                AbsoluteMinimum = 0,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.None, 
                StringFormat = "0",
                IsPanEnabled = false,
                IsZoomEnabled = false,
                IntervalLength = 40
            };
            
            // Sử dụng BarSeries (trong OxyPlot.WindowsForms nó tạo ra cột ngang)
            BarSeries userSeries = new BarSeries { 
                Title = "Người dùng mới", 
                FillColor = OxyColor.FromRgb(230, 126, 34),
                StrokeColor = OxyColor.FromRgb(230, 126, 34),
                StrokeThickness = 1,
                LabelPlacement = LabelPlacement.Outside,
                BarWidth = 0.7,
                LabelFormatString = "{0}",
                IsStacked = false
            };

            if (thongKeType == ThongKeType.Thang)
            {
                var data = GetUserRegistrationsPerMonth();
                for (int i = 1; i <= 12; i++)
                {
                    int value = data.ContainsKey(i) ? data[i] : 0;
                    categoryAxis.Labels.Add($"Tháng {i}");
                    userSeries.Items.Add(new BarItem(value));
                }
                valueAxis.Title = "Số người dùng mới";
                model.Title = $"Người dùng mới theo tháng ({DateTime.Now.Year})";
            }
            else if (thongKeType == ThongKeType.Tuan)
            {
                var data = GetUserRegistrationsPerWeek(DateTime.Now.Year, DateTime.Now.Month);
                for (int i = 1; i <= data.Count; i++)
                {
                    int value = data.ContainsKey(i) ? data[i] : 0;
                    categoryAxis.Labels.Add($"Tuần {i}");
                    userSeries.Items.Add(new BarItem(value));
                }
                valueAxis.Title = "Số người dùng mới";
                model.Title = $"Người dùng mới theo tuần (tháng {DateTime.Now.Month}/{DateTime.Now.Year})";
            }
            else if (thongKeType == ThongKeType.Nam)
            {
                var data = GetUserRegistrationsPerYear();
                var years = data.Keys.OrderBy(y => y).ToList();
                foreach (var y in years)
                {
                    categoryAxis.Labels.Add($"Năm {y}");
                    userSeries.Items.Add(new BarItem(data[y]));
                }
                valueAxis.Title = "Số người dùng mới";
                model.Title = "Người dùng mới theo năm";
            }

            model.Axes.Add(categoryAxis);
            model.Axes.Add(valueAxis);
            model.Series.Add(userSeries);
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
