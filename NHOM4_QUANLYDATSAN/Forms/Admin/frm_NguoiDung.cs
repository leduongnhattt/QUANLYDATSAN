using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NHOM4_QUANLYDATSAN.Helpers;
using System.Data.SqlClient;

namespace NHOM4_QUANLYDATSAN.Forms.Admin
{
    public partial class frm_NguoiDung : Form
    {
        private void btn_Load_Click(object sender, EventArgs e)
        {
            LoadDataToGridView();
            txt_TimKiem.Text = "Nhập thông tin tìm kiếm...";
            txt_TimKiem.ForeColor = Color.Gray;
        }
        private const string QUERY_USERS = "SELECT UserId, Username, FullName, Email, Phone, Address, Password, CreatedAt, AvatarPath FROM Users WHERE RoleID = 2";

        public frm_NguoiDung()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            SetupForm();
            LoadDataToGridView();
            // Đảm bảo DataGridView luôn fit cột khi resize form
            this.Resize += (s, e) => AdjustGridColumns();
        }

        private void SetupForm()
        {
            // Thiết lập placeholder cho textbox tìm kiếm
            txt_TimKiem.Enter += TextBox1_Enter;
            txt_TimKiem.Leave += TextBox1_Leave;
            
            // Thiết lập font và style cho buttons
            SetButtonStyle(btn_Them);
            SetButtonStyle(btn_Sua);
            SetButtonStyle(btn_Xoa);
            SetButtonStyle(btn_Tim);
            SetButtonStyle(btn_Xuat);
        }

        private void TextBox1_Enter(object sender, EventArgs e)
        {
            if (txt_TimKiem.Text == "Nhập thông tin tìm kiếm...")
            {
                txt_TimKiem.Text = "";
                txt_TimKiem.ForeColor = Color.Black;
            }
        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_TimKiem.Text))
            {
                txt_TimKiem.Text = "Nhập thông tin tìm kiếm...";
                txt_TimKiem.ForeColor = Color.Gray;
            }
        }

        private void SetButtonStyle(Button button)
        {
            button.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 1;
            button.FlatAppearance.BorderColor = Color.SkyBlue;
            button.Cursor = Cursors.Hand;
        }

        private void frm_NguoiDung_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
            // Thiết lập giao diện DataGridView
            SetupDataGridView();
            AdjustGridColumns();
        }

        /// <summary>
        /// Đảm bảo DataGridView luôn fit hết các cột, không xuất hiện scroll bar ngang
        /// </summary>
        private void AdjustGridColumns()
        {
            // Đảm bảo AutoSizeColumnsMode luôn là Fill
            grid_NguoiDung.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // Đảm bảo không có scroll bar ngang
            grid_NguoiDung.ScrollBars = ScrollBars.Vertical;
            // Đảm bảo FillWeight không bị reset khi resize
            foreach (DataGridViewColumn col in grid_NguoiDung.Columns)
            {
                // Giữ nguyên FillWeight đã set trong Designer
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void SetupDataGridView()
        {
            // Thiết lập style cho DataGridView
            grid_NguoiDung.BorderStyle = BorderStyle.None;
            grid_NguoiDung.RowHeadersVisible = false;
            grid_NguoiDung.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid_NguoiDung.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            
            // Tạo đường viền ngoài cho DataGridView
            grid_NguoiDung.Paint += (s, e) => {
                e.Graphics.DrawRectangle(new Pen(Color.LightSkyBlue, 1), 
                    new Rectangle(0, 0, grid_NguoiDung.Width - 1, grid_NguoiDung.Height - 1));
            };

            // Thiết lập màu sắc cho header
            grid_NguoiDung.EnableHeadersVisualStyles = false;
            grid_NguoiDung.ColumnHeadersDefaultCellStyle.BackColor = Color.SkyBlue;
            grid_NguoiDung.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid_NguoiDung.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            grid_NguoiDung.ColumnHeadersHeight = 40;
        }

        private void LoadDataToGridView()
        {
            
            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(QUERY_USERS, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Thêm cột STT vào DataTable
                            dataTable.Columns.Add("STT", typeof(int));

                            // Thêm cột AvatarImage kiểu Image
                            if (!dataTable.Columns.Contains("AvatarImage"))
                                dataTable.Columns.Add("AvatarImage", typeof(Image));

                            // Chuyển đổi AvatarPath (string) sang AvatarImage (Image)
                            foreach (DataRow row in dataTable.Rows)
                            {
                                object avatarPathObj = row["AvatarPath"];
                                if (avatarPathObj != DBNull.Value && !string.IsNullOrEmpty(avatarPathObj.ToString()))
                                {
                                    try
                                    {
                                        row["AvatarImage"] = Image.FromFile(avatarPathObj.ToString());
                                    }
                                    catch
                                    {
                                        row["AvatarImage"] = null;
                                    }
                                }
                                else
                                {
                                    row["AvatarImage"] = null;
                                }
                            }

                            // Thêm giá trị tự tăng cho cột STT
                            for (int i = 0; i < dataTable.Rows.Count; i++)
                            {
                                dataTable.Rows[i]["STT"] = i + 1;
                            }

                            grid_NguoiDung.AutoGenerateColumns = false;
                            grid_NguoiDung.Columns.Clear();

                            grid_NguoiDung.Columns.Add(new DataGridViewTextBoxColumn { Name = "colSTT", HeaderText = "STT", DataPropertyName = "STT", Width = 50 });
                            grid_NguoiDung.Columns.Add(new DataGridViewTextBoxColumn { Name = "colUsername", HeaderText = "Tên Đăng Nhập", DataPropertyName = "Username", Width = 150 });
                            grid_NguoiDung.Columns.Add(new DataGridViewTextBoxColumn { Name = "colFullName", HeaderText = "Họ và Tên", DataPropertyName = "FullName", Width = 150 });
                            grid_NguoiDung.Columns.Add(new DataGridViewTextBoxColumn { Name = "colEmail", HeaderText = "Email", DataPropertyName = "Email", Width = 200 });
                            grid_NguoiDung.Columns.Add(new DataGridViewTextBoxColumn { Name = "colPhone", HeaderText = "Số Điện Thoại", DataPropertyName = "Phone", Width = 120 });
                            grid_NguoiDung.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAddress", HeaderText = "Địa Chỉ", DataPropertyName = "Address", Width = 200 });
                            grid_NguoiDung.Columns.Add(new DataGridViewTextBoxColumn { Name = "colPassword", HeaderText = "Mật Khẩu", DataPropertyName = "Password", Width = 150 });
                            grid_NguoiDung.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCreatedAt", HeaderText = "Ngày Tạo", DataPropertyName = "CreatedAt", Width = 120 });
                            grid_NguoiDung.Columns.Add(new DataGridViewImageColumn { Name = "colAvatar", HeaderText = "Hình Ảnh", DataPropertyName = "AvatarImage", Width = 160, ImageLayout = DataGridViewImageCellLayout.Zoom });

                            grid_NguoiDung.DataSource = dataTable;
                        }
                    }
                }
                finally
                {
                    DatabaseHelper.CloseConnection(connection);
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate();
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.LightSkyBlue;
                button.ForeColor = Color.DarkBlue;
            }
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.LightBlue;
                button.ForeColor = Color.Black;
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            frm_ThemNguoiDung frmThem = new frm_ThemNguoiDung();
            frmThem.ShowDialog();
        }
        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (grid_NguoiDung.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn người dùng cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var row = grid_NguoiDung.SelectedRows[0];
            string username = row.Cells["colUsername"] != null ? row.Cells["colUsername"].Value?.ToString() : null;
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Không lấy được thông tin người dùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Lấy thông tin user từ row
            string fullName = row.Cells["colFullName"].Value?.ToString();
            string email = row.Cells["colEmail"].Value?.ToString();
            string phone = row.Cells["colPhone"].Value?.ToString();
            string address = row.Cells["colAddress"].Value?.ToString();
            string password = row.Cells["colPassword"].Value?.ToString();

            // Lấy đúng đường dẫn ảnh từ DataBoundItem (DataRowView)
            string avatarPath = null;
            if (row.DataBoundItem is DataRowView drv && drv.DataView.Table.Columns.Contains("AvatarPath"))
                avatarPath = drv["AvatarPath"]?.ToString();

            // Mở form thêm người dùng ở chế độ sửa
            frm_ThemNguoiDung frmSua = new frm_ThemNguoiDung();
            frmSua.SetEditMode(username, fullName, email, phone, address, password, avatarPath);
            frmSua.ShowDialog();
            LoadDataToGridView();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (grid_NguoiDung.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn người dùng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var row = grid_NguoiDung.SelectedRows[0];
            string username = row.Cells["colUsername"] != null ? row.Cells["colUsername"].Value?.ToString() : null;
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Không lấy được thông tin người dùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var confirm = MessageBox.Show($"Bạn có chắc muốn xóa người dùng '{username}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                DeleteUser(username);
                LoadDataToGridView();
            }
        }

        private void btn_Tim_Click(object sender, EventArgs e)
        {
            string username = txt_TimKiem.Text.Trim();
            if (string.IsNullOrEmpty(username) || username == "Nhập thông tin tìm kiếm...")
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                try
                {
                    // Lấy đúng các trường như DataGridView đang hiển thị
                    string query = "SELECT UserId, Username, FullName, Email, Phone, Address, Password, CreatedAt, AvatarPath FROM Users WHERE Username = @Username AND RoleID = 2";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    if (dt.Columns.Contains("STT"))
                                        dt.Rows[i]["STT"] = i + 1;
                                    if (dt.Columns.Contains("AvatarImage"))
                                    {
                                        object avatarPathObj = dt.Rows[i]["AvatarPath"];
                                        if (avatarPathObj != DBNull.Value && !string.IsNullOrEmpty(avatarPathObj.ToString()))
                                        {
                                            try { dt.Rows[i]["AvatarImage"] = Image.FromFile(avatarPathObj.ToString()); }
                                            catch { dt.Rows[i]["AvatarImage"] = null; }
                                        }
                                        else
                                        {
                                            dt.Rows[i]["AvatarImage"] = null;
                                        }
                                    }
                                }
                                grid_NguoiDung.AutoGenerateColumns = false;
                                grid_NguoiDung.DataSource = dt;
                                MessageBox.Show($"Tìm thấy người dùng '{username}' trong hệ thống!", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show($"Không tìm thấy người dùng '{username}'!", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                finally
                {
                    DatabaseHelper.CloseConnection(connection);
                }
            }
        }

        private void btn_Xuat_Click(object sender, EventArgs e)
        {
            if (grid_NguoiDung.DataSource is DataTable dt)
            {
                var dialog = MessageBox.Show("Bạn muốn xuất dữ liệu ra file Excel (.xlsx) hay file văn bản (.txt)?\n\nChọn Yes để xuất Excel, No để xuất TXT.", "Chọn định dạng xuất file", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (dialog == DialogResult.Cancel) return;
                if (dialog == DialogResult.Yes)
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "Excel files (*.xlsx)|*.xlsx";
                    sfd.Title = "Xuất dữ liệu người dùng ra file Excel";
                    sfd.FileName = "nguoidung.xlsx";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            using (var workbook = new XLWorkbook())
                            {
                                var ws = workbook.Worksheets.Add("NguoiDung");
                                int col = 1;
                                foreach (DataColumn dc in dt.Columns)
                                {
                                    if (dc.ColumnName == "AvatarImage") continue;
                                    ws.Cell(1, col).Value = dc.ColumnName;
                                    col++;
                                }
                                int row = 2;
                                foreach (DataRow dr in dt.Rows)
                                {
                                    col = 1;
                                    foreach (DataColumn dc in dt.Columns)
                                    {
                                        if (dc.ColumnName == "AvatarImage") continue;
                                        ws.Cell(row, col).Value = dr[dc.ColumnName]?.ToString();
                                        col++;
                                    }
                                    row++;
                                }
                                ws.Columns().AdjustToContents();
                                workbook.SaveAs(sfd.FileName);
                            }
                            MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Lỗi khi xuất file Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else if (dialog == DialogResult.No)
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "Text files (*.txt)|*.txt";
                    sfd.Title = "Xuất dữ liệu người dùng ra file văn bản";
                    sfd.FileName = "nguoidung.txt";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            using (var sw = new System.IO.StreamWriter(sfd.FileName, false, Encoding.UTF8))
                            {
                                var headers = dt.Columns.Cast<DataColumn>().Where(c => c.ColumnName != "AvatarImage").Select(c => c.ColumnName);
                                sw.WriteLine(string.Join("\t", headers));
                                foreach (DataRow dr in dt.Rows)
                                {
                                    var fields = dt.Columns.Cast<DataColumn>().Where(c => c.ColumnName != "AvatarImage").Select(c => dr[c]?.ToString()?.Replace("\t", " ") ?? "");
                                    sw.WriteLine(string.Join("\t", fields));
                                }
                            }
                            MessageBox.Show("Xuất file TXT thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Lỗi khi xuất file TXT: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Xóa user theo username
        private void DeleteUser(string username)
        {
            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                try
                {
                    string query = "DELETE FROM Users WHERE Username = @Username";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.ExecuteNonQuery();
                    }
                }
                finally
                {
                    DatabaseHelper.CloseConnection(connection);
                }
            }
        }
    }
}
