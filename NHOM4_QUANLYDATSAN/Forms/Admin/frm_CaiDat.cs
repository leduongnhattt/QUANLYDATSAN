using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NHOM4_QUANLYDATSAN.Forms.Admin
{
    public partial class frm_CaiDat : Form
    {
        private bool isDirty = false;
        private Timer timeoutTimer;
        private int timeoutMinutes = 15;
        public frm_CaiDat()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            comboBoxLanguage.SelectedIndex = 0;
            btnSave.Enabled = false;

            // Sự kiện thay đổi control
            comboBoxLanguage.SelectedIndexChanged += SettingChanged;
            numericTimeout.ValueChanged += SettingChanged;
            checkBoxEnableNotification.CheckedChanged += SettingChanged;
            checkBoxSound.CheckedChanged += SettingChanged;
            checkBoxPopup.CheckedChanged += SettingChanged;
            btnSave.Click += btnSave_Click;
        }

        private void frm_CaiDat_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
            // Khởi tạo timer timeout nếu chưa có
            if (timeoutTimer == null)
            {
                timeoutTimer = new Timer();
                timeoutTimer.Interval = timeoutMinutes * 60 * 1000;
                timeoutTimer.Tick += TimeoutTimer_Tick;
                timeoutTimer.Start();
            }
            this.MouseMove += ResetTimeout;
            this.KeyDown += ResetTimeout;
            this.MouseClick += ResetTimeout;
        }
        private void SettingChanged(object sender, EventArgs e)
        {
            isDirty = true;
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Lưu cài đặt ngôn ngữ
            string selectedLang = comboBoxLanguage.SelectedItem.ToString();
            if (selectedLang == "English")
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en");
                MessageBox.Show("Language changed to English. Please restart the application to apply changes.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("vi");
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("vi");
            }
            // Lưu timeout
            timeoutMinutes = (int)numericTimeout.Value;
            if (timeoutTimer != null)
            {
                timeoutTimer.Interval = timeoutMinutes * 60 * 1000;
            }
            isDirty = false;
            btnSave.Enabled = false;
            MessageBox.Show("Đã lưu cài đặt thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TimeoutTimer_Tick(object sender, EventArgs e)
        {
            // Logout về trang đăng nhập
            this.Invoke((MethodInvoker)delegate
            {
                MessageBox.Show("Bạn đã bị đăng xuất do không hoạt động.", "Timeout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                foreach (Form f in Application.OpenForms)
                {
                    if (!(f is NHOM4_QUANLYDATSAN.Forms.LoginForm))
                        f.Hide();
                }
                var login = Application.OpenForms.OfType<NHOM4_QUANLYDATSAN.Forms.LoginForm>().FirstOrDefault();
                if (login != null)
                {
                    login.Show();
                }
                else
                {
                    NHOM4_QUANLYDATSAN.Forms.LoginForm loginForm = new NHOM4_QUANLYDATSAN.Forms.LoginForm();
                    loginForm.Show();
                }
            });
        }

        private void ResetTimeout(object sender, EventArgs e)
        {
            if (timeoutTimer != null)
            {
                timeoutTimer.Stop();
                timeoutTimer.Start();
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate();
        }
    }
}
