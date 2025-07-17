using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NHOM4_QUANLYDATSAN.Data;
using NHOM4_QUANLYDATSAN.Models; 

namespace NHOM4_QUANLYDATSAN.Forms.Owner
{
    public partial class frm_DatSan : Form
    {
        private string _userName;
        private string _email;
        public frm_DatSan(string _username, string email)
        {
            InitializeComponent();
            _userName = _username;
            _email = email;
            LoadLoaiSan(_userName);
        }
        private void frm_DatSan_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

            using (var context = new SportsBookingContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == _userName && u.Email == _email);
                if (user == null) return;
                int userId = user.UserID;
                var courts = context.Courts
                    .Where(c => c.UserID == userId)
                    .Select(c => new
                    {
                        CourtID = c.CourtID,
                        CourtName = c.CourtName,
                        SportType = c.SportType,
                        PricePerHour = c.PricePerHour,
                        Status = c.Status,
                        ImagePath = c.ImagePath,
                    })
                    .ToList();

                flowLayoutPanelCourts.Controls.Clear();
                flowLayoutPanelCourts.AutoScroll = true;
                flowLayoutPanelCourts.WrapContents = true;
                flowLayoutPanelCourts.FlowDirection = FlowDirection.LeftToRight;
                flowLayoutPanelCourts.Width = 1035;

                DisplayCourts(courts);
                LoadLoaiSan(_userName);
            }
        }
        private void LoadLoaiSan(string userName)
        {
            using (var context = new SportsBookingContext())
            {
                int userId = context.Users
                    .Where(u => u.Username == userName)
                    .Select(u => u.UserID)
                    .FirstOrDefault();

                if (userId == 0)
                {
                    MessageBox.Show("Không tìm thấy người dùng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var loaiSans = context.Courts
                    .Where(c => c.UserID == userId)
                    .Select(c => c.SportType)
                    .Distinct()
                    .ToList();

                cbb_TheThao.Items.Clear();
                cbb_TheThao.Items.Add("Tất cả");
                foreach (var loaiSan in loaiSans)
                {
                    cbb_TheThao.Items.Add(loaiSan);
                }

                cbb_TheThao.SelectedIndex = 0;
            }
        }

        private void DisplayCourts(IEnumerable<dynamic> courts)
        {
            flowLayoutPanelCourts.Controls.Clear();

            foreach (var court in courts)
            {
                Panel card = new Panel
                {
                    Width = 300,
                    Height = 420,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(20),
                    BackColor = Color.White,
                };

                PictureBox pic = new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Width = 280,
                    Height = 220,
                    Top = 10,
                    Left = 10
                };
                try
                {
                    string resourcesPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources");
                    string imageFullPath = System.IO.Path.Combine(resourcesPath, court.ImagePath);
                    pic.Image = Image.FromFile(imageFullPath);
                }
                catch
                {
                    pic.Image = null;
                }

                Label lblTen = new Label
                {
                    Text = court.CourtName,
                    Font = new Font("Segoe UI", 16, FontStyle.Bold),
                    Top = 240,
                    Left = 10,
                    Width = 280
                };

                Label lblLoai = new Label
                {
                    Text = $"Môn: {court.SportType}",
                    Top = 275,
                    Left = 10,
                    Width = 280
                };

                Label lblGia = new Label
                {
                    Text = $"Giá: {court.PricePerHour:N0}đ/giờ",
                    Top = 305,
                    Left = 10,
                    Width = 280
                };

                Label lblTrangThai = new Label
                {
                    Text = $"Trạng thái: {court.Status}",
                    Top = 335,
                    Left = 10,
                    Width = 280,
                    ForeColor = court.Status == "Còn trống" ? Color.Green : Color.Red
                };

                Button btnDat = new Button
                {
                    Text = "Đặt",
                    Top = 365,
                    Left = 10,
                    Width = 280,
                    Height = 40,
                    BackColor = Color.DodgerBlue,
                    ForeColor = Color.White
                };
                btnDat.Click += (s, ev) =>
                {
                    frm_ThemThongTinDatSan thongTin = new frm_ThemThongTinDatSan(court.CourtID);
                    thongTin.Show();
                };

                card.Controls.Add(pic);
                card.Controls.Add(lblTen);
                card.Controls.Add(lblLoai);
                card.Controls.Add(lblGia);
                card.Controls.Add(lblTrangThai);
                card.Controls.Add(btnDat);

                flowLayoutPanelCourts.Controls.Add(card);
            }
        }

        private void cbb_TheThao_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSportType = cbb_TheThao.SelectedItem?.ToString();

            using (var context = new SportsBookingContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == _userName && u.Email == _email);
                if (user == null) return;
                int userId = user.UserID;
                var filteredCourts = context.Courts
                    .Where(c => c.UserID == userId && (selectedSportType == "Tất cả" || c.SportType == selectedSportType))
                    .Select(c => new
                    {
                        CourtID = c.CourtID,
                        CourtName = c.CourtName,
                        SportType = c.SportType,
                        PricePerHour = c.PricePerHour,
                        Status = c.Status,
                        ImagePath = c.ImagePath
                    })
                    .ToList();

                DisplayCourts(filteredCourts);
            }
        }
    }
}
