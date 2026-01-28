using Microsoft.Data.SqlClient;
using System.Data;

namespace QuanLyXayDung
{
    internal class NhanVienDAL
    {
        static string chuoiKN =
           @"Server=localhost\SQLEXPRESS;Database=QuanLyXayDung;Trusted_Connection=True;TrustServerCertificate=True;";

        public static DataTable GetAll()
        {
            string sql = @"
                SELECT 
                    nv.MaNV,
                    nv.HoTen,
                    nv.GioiTinh,
                    nv.NgaySinh,
                    nv.DiaChi,
                    nv.MaPB,
                    pb.TenPB
                FROM tblNhanvien nv
                JOIN tblPhongBan pb ON nv.MaPB = pb.MaPB
                ORDER BY nv.MaNV
            ";

            using (SqlConnection conn = new SqlConnection(chuoiKN))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public static DataTable GetAllPhongBan()
        {
            string sql = "SELECT MaPB, TenPB FROM tblPhongBan ORDER BY TenPB";

            using (SqlConnection conn = new SqlConnection(chuoiKN))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public static bool ThemNhanVien(string maNV, string hoTen, string diaChi, DateTime? ngaySinh, string gioiTinh, string maPB)
        {
            using SqlConnection conn = new SqlConnection(chuoiKN);
            using SqlCommand cmd = new SqlCommand("sp_ThemNhanVien", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaNV", maNV);
            cmd.Parameters.AddWithValue("@HoTen", hoTen);
            cmd.Parameters.AddWithValue("@DiaChi", diaChi ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh.HasValue ? (object)ngaySinh.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@MaPB", maPB);

            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        public static bool SuaNhanVien(string maNV, string hoTen, string diaChi, DateTime? ngaySinh, string gioiTinh, string maPB)
        {
            using SqlConnection conn = new SqlConnection(chuoiKN);
            using SqlCommand cmd = new SqlCommand("sp_SuaNhanVien", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaNV", maNV);
            cmd.Parameters.AddWithValue("@HoTen", hoTen);
            cmd.Parameters.AddWithValue("@DiaChi", diaChi ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh.HasValue ? (object)ngaySinh.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@MaPB", maPB);

            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        public static bool XoaNhanVien(string maNV)
        {
            using SqlConnection conn = new SqlConnection(chuoiKN);
            using SqlCommand cmd = new SqlCommand("sp_XoaNhanVien", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaNV", maNV);

            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }
    }
}
