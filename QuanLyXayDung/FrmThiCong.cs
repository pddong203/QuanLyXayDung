using System;
using System.Windows.Forms;

namespace QuanLyXayDung
{
    public partial class FrmThiCong : Form
    {
        public FrmThiCong()
        {
            InitializeComponent();
            Load += FrmThiCong_Load;
            dgvThiCong.SelectionChanged += dgvThiCong_SelectionChanged;
        }

        private void FrmThiCong_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadCombobox();
        }

        private void LoadData()
        {
            dgvThiCong.DataSource = ThiCongDAL.GetAll();
            if (dgvThiCong.Columns["MaNV"] != null) dgvThiCong.Columns["MaNV"].HeaderText = "Mã NV";
            if (dgvThiCong.Columns["HoTen"] != null) dgvThiCong.Columns["HoTen"].HeaderText = "Họ Tên";
            if (dgvThiCong.Columns["MaCT"] != null) dgvThiCong.Columns["MaCT"].HeaderText = "Mã CT";
            if (dgvThiCong.Columns["TenCT"] != null) dgvThiCong.Columns["TenCT"].HeaderText = "Tên Công Trình";
            if (dgvThiCong.Columns["SoNgayCong"] != null) dgvThiCong.Columns["SoNgayCong"].HeaderText = "Số Ngày Công";
            
            dgvThiCong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadCombobox()
        {
            // Load Công trình từ ThiCongDAL
            cboCongTrinh.DataSource = ThiCongDAL.GetDSCongTrinh();
            cboCongTrinh.DisplayMember = "TenCT";
            cboCongTrinh.ValueMember = "MaCT";
            cboCongTrinh.SelectedIndex = -1;

            // Load Nhân viên từ ThiCongDAL
            cboNhanVien.DataSource = ThiCongDAL.GetDSNhanVien();
            cboNhanVien.DisplayMember = "HoTen";
            cboNhanVien.ValueMember = "MaNV";
            cboNhanVien.SelectedIndex = -1;
        }

        private void dgvThiCong_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvThiCong.CurrentRow == null || dgvThiCong.SelectedRows.Count == 0) return;

            var row = dgvThiCong.CurrentRow;
            try
            {
                cboNhanVien.SelectedValue = row.Cells["MaNV"].Value.ToString();
                cboCongTrinh.SelectedValue = row.Cells["MaCT"].Value.ToString();
                
                if (int.TryParse(row.Cells["SoNgayCong"].Value.ToString(), out int ngayCong))
                {
                    txtSoNgayCong.Value = ngayCong;
                }
                else
                {
                    txtSoNgayCong.Value = 0;
                }
            }
            catch { }
        }

        private void btnPhanCong_Click(object sender, EventArgs e)
        {
            if (cboNhanVien.SelectedValue == null || cboCongTrinh.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Nhân viên và Công trình!");
                return;
            }

            string maNV = cboNhanVien.SelectedValue.ToString();
            string maCT = cboCongTrinh.SelectedValue.ToString();

            if (ThiCongDAL.PhanCongNhanVien(maNV, maCT))
            {
                MessageBox.Show("Phân công thành công!");
                LoadData();
            }
            else
            {
                MessageBox.Show("Phân công thất bại! (Có thể nhân viên đã có trong công trình này)");
            }
        }

        private void btnChamCong_Click(object sender, EventArgs e)
        {
            if (cboNhanVien.SelectedValue == null || cboCongTrinh.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Nhân viên và Công trình cần chấm công!");
                return;
            }

            string? maNV = cboNhanVien.SelectedValue.ToString();
            string? maCT = cboCongTrinh.SelectedValue.ToString();
            
            int ngayCongHienTai = (int)txtSoNgayCong.Value;
            int ngayCongMoi = ngayCongHienTai + 1;

            if (maNV == null || maCT == null) return;

            if (ThiCongDAL.ChamCong(maNV, maCT, ngayCongMoi))
            {
                MessageBox.Show("Đã chấm công (+1) thành công!");
                LoadData();
            }
            else
            {
                MessageBox.Show("Chấm công thất bại! (Nhân viên chưa được phân công vào CT này)");
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (cboNhanVien.SelectedValue == null || cboCongTrinh.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn bản ghi cần cập nhật!");
                return;
            }

            string? maNV = cboNhanVien.SelectedValue.ToString();
            string? maCT = cboCongTrinh.SelectedValue.ToString();
            int ngayCong = (int)txtSoNgayCong.Value;

            if (maNV == null || maCT == null) return;

            if (ThiCongDAL.ChamCong(maNV, maCT, ngayCong))
            {
                MessageBox.Show("Cập nhật số ngày công thành công!");
                LoadData();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (cboNhanVien.SelectedValue == null || cboCongTrinh.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn bản ghi cần xóa!");
                return;
            }

            string maNV = cboNhanVien.SelectedValue.ToString();
            string maCT = cboCongTrinh.SelectedValue.ToString();

            if (MessageBox.Show("Bạn chắc chắn muốn hủy phân công này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (ThiCongDAL.XoaPhanCong(maNV, maCT))
                {
                    MessageBox.Show("Xóa phân công thành công!");
                    LoadData();
                    LamMoi();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!");
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void LamMoi()
        {
            cboNhanVien.SelectedIndex = -1;
            cboCongTrinh.SelectedIndex = -1;
            txtSoNgayCong.Value = 0;
            cboNhanVien.Focus();
        }
    }
}
