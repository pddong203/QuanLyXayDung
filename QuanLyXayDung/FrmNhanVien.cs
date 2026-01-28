using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyXayDung
{
    public partial class FrmNhanVien : Form
    {
        bool isAdding = false; // Biến để theo dõi trạng thái thêm mới

        public FrmNhanVien()
        {
            InitializeComponent();
            Load += FrmNhanVien_Load;
            dgvNhanVien.SelectionChanged += dgvNhanVien_SelectionChanged;
        }

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            LoadNhanVien();
            LoadPhongBan();
            EnableControls(false);
        }

        private void LoadNhanVien()
        {
            dgvNhanVien.DataSource = NhanVienDAL.GetAll();
        }

        private void LoadPhongBan()
        {
            DataTable dt = NhanVienDAL.GetAllPhongBan();
            cmbPhongBan.DataSource = dt;
            cmbPhongBan.DisplayMember = "TenPB";
            cmbPhongBan.ValueMember = "MaPB";
        }

        private void dgvNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow == null) return;

            isAdding = false;
            EnableControls(false);

            txtMaNV.Text = dgvNhanVien.CurrentRow.Cells["MaNV"].Value?.ToString() ?? "";
            txtHoTen.Text = dgvNhanVien.CurrentRow.Cells["HoTen"].Value?.ToString() ?? "";
            txtDiaChi.Text = dgvNhanVien.CurrentRow.Cells["DiaChi"].Value?.ToString() ?? "";

            // Xử lý ngày sinh
            if (dgvNhanVien.CurrentRow.Cells["NgaySinh"].Value != DBNull.Value &&
                dgvNhanVien.CurrentRow.Cells["NgaySinh"].Value != null)
            {
                dtpNgaySinh.Value = Convert.ToDateTime(dgvNhanVien.CurrentRow.Cells["NgaySinh"].Value);
            }
            else
            {
                dtpNgaySinh.Value = DateTime.Now.AddYears(-25);
            }

            // Xử lý giới tính
            string gioiTinh = dgvNhanVien.CurrentRow.Cells["GioiTinh"].Value?.ToString() ?? "";
            if (!string.IsNullOrEmpty(gioiTinh))
            {
                cmbGioiTinh.SelectedItem = gioiTinh;
            }

            // Xử lý phòng ban
            string maPB = dgvNhanVien.CurrentRow.Cells["MaPB"].Value?.ToString() ?? "";
            if (!string.IsNullOrEmpty(maPB))
            {
                cmbPhongBan.SelectedValue = maPB;
            }

            txtMaNV.Enabled = false;
        }

        private void ClearInput()
        {
            txtMaNV.Clear();
            txtHoTen.Clear();
            txtDiaChi.Clear();
            dtpNgaySinh.Value = DateTime.Now.AddYears(-25);
            cmbGioiTinh.SelectedIndex = -1;
            if (cmbPhongBan.Items.Count > 0)
                cmbPhongBan.SelectedIndex = 0;
        }

        private void EnableControls(bool enabled)
        {
            txtHoTen.Enabled = enabled;
            txtDiaChi.Enabled = enabled;
            dtpNgaySinh.Enabled = enabled;
            cmbGioiTinh.Enabled = enabled;
            cmbPhongBan.Enabled = enabled;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdding = true;
            ClearInput();
            txtMaNV.Enabled = true;
            EnableControls(true);
            txtMaNV.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            isAdding = false;
            EnableControls(true);
            txtHoTen.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maNV = dgvNhanVien.CurrentRow.Cells["MaNV"].Value?.ToString() ?? "";
            string hoTen = dgvNhanVien.CurrentRow.Cells["HoTen"].Value?.ToString() ?? "";

            DialogResult dr = MessageBox.Show(
                $"Bạn có chắc muốn xóa nhân viên {maNV} - {hoTen}?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (dr != DialogResult.Yes) return;

            bool kq = NhanVienDAL.XoaNhanVien(maNV);

            if (kq)
            {
                MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadNhanVien();
                ClearInput();
                EnableControls(false);
            }
            else
            {
                MessageBox.Show(
                    "Không thể xóa nhân viên!\nNhân viên có thể đang là trưởng phòng hoặc đang tham gia công trình.",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNV.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            if (cmbPhongBan.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn phòng ban!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maNV = txtMaNV.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            DateTime? ngaySinh = dtpNgaySinh.Value;
            string gioiTinh = cmbGioiTinh.SelectedItem?.ToString();
            string maPB = cmbPhongBan.SelectedValue.ToString();

            bool kq;

            if (isAdding)
            {
                // THÊM
                kq = NhanVienDAL.ThemNhanVien(maNV, hoTen, diaChi, ngaySinh, gioiTinh, maPB);
                if (kq)
                {
                    MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm nhân viên thất bại!\nMã nhân viên có thể đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                // SỬA
                kq = NhanVienDAL.SuaNhanVien(maNV, hoTen, diaChi, ngaySinh, gioiTinh, maPB);
                if (kq)
                {
                    MessageBox.Show("Sửa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sửa nhân viên thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            LoadNhanVien();
            EnableControls(false);
            txtMaNV.Enabled = false;
        }
    }
}
