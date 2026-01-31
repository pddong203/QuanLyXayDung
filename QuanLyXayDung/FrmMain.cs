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

        private void phòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FrmPhongBan();
            form.Show();
        }

        // Menu: Danh mục -> Công trình
        private void congTrinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FrmCongTrinh();
            form.Show();
        }

        private void nhânViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmNhanVien f = new FrmNhanVien();
            f.Show();
        }
    }
}
