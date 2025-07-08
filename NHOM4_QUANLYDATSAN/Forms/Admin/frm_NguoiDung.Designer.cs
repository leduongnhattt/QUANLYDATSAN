namespace NHOM4_QUANLYDATSAN.Forms.Admin
{
    partial class frm_NguoiDung
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.grid_NguoiDung = new System.Windows.Forms.DataGridView();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenDangNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHoVaTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoDienThoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMatKhau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayTao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHinhAnh = new System.Windows.Forms.DataGridViewImageColumn();
            this.btn_Them = new System.Windows.Forms.Button();
            this.btn_Sua = new System.Windows.Forms.Button();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_Tim = new System.Windows.Forms.Button();
            this.txt_TimKiem = new System.Windows.Forms.TextBox();
            this.btn_Xuat = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.grid_NguoiDung)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(51, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(423, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ NGƯỜI DÙNG";
            // 
            // grid_NguoiDung
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.grid_NguoiDung.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grid_NguoiDung.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid_NguoiDung.BackgroundColor = System.Drawing.Color.White;
            this.grid_NguoiDung.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_NguoiDung.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grid_NguoiDung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_NguoiDung.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSTT,
            this.colTenDangNhap,
            this.colHoVaTen,
            this.colEmail,
            this.colSoDienThoai,
            this.colDiaChi,
            this.colMatKhau,
            this.colNgayTao,
            this.colHinhAnh});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.DarkBlue;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_NguoiDung.DefaultCellStyle = dataGridViewCellStyle3;
            this.grid_NguoiDung.EnableHeadersVisualStyles = false;
            this.grid_NguoiDung.GridColor = System.Drawing.Color.Gainsboro;
            this.grid_NguoiDung.Location = new System.Drawing.Point(30, 198);
            this.grid_NguoiDung.MultiSelect = false;
            this.grid_NguoiDung.Name = "grid_NguoiDung";
            this.grid_NguoiDung.ReadOnly = true;
            this.grid_NguoiDung.RowHeadersWidth = 51;
            this.grid_NguoiDung.RowTemplate.Height = 150;
            this.grid_NguoiDung.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_NguoiDung.Size = new System.Drawing.Size(1538, 500);
            this.grid_NguoiDung.TabIndex = 1;
            // 
            // colSTT
            // 
            this.colSTT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSTT.FillWeight = 7F;
            this.colSTT.HeaderText = "STT";
            this.colSTT.MinimumWidth = 60;
            this.colSTT.Name = "colSTT";
            this.colSTT.ReadOnly = true;
            // 
            // colTenDangNhap
            // 
            this.colTenDangNhap.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTenDangNhap.FillWeight = 16F;
            this.colTenDangNhap.HeaderText = "Tên Đăng Nhập";
            this.colTenDangNhap.MinimumWidth = 140;
            this.colTenDangNhap.Name = "colTenDangNhap";
            this.colTenDangNhap.ReadOnly = true;
            // 
            // colHoVaTen
            // 
            this.colHoVaTen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colHoVaTen.FillWeight = 16F;
            this.colHoVaTen.HeaderText = "Họ và Tên";
            this.colHoVaTen.MinimumWidth = 140;
            this.colHoVaTen.Name = "colHoVaTen";
            this.colHoVaTen.ReadOnly = true;
            // 
            // colEmail
            // 
            this.colEmail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colEmail.FillWeight = 22F;
            this.colEmail.HeaderText = "Email";
            this.colEmail.MinimumWidth = 200;
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            // 
            // colSoDienThoai
            // 
            this.colSoDienThoai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSoDienThoai.FillWeight = 13F;
            this.colSoDienThoai.HeaderText = "Số Điện Thoại";
            this.colSoDienThoai.MinimumWidth = 120;
            this.colSoDienThoai.Name = "colSoDienThoai";
            this.colSoDienThoai.ReadOnly = true;
            // 
            // colDiaChi
            // 
            this.colDiaChi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDiaChi.FillWeight = 16F;
            this.colDiaChi.HeaderText = "Địa Chỉ";
            this.colDiaChi.MinimumWidth = 140;
            this.colDiaChi.Name = "colDiaChi";
            this.colDiaChi.ReadOnly = true;
            // 
            // colMatKhau
            // 
            this.colMatKhau.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMatKhau.FillWeight = 12F;
            this.colMatKhau.HeaderText = "Mật Khẩu";
            this.colMatKhau.MinimumWidth = 120;
            this.colMatKhau.Name = "colMatKhau";
            this.colMatKhau.ReadOnly = true;
            // 
            // colNgayTao
            // 
            this.colNgayTao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNgayTao.FillWeight = 10F;
            this.colNgayTao.HeaderText = "Ngày Tạo";
            this.colNgayTao.MinimumWidth = 100;
            this.colNgayTao.Name = "colNgayTao";
            this.colNgayTao.ReadOnly = true;
            // 
            // colHinhAnh
            // 
            this.colHinhAnh.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colHinhAnh.FillWeight = 28F;
            this.colHinhAnh.HeaderText = "Hình Ảnh";
            this.colHinhAnh.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colHinhAnh.MinimumWidth = 260;
            this.colHinhAnh.Name = "colHinhAnh";
            this.colHinhAnh.ReadOnly = true;
            // 
            // btn_Them
            // 
            this.btn_Them.BackColor = System.Drawing.Color.LightBlue;
            this.btn_Them.FlatAppearance.BorderColor = System.Drawing.Color.SkyBlue;
            this.btn_Them.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Them.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Them.Image = global::NHOM4_QUANLYDATSAN.Properties.Resources.icons8_user_30;
            this.btn_Them.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Them.Location = new System.Drawing.Point(473, 722);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_Them.Size = new System.Drawing.Size(150, 50);
            this.btn_Them.TabIndex = 2;
            this.btn_Them.Text = "   Thêm";
            this.btn_Them.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Them.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Them.UseVisualStyleBackColor = false;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            this.btn_Them.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.btn_Them.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // btn_Sua
            // 
            this.btn_Sua.BackColor = System.Drawing.Color.LightBlue;
            this.btn_Sua.FlatAppearance.BorderColor = System.Drawing.Color.SkyBlue;
            this.btn_Sua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Sua.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Sua.Image = global::NHOM4_QUANLYDATSAN.Properties.Resources.icons8_setting_32;
            this.btn_Sua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Sua.Location = new System.Drawing.Point(673, 722);
            this.btn_Sua.Name = "btn_Sua";
            this.btn_Sua.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_Sua.Size = new System.Drawing.Size(150, 50);
            this.btn_Sua.TabIndex = 3;
            this.btn_Sua.Text = "   Sửa";
            this.btn_Sua.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Sua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Sua.UseVisualStyleBackColor = false;
            this.btn_Sua.Click += new System.EventHandler(this.btn_Sua_Click);
            this.btn_Sua.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.btn_Sua.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.BackColor = System.Drawing.Color.LightBlue;
            this.btn_Xoa.FlatAppearance.BorderColor = System.Drawing.Color.SkyBlue;
            this.btn_Xoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Xoa.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Xoa.Location = new System.Drawing.Point(873, 722);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(150, 50);
            this.btn_Xoa.TabIndex = 4;
            this.btn_Xoa.Text = "Xóa";
            this.btn_Xoa.UseVisualStyleBackColor = false;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            this.btn_Xoa.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.btn_Xoa.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // btn_Tim
            // 
            this.btn_Tim.BackColor = System.Drawing.Color.LightBlue;
            this.btn_Tim.FlatAppearance.BorderColor = System.Drawing.Color.SkyBlue;
            this.btn_Tim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Tim.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Tim.Location = new System.Drawing.Point(1418, 113);
            this.btn_Tim.Name = "btn_Tim";
            this.btn_Tim.Size = new System.Drawing.Size(150, 50);
            this.btn_Tim.TabIndex = 5;
            this.btn_Tim.Text = "Tìm Kiếm";
            this.btn_Tim.UseVisualStyleBackColor = false;
            this.btn_Tim.Click += new System.EventHandler(this.btn_Tim_Click);
            this.btn_Tim.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.btn_Tim.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // txt_TimKiem
            // 
            this.txt_TimKiem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_TimKiem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txt_TimKiem.ForeColor = System.Drawing.Color.Gray;
            this.txt_TimKiem.Location = new System.Drawing.Point(1118, 121);
            this.txt_TimKiem.Name = "txt_TimKiem";
            this.txt_TimKiem.Size = new System.Drawing.Size(280, 34);
            this.txt_TimKiem.TabIndex = 6;
            this.txt_TimKiem.Text = "Nhập thông tin tìm kiếm...";
            // 
            // btn_Xuat
            // 
            this.btn_Xuat.BackColor = System.Drawing.Color.LightBlue;
            this.btn_Xuat.FlatAppearance.BorderColor = System.Drawing.Color.SkyBlue;
            this.btn_Xuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Xuat.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Xuat.Location = new System.Drawing.Point(1073, 722);
            this.btn_Xuat.Name = "btn_Xuat";
            this.btn_Xuat.Size = new System.Drawing.Size(150, 50);
            this.btn_Xuat.TabIndex = 7;
            this.btn_Xuat.Text = "Xuất File";
            this.btn_Xuat.UseVisualStyleBackColor = false;
            this.btn_Xuat.Click += new System.EventHandler(this.btn_Xuat_Click);
            this.btn_Xuat.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.btn_Xuat.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.Location = new System.Drawing.Point(532, -11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1500, 10);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.AliceBlue;
            this.panel2.Location = new System.Drawing.Point(51, 69);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(500, 2);
            this.panel2.TabIndex = 9;
            // 
            // frm_NguoiDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1611, 809);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_Xuat);
            this.Controls.Add(this.txt_TimKiem);
            this.Controls.Add(this.btn_Tim);
            this.Controls.Add(this.btn_Xoa);
            this.Controls.Add(this.btn_Sua);
            this.Controls.Add(this.btn_Them);
            this.Controls.Add(this.grid_NguoiDung);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_NguoiDung";
            this.Text = "frm_NguoiDung";
            this.Load += new System.EventHandler(this.frm_NguoiDung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_NguoiDung)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grid_NguoiDung;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.Button btn_Sua;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button btn_Tim;
        private System.Windows.Forms.TextBox txt_TimKiem;
        private System.Windows.Forms.Button btn_Xuat;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenDangNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoVaTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoDienThoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMatKhau;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayTao;
        private System.Windows.Forms.DataGridViewImageColumn colHinhAnh;
    }
}