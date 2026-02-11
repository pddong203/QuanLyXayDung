using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyXayDung
{
    public partial class FrmMain : Form
    {
        private static readonly Color CardHoverColor = Color.FromArgb(236, 240, 241);
        private static readonly Color CardNormalColor = Color.White;

        public FrmMain()
        {
            InitializeComponent();
            AttachCardHoverEffects();
        }

        private void AttachCardHoverEffects()
        {
            AttachHover(pnlPhongBan);
            AttachHover(pnlNhanVien);
            AttachHover(pnlCongTrinh);
            AttachHover(pnlThiCong);
        }

        private void AttachHover(Panel pnl)
        {
            pnl.MouseEnter += (s, e) => { pnl.BackColor = CardHoverColor; };
            pnl.MouseLeave += (s, e) => { pnl.BackColor = CardNormalColor; };
        }

        private void pnlPhongBan_Click(object sender, EventArgs e)
        {
            new FrmPhongBan().Show();
        }

        private void pnlNhanVien_Click(object sender, EventArgs e)
        {
            new FrmNhanVien().Show();
        }

        private void pnlCongTrinh_Click(object sender, EventArgs e)
        {
            new FrmCongTrinh().Show();
        }

        private void pnlThiCong_Click(object sender, EventArgs e)
        {
            new FrmThiCong().Show();
        }
    }
}
