namespace QuanLyXayDung
{
    partial class FrmNhanVien
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
            txtMaNV = new TextBox();
            txtHoTen = new TextBox();
            txtDiaChi = new TextBox();
            dtpNgaySinh = new DateTimePicker();
            cmbGioiTinh = new ComboBox();
            cmbPhongBan = new ComboBox();
            dgvNhanVien = new DataGridView();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLuu = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 27);
            label1.Name = "label1";
            label1.Size = new Size(78, 15);
            label1.TabIndex = 0;
            label1.Text = "Mã nhân viên";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 62);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 1;
            label2.Text = "Họ tên";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 97);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 2;
            label3.Text = "Địa chỉ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 132);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 3;
            label4.Text = "Ngày sinh";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(26, 167);
            label5.Name = "label5";
            label5.Size = new Size(52, 15);
            label5.TabIndex = 4;
            label5.Text = "Giới tính";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(26, 202);
            label6.Name = "label6";
            label6.Size = new Size(62, 15);
            label6.TabIndex = 5;
            label6.Text = "Phòng ban";
            // 
            // txtMaNV
            // 
            txtMaNV.Location = new Point(120, 24);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.Size = new Size(200, 23);
            txtMaNV.TabIndex = 6;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(120, 59);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(200, 23);
            txtHoTen.TabIndex = 7;
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(120, 94);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(200, 23);
            txtDiaChi.TabIndex = 8;
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.Format = DateTimePickerFormat.Short;
            dtpNgaySinh.Location = new Point(120, 129);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(200, 23);
            dtpNgaySinh.TabIndex = 9;
            // 
            // cmbGioiTinh
            // 
            cmbGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGioiTinh.FormattingEnabled = true;
            cmbGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            cmbGioiTinh.Location = new Point(120, 164);
            cmbGioiTinh.Name = "cmbGioiTinh";
            cmbGioiTinh.Size = new Size(200, 23);
            cmbGioiTinh.TabIndex = 10;
            // 
            // cmbPhongBan
            // 
            cmbPhongBan.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPhongBan.FormattingEnabled = true;
            cmbPhongBan.Location = new Point(120, 199);
            cmbPhongBan.Name = "cmbPhongBan";
            cmbPhongBan.Size = new Size(200, 23);
            cmbPhongBan.TabIndex = 11;
            // 
            // dgvNhanVien
            // 
            dgvNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNhanVien.Location = new Point(377, 12);
            dgvNhanVien.Name = "dgvNhanVien";
            dgvNhanVien.Size = new Size(600, 400);
            dgvNhanVien.TabIndex = 12;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(72, 260);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(75, 23);
            btnThem.TabIndex = 13;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(202, 260);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(75, 23);
            btnSua.TabIndex = 14;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(332, 260);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(75, 23);
            btnXoa.TabIndex = 15;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(202, 310);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(75, 23);
            btnLuu.TabIndex = 16;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // FrmNhanVien
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 450);
            Controls.Add(btnLuu);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(dgvNhanVien);
            Controls.Add(cmbPhongBan);
            Controls.Add(cmbGioiTinh);
            Controls.Add(dtpNgaySinh);
            Controls.Add(txtDiaChi);
            Controls.Add(txtHoTen);
            Controls.Add(txtMaNV);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmNhanVien";
            Text = "Quản lý nhân viên";
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).EndInit();
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
        private TextBox txtMaNV;
        private TextBox txtHoTen;
        private TextBox txtDiaChi;
        private DateTimePicker dtpNgaySinh;
        private ComboBox cmbGioiTinh;
        private ComboBox cmbPhongBan;
        private DataGridView dgvNhanVien;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLuu;
    }
}
