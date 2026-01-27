namespace QuanLyXayDung
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            hệThốngToolStripMenuItem = new ToolStripMenuItem();
            đăngNhậpToolStripMenuItem = new ToolStripMenuItem();
            đổiMậtKhẩuToolStripMenuItem = new ToolStripMenuItem();
            nhânViênToolStripMenuItem = new ToolStripMenuItem();
            nhânViênToolStripMenuItem1 = new ToolStripMenuItem();
            phòngBanToolStripMenuItem = new ToolStripMenuItem();
            côngTrìnhToolStripMenuItem = new ToolStripMenuItem();
            thiCôngToolStripMenuItem = new ToolStripMenuItem();
            nghiệpVụToolStripMenuItem = new ToolStripMenuItem();
            chấmCôngToolStripMenuItem = new ToolStripMenuItem();
            tínhLươngToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { hệThốngToolStripMenuItem, nhânViênToolStripMenuItem, nghiệpVụToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            hệThốngToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { đăngNhậpToolStripMenuItem, đổiMậtKhẩuToolStripMenuItem });
            hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            hệThốngToolStripMenuItem.Size = new Size(69, 20);
            hệThốngToolStripMenuItem.Text = "Hệ thống";
            // 
            // đăngNhậpToolStripMenuItem
            // 
            đăngNhậpToolStripMenuItem.Name = "đăngNhậpToolStripMenuItem";
            đăngNhậpToolStripMenuItem.Size = new Size(145, 22);
            đăngNhậpToolStripMenuItem.Text = "Đăng nhập";
            // 
            // đổiMậtKhẩuToolStripMenuItem
            // 
            đổiMậtKhẩuToolStripMenuItem.Name = "đổiMậtKhẩuToolStripMenuItem";
            đổiMậtKhẩuToolStripMenuItem.Size = new Size(145, 22);
            đổiMậtKhẩuToolStripMenuItem.Text = "Đổi mật khẩu";
            // 
            // nhânViênToolStripMenuItem
            // 
            nhânViênToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { nhânViênToolStripMenuItem1, phòngBanToolStripMenuItem, côngTrìnhToolStripMenuItem, thiCôngToolStripMenuItem });
            nhânViênToolStripMenuItem.Name = "nhânViênToolStripMenuItem";
            nhânViênToolStripMenuItem.Size = new Size(74, 20);
            nhânViênToolStripMenuItem.Text = "Danh mục";
            // 
            // nhânViênToolStripMenuItem1
            // 
            nhânViênToolStripMenuItem1.Name = "nhânViênToolStripMenuItem1";
            nhânViênToolStripMenuItem1.Size = new Size(180, 22);
            nhânViênToolStripMenuItem1.Text = "Nhân viên";
            // 
            // phòngBanToolStripMenuItem
            // 
            phòngBanToolStripMenuItem.Name = "phòngBanToolStripMenuItem";
            phòngBanToolStripMenuItem.Size = new Size(180, 22);
            phòngBanToolStripMenuItem.Text = "Phòng ban";
            phòngBanToolStripMenuItem.Click += phòngBanToolStripMenuItem_Click;
            // 
            // côngTrìnhToolStripMenuItem
            // 
            côngTrìnhToolStripMenuItem.Name = "côngTrìnhToolStripMenuItem";
            côngTrìnhToolStripMenuItem.Size = new Size(180, 22);
            côngTrìnhToolStripMenuItem.Text = "Công trình";
            // 
            // thiCôngToolStripMenuItem
            // 
            thiCôngToolStripMenuItem.Name = "thiCôngToolStripMenuItem";
            thiCôngToolStripMenuItem.Size = new Size(180, 22);
            thiCôngToolStripMenuItem.Text = "Thi công";
            // 
            // nghiệpVụToolStripMenuItem
            // 
            nghiệpVụToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { chấmCôngToolStripMenuItem, tínhLươngToolStripMenuItem });
            nghiệpVụToolStripMenuItem.Name = "nghiệpVụToolStripMenuItem";
            nghiệpVụToolStripMenuItem.Size = new Size(74, 20);
            nghiệpVụToolStripMenuItem.Text = "Nghiệp vụ";
            // 
            // chấmCôngToolStripMenuItem
            // 
            chấmCôngToolStripMenuItem.Name = "chấmCôngToolStripMenuItem";
            chấmCôngToolStripMenuItem.Size = new Size(136, 22);
            chấmCôngToolStripMenuItem.Text = "Chấm công";
            // 
            // tínhLươngToolStripMenuItem
            // 
            tínhLươngToolStripMenuItem.Name = "tínhLươngToolStripMenuItem";
            tínhLươngToolStripMenuItem.Size = new Size(136, 22);
            tínhLươngToolStripMenuItem.Text = "Tính lương";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem hệThốngToolStripMenuItem;
        private ToolStripMenuItem đăngNhậpToolStripMenuItem;
        private ToolStripMenuItem đổiMậtKhẩuToolStripMenuItem;
        private ToolStripMenuItem nhânViênToolStripMenuItem;
        private ToolStripMenuItem nhânViênToolStripMenuItem1;
        private ToolStripMenuItem phòngBanToolStripMenuItem;
        private ToolStripMenuItem côngTrìnhToolStripMenuItem;
        private ToolStripMenuItem thiCôngToolStripMenuItem;
        private ToolStripMenuItem nghiệpVụToolStripMenuItem;
        private ToolStripMenuItem chấmCôngToolStripMenuItem;
        private ToolStripMenuItem tínhLươngToolStripMenuItem;
    }
}
