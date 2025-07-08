namespace NHOM4_QUANLYDATSAN.Forms.Owner
{
    partial class frm_DatSan
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
            this.flowLayoutPanelCourts = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.cbb_TheThao = new ReaLTaiizor.Controls.MetroComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // flowLayoutPanelCourts
            // 
            this.flowLayoutPanelCourts.AutoScroll = true;
            this.flowLayoutPanelCourts.Location = new System.Drawing.Point(56, 160);
            this.flowLayoutPanelCourts.Name = "flowLayoutPanelCourts";
            this.flowLayoutPanelCourts.Size = new System.Drawing.Size(1245, 611);
            this.flowLayoutPanelCourts.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(51, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(326, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Thể thao, Mọi Lúc, Mọi Nơi";
            // 
            // cbb_TheThao
            // 
            this.cbb_TheThao.AllowDrop = true;
            this.cbb_TheThao.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.cbb_TheThao.BackColor = System.Drawing.Color.Transparent;
            this.cbb_TheThao.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.cbb_TheThao.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.cbb_TheThao.CausesValidation = false;
            this.cbb_TheThao.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cbb_TheThao.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.cbb_TheThao.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.cbb_TheThao.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbb_TheThao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_TheThao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_TheThao.FormattingEnabled = true;
            this.cbb_TheThao.IsDerivedStyle = true;
            this.cbb_TheThao.ItemHeight = 20;
            this.cbb_TheThao.Location = new System.Drawing.Point(82, 108);
            this.cbb_TheThao.Name = "cbb_TheThao";
            this.cbb_TheThao.SelectedItemBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.cbb_TheThao.SelectedItemForeColor = System.Drawing.Color.White;
            this.cbb_TheThao.Size = new System.Drawing.Size(164, 26);
            this.cbb_TheThao.Style = ReaLTaiizor.Enum.Metro.Style.Light;
            this.cbb_TheThao.StyleManager = null;
            this.cbb_TheThao.TabIndex = 3;
            this.cbb_TheThao.ThemeAuthor = "Taiizor";
            this.cbb_TheThao.ThemeName = "MetroLight";
            this.cbb_TheThao.SelectedIndexChanged += new System.EventHandler(this.cbb_TheThao_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(78, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Bộ môn";
            // 
            // frm_DatSan
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1353, 760);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanelCourts);
            this.Controls.Add(this.cbb_TheThao);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_DatSan";
            this.Text = "frm_TrangChu";
            this.Load += new System.EventHandler(this.frm_DatSan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private ReaLTaiizor.Controls.MetroComboBox cbb_TheThao;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelCourts;
        private System.Windows.Forms.Label label1;
    }
}