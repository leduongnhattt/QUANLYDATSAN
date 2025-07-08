using NHOM4_QUANLYDATSAN.Data;
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
    public partial class frm_QuanLySan : Form
    {
        private string _username;
        private string _email;
        public frm_QuanLySan(string username, string email)
        {
            InitializeComponent();
            _username = username;
            LoadData();
            _email = email;
        }

        private void frm_ThemSanLoad(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            frm_ThemSan frm_ThemSan = new frm_ThemSan(_username);
            frm_ThemSan.ShowDialog();
            LoadData();
            txt_TimKiem.Text = "";
            txt_TimKiem.ForeColor = Color.Black;
            txt_TimKiem.GotFocus += (s, ev) =>
            {
                if (txt_TimKiem.Text == "Nhập tên sân để tìm kiếm ...")
                {
                    txt_TimKiem.Text = "";
                    txt_TimKiem.ForeColor = Color.Black;
                }
            };
            txt_TimKiem.LostFocus += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txt_TimKiem.Text))
                {
                    txt_TimKiem.Text = "Nhập tên sân để tìm kiếm ...";
                    txt_TimKiem.ForeColor = Color.Gray;
                }
            };
        }
        private void LoadData()
        {
            using (var context = new SportsBookingContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == _username);
                if (user != null)
                {
                    var sportsFields = context.Courts.Where(sf => sf.UserID == user.UserID).ToList();

                    grid_San.Rows.Clear();
                    int index = 1;
                    string resourcesPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources");
                    foreach (var field in sportsFields)
                    {
                        Image img = null;
                        if (!string.IsNullOrEmpty(field.ImagePath))
                        {
                            string imageFullPath = System.IO.Path.Combine(resourcesPath, field.ImagePath);
                            if (System.IO.File.Exists(imageFullPath))
                            {
                                img = Image.FromFile(imageFullPath);
                            }
                        }
                        grid_San.Rows.Add(
                            index++,
                            field.CourtName,
                            field.SportType,
                            field.VenueName,
                            field.PricePerHour,
                            img,
                            field.TimeOpen.ToString(@"hh\:mm") + " - " + field.TimeClose.ToString(@"hh\:mm"),
                            field.CountTime
                        );
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy người dùng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (grid_San.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dòng muốn xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = grid_San.CurrentRow;
            var courtName = selectedRow.Cells[1].Value.ToString();

            var confirmResult = MessageBox.Show($"Bạn có muốn xóa sân tên '{courtName}' không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                using (var context = new SportsBookingContext())
                {
                    var court = context.Courts.FirstOrDefault(c => c.CourtName == courtName);
                    if (court != null)
                    {
                        context.Courts.Remove(court);
                        context.SaveChanges();
                        MessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sân để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (grid_San.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dòng muốn sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = grid_San.CurrentRow; 
            var courtName = selectedRow.Cells[1].Value.ToString();

            using (var context = new SportsBookingContext())
            {
                var court = context.Courts.FirstOrDefault(c => c.CourtName == courtName);
                if (court != null)
                {
                    frm_ThemSan frm_SuaSan = new frm_ThemSan(_username, court);
                    frm_SuaSan.ShowDialog();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sân để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_Tim_Click(object sender, EventArgs e)
        {
            string searchText = txt_TimKiem.Text.Trim().ToLower();
            if (string.IsNullOrWhiteSpace(searchText))
            {
                MessageBox.Show("Vui lòng nhập tên sân để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var context = new SportsBookingContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == _username);
                if (user != null)
                {
                    var sportsFields = context.Courts.Where(sf => sf.UserID == user.UserID && sf.CourtName.ToLower() == searchText).ToList();

                    grid_San.Rows.Clear();
                    int index = 1;
                    foreach (var field in sportsFields)
                    {
                        grid_San.Rows.Add(
                            index++,
                            field.CourtName,
                            field.SportType,
                            field.VenueName,
                            field.PricePerHour,
                            string.IsNullOrEmpty(field.ImagePath) ? null : Image.FromFile(field.ImagePath),
                            field.TimeOpen.ToString(@"hh\:mm") + " - " + field.TimeClose.ToString(@"hh\:mm"),
                            field.CountTime
                        );
                    }

                    if (sportsFields.Count > 0)
                    {
                        MessageBox.Show($"Tìm thấy {sportsFields.Count} sân phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sân nào phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData(); 
                    }
                    txt_TimKiem.Text = "";
                }
                else
                {
                    MessageBox.Show("Không tìm thấy người dùng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoadData(); 
                }
            }
        }

        private void frm_QuanLySan_Load(object sender, EventArgs e)
        {
            txt_TimKiem.ForeColor = Color.Gray;
        }
    }
}
