namespace NHOM4_QUANLYDATSAN.Forms.Owner
{
    partial class frm_HoiVien
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
            this.lbl_TenKhachHang = new System.Windows.Forms.Label();
            this.lbl_Sdt = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_TenKhachHang = new System.Windows.Forms.TextBox();
            this.txt_Sdt = new System.Windows.Forms.TextBox();
            this.txt_HoiVien = new System.Windows.Forms.TextBox();
            this.txt_GhiChu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Tuan = new System.Windows.Forms.TextBox();
            this.txt_Them = new ReaLTaiizor.Controls.Button();
            this.cbb_HoiVien = new System.Windows.Forms.ComboBox();
            this.grid_HoiVien = new ReaLTaiizor.Controls.PoisonDataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_TenKhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Sdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_NgayBD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_NgayKT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_GiamGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.col_Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grid_HoiVien)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(284, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "ĐĂNG KÝ HỘI VIÊN";
            // 
            // lbl_TenKhachHang
            // 
            this.lbl_TenKhachHang.AutoSize = true;
            this.lbl_TenKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TenKhachHang.Location = new System.Drawing.Point(196, 94);
            this.lbl_TenKhachHang.Name = "lbl_TenKhachHang";
            this.lbl_TenKhachHang.Size = new System.Drawing.Size(175, 25);
            this.lbl_TenKhachHang.TabIndex = 2;
            this.lbl_TenKhachHang.Text = "Tên Khách Hàng";
            // 
            // lbl_Sdt
            // 
            this.lbl_Sdt.AutoSize = true;
            this.lbl_Sdt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Sdt.Location = new System.Drawing.Point(196, 164);
            this.lbl_Sdt.Name = "lbl_Sdt";
            this.lbl_Sdt.Size = new System.Drawing.Size(139, 25);
            this.lbl_Sdt.TabIndex = 3;
            this.lbl_Sdt.Text = "Số điện thoại";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(196, 236);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(196, 318);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Gói Hội Viên";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(766, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ghi Chú";
            // 
            // txt_TenKhachHang
            // 
            this.txt_TenKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TenKhachHang.Location = new System.Drawing.Point(399, 91);
            this.txt_TenKhachHang.Name = "txt_TenKhachHang";
            this.txt_TenKhachHang.Size = new System.Drawing.Size(253, 30);
            this.txt_TenKhachHang.TabIndex = 7;
            // 
            // txt_Sdt
            // 
            this.txt_Sdt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Sdt.Location = new System.Drawing.Point(399, 159);
            this.txt_Sdt.Name = "txt_Sdt";
            this.txt_Sdt.Size = new System.Drawing.Size(253, 30);
            this.txt_Sdt.TabIndex = 8;
            // 
            // txt_HoiVien
            // 
            this.txt_HoiVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_HoiVien.Location = new System.Drawing.Point(399, 233);
            this.txt_HoiVien.Name = "txt_HoiVien";
            this.txt_HoiVien.Size = new System.Drawing.Size(253, 30);
            this.txt_HoiVien.TabIndex = 9;
            // 
            // txt_GhiChu
            // 
            this.txt_GhiChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_GhiChu.Location = new System.Drawing.Point(902, 91);
            this.txt_GhiChu.Multiline = true;
            this.txt_GhiChu.Name = "txt_GhiChu";
            this.txt_GhiChu.Size = new System.Drawing.Size(253, 172);
            this.txt_GhiChu.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(766, 313);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 25);
            this.label5.TabIndex = 13;
            this.label5.Text = "Số Tuần";
            // 
            // txt_Tuan
            // 
            this.txt_Tuan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Tuan.Location = new System.Drawing.Point(902, 310);
            this.txt_Tuan.Name = "txt_Tuan";
            this.txt_Tuan.Size = new System.Drawing.Size(253, 30);
            this.txt_Tuan.TabIndex = 14;
            // 
            // txt_Them
            // 
            this.txt_Them.BackColor = System.Drawing.Color.Transparent;
            this.txt_Them.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.txt_Them.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txt_Them.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.txt_Them.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.txt_Them.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txt_Them.Image = null;
            this.txt_Them.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_Them.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.txt_Them.Location = new System.Drawing.Point(651, 387);
            this.txt_Them.Name = "txt_Them";
            this.txt_Them.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.txt_Them.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.txt_Them.Size = new System.Drawing.Size(120, 51);
            this.txt_Them.TabIndex = 15;
            this.txt_Them.Text = "Thêm";
            this.txt_Them.TextAlignment = System.Drawing.StringAlignment.Center;
            this.txt_Them.Click += new System.EventHandler(this.txt_Them_Click);
            // 
            // cbb_HoiVien
            // 
            this.cbb_HoiVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_HoiVien.FormattingEnabled = true;
            this.cbb_HoiVien.Items.AddRange(new object[] {
            "Theo Tuần- Giảm 5%",
            "Theo Tháng - Giảm 10%",
            "Theo Năm - Giảm 15%"});
            this.cbb_HoiVien.Location = new System.Drawing.Point(399, 310);
            this.cbb_HoiVien.Name = "cbb_HoiVien";
            this.cbb_HoiVien.Size = new System.Drawing.Size(253, 33);
            this.cbb_HoiVien.TabIndex = 16;
            this.cbb_HoiVien.SelectedIndexChanged += new System.EventHandler(this.cbb_HoiVien_SelectedIndexChanged);
            // 
            // grid_HoiVien
            // 
            this.grid_HoiVien.AllowUserToResizeRows = false;
            this.grid_HoiVien.BackgroundColor = System.Drawing.Color.LightYellow;
            this.grid_HoiVien.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid_HoiVien.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grid_HoiVien.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_HoiVien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid_HoiVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_HoiVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.col_TenKhachHang,
            this.col_Sdt,
            this.col_Email,
            this.col_NgayBD,
            this.col_NgayKT,
            this.col_GiamGia,
            this.col_GhiChu,
            this.col_Edit,
            this.col_Delete});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid_HoiVien.DefaultCellStyle = dataGridViewCellStyle2;
            this.grid_HoiVien.EnableHeadersVisualStyles = false;
            this.grid_HoiVien.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grid_HoiVien.GridColor = System.Drawing.Color.Red;
            this.grid_HoiVien.Location = new System.Drawing.Point(65, 479);
            this.grid_HoiVien.Name = "grid_HoiVien";
            this.grid_HoiVien.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_HoiVien.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grid_HoiVien.RowHeadersWidth = 51;
            this.grid_HoiVien.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grid_HoiVien.RowTemplate.DividerHeight = 2;
            this.grid_HoiVien.RowTemplate.Height = 30;
            this.grid_HoiVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_HoiVien.Size = new System.Drawing.Size(1231, 256);
            this.grid_HoiVien.TabIndex = 17;
            this.grid_HoiVien.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_HoiVien_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.HeaderText = "STT";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 75;
            // 
            // col_TenKhachHang
            // 
            this.col_TenKhachHang.DataPropertyName = "col_TenKhachHang";
            this.col_TenKhachHang.HeaderText = "Tên Khách Hàng";
            this.col_TenKhachHang.MinimumWidth = 6;
            this.col_TenKhachHang.Name = "col_TenKhachHang";
            this.col_TenKhachHang.Width = 150;
            // 
            // col_Sdt
            // 
            this.col_Sdt.DataPropertyName = "col_Sdt";
            this.col_Sdt.HeaderText = "Số điện thoại";
            this.col_Sdt.MinimumWidth = 6;
            this.col_Sdt.Name = "col_Sdt";
            this.col_Sdt.Width = 125;
            // 
            // col_Email
            // 
            this.col_Email.DataPropertyName = "col_Email";
            this.col_Email.HeaderText = "Email";
            this.col_Email.MinimumWidth = 6;
            this.col_Email.Name = "col_Email";
            this.col_Email.Width = 125;
            // 
            // col_NgayBD
            // 
            this.col_NgayBD.DataPropertyName = "col_NgayBD";
            this.col_NgayBD.HeaderText = "Ngày bắt đầu";
            this.col_NgayBD.MinimumWidth = 6;
            this.col_NgayBD.Name = "col_NgayBD";
            this.col_NgayBD.Width = 130;
            // 
            // col_NgayKT
            // 
            this.col_NgayKT.DataPropertyName = "col_NgayKT";
            this.col_NgayKT.HeaderText = "Ngày kết thúc";
            this.col_NgayKT.MinimumWidth = 6;
            this.col_NgayKT.Name = "col_NgayKT";
            this.col_NgayKT.Width = 150;
            // 
            // col_GiamGia
            // 
            this.col_GiamGia.DataPropertyName = "col_GiamGia";
            this.col_GiamGia.HeaderText = "Giảm Giá";
            this.col_GiamGia.MinimumWidth = 6;
            this.col_GiamGia.Name = "col_GiamGia";
            this.col_GiamGia.Width = 125;
            // 
            // col_GhiChu
            // 
            this.col_GhiChu.DataPropertyName = "col_GhiChu";
            this.col_GhiChu.HeaderText = "Ghi Chú";
            this.col_GhiChu.MinimumWidth = 6;
            this.col_GhiChu.Name = "col_GhiChu";
            this.col_GhiChu.Width = 125;
            // 
            // col_Edit
            // 
            this.col_Edit.HeaderText = "Sửa";
            this.col_Edit.MinimumWidth = 6;
            this.col_Edit.Name = "col_Edit";
            this.col_Edit.Text = "Sửa";
            this.col_Edit.UseColumnTextForButtonValue = true;
            this.col_Edit.Width = 125;
            // 
            // col_Delete
            // 
            this.col_Delete.HeaderText = "Xóa";
            this.col_Delete.MinimumWidth = 6;
            this.col_Delete.Name = "col_Delete";
            this.col_Delete.Text = "Xóa";
            this.col_Delete.UseColumnTextForButtonValue = true;
            this.col_Delete.Width = 125;
            // 
            // frm_HoiVien
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1353, 783);
            this.Controls.Add(this.grid_HoiVien);
            this.Controls.Add(this.cbb_HoiVien);
            this.Controls.Add(this.txt_Them);
            this.Controls.Add(this.txt_Tuan);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_GhiChu);
            this.Controls.Add(this.txt_HoiVien);
            this.Controls.Add(this.txt_Sdt);
            this.Controls.Add(this.txt_TenKhachHang);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_Sdt);
            this.Controls.Add(this.lbl_TenKhachHang);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_HoiVien";
            this.Text = "frm_TrangChu";
            this.Load += new System.EventHandler(this.frm_HoiVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_HoiVien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_TenKhachHang;
        private System.Windows.Forms.Label lbl_Sdt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_TenKhachHang;
        private System.Windows.Forms.TextBox txt_Sdt;
        private System.Windows.Forms.TextBox txt_HoiVien;
        private System.Windows.Forms.TextBox txt_GhiChu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Tuan;
        private ReaLTaiizor.Controls.Button txt_Them;
        private System.Windows.Forms.ComboBox cbb_HoiVien;
        private ReaLTaiizor.Controls.PoisonDataGridView grid_HoiVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_TenKhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Sdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_NgayBD;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_NgayKT;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_GiamGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_GhiChu;
        private System.Windows.Forms.DataGridViewButtonColumn col_Edit;
        private System.Windows.Forms.DataGridViewButtonColumn col_Delete;
    }
}