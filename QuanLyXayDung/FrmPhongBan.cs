using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyXayDung
{
    public partial class FrmPhongBan : Form
    {
        bool isAdding = false;// Biến để theo dõi trạng thái thêm mới
        public FrmPhongBan()
        {
            InitializeComponent();
            Load += FrmPhongBan_Load;
            dgvPhongBan.SelectionChanged += dgvPhongBan_SelectionChanged;
        }

        private void FrmPhongBan_Load(object sender, EventArgs e)
        {
            LoadPhongBan();
            btnChonTruongPhong.Visible = false;
        }

        private void LoadPhongBan()
        {
            dgvPhongBan.DataSource = PhongBanDAL.GetAll();

            // Ẩn cột MaPB
            //dgvPhongBan.Columns["MaPB"].Visible = false;
        }

        private void dgvPhongBan_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPhongBan.CurrentRow == null) return;

            isAdding = false;

            txtMaPhong.Text = dgvPhongBan.CurrentRow.Cells["MaPB"].Value.ToString();
            txtTenPhong.Text = dgvPhongBan.CurrentRow.Cells["TenPB"].Value.ToString();
            txtChucNang.Text = dgvPhongBan.CurrentRow.Cells["ChucNang"].Value?.ToString();

            txtMaPhong.Enabled = false;

            string maPB = dgvPhongBan.CurrentRow
                                      .Cells["MaPB"]
                                      .Value
                                      .ToString();

            LoadNhanVienTheoPhong(maPB);
        }

        private void LoadNhanVienTheoPhong(string maPB)
        {
            dgvNhanVienPhongBan.DataSource =
                PhongBanDAL.GetNVByMaPB(maPB);
        }
        private void ClearInput()
        {
            txtMaPhong.Clear();
            txtTenPhong.Clear();
            txtChucNang.Clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdding = true;

            txtMaPhong.Clear();
            txtTenPhong.Clear();
            txtChucNang.Clear();

            txtMaPhong.Enabled = true;
            txtTenPhong.Enabled = true;
            txtChucNang.Enabled = true;

            txtMaPhong.Focus();
            //string maPB = txtMaPhong.Text.Trim();
            //string tenPB = txtTenPhong.Text.Trim();
            //string chucNang = txtChucNang.Text.Trim();
            //if (string.IsNullOrEmpty(maPB) || string.IsNullOrEmpty(tenPB))
            //{
            //    MessageBox.Show("Vui lòng nhập Mã phòng ban và Tên phòng ban!");
            //    return;
            //}
            //bool kq = PhongBanDAL.ThemPhongBan(maPB, tenPB, chucNang);
            //if (kq)
            //{
            //    MessageBox.Show("Thêm phòng ban thành công!");
            //    LoadPhongBan();
            //    ClearInput();
            //}
            //else
            //{
            //    MessageBox.Show("Thêm phòng ban thất bại!");
            //}
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maPB = txtMaPhong.Text.Trim();
            string tenPB = txtTenPhong.Text.Trim();
            string chucNang = txtChucNang.Text.Trim();
            if (string.IsNullOrEmpty(maPB) || string.IsNullOrEmpty(tenPB))
            {
                MessageBox.Show("Vui lòng chọn phòng ban!");
                return;
            }

            bool kq = PhongBanDAL.SuaPhongBan(maPB, tenPB, chucNang);

            if (kq)
            {
                MessageBox.Show("Sửa phòng ban thành công!");
                LoadPhongBan();
            }
            else
            {
                MessageBox.Show("Sửa phòng ban thất bại!");
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvPhongBan.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn phòng ban cần xóa!");
                return;
            }

            string maPB = dgvPhongBan.CurrentRow.Cells["MaPB"].Value.ToString();

            DialogResult dr = MessageBox.Show(
                $"Bạn có chắc muốn xóa phòng ban {maPB}?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (dr != DialogResult.Yes) return;

            bool kq = PhongBanDAL.XoaPhongBan(maPB);

            if (kq)
            {
                MessageBox.Show("Xóa phòng ban thành công!");
                LoadPhongBan();
                ClearInput();
            }
            else
            {
                MessageBox.Show(
                    "Không thể xóa phòng ban!\nPhòng ban có thể còn nhân viên.",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private string maNVChon = "";
        private void dgvNhanVienPhongBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            maNVChon = dgvNhanVienPhongBan.Rows[e.RowIndex]
                                        .Cells["MaNV"].Value.ToString();

            btnChonTruongPhong.Visible = true;
        }

        private void btnChonTruongPhong_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maNVChon))
            {
                MessageBox.Show("Vui lòng chọn nhân viên!");
                return;
            }

            string maPB = txtMaPhong.Text.Trim();

            // Lấy trưởng phòng hiện tại
            string maTruongPhongHienTai = PhongBanDAL.GetMaTruongPhong(maPB);

            DialogResult dr;

            if (!string.IsNullOrEmpty(maTruongPhongHienTai))
            {
                // Đã có trưởng phòng
                dr = MessageBox.Show(
                    "Phòng ban này đã có Trưởng phòng.\nBạn có muốn thay thế không?",
                    "Xác nhận thay thế",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );
            }
            else
            {
                // Chưa có trưởng phòng
                dr = MessageBox.Show(
                    "Bạn có chắc muốn chọn nhân viên này làm Trưởng phòng?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
            }

            if (dr != DialogResult.Yes) return;

            bool kq = PhongBanDAL.ChonTruongPhong(maPB, maNVChon);

            if (kq)
            {
                MessageBox.Show("Chọn trưởng phòng thành công!");
                LoadPhongBan();
            }
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (isAdding)
            {
                // THÊM
                PhongBanDAL.ThemPhongBan(
                    txtMaPhong.Text.Trim(),
                    txtTenPhong.Text.Trim(),
                    txtChucNang.Text.Trim()
                );
            }
            else
            {
                // SỬA
                PhongBanDAL.SuaPhongBan(
                    txtMaPhong.Text.Trim(),
                    txtTenPhong.Text.Trim(),
                    txtChucNang.Text.Trim()
                );
            }

            LoadPhongBan();
        }
    }
}
