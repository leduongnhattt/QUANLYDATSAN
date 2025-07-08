using NHOM4_QUANLYDATSAN.Data;
using NHOM4_QUANLYDATSAN.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NHOM4_QUANLYDATSAN.Forms.Owner
{
    public partial class frm_ThemSan : Form
    {
        private string _username;
        private int _userID;
        private Court _courtToEdit;

        public frm_ThemSan(string username)
        {
            InitializeComponent();
            _username = username;
            using (var context = new SportsBookingContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == _username);
                if (user != null)
                {
                    _userID = user.UserID;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy người dùng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }

        public frm_ThemSan(string username, Court courtToEdit) : this(username)
        {
            _courtToEdit = courtToEdit;
            LoadCourtData();
        }

        private void LoadCourtData()
        {
            if (_courtToEdit != null)
            {
                txt_TenSan.TextButton = _courtToEdit.CourtName;
                txt_Mon.TextButton = _courtToEdit.SportType;
                txt_DiaDiem.Text = _courtToEdit.VenueName;
                txt_Gia.TextButton = _courtToEdit.PricePerHour.ToString();
                if (!string.IsNullOrEmpty(_courtToEdit.ImagePath) && System.IO.File.Exists(_courtToEdit.ImagePath))
                {
                    using (var stream = new System.IO.FileStream(_courtToEdit.ImagePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                    {
                        using (var tempImage = new Bitmap(stream))
                        {
                            pic_HinhAnh.Image = new Bitmap(tempImage); // Make a copy to avoid file lock
                        }
                    }
                    pic_HinhAnh.Tag = _courtToEdit.ImagePath;
                }
                txt_Gio.TextButton = _courtToEdit.CountTime.ToString();
                date_MoCua.Value = DateTime.Today.Add(_courtToEdit.TimeOpen);
                date_DongCua.Value = DateTime.Today.Add(_courtToEdit.TimeClose);
                btn_Them.TextButton = "Sửa";
                bigLabel1.Text = "SỬA THÔNG TIN SÂN";
            }
        }

        private void pic_HinhAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var stream = new System.IO.FileStream(openFileDialog.FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                    {
                        using (var tempImage = new Bitmap(stream))
                        {
                            pic_HinhAnh.Image = new Bitmap(tempImage); // Make a copy to avoid file lock
                        }
                    }
                    pic_HinhAnh.Tag = openFileDialog.FileName;
                }
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            StringBuilder errorMessages = new StringBuilder();

            // Ensure trimmed values are checked
            string tenSan = txt_TenSan.TextButton.Trim();
            string monThiDau = txt_Mon.TextButton.Trim();
            string diaDiem = txt_DiaDiem.Text.Trim();
            string giaText = txt_Gia.TextButton.Trim();
            int gioThiDau = int.Parse(txt_Gio.TextButton.Trim());
            TimeSpan timeOpen = date_MoCua.Value.TimeOfDay;
            TimeSpan timeClose = date_DongCua.Value.TimeOfDay;

            if (gioThiDau <= 0)
            {
                errorMessages.AppendLine("Giờ thi đấu phải lớn hơn 0.");
            }

            if (string.IsNullOrWhiteSpace(tenSan))
            {
                errorMessages.AppendLine("Tên sân không được để trống.");
            }

            if (string.IsNullOrWhiteSpace(monThiDau))
            {
                errorMessages.AppendLine("Môn thi đấu không được để trống.");
            }

            if (string.IsNullOrWhiteSpace(diaDiem))
            {
                errorMessages.AppendLine("Địa điểm không được để trống.");
            }

            decimal price = 0;
            if (string.IsNullOrWhiteSpace(giaText) || !decimal.TryParse(giaText, out price) || price <= 0)
            {
                errorMessages.AppendLine("Giá phải là số hợp lệ theo định dạng 10 000.");
            }

            if (pic_HinhAnh.Tag == null)
            {
                errorMessages.AppendLine("Hình ảnh không được để trống.");
            }

            if (errorMessages.Length > 0)
            {
                MessageBox.Show(errorMessages.ToString(), "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string imagePath = pic_HinhAnh.Tag.ToString();
            string resourcesPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Resources");
            if (!System.IO.Directory.Exists(resourcesPath))
            {
                System.IO.Directory.CreateDirectory(resourcesPath);
            }
            string newImagePath = System.IO.Path.Combine(resourcesPath, System.IO.Path.GetFileName(imagePath));

            try
            {
                System.IO.File.Copy(imagePath, newImagePath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể sao chép hình ảnh. Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var context = new SportsBookingContext())
            {
                if (_courtToEdit != null)
                {
                    var courtToUpdate = context.Courts.FirstOrDefault(c => c.CourtID == _courtToEdit.CourtID);
                    if (courtToUpdate != null)
                    {
                        // Update existing court
                        courtToUpdate.CourtName = tenSan;
                        courtToUpdate.SportType = monThiDau;
                        courtToUpdate.PricePerHour = price;
                        courtToUpdate.TimeOpen = timeOpen;
                        courtToUpdate.TimeClose = timeClose;
                        courtToUpdate.CountTime = gioThiDau;
                        courtToUpdate.VenueName = diaDiem;
                        courtToUpdate.ImagePath = newImagePath;
                        context.SaveChanges();
                        MessageBox.Show("Sửa sân thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sân để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    var newCourt = new Court
                    {
                        CourtName = tenSan,
                        SportType = monThiDau,
                        PricePerHour = price,
                        TimeOpen = timeOpen,
                        TimeClose = timeClose,
                        CountTime = gioThiDau,
                        Status = "Còn Sân",
                        ImagePath = newImagePath,
                        Note = "",
                        VenueName = diaDiem,
                        UserID = _userID
                    };
                    context.Courts.Add(newCourt);
                    context.SaveChanges();
                    MessageBox.Show("Thêm sân thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            this.Close();
        }

        private void btn_LayAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var stream = new System.IO.FileStream(openFileDialog.FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                        {
                            using (var image = Image.FromStream(stream))
                            {
                                if (image.Width > 5000 || image.Height > 5000) // Example size limit
                                {
                                    MessageBox.Show("Hình ảnh quá lớn. Vui lòng chọn hình ảnh nhỏ hơn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                pic_HinhAnh.Image = new Bitmap(image); // Load image safely
                                pic_HinhAnh.Tag = openFileDialog.FileName; // Store the file path in the Tag property
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Không thể tải hình ảnh. Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ClearFields()
        {
            txt_TenSan.TextButton = string.Empty;
            txt_Mon.TextButton = string.Empty;
            txt_DiaDiem.Text = string.Empty;
            txt_Gia.TextButton = string.Empty;
            pic_HinhAnh.Image = null;
            pic_HinhAnh.Tag = null;
            txt_Gio.TextButton = string.Empty;
            date_MoCua.Text = string.Empty;
            date_DongCua.Text = string.Empty;
        }
    }
}
