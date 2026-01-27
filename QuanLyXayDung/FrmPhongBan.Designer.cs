namespace QuanLyXayDung
{
    partial class FrmPhongBan
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
            label1 = new Label();
            label2 = new Label();
            txtTenPhong = new TextBox();
            txtChucNang = new TextBox();
            dgvPhongBan = new DataGridView();
            dgvNhanVienPhongBan = new DataGridView();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            label3 = new Label();
            txtMaPhong = new TextBox();
            btnChonTruongPhong = new Button();
            btnLuu = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPhongBan).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVienPhongBan).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 62);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 0;
            label1.Text = "Tên phòng";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 97);
            label2.Name = "label2";
            label2.Size = new Size(65, 15);
            label2.TabIndex = 1;
            label2.Text = "Chức năng";
            // 
            // txtTenPhong
            // 
            txtTenPhong.Location = new Point(105, 59);
            txtTenPhong.Name = "txtTenPhong";
            txtTenPhong.Size = new Size(100, 23);
            txtTenPhong.TabIndex = 2;
            // 
            // txtChucNang
            // 
            txtChucNang.Location = new Point(105, 94);
            txtChucNang.Name = "txtChucNang";
            txtChucNang.Size = new Size(100, 23);
            txtChucNang.TabIndex = 3;
            // 
            // dgvPhongBan
            // 
            dgvPhongBan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPhongBan.Location = new Point(377, 12);
            dgvPhongBan.Name = "dgvPhongBan";
            dgvPhongBan.Size = new Size(411, 341);
            dgvPhongBan.TabIndex = 4;
            // 
            // dgvNhanVienPhongBan
            // 
            dgvNhanVienPhongBan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNhanVienPhongBan.Location = new Point(24, 139);
            dgvNhanVienPhongBan.Name = "dgvNhanVienPhongBan";
            dgvNhanVienPhongBan.Size = new Size(326, 214);
            dgvNhanVienPhongBan.TabIndex = 5;
            dgvNhanVienPhongBan.CellClick += dgvNhanVienPhongBan_CellClick;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(72, 395);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(75, 23);
            btnThem.TabIndex = 6;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(202, 395);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(75, 23);
            btnSua.TabIndex = 7;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(344, 395);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(75, 23);
            btnXoa.TabIndex = 8;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 27);
            label3.Name = "label3";
            label3.Size = new Size(62, 15);
            label3.TabIndex = 9;
            label3.Text = "Mã phòng";
            // 
            // txtMaPhong
            // 
            txtMaPhong.Location = new Point(105, 24);
            txtMaPhong.Name = "txtMaPhong";
            txtMaPhong.Size = new Size(100, 23);
            txtMaPhong.TabIndex = 10;
            // 
            // btnChonTruongPhong
            // 
            btnChonTruongPhong.Location = new Point(617, 395);
            btnChonTruongPhong.Name = "btnChonTruongPhong";
            btnChonTruongPhong.Size = new Size(75, 23);
            btnChonTruongPhong.TabIndex = 11;
            btnChonTruongPhong.Text = "Chọn T.Phòng";
            btnChonTruongPhong.UseVisualStyleBackColor = true;
            btnChonTruongPhong.Click += btnChonTruongPhong_Click;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(484, 395);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(75, 23);
            btnLuu.TabIndex = 12;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // FrmPhongBan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnLuu);
            Controls.Add(btnChonTruongPhong);
            Controls.Add(txtMaPhong);
            Controls.Add(label3);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(dgvNhanVienPhongBan);
            Controls.Add(dgvPhongBan);
            Controls.Add(txtChucNang);
            Controls.Add(txtTenPhong);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmPhongBan";
            Text = "FrmPhongBan";
            ((System.ComponentModel.ISupportInitialize)dgvPhongBan).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVienPhongBan).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtTenPhong;
        private TextBox txtChucNang;
        private DataGridView dgvPhongBan;
        private DataGridView dgvNhanVienPhongBan;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Label label3;
        private TextBox txtMaPhong;
        private Button btnChonTruongPhong;
        private Button btnLuu;
    }
}