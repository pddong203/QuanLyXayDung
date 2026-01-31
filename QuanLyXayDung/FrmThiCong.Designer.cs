namespace QuanLyXayDung
{
    partial class FrmThiCong
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

        private void InitializeComponent()
        {
            this.dgvThiCong = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSoNgayCong = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.cboNhanVien = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboCongTrinh = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPhanCong = new System.Windows.Forms.Button();
            this.btnChamCong = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            
            ((System.ComponentModel.ISupportInitialize)(this.dgvThiCong)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoNgayCong)).BeginInit();
            this.SuspendLayout();

            // 
            // dgvThiCong
            // 
            this.dgvThiCong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThiCong.Location = new System.Drawing.Point(12, 190);
            this.dgvThiCong.Name = "dgvThiCong";
            this.dgvThiCong.ReadOnly = true;
            this.dgvThiCong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThiCong.Size = new System.Drawing.Size(760, 360);
            this.dgvThiCong.TabIndex = 0;
            
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLamMoi);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.btnChamCong);
            this.groupBox1.Controls.Add(this.btnPhanCong);
            this.groupBox1.Controls.Add(this.txtSoNgayCong);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboNhanVien);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboCongTrinh);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 160);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin phân công";

            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Công trình:";

            // 
            // cboCongTrinh
            // 
            this.cboCongTrinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCongTrinh.FormattingEnabled = true;
            this.cboCongTrinh.Location = new System.Drawing.Point(110, 27);
            this.cboCongTrinh.Name = "cboCongTrinh";
            this.cboCongTrinh.Size = new System.Drawing.Size(250, 23);
            this.cboCongTrinh.TabIndex = 1;

            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(400, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nhân viên:";

            // 
            // cboNhanVien
            // 
            this.cboNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhanVien.FormattingEnabled = true;
            this.cboNhanVien.Location = new System.Drawing.Point(480, 27);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Size = new System.Drawing.Size(250, 23);
            this.cboNhanVien.TabIndex = 3;

            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Số ngày công:";

            // 
            // txtSoNgayCong
            // 
            this.txtSoNgayCong.Location = new System.Drawing.Point(110, 68);
            this.txtSoNgayCong.Name = "txtSoNgayCong";
            this.txtSoNgayCong.Size = new System.Drawing.Size(100, 23);
            this.txtSoNgayCong.TabIndex = 5;

            // 
            // btnPhanCong
            // 
            this.btnPhanCong.Location = new System.Drawing.Point(110, 110);
            this.btnPhanCong.Name = "btnPhanCong";
            this.btnPhanCong.Size = new System.Drawing.Size(100, 30);
            this.btnPhanCong.TabIndex = 6;
            this.btnPhanCong.Text = "Phân công";
            this.btnPhanCong.UseVisualStyleBackColor = true;
            this.btnPhanCong.Click += new System.EventHandler(this.btnPhanCong_Click);

            // 
            // btnChamCong
            // 
            this.btnChamCong.Location = new System.Drawing.Point(220, 110);
            this.btnChamCong.Name = "btnChamCong";
            this.btnChamCong.Size = new System.Drawing.Size(100, 30);
            this.btnChamCong.TabIndex = 7;
            this.btnChamCong.Text = "Chấm công";
            this.btnChamCong.UseVisualStyleBackColor = true;
            this.btnChamCong.Click += new System.EventHandler(this.btnChamCong_Click);

            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(330, 110);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 30);
            this.btnXoa.TabIndex = 8;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(440, 110);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(100, 30);
            this.btnLamMoi.TabIndex = 9;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            // 
            // FrmThiCong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvThiCong);
            this.Name = "FrmThiCong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Thi Công - Phân Công";
            
            ((System.ComponentModel.ISupportInitialize)(this.dgvThiCong)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoNgayCong)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dgvThiCong;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboCongTrinh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboNhanVien;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown txtSoNgayCong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPhanCong;
        private System.Windows.Forms.Button btnChamCong;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
    }
}
