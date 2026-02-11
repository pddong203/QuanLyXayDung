namespace QuanLyXayDung
{
    partial class FrmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();
            pnlContent = new Panel();
            pnlThiCong = new Panel();
            lblThiCongDesc = new Label();
            lblThiCong = new Label();
            pnlCongTrinh = new Panel();
            lblCongTrinhDesc = new Label();
            lblCongTrinh = new Label();
            pnlNhanVien = new Panel();
            lblNhanVienDesc = new Label();
            lblNhanVien = new Label();
            pnlPhongBan = new Panel();
            lblPhongBanDesc = new Label();
            lblPhongBan = new Label();
            pnlHeader.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlThiCong.SuspendLayout();
            pnlCongTrinh.SuspendLayout();
            pnlNhanVien.SuspendLayout();
            pnlPhongBan.SuspendLayout();
            SuspendLayout();
            //
            // pnlHeader
            //
            pnlHeader.BackColor = Color.FromArgb(44, 62, 80);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(984, 90);
            pnlHeader.TabIndex = 0;
            //
            // lblTitle
            //
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(24, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(268, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Quản Lý Xây Dựng";
            //
            // lblSubtitle
            //
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.FromArgb(189, 195, 199);
            lblSubtitle.Location = new Point(28, 64);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(280, 19);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Chọn chức năng bên dưới để bắt đầu làm việc";
            //
            // pnlContent
            //
            pnlContent.BackColor = Color.FromArgb(245, 246, 250);
            pnlContent.Controls.Add(pnlThiCong);
            pnlContent.Controls.Add(pnlCongTrinh);
            pnlContent.Controls.Add(pnlNhanVien);
            pnlContent.Controls.Add(pnlPhongBan);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 90);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(32, 28, 32, 28);
            pnlContent.Size = new Size(984, 471);
            pnlContent.TabIndex = 1;
            //
            // pnlPhongBan
            //
            pnlPhongBan.BackColor = Color.White;
            pnlPhongBan.BorderStyle = BorderStyle.FixedSingle;
            pnlPhongBan.Controls.Add(lblPhongBanDesc);
            pnlPhongBan.Controls.Add(lblPhongBan);
            pnlPhongBan.Cursor = Cursors.Hand;
            pnlPhongBan.Location = new Point(32, 28);
            pnlPhongBan.Name = "pnlPhongBan";
            pnlPhongBan.Padding = new Padding(20);
            pnlPhongBan.Size = new Size(280, 140);
            pnlPhongBan.TabIndex = 0;
            pnlPhongBan.Click += pnlPhongBan_Click;
            lblPhongBan.Click += pnlPhongBan_Click;
            lblPhongBanDesc.Click += pnlPhongBan_Click;
            //
            // lblPhongBan
            //
            lblPhongBan.AutoSize = true;
            lblPhongBan.Cursor = Cursors.Hand;
            lblPhongBan.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblPhongBan.ForeColor = Color.FromArgb(44, 62, 80);
            lblPhongBan.Location = new Point(20, 20);
            lblPhongBan.Name = "lblPhongBan";
            lblPhongBan.Size = new Size(99, 25);
            lblPhongBan.TabIndex = 0;
            lblPhongBan.Text = "Phòng ban";
            //
            // lblPhongBanDesc
            //
            lblPhongBanDesc.Cursor = Cursors.Hand;
            lblPhongBanDesc.Font = new Font("Segoe UI", 9.5F);
            lblPhongBanDesc.ForeColor = Color.FromArgb(127, 140, 141);
            lblPhongBanDesc.Location = new Point(20, 52);
            lblPhongBanDesc.Name = "lblPhongBanDesc";
            lblPhongBanDesc.Size = new Size(238, 58);
            lblPhongBanDesc.TabIndex = 1;
            lblPhongBanDesc.Text = "Quản lý danh sách phòng ban, trưởng phòng và nhân viên thuộc phòng.";
            //
            // pnlNhanVien
            //
            pnlNhanVien.BackColor = Color.White;
            pnlNhanVien.BorderStyle = BorderStyle.FixedSingle;
            pnlNhanVien.Controls.Add(lblNhanVienDesc);
            pnlNhanVien.Controls.Add(lblNhanVien);
            pnlNhanVien.Cursor = Cursors.Hand;
            pnlNhanVien.Location = new Point(328, 28);
            pnlNhanVien.Name = "pnlNhanVien";
            pnlNhanVien.Padding = new Padding(20);
            pnlNhanVien.Size = new Size(280, 140);
            pnlNhanVien.TabIndex = 1;
            pnlNhanVien.Click += pnlNhanVien_Click;
            lblNhanVien.Click += pnlNhanVien_Click;
            lblNhanVienDesc.Click += pnlNhanVien_Click;
            //
            // lblNhanVien
            //
            lblNhanVien.AutoSize = true;
            lblNhanVien.Cursor = Cursors.Hand;
            lblNhanVien.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblNhanVien.ForeColor = Color.FromArgb(44, 62, 80);
            lblNhanVien.Location = new Point(20, 20);
            lblNhanVien.Name = "lblNhanVien";
            lblNhanVien.Size = new Size(87, 25);
            lblNhanVien.TabIndex = 0;
            lblNhanVien.Text = "Nhân viên";
            //
            // lblNhanVienDesc
            //
            lblNhanVienDesc.Cursor = Cursors.Hand;
            lblNhanVienDesc.Font = new Font("Segoe UI", 9.5F);
            lblNhanVienDesc.ForeColor = Color.FromArgb(127, 140, 141);
            lblNhanVienDesc.Location = new Point(20, 52);
            lblNhanVienDesc.Name = "lblNhanVienDesc";
            lblNhanVienDesc.Size = new Size(238, 58);
            lblNhanVienDesc.TabIndex = 1;
            lblNhanVienDesc.Text = "Quản lý thông tin nhân viên, phân công phòng ban.";
            //
            // pnlCongTrinh
            //
            pnlCongTrinh.BackColor = Color.White;
            pnlCongTrinh.BorderStyle = BorderStyle.FixedSingle;
            pnlCongTrinh.Controls.Add(lblCongTrinhDesc);
            pnlCongTrinh.Controls.Add(lblCongTrinh);
            pnlCongTrinh.Cursor = Cursors.Hand;
            pnlCongTrinh.Location = new Point(32, 184);
            pnlCongTrinh.Name = "pnlCongTrinh";
            pnlCongTrinh.Padding = new Padding(20);
            pnlCongTrinh.Size = new Size(280, 140);
            pnlCongTrinh.TabIndex = 2;
            pnlCongTrinh.Click += pnlCongTrinh_Click;
            lblCongTrinh.Click += pnlCongTrinh_Click;
            lblCongTrinhDesc.Click += pnlCongTrinh_Click;
            //
            // lblCongTrinh
            //
            lblCongTrinh.AutoSize = true;
            lblCongTrinh.Cursor = Cursors.Hand;
            lblCongTrinh.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblCongTrinh.ForeColor = Color.FromArgb(44, 62, 80);
            lblCongTrinh.Location = new Point(20, 20);
            lblCongTrinh.Name = "lblCongTrinh";
            lblCongTrinh.Size = new Size(87, 25);
            lblCongTrinh.TabIndex = 0;
            lblCongTrinh.Text = "Công trình";
            //
            // lblCongTrinhDesc
            //
            lblCongTrinhDesc.Cursor = Cursors.Hand;
            lblCongTrinhDesc.Font = new Font("Segoe UI", 9.5F);
            lblCongTrinhDesc.ForeColor = Color.FromArgb(127, 140, 141);
            lblCongTrinhDesc.Location = new Point(20, 52);
            lblCongTrinhDesc.Name = "lblCongTrinhDesc";
            lblCongTrinhDesc.Size = new Size(238, 58);
            lblCongTrinhDesc.TabIndex = 1;
            lblCongTrinhDesc.Text = "Quản lý công trình, tiến độ và thời gian thi công.";
            //
            // pnlThiCong
            //
            pnlThiCong.BackColor = Color.White;
            pnlThiCong.BorderStyle = BorderStyle.FixedSingle;
            pnlThiCong.Controls.Add(lblThiCongDesc);
            pnlThiCong.Controls.Add(lblThiCong);
            pnlThiCong.Cursor = Cursors.Hand;
            pnlThiCong.Location = new Point(328, 184);
            pnlThiCong.Name = "pnlThiCong";
            pnlThiCong.Padding = new Padding(20);
            pnlThiCong.Size = new Size(280, 140);
            pnlThiCong.TabIndex = 3;
            pnlThiCong.Click += pnlThiCong_Click;
            lblThiCong.Click += pnlThiCong_Click;
            lblThiCongDesc.Click += pnlThiCong_Click;
            //
            // lblThiCong
            //
            lblThiCong.AutoSize = true;
            lblThiCong.Cursor = Cursors.Hand;
            lblThiCong.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblThiCong.ForeColor = Color.FromArgb(44, 62, 80);
            lblThiCong.Location = new Point(20, 20);
            lblThiCong.Name = "lblThiCong";
            lblThiCong.Size = new Size(73, 25);
            lblThiCong.TabIndex = 0;
            lblThiCong.Text = "Thi công";
            //
            // lblThiCongDesc
            //
            lblThiCongDesc.Cursor = Cursors.Hand;
            lblThiCongDesc.Font = new Font("Segoe UI", 9.5F);
            lblThiCongDesc.ForeColor = Color.FromArgb(127, 140, 141);
            lblThiCongDesc.Location = new Point(20, 52);
            lblThiCongDesc.Name = "lblThiCongDesc";
            lblThiCongDesc.Size = new Size(238, 58);
            lblThiCongDesc.TabIndex = 1;
            lblThiCongDesc.Text = "Phân công nhân viên, chấm công theo công trình.";
            //
            // FrmMain
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 561);
            Controls.Add(pnlContent);
            Controls.Add(pnlHeader);
            MinimumSize = new Size(800, 500);
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Xây Dựng";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlContent.ResumeLayout(false);
            pnlThiCong.ResumeLayout(false);
            pnlThiCong.PerformLayout();
            pnlCongTrinh.ResumeLayout(false);
            pnlCongTrinh.PerformLayout();
            pnlNhanVien.ResumeLayout(false);
            pnlNhanVien.PerformLayout();
            pnlPhongBan.ResumeLayout(false);
            pnlPhongBan.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSubtitle;
        private Panel pnlContent;
        private Panel pnlPhongBan;
        private Label lblPhongBanDesc;
        private Label lblPhongBan;
        private Panel pnlNhanVien;
        private Label lblNhanVienDesc;
        private Label lblNhanVien;
        private Panel pnlCongTrinh;
        private Label lblCongTrinhDesc;
        private Label lblCongTrinh;
        private Panel pnlThiCong;
        private Label lblThiCongDesc;
        private Label lblThiCong;
    }
}
