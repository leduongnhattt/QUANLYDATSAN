namespace NHOM4_QUANLYDATSAN.Forms.Owner
{
    partial class frm_QuanLyDatSan
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
            this.grid_DatSan = new ReaLTaiizor.Controls.PoisonDataGridView();
            this.col_STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Sdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ThoiGian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Gio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_tenSan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_HoiVien = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_TongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.col_Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btn_Tim = new ReaLTaiizor.Controls.Button();
            this.txt_TimKiem = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            this.lbl_NgayDat = new System.Windows.Forms.Label();
            this.date_NgayDat = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.grid_DatSan)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "QUẢN LÝ ĐẶT SÂN";
            // 
            // grid_DatSan
            // 
            this.grid_DatSan.AllowUserToResizeRows = false;
            this.grid_DatSan.BackgroundColor = System.Drawing.Color.LightYellow;
            this.grid_DatSan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid_DatSan.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grid_DatSan.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_DatSan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid_DatSan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_DatSan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_STT,
            this.col_HoTen,
            this.col_Sdt,
            this.col_ThoiGian,
            this.col_Gio,
            this.col_tenSan,
            this.col_TrangThai,
            this.col_HoiVien,
            this.col_TongTien,
            this.col_Edit,
            this.col_Delete});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid_DatSan.DefaultCellStyle = dataGridViewCellStyle2;
            this.grid_DatSan.EnableHeadersVisualStyles = false;
            this.grid_DatSan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grid_DatSan.GridColor = System.Drawing.Color.Red;
            this.grid_DatSan.Location = new System.Drawing.Point(12, 147);
            this.grid_DatSan.Name = "grid_DatSan";
            this.grid_DatSan.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_DatSan.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grid_DatSan.RowHeadersWidth = 51;
            this.grid_DatSan.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grid_DatSan.RowTemplate.DividerHeight = 2;
            this.grid_DatSan.RowTemplate.Height = 50;
            this.grid_DatSan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_DatSan.Size = new System.Drawing.Size(1278, 558);
            this.grid_DatSan.TabIndex = 2;
            this.grid_DatSan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_DatSan_CellContentClick);
            // 
            // col_STT
            // 
            this.col_STT.HeaderText = "STT";
            this.col_STT.MinimumWidth = 6;
            this.col_STT.Name = "col_STT";
            this.col_STT.Width = 75;
            // 
            // col_HoTen
            // 
            this.col_HoTen.HeaderText = "Tên Khách Hàng";
            this.col_HoTen.MinimumWidth = 6;
            this.col_HoTen.Name = "col_HoTen";
            this.col_HoTen.Width = 150;
            // 
            // col_Sdt
            // 
            this.col_Sdt.HeaderText = "Số điện thoại";
            this.col_Sdt.MinimumWidth = 6;
            this.col_Sdt.Name = "col_Sdt";
            this.col_Sdt.Width = 125;
            // 
            // col_ThoiGian
            // 
            this.col_ThoiGian.HeaderText = "Thời Gian";
            this.col_ThoiGian.MinimumWidth = 6;
            this.col_ThoiGian.Name = "col_ThoiGian";
            this.col_ThoiGian.Width = 125;
            // 
            // col_Gio
            // 
            this.col_Gio.HeaderText = "Số Giờ Được Đặt";
            this.col_Gio.MinimumWidth = 6;
            this.col_Gio.Name = "col_Gio";
            this.col_Gio.Width = 150;
            // 
            // col_tenSan
            // 
            this.col_tenSan.HeaderText = "Tên Sân";
            this.col_tenSan.MinimumWidth = 6;
            this.col_tenSan.Name = "col_tenSan";
            this.col_tenSan.Width = 125;
            // 
            // col_TrangThai
            // 
            this.col_TrangThai.HeaderText = "Trạng Thái";
            this.col_TrangThai.MinimumWidth = 6;
            this.col_TrangThai.Name = "col_TrangThai";
            this.col_TrangThai.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_TrangThai.Width = 125;
            // 
            // col_HoiVien
            // 
            this.col_HoiVien.HeaderText = "Hội Viên";
            this.col_HoiVien.MinimumWidth = 6;
            this.col_HoiVien.Name = "col_HoiVien";
            this.col_HoiVien.Width = 75;
            // 
            // col_TongTien
            // 
            this.col_TongTien.HeaderText = "Tổng Tiền";
            this.col_TongTien.MinimumWidth = 6;
            this.col_TongTien.Name = "col_TongTien";
            this.col_TongTien.ReadOnly = true;
            this.col_TongTien.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_TongTien.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_TongTien.Width = 125;
            // 
            // col_Edit
            // 
            this.col_Edit.HeaderText = "";
            this.col_Edit.MinimumWidth = 6;
            this.col_Edit.Name = "col_Edit";
            this.col_Edit.Text = "Sửa";
            this.col_Edit.UseColumnTextForButtonValue = true;
            this.col_Edit.Width = 75;
            // 
            // col_Delete
            // 
            this.col_Delete.HeaderText = "";
            this.col_Delete.MinimumWidth = 6;
            this.col_Delete.Name = "col_Delete";
            this.col_Delete.Text = "Xóa";
            this.col_Delete.UseColumnTextForButtonValue = true;
            this.col_Delete.Width = 75;
            // 
            // btn_Tim
            // 
            this.btn_Tim.BackColor = System.Drawing.Color.Transparent;
            this.btn_Tim.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btn_Tim.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Tim.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btn_Tim.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btn_Tim.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_Tim.Image = null;
            this.btn_Tim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Tim.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btn_Tim.Location = new System.Drawing.Point(1170, 95);
            this.btn_Tim.Name = "btn_Tim";
            this.btn_Tim.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btn_Tim.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btn_Tim.Size = new System.Drawing.Size(120, 40);
            this.btn_Tim.TabIndex = 6;
            this.btn_Tim.Text = "Tìm Kiếm";
            this.btn_Tim.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btn_Tim.Click += new System.EventHandler(this.btn_Tim_Click);
            // 
            // txt_TimKiem
            // 
            this.txt_TimKiem.AnimateReadOnly = false;
            this.txt_TimKiem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txt_TimKiem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txt_TimKiem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txt_TimKiem.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txt_TimKiem.Depth = 0;
            this.txt_TimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txt_TimKiem.HideSelection = true;
            this.txt_TimKiem.Hint = "Nhập tên khách hàng để tìm kiếm ...";
            this.txt_TimKiem.LeadingIcon = null;
            this.txt_TimKiem.Location = new System.Drawing.Point(876, 87);
            this.txt_TimKiem.MaxLength = 32767;
            this.txt_TimKiem.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            this.txt_TimKiem.Name = "txt_TimKiem";
            this.txt_TimKiem.PasswordChar = '\0';
            this.txt_TimKiem.PrefixSuffixText = null;
            this.txt_TimKiem.ReadOnly = false;
            this.txt_TimKiem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_TimKiem.SelectedText = "";
            this.txt_TimKiem.SelectionLength = 0;
            this.txt_TimKiem.SelectionStart = 0;
            this.txt_TimKiem.ShortcutsEnabled = true;
            this.txt_TimKiem.Size = new System.Drawing.Size(267, 48);
            this.txt_TimKiem.TabIndex = 7;
            this.txt_TimKiem.TabStop = false;
            this.txt_TimKiem.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_TimKiem.TrailingIcon = null;
            this.txt_TimKiem.UseSystemPasswordChar = false;
            // 
            // lbl_NgayDat
            // 
            this.lbl_NgayDat.AutoSize = true;
            this.lbl_NgayDat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NgayDat.Location = new System.Drawing.Point(12, 95);
            this.lbl_NgayDat.Name = "lbl_NgayDat";
            this.lbl_NgayDat.Size = new System.Drawing.Size(153, 25);
            this.lbl_NgayDat.TabIndex = 8;
            this.lbl_NgayDat.Text = "Lịch sân ngày:";
            // 
            // date_NgayDat
            // 
            this.date_NgayDat.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_NgayDat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_NgayDat.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_NgayDat.Location = new System.Drawing.Point(189, 90);
            this.date_NgayDat.Name = "date_NgayDat";
            this.date_NgayDat.Size = new System.Drawing.Size(255, 30);
            this.date_NgayDat.TabIndex = 9;
            this.date_NgayDat.ValueChanged += new System.EventHandler(this.Date_NgayDat_ValueChanged);
            // 
            // frm_QuanLyDatSan
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1351, 760);
            this.Controls.Add(this.date_NgayDat);
            this.Controls.Add(this.lbl_NgayDat);
            this.Controls.Add(this.txt_TimKiem);
            this.Controls.Add(this.btn_Tim);
            this.Controls.Add(this.grid_DatSan);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_QuanLyDatSan";
            this.Text = "frm_TrangChu";
            this.Load += new System.EventHandler(this.frm_QuanLyDatSan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_DatSan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ReaLTaiizor.Controls.PoisonDataGridView grid_DatSan;
        private ReaLTaiizor.Controls.Button btn_Tim;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit txt_TimKiem;
        private System.Windows.Forms.Label lbl_NgayDat;
        private System.Windows.Forms.DateTimePicker date_NgayDat;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Sdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ThoiGian;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Gio;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tenSan;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_TrangThai;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_HoiVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_TongTien;
        private System.Windows.Forms.DataGridViewButtonColumn col_Edit;
        private System.Windows.Forms.DataGridViewButtonColumn col_Delete;
    }
}