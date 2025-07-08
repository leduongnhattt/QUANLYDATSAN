namespace NHOM4_QUANLYDATSAN.Forms.Owner
{
    partial class frm_QuanLySan
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
            this.grid_San = new ReaLTaiizor.Controls.PoisonDataGridView();
            this.col_STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_TenSan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_LoaiSan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_DiaDiem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Gia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_HinhAnh = new System.Windows.Forms.DataGridViewImageColumn();
            this.col_ThoiGian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Gio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Them = new ReaLTaiizor.Controls.Button();
            this.btn_Sua = new ReaLTaiizor.Controls.Button();
            this.btn_Xoa = new ReaLTaiizor.Controls.Button();
            this.btn_Tim = new ReaLTaiizor.Controls.Button();
            this.txt_TimKiem = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_San)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "QUẢN LÝ SÂN";
            // 
            // grid_San
            // 
            this.grid_San.AllowUserToResizeRows = false;
            this.grid_San.BackgroundColor = System.Drawing.Color.LightYellow;
            this.grid_San.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid_San.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grid_San.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_San.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid_San.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_San.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_STT,
            this.col_TenSan,
            this.col_LoaiSan,
            this.col_DiaDiem,
            this.col_Gia,
            this.col_HinhAnh,
            this.col_ThoiGian,
            this.col_Gio});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid_San.DefaultCellStyle = dataGridViewCellStyle2;
            this.grid_San.EnableHeadersVisualStyles = false;
            this.grid_San.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grid_San.GridColor = System.Drawing.Color.Red;
            this.grid_San.Location = new System.Drawing.Point(26, 119);
            this.grid_San.Name = "grid_San";
            this.grid_San.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_San.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grid_San.RowHeadersWidth = 51;
            this.grid_San.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grid_San.RowTemplate.DividerHeight = 2;
            this.grid_San.RowTemplate.Height = 200;
            this.grid_San.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_San.Size = new System.Drawing.Size(1126, 497);
            this.grid_San.TabIndex = 2;
            // 
            // col_STT
            // 
            this.col_STT.HeaderText = "STT";
            this.col_STT.MinimumWidth = 6;
            this.col_STT.Name = "col_STT";
            this.col_STT.Width = 75;
            // 
            // col_TenSan
            // 
            this.col_TenSan.HeaderText = "Tên Sân";
            this.col_TenSan.MinimumWidth = 6;
            this.col_TenSan.Name = "col_TenSan";
            this.col_TenSan.Width = 125;
            // 
            // col_LoaiSan
            // 
            this.col_LoaiSan.HeaderText = "Loại Sân";
            this.col_LoaiSan.MinimumWidth = 6;
            this.col_LoaiSan.Name = "col_LoaiSan";
            this.col_LoaiSan.Width = 125;
            // 
            // col_DiaDiem
            // 
            this.col_DiaDiem.HeaderText = "Địa Điểm";
            this.col_DiaDiem.MinimumWidth = 6;
            this.col_DiaDiem.Name = "col_DiaDiem";
            this.col_DiaDiem.Width = 150;
            // 
            // col_Gia
            // 
            this.col_Gia.HeaderText = "Giá";
            this.col_Gia.MinimumWidth = 6;
            this.col_Gia.Name = "col_Gia";
            this.col_Gia.Width = 125;
            // 
            // col_HinhAnh
            // 
            this.col_HinhAnh.HeaderText = "Hình Ảnh";
            this.col_HinhAnh.MinimumWidth = 6;
            this.col_HinhAnh.Name = "col_HinhAnh";
            this.col_HinhAnh.Width = 200;
            // 
            // col_ThoiGian
            // 
            this.col_ThoiGian.HeaderText = "Thời Gian";
            this.col_ThoiGian.MinimumWidth = 6;
            this.col_ThoiGian.Name = "col_ThoiGian";
            this.col_ThoiGian.Width = 150;
            // 
            // col_Gio
            // 
            this.col_Gio.HeaderText = "Số Giờ Được Đặt";
            this.col_Gio.MinimumWidth = 6;
            this.col_Gio.Name = "col_Gio";
            this.col_Gio.Width = 125;
            // 
            // btn_Them
            // 
            this.btn_Them.BackColor = System.Drawing.Color.Transparent;
            this.btn_Them.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btn_Them.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Them.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btn_Them.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btn_Them.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_Them.Image = null;
            this.btn_Them.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Them.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btn_Them.Location = new System.Drawing.Point(286, 648);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btn_Them.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btn_Them.Size = new System.Drawing.Size(120, 40);
            this.btn_Them.TabIndex = 3;
            this.btn_Them.Text = "Thêm";
            this.btn_Them.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // btn_Sua
            // 
            this.btn_Sua.BackColor = System.Drawing.Color.Transparent;
            this.btn_Sua.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btn_Sua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Sua.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btn_Sua.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btn_Sua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_Sua.Image = null;
            this.btn_Sua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Sua.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btn_Sua.Location = new System.Drawing.Point(514, 648);
            this.btn_Sua.Name = "btn_Sua";
            this.btn_Sua.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btn_Sua.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btn_Sua.Size = new System.Drawing.Size(120, 40);
            this.btn_Sua.TabIndex = 4;
            this.btn_Sua.Text = "Sửa";
            this.btn_Sua.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btn_Sua.Click += new System.EventHandler(this.btn_Sua_Click);
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.BackColor = System.Drawing.Color.Transparent;
            this.btn_Xoa.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btn_Xoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Xoa.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btn_Xoa.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btn_Xoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_Xoa.Image = null;
            this.btn_Xoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Xoa.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btn_Xoa.Location = new System.Drawing.Point(740, 648);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btn_Xoa.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btn_Xoa.Size = new System.Drawing.Size(120, 40);
            this.btn_Xoa.TabIndex = 5;
            this.btn_Xoa.Text = "Xóa";
            this.btn_Xoa.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
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
            this.btn_Tim.Location = new System.Drawing.Point(905, 37);
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
            this.txt_TimKiem.Hint = "Nhập tên sân để tìm kiếm ...";
            this.txt_TimKiem.LeadingIcon = null;
            this.txt_TimKiem.Location = new System.Drawing.Point(611, 29);
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
            this.txt_TimKiem.Size = new System.Drawing.Size(254, 48);
            this.txt_TimKiem.TabIndex = 7;
            this.txt_TimKiem.TabStop = false;
            this.txt_TimKiem.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_TimKiem.TrailingIcon = null;
            this.txt_TimKiem.UseSystemPasswordChar = false;
            // 
            // frm_QuanLySan
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1201, 760);
            this.Controls.Add(this.txt_TimKiem);
            this.Controls.Add(this.btn_Tim);
            this.Controls.Add(this.btn_Xoa);
            this.Controls.Add(this.btn_Sua);
            this.Controls.Add(this.btn_Them);
            this.Controls.Add(this.grid_San);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_QuanLySan";
            this.Text = "frm_TrangChu";
            this.Load += new System.EventHandler(this.frm_ThemSanLoad);
            ((System.ComponentModel.ISupportInitialize)(this.grid_San)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ReaLTaiizor.Controls.PoisonDataGridView grid_San;
        private ReaLTaiizor.Controls.Button btn_Them;
        private ReaLTaiizor.Controls.Button btn_Sua;
        private ReaLTaiizor.Controls.Button btn_Xoa;
        private ReaLTaiizor.Controls.Button btn_Tim;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit txt_TimKiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_TenSan;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_LoaiSan;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DiaDiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Gia;
        private System.Windows.Forms.DataGridViewImageColumn col_HinhAnh;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ThoiGian;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Gio;
    }
}