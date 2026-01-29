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
            FrmPhongBan f = new FrmPhongBan();
            f.Show();
        }

        private void nhânViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmNhanVien f = new FrmNhanVien();
            f.Show();
        }
    }
}
