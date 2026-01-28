using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyXayDung
{
    public partial class FrmCongTrinh : Form
    {
        bool isAdding = false; // Biến để theo dõi trạng thái thêm mới

        public FrmCongTrinh()
        {
            InitializeComponent();
            Load += FrmCongTrinh_Load;
            dgvCongTrinh.SelectionChanged += dgvCongTrinh_SelectionChanged;
            
            // Thiết lập phím tắt
            KeyPreview = true;
            KeyDown += FrmCongTrinh_KeyDown;
        }

        private void FrmCongTrinh_Load(object sender, EventArgs e)
        {
            LoadCongTrinh();
        }

        private void LoadCongTrinh()
        {
            dgvCongTrinh.DataSource = CongTrinhDAL.GetAll();
            
            // Đặt tên cột hiển thị tiếng Việt
            if (dgvCongTrinh.Columns.Count > 0)
            {
                dgvCongTrinh.Columns["MaCT"].HeaderText = "Mã CT";
                dgvCongTrinh.Columns["TenCT"].HeaderText = "Tên công trình";
                dgvCongTrinh.Columns["DiaDiem"].HeaderText = "Địa điểm";
                dgvCongTrinh.Columns["NgayCapPhep"].HeaderText = "Ngày cấp phép";
                dgvCongTrinh.Columns["NgayKhoiCong"].HeaderText = "Ngày khởi công";
                dgvCongTrinh.Columns["NgayDuKienHoanThanh"].HeaderText = "Ngày dự kiến HT";
                dgvCongTrinh.Columns["SoNhanVien"].HeaderText = "Số NV";

                // Định dạng cột ngày theo dd/MM/yyyy
                dgvCongTrinh.Columns["NgayCapPhep"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvCongTrinh.Columns["NgayKhoiCong"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvCongTrinh.Columns["NgayDuKienHoanThanh"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
        }

        private void dgvCongTrinh_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCongTrinh.CurrentRow == null) return;

            isAdding = false;
            DataGridViewRow row = dgvCongTrinh.CurrentRow;

            txtMaCT.Text = row.Cells["MaCT"].Value?.ToString() ?? "";
            txtTenCT.Text = row.Cells["TenCT"].Value?.ToString() ?? "";
            txtDiaDiem.Text = row.Cells["DiaDiem"].Value?.ToString() ?? "";

            // Xử lý ngày tháng khi xem/sửa dữ liệu cũ:
            // - Nếu có trong DB: hiển thị ngày đó
            // - Nếu null: để trống (không hiển thị gì)
            if (row.Cells["NgayCapPhep"].Value != DBNull.Value && row.Cells["NgayCapPhep"].Value != null)
            {
                dtpNgayCapPhep.Value = (DateTime)row.Cells["NgayCapPhep"].Value;
                dtpNgayCapPhep.CustomFormat = "dd/MM/yyyy";
            }
            else
            {
                dtpNgayCapPhep.CustomFormat = " ";
                dtpNgayCapPhep.Tag = "blank";
            }

            if (row.Cells["NgayKhoiCong"].Value != DBNull.Value && row.Cells["NgayKhoiCong"].Value != null)
            {
                dtpNgayKhoiCong.Value = (DateTime)row.Cells["NgayKhoiCong"].Value;
                dtpNgayKhoiCong.CustomFormat = "dd/MM/yyyy";
            }
            else
            {
                dtpNgayKhoiCong.CustomFormat = " ";
                dtpNgayKhoiCong.Tag = "blank";
            }

            if (row.Cells["NgayDuKienHoanThanh"].Value != DBNull.Value && row.Cells["NgayDuKienHoanThanh"].Value != null)
            {
                dtpNgayDuKienHoanThanh.Value = (DateTime)row.Cells["NgayDuKienHoanThanh"].Value;
                dtpNgayDuKienHoanThanh.CustomFormat = "dd/MM/yyyy";
            }
            else
            {
                dtpNgayDuKienHoanThanh.CustomFormat = " ";
                dtpNgayDuKienHoanThanh.Tag = "blank";
            }

            txtMaCT.Enabled = false; // Không cho sửa mã khi đang sửa
        }

        private void ClearInput()
        {
            txtMaCT.Clear();
            txtTenCT.Clear();
            txtDiaDiem.Clear();
            // Thêm mới: không mặc định ngày, để trống cho đến khi người dùng chọn
            dtpNgayCapPhep.CustomFormat = " ";
            dtpNgayCapPhep.Tag = "blank";
            dtpNgayKhoiCong.CustomFormat = " ";
            dtpNgayKhoiCong.Tag = "blank";
            dtpNgayDuKienHoanThanh.CustomFormat = " ";
            dtpNgayDuKienHoanThanh.Tag = "blank";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdding = true;
            ClearInput();
            txtMaCT.Enabled = true;
            txtTenCT.Enabled = true;
            txtDiaDiem.Enabled = true;
            dtpNgayCapPhep.Enabled = true;
            dtpNgayKhoiCong.Enabled = true;
            dtpNgayDuKienHoanThanh.Enabled = true;
            txtMaCT.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvCongTrinh.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn công trình cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maCT = txtMaCT.Text.Trim();
            if (string.IsNullOrEmpty(maCT))
            {
                MessageBox.Show("Vui lòng chọn công trình!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cho phép sửa các trường khác
            txtTenCT.Enabled = true;
            txtDiaDiem.Enabled = true;
            dtpNgayCapPhep.Enabled = true;
            dtpNgayKhoiCong.Enabled = true;
            dtpNgayDuKienHoanThanh.Enabled = true;
            txtTenCT.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvCongTrinh.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn công trình cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maCT = dgvCongTrinh.CurrentRow.Cells["MaCT"].Value.ToString();
            string tenCT = dgvCongTrinh.CurrentRow.Cells["TenCT"].Value?.ToString() ?? "";

            DialogResult dr = MessageBox.Show(
                $"Bạn có chắc muốn xóa công trình:\nMã: {maCT}\nTên: {tenCT}?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (dr != DialogResult.Yes) return;

            bool kq = CongTrinhDAL.XoaCongTrinh(maCT);

            if (kq)
            {
                MessageBox.Show("Xóa công trình thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCongTrinh();
                ClearInput();
            }
            else
            {
                MessageBox.Show(
                    "Không thể xóa công trình!\nCông trình có thể còn nhân viên thi công.",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu đầu vào
            string maCT = txtMaCT.Text.Trim();
            string tenCT = txtTenCT.Text.Trim();
            string diaDiem = txtDiaDiem.Text.Trim();

            if (string.IsNullOrEmpty(maCT))
            {
                MessageBox.Show("Vui lòng nhập Mã công trình!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaCT.Focus();
                return;
            }

            if (string.IsNullOrEmpty(tenCT))
            {
                MessageBox.Show("Vui lòng nhập Tên công trình!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenCT.Focus();
                return;
            }

            // Lấy giá trị ngày tháng:
            // - Nếu Tag == \"blank\": coi là null
            // - Ngược lại: lấy đúng Value
            DateTime? ngayCapPhep = GetDateFromPicker(dtpNgayCapPhep);
            DateTime? ngayKhoiCong = GetDateFromPicker(dtpNgayKhoiCong);
            DateTime? ngayDuKienHoanThanh = GetDateFromPicker(dtpNgayDuKienHoanThanh);

            // Kiểm tra ngày dự kiến hoàn thành phải sau ngày khởi công
            if (ngayKhoiCong.HasValue && ngayDuKienHoanThanh.HasValue &&
                ngayDuKienHoanThanh.Value < ngayKhoiCong.Value)
            {
                MessageBox.Show("Ngày dự kiến hoàn thành phải sau ngày khởi công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpNgayDuKienHoanThanh.Focus();
                return;
            }

            bool kq = false;
            string message = "";

            if (isAdding)
            {
                // THÊM MỚI
                kq = CongTrinhDAL.ThemCongTrinh(maCT, tenCT, diaDiem, ngayCapPhep, ngayKhoiCong, ngayDuKienHoanThanh);
                message = kq ? "Thêm công trình thành công!" : "Thêm công trình thất bại! Mã công trình có thể đã tồn tại.";
            }
            else
            {
                // SỬA
                kq = CongTrinhDAL.SuaCongTrinh(maCT, tenCT, diaDiem, ngayCapPhep, ngayKhoiCong, ngayDuKienHoanThanh);
                message = kq ? "Sửa công trình thành công!" : "Sửa công trình thất bại!";
            }

            if (kq)
            {
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCongTrinh();
                ClearInput();
                isAdding = false;
            }
            else
            {
                MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hỗ trợ phím tắt
        private void FrmCongTrinh_KeyDown(object sender, KeyEventArgs e)
        {
            // Ctrl+N: Thêm mới
            if (e.Control && e.KeyCode == Keys.N)
            {
                btnThem_Click(sender, e);
                e.Handled = true;
            }
            // Ctrl+S: Lưu
            else if (e.Control && e.KeyCode == Keys.S)
            {
                btnLuu_Click(sender, e);
                e.Handled = true;
            }
            // Delete: Xóa
            else if (e.KeyCode == Keys.Delete && !txtMaCT.Focused && !txtTenCT.Focused && !txtDiaDiem.Focused)
            {
                btnXoa_Click(sender, e);
                e.Handled = true;
            }
            // F2: Sửa
            else if (e.KeyCode == Keys.F2)
            {
                btnSua_Click(sender, e);
                e.Handled = true;
            }
        }

        // Khi người dùng tick/đổi ngày trên DateTimePicker
        private void dtpNgay_ValueChanged(object sender, EventArgs e)
        {
            var picker = sender as DateTimePicker;
            if (picker == null) return;

            // Người dùng đã chọn ngày → không còn là blank nữa
            picker.Tag = null;
            picker.CustomFormat = "dd/MM/yyyy";
        }

        private DateTime? GetDateFromPicker(DateTimePicker picker)
        {
            bool isBlank = picker.Tag as string == "blank";
            return isBlank ? (DateTime?)null : picker.Value;
        }
    }
}
