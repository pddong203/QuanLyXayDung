using Microsoft.Data.SqlClient;
using System.Data;

namespace QuanLyXayDung
{

    internal class PhongBanDAL
    {
        static string chuoiKN =
           @"Server=localhost\SQLEXPRESS;Database=QuanLyXayDung;Trusted_Connection=True;TrustServerCertificate=True;";
        public static DataTable GetAll()
        {
            using (SqlConnection conn = new SqlConnection(chuoiKN))
            using (SqlCommand cmd = new SqlCommand("sp_LayDanhSachPhongBan", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public static DataTable GetNVByMaPB(string maPB)
        {
            string sql = @"
                SELECT 
                    MaNV,
                    HoTen,
                    GioiTinh,
                    NgaySinh,
                    DiaChi
                FROM tblNhanvien
                WHERE MaPB = @MaPB
            ";

            using (SqlConnection conn = new SqlConnection(chuoiKN))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaPB", maPB);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        //Thêm phòng ban
        public static bool ThemPhongBan(string maPB, string tenPB, string chucNang)
        {
            using SqlConnection conn = new SqlConnection(chuoiKN);
            using SqlCommand cmd = new SqlCommand("sp_ThemPhongBan", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaPB", maPB);
            cmd.Parameters.AddWithValue("@TenPB", tenPB);
            cmd.Parameters.AddWithValue("@ChucNang", chucNang);

            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        public static bool SuaPhongBan(string maPB, string tenPB, string chucNang)
        {
            using SqlConnection conn = new SqlConnection(chuoiKN);
            using SqlCommand cmd = new SqlCommand("sp_SuaPhongBan", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaPB", maPB);
            cmd.Parameters.AddWithValue("@TenPB", tenPB);
            cmd.Parameters.AddWithValue("@ChucNang", chucNang);

            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }


        public static bool XoaPhongBan(string maPB)
        {
            using SqlConnection conn = new SqlConnection(chuoiKN);
            using SqlCommand cmd = new SqlCommand("sp_XoaPhongBan", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaPB", maPB);

            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        public static bool ChonTruongPhong(string maPB, string maNV)
        {
            using SqlConnection conn = new SqlConnection(chuoiKN);
            using SqlCommand cmd = new SqlCommand("sp_ChonTruongPhong", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaPB", maPB);
            cmd.Parameters.AddWithValue("@MaNV", maNV);

            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }
        public static string GetMaTruongPhong(string maPB)
        {
            string sql = "SELECT MaTruongPhong FROM tblPhongBan WHERE MaPB = @MaPB";

            using (SqlConnection conn = new SqlConnection(chuoiKN))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaPB", maPB);
                conn.Open();
                object result = cmd.ExecuteScalar();
                return result == DBNull.Value ? null : result?.ToString();
            }
        }
    }

}

