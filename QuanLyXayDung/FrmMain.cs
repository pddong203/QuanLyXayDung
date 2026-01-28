namespace QuanLyXayDung
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        // Menu: Danh mục -> Phòng ban
        private void phongBanToolStripMenuItem_Click(object sender, EventArgs e)
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
    }
}
