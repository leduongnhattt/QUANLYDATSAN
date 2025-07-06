namespace NHOM4_QUANLYDATSAN.Forms.Admin
{
    partial class frm_CaiDat
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxLanguage = new System.Windows.Forms.GroupBox();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.labelLanguage = new System.Windows.Forms.Label();
            this.groupBoxTimeout = new System.Windows.Forms.GroupBox();
            this.numericTimeout = new System.Windows.Forms.NumericUpDown();
            this.labelTimeout = new System.Windows.Forms.Label();
            this.groupBoxNotification = new System.Windows.Forms.GroupBox();
            this.checkBoxEnableNotification = new System.Windows.Forms.CheckBox();
            this.checkBoxSound = new System.Windows.Forms.CheckBox();
            this.checkBoxPopup = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 46);
            this.label1.TabIndex = 1;
            this.label1.Text = "CÀI ĐẶT";
            // groupBoxLanguage
            this.groupBoxLanguage.Controls.Add(this.comboBoxLanguage);
            this.groupBoxLanguage.Controls.Add(this.labelLanguage);
            this.groupBoxLanguage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.groupBoxLanguage.Location = new System.Drawing.Point(60, 100);
            this.groupBoxLanguage.Name = "groupBoxLanguage";
            this.groupBoxLanguage.Size = new System.Drawing.Size(400, 100);
            this.groupBoxLanguage.TabIndex = 2;
            this.groupBoxLanguage.TabStop = false;
            this.groupBoxLanguage.Text = "Ngôn ngữ";
            // comboBoxLanguage
            this.comboBoxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLanguage.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.comboBoxLanguage.Items.AddRange(new object[] {"Tiếng Việt", "English"});
            this.comboBoxLanguage.Location = new System.Drawing.Point(150, 40);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(200, 36);
            this.comboBoxLanguage.TabIndex = 1;
            // labelLanguage
            this.labelLanguage.AutoSize = true;
            this.labelLanguage.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelLanguage.Location = new System.Drawing.Point(20, 43);
            this.labelLanguage.Name = "labelLanguage";
            this.labelLanguage.Size = new System.Drawing.Size(110, 28);
            this.labelLanguage.TabIndex = 0;
            this.labelLanguage.Text = "Chọn ngôn ngữ:";
            // groupBoxTimeout
            this.groupBoxTimeout.Controls.Add(this.numericTimeout);
            this.groupBoxTimeout.Controls.Add(this.labelTimeout);
            this.groupBoxTimeout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.groupBoxTimeout.Location = new System.Drawing.Point(60, 230);
            this.groupBoxTimeout.Name = "groupBoxTimeout";
            this.groupBoxTimeout.Size = new System.Drawing.Size(400, 100);
            this.groupBoxTimeout.TabIndex = 3;
            this.groupBoxTimeout.TabStop = false;
            this.groupBoxTimeout.Text = "Thời gian timeout";
            // numericTimeout
            this.numericTimeout.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.numericTimeout.Location = new System.Drawing.Point(220, 40);
            this.numericTimeout.Maximum = new decimal(new int[] {120, 0, 0, 0});
            this.numericTimeout.Minimum = new decimal(new int[] {1, 0, 0, 0});
            this.numericTimeout.Name = "numericTimeout";
            this.numericTimeout.Size = new System.Drawing.Size(80, 34);
            this.numericTimeout.TabIndex = 1;
            this.numericTimeout.Value = new decimal(new int[] {15, 0, 0, 0});
            // labelTimeout
            this.labelTimeout.AutoSize = true;
            this.labelTimeout.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelTimeout.Location = new System.Drawing.Point(20, 43);
            this.labelTimeout.Name = "labelTimeout";
            this.labelTimeout.Size = new System.Drawing.Size(180, 28);
            this.labelTimeout.TabIndex = 0;
            this.labelTimeout.Text = "Timeout (phút):";
            // groupBoxNotification
            this.groupBoxNotification.Controls.Add(this.checkBoxEnableNotification);
            this.groupBoxNotification.Controls.Add(this.checkBoxSound);
            this.groupBoxNotification.Controls.Add(this.checkBoxPopup);
            this.groupBoxNotification.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.groupBoxNotification.Location = new System.Drawing.Point(60, 360);
            this.groupBoxNotification.Name = "groupBoxNotification";
            this.groupBoxNotification.Size = new System.Drawing.Size(400, 140);
            this.groupBoxNotification.TabIndex = 4;
            this.groupBoxNotification.TabStop = false;
            this.groupBoxNotification.Text = "Cài đặt thông báo";
            // checkBoxEnableNotification
            this.checkBoxEnableNotification.AutoSize = true;
            this.checkBoxEnableNotification.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.checkBoxEnableNotification.Location = new System.Drawing.Point(24, 40);
            this.checkBoxEnableNotification.Name = "checkBoxEnableNotification";
            this.checkBoxEnableNotification.Size = new System.Drawing.Size(210, 32);
            this.checkBoxEnableNotification.TabIndex = 0;
            this.checkBoxEnableNotification.Text = "Bật thông báo";
            this.checkBoxEnableNotification.UseVisualStyleBackColor = true;
            // checkBoxSound
            this.checkBoxSound.AutoSize = true;
            this.checkBoxSound.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.checkBoxSound.Location = new System.Drawing.Point(24, 80);
            this.checkBoxSound.Name = "checkBoxSound";
            this.checkBoxSound.Size = new System.Drawing.Size(180, 32);
            this.checkBoxSound.TabIndex = 1;
            this.checkBoxSound.Text = "Âm thanh thông báo";
            this.checkBoxSound.UseVisualStyleBackColor = true;
            // checkBoxPopup
            this.checkBoxPopup.AutoSize = true;
            this.checkBoxPopup.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.checkBoxPopup.Location = new System.Drawing.Point(220, 80);
            this.checkBoxPopup.Name = "checkBoxPopup";
            this.checkBoxPopup.Size = new System.Drawing.Size(150, 32);
            this.checkBoxPopup.TabIndex = 2;
            this.checkBoxPopup.Text = "Popup thông báo";
            this.checkBoxPopup.UseVisualStyleBackColor = true;
            // btnSave
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(180, 530);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(160, 45);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            // frm_CaiDat
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1464, 788);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBoxNotification);
            this.Controls.Add(this.groupBoxTimeout);
            this.Controls.Add(this.groupBoxLanguage);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_CaiDat";
            this.Text = "frm_CaiDat";
            this.Load += new System.EventHandler(this.frm_CaiDat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericTimeout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxLanguage;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.Label labelLanguage;
        private System.Windows.Forms.GroupBox groupBoxTimeout;
        private System.Windows.Forms.NumericUpDown numericTimeout;
        private System.Windows.Forms.Label labelTimeout;
        private System.Windows.Forms.GroupBox groupBoxNotification;
        private System.Windows.Forms.CheckBox checkBoxEnableNotification;
        private System.Windows.Forms.CheckBox checkBoxSound;
        private System.Windows.Forms.CheckBox checkBoxPopup;
        private System.Windows.Forms.Button btnSave;
    }
}