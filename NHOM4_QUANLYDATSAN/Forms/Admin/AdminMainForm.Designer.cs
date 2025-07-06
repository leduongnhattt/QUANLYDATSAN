namespace NHOM4_QUANLYDATSAN.Forms.Admin
{
    partial class AdminMainForm
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.nightControlBox1 = new ReaLTaiizor.Controls.NightControlBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Ham = new System.Windows.Forms.PictureBox();
            this.sidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.pn_TrangChu = new System.Windows.Forms.Panel();
            this.btn_TrangChu = new System.Windows.Forms.Button();
            this.pn_NguoiDung = new System.Windows.Forms.Panel();
            this.btn_NguoiDung = new System.Windows.Forms.Button();
            this.pn_CaiDat = new System.Windows.Forms.Panel();
            this.btn_CaiDat = new System.Windows.Forms.Button();
            this.pn_DangXuat = new System.Windows.Forms.Panel();
            this.btn_DangXuat = new System.Windows.Forms.Button();
            this.sidebarTransition = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Ham)).BeginInit();
            this.sidebar.SuspendLayout();
            this.pn_TrangChu.SuspendLayout();
            this.pn_NguoiDung.SuspendLayout();
            this.pn_CaiDat.SuspendLayout();
            this.pn_DangXuat.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightYellow;
            this.panel1.Controls.Add(this.nightControlBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_Ham);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1437, 69);
            this.panel1.TabIndex = 0;
            // 
            // nightControlBox1
            // 
            this.nightControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nightControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.nightControlBox1.CloseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.nightControlBox1.CloseHoverForeColor = System.Drawing.Color.White;
            this.nightControlBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nightControlBox1.DefaultLocation = true;
            this.nightControlBox1.DisableMaximizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.nightControlBox1.DisableMinimizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.nightControlBox1.EnableCloseColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.nightControlBox1.EnableMaximizeButton = true;
            this.nightControlBox1.EnableMaximizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.nightControlBox1.EnableMinimizeButton = true;
            this.nightControlBox1.EnableMinimizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.nightControlBox1.Location = new System.Drawing.Point(1298, 0);
            this.nightControlBox1.MaximizeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nightControlBox1.MaximizeHoverForeColor = System.Drawing.Color.White;
            this.nightControlBox1.MinimizeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nightControlBox1.MinimizeHoverForeColor = System.Drawing.Color.White;
            this.nightControlBox1.Name = "nightControlBox1";
            this.nightControlBox1.Size = new System.Drawing.Size(139, 31);
            this.nightControlBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(91, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "QUAN LY SAN THE THAO";
            // 
            // btn_Ham
            // 
            this.btn_Ham.Image = global::NHOM4_QUANLYDATSAN.Properties.Resources.icons8_menu_30;
            this.btn_Ham.Location = new System.Drawing.Point(19, 12);
            this.btn_Ham.Name = "btn_Ham";
            this.btn_Ham.Size = new System.Drawing.Size(51, 43);
            this.btn_Ham.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btn_Ham.TabIndex = 1;
            this.btn_Ham.TabStop = false;
            this.btn_Ham.Click += new System.EventHandler(this.btn_Ham_Click);
            // 
            // sidebar
            // 
            this.sidebar.BackColor = System.Drawing.Color.DodgerBlue;
            this.sidebar.Controls.Add(this.pn_TrangChu);
            this.sidebar.Controls.Add(this.pn_NguoiDung);
            this.sidebar.Controls.Add(this.pn_CaiDat);
            this.sidebar.Controls.Add(this.pn_DangXuat);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.Location = new System.Drawing.Point(0, 69);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(336, 751);
            this.sidebar.TabIndex = 1;
            // 
            // pn_TrangChu
            // 
            this.pn_TrangChu.BackColor = System.Drawing.SystemColors.Highlight;
            this.pn_TrangChu.Controls.Add(this.btn_TrangChu);
            this.pn_TrangChu.Location = new System.Drawing.Point(3, 3);
            this.pn_TrangChu.Name = "pn_TrangChu";
            this.pn_TrangChu.Size = new System.Drawing.Size(328, 73);
            this.pn_TrangChu.TabIndex = 3;
            // 
            // btn_TrangChu
            // 
            this.btn_TrangChu.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_TrangChu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_TrangChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TrangChu.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_TrangChu.Image = global::NHOM4_QUANLYDATSAN.Properties.Resources.icons8_home_32;
            this.btn_TrangChu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_TrangChu.Location = new System.Drawing.Point(0, 0);
            this.btn_TrangChu.Name = "btn_TrangChu";
            this.btn_TrangChu.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btn_TrangChu.Size = new System.Drawing.Size(328, 73);
            this.btn_TrangChu.TabIndex = 2;
            this.btn_TrangChu.Text = "Trang chủ";
            this.btn_TrangChu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_TrangChu.UseVisualStyleBackColor = false;
            this.btn_TrangChu.Click += new System.EventHandler(this.btn_TrangChu_Click);
            // 
            // pn_NguoiDung
            // 
            this.pn_NguoiDung.BackColor = System.Drawing.SystemColors.Highlight;
            this.pn_NguoiDung.Controls.Add(this.btn_NguoiDung);
            this.pn_NguoiDung.Location = new System.Drawing.Point(3, 82);
            this.pn_NguoiDung.Name = "pn_NguoiDung";
            this.pn_NguoiDung.Size = new System.Drawing.Size(328, 73);
            this.pn_NguoiDung.TabIndex = 4;
            // 
            // btn_NguoiDung
            // 
            this.btn_NguoiDung.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_NguoiDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_NguoiDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_NguoiDung.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_NguoiDung.Image = global::NHOM4_QUANLYDATSAN.Properties.Resources.icons8_user_30;
            this.btn_NguoiDung.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_NguoiDung.Location = new System.Drawing.Point(0, 0);
            this.btn_NguoiDung.Name = "btn_NguoiDung";
            this.btn_NguoiDung.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btn_NguoiDung.Size = new System.Drawing.Size(328, 73);
            this.btn_NguoiDung.TabIndex = 2;
            this.btn_NguoiDung.Text = "Người dùng";
            this.btn_NguoiDung.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_NguoiDung.UseVisualStyleBackColor = false;
            this.btn_NguoiDung.Click += new System.EventHandler(this.btn_NguoiDung_Click);
            // 
            // pn_CaiDat
            // 
            this.pn_CaiDat.BackColor = System.Drawing.SystemColors.Highlight;
            this.pn_CaiDat.Controls.Add(this.btn_CaiDat);
            this.pn_CaiDat.Location = new System.Drawing.Point(3, 161);
            this.pn_CaiDat.Name = "pn_CaiDat";
            this.pn_CaiDat.Size = new System.Drawing.Size(328, 73);
            this.pn_CaiDat.TabIndex = 5;
            // 
            // btn_CaiDat
            // 
            this.btn_CaiDat.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_CaiDat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_CaiDat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CaiDat.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_CaiDat.Image = global::NHOM4_QUANLYDATSAN.Properties.Resources.icons8_setting_32;
            this.btn_CaiDat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_CaiDat.Location = new System.Drawing.Point(0, 0);
            this.btn_CaiDat.Name = "btn_CaiDat";
            this.btn_CaiDat.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btn_CaiDat.Size = new System.Drawing.Size(328, 73);
            this.btn_CaiDat.TabIndex = 2;
            this.btn_CaiDat.Text = "Cài Đặt";
            this.btn_CaiDat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_CaiDat.UseVisualStyleBackColor = false;
            this.btn_CaiDat.Click += new System.EventHandler(this.btn_CaiDat_Click);
            // 
            // pn_DangXuat
            // 
            this.pn_DangXuat.BackColor = System.Drawing.SystemColors.Highlight;
            this.pn_DangXuat.Controls.Add(this.btn_DangXuat);
            this.pn_DangXuat.Location = new System.Drawing.Point(3, 240);
            this.pn_DangXuat.Name = "pn_DangXuat";
            this.pn_DangXuat.Size = new System.Drawing.Size(328, 73);
            this.pn_DangXuat.TabIndex = 6;
            // 
            // btn_DangXuat
            // 
            this.btn_DangXuat.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_DangXuat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_DangXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DangXuat.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_DangXuat.Image = global::NHOM4_QUANLYDATSAN.Properties.Resources.icons8_shutdown_30;
            this.btn_DangXuat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_DangXuat.Location = new System.Drawing.Point(0, 0);
            this.btn_DangXuat.Name = "btn_DangXuat";
            this.btn_DangXuat.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btn_DangXuat.Size = new System.Drawing.Size(328, 73);
            this.btn_DangXuat.TabIndex = 2;
            this.btn_DangXuat.Text = "Đăng Xuất";
            this.btn_DangXuat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_DangXuat.UseVisualStyleBackColor = false;
            this.btn_DangXuat.Click += new System.EventHandler(this.btn_DangXuat_Click);
            // 
            // sidebarTransition
            // 
            this.sidebarTransition.Interval = 10;
            this.sidebarTransition.Tick += new System.EventHandler(this.sidebarTransition_Tick);
            // 
            // AdminMainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1437, 820);
            this.Controls.Add(this.sidebar);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "AdminMainForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Ham)).EndInit();
            this.sidebar.ResumeLayout(false);
            this.pn_TrangChu.ResumeLayout(false);
            this.pn_NguoiDung.ResumeLayout(false);
            this.pn_CaiDat.ResumeLayout(false);
            this.pn_DangXuat.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox btn_Ham;
        private System.Windows.Forms.Label label1;
        private ReaLTaiizor.Controls.NightControlBox nightControlBox1;
        private System.Windows.Forms.FlowLayoutPanel sidebar;
        private System.Windows.Forms.Panel pn_TrangChu;
        private System.Windows.Forms.Panel pn_NguoiDung;
        private System.Windows.Forms.Button btn_NguoiDung;
        private System.Windows.Forms.Panel pn_CaiDat;
        private System.Windows.Forms.Button btn_CaiDat;
        private System.Windows.Forms.Panel pn_DangXuat;
        private System.Windows.Forms.Button btn_DangXuat;
        private System.Windows.Forms.Timer sidebarTransition;
        private System.Windows.Forms.Button btn_TrangChu;
    }
}