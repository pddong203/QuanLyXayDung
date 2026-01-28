namespace QuanLyXayDung
{
    partial class FrmCongTrinh
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
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtMaCT = new TextBox();
            txtTenCT = new TextBox();
            txtDiaDiem = new TextBox();
            dtpNgayCapPhep = new DateTimePicker();
            dtpNgayKhoiCong = new DateTimePicker();
            dtpNgayDuKienHoanThanh = new DateTimePicker();
            dgvCongTrinh = new DataGridView();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLuu = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCongTrinh).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 27);
            label1.Name = "label1";
            label1.Size = new Size(89, 15);
            label1.TabIndex = 0;
            label1.Text = "Mã công trình";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 62);
            label2.Name = "label2";
            label2.Size = new Size(90, 15);
            label2.TabIndex = 1;
            label2.Text = "Tên công trình";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 97);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 2;
            label3.Text = "Địa điểm";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 132);
            label4.Name = "label4";
            label4.Size = new Size(88, 15);
            label4.TabIndex = 3;
            label4.Text = "Ngày cấp phép";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(26, 167);
            label5.Name = "label5";
            label5.Size = new Size(80, 15);
            label5.TabIndex = 4;
            label5.Text = "Ngày khởi công";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(26, 202);
            label6.Name = "label6";
            label6.Size = new Size(140, 15);
            label6.TabIndex = 5;
            label6.Text = "Ngày dự kiến hoàn thành";
            // 
            // txtMaCT
            // 
            txtMaCT.Location = new Point(172, 24);
            txtMaCT.Name = "txtMaCT";
            txtMaCT.Size = new Size(200, 23);
            txtMaCT.TabIndex = 6;
            // 
            // txtTenCT
            // 
            txtTenCT.Location = new Point(172, 59);
            txtTenCT.Name = "txtTenCT";
            txtTenCT.Size = new Size(200, 23);
            txtTenCT.TabIndex = 7;
            // 
            // txtDiaDiem
            // 
            txtDiaDiem.Location = new Point(172, 94);
            txtDiaDiem.Name = "txtDiaDiem";
            txtDiaDiem.Size = new Size(200, 23);
            txtDiaDiem.TabIndex = 8;
            // 
            // dtpNgayCapPhep
            // 
            dtpNgayCapPhep.Format = DateTimePickerFormat.Custom;
            dtpNgayCapPhep.CustomFormat = " ";
            dtpNgayCapPhep.Location = new Point(172, 129);
            dtpNgayCapPhep.Name = "dtpNgayCapPhep";
            dtpNgayCapPhep.Size = new Size(200, 23);
            dtpNgayCapPhep.TabIndex = 9;
            dtpNgayCapPhep.ValueChanged += dtpNgay_ValueChanged;
            // 
            // dtpNgayKhoiCong
            // 
            dtpNgayKhoiCong.Format = DateTimePickerFormat.Custom;
            dtpNgayKhoiCong.CustomFormat = " ";
            dtpNgayKhoiCong.Location = new Point(172, 164);
            dtpNgayKhoiCong.Name = "dtpNgayKhoiCong";
            dtpNgayKhoiCong.Size = new Size(200, 23);
            dtpNgayKhoiCong.TabIndex = 10;
            dtpNgayKhoiCong.ValueChanged += dtpNgay_ValueChanged;
            // 
            // dtpNgayDuKienHoanThanh
            // 
            dtpNgayDuKienHoanThanh.Format = DateTimePickerFormat.Custom;
            dtpNgayDuKienHoanThanh.CustomFormat = " ";
            dtpNgayDuKienHoanThanh.Location = new Point(172, 199);
            dtpNgayDuKienHoanThanh.Name = "dtpNgayDuKienHoanThanh";
            dtpNgayDuKienHoanThanh.Size = new Size(200, 23);
            dtpNgayDuKienHoanThanh.TabIndex = 11;
            dtpNgayDuKienHoanThanh.ValueChanged += dtpNgay_ValueChanged;
            // 
            // dgvCongTrinh
            // 
            dgvCongTrinh.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCongTrinh.Location = new Point(26, 240);
            dgvCongTrinh.Name = "dgvCongTrinh";
            dgvCongTrinh.Size = new Size(750, 200);
            dgvCongTrinh.TabIndex = 12;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(26, 460);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(75, 23);
            btnThem.TabIndex = 13;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(156, 460);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(75, 23);
            btnSua.TabIndex = 14;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(286, 460);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(75, 23);
            btnXoa.TabIndex = 15;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(416, 460);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(75, 23);
            btnLuu.TabIndex = 16;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // FrmCongTrinh
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 500);
            Controls.Add(btnLuu);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(dgvCongTrinh);
            Controls.Add(dtpNgayDuKienHoanThanh);
            Controls.Add(dtpNgayKhoiCong);
            Controls.Add(dtpNgayCapPhep);
            Controls.Add(txtDiaDiem);
            Controls.Add(txtTenCT);
            Controls.Add(txtMaCT);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmCongTrinh";
            Text = "Quản lý Công trình";
            ((System.ComponentModel.ISupportInitialize)dgvCongTrinh).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtMaCT;
        private TextBox txtTenCT;
        private TextBox txtDiaDiem;
        private DateTimePicker dtpNgayCapPhep;
        private DateTimePicker dtpNgayKhoiCong;
        private DateTimePicker dtpNgayDuKienHoanThanh;
        private DataGridView dgvCongTrinh;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLuu;
    }
}
