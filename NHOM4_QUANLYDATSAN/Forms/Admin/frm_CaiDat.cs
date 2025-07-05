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
        public frm_CaiDat()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private void frm_CaiDat_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate();
        }
    }
}
