using System;
using System.Windows.Forms;

namespace QuanLyXayDung
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void phongBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPhongBan f = new FrmPhongBan();
            f.Show();
        }

        private void thiCongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmThiCong f = new FrmThiCong();
            f.Show();
        }
    }
}
