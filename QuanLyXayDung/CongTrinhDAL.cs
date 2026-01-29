using Microsoft.Data.SqlClient;
using System.Data;

namespace QuanLyXayDung
{
    internal class CongTrinhDAL
    {
        static string chuoiKN =
           @"Server=localhost\SQLEXPRESS;Database=QuanLyXayDung;Trusted_Connection=True;TrustServerCertificate=True;";

        public static DataTable GetAll()
        {
            using (SqlConnection conn = new SqlConnection(chuoiKN))
            using (SqlCommand cmd = new SqlCommand("sp_LayDanhSachCongTrinh", conn))
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

        // Thêm công trình
        public static bool ThemCongTrinh(
            string maCT, 
            string tenCT, 
            string diaDiem, 
            DateTime? ngayCapPhep, 
            DateTime? ngayKhoiCong, 
            DateTime? ngayDuKienHoanThanh)
        {
            using SqlConnection conn = new SqlConnection(chuoiKN);
            using SqlCommand cmd = new SqlCommand("sp_ThemCongTrinh", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaCT", maCT);
            cmd.Parameters.AddWithValue("@TenCT", tenCT);
            cmd.Parameters.AddWithValue("@DiaDiem", (object)diaDiem ?? DBNull.Value);
            
            if (ngayCapPhep.HasValue)
                cmd.Parameters.AddWithValue("@NgayCapPhep", ngayCapPhep.Value);
            else
                cmd.Parameters.AddWithValue("@NgayCapPhep", DBNull.Value);

            if (ngayKhoiCong.HasValue)
                cmd.Parameters.AddWithValue("@NgayKhoiCong", ngayKhoiCong.Value);
            else
                cmd.Parameters.AddWithValue("@NgayKhoiCong", DBNull.Value);

            if (ngayDuKienHoanThanh.HasValue)
                cmd.Parameters.AddWithValue("@NgayDuKienHoanThanh", ngayDuKienHoanThanh.Value);
            else
                cmd.Parameters.AddWithValue("@NgayDuKienHoanThanh", DBNull.Value);

            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        // Sửa công trình
        public static bool SuaCongTrinh(
            string maCT, 
            string tenCT, 
            string diaDiem, 
            DateTime? ngayCapPhep, 
            DateTime? ngayKhoiCong, 
            DateTime? ngayDuKienHoanThanh)
        {
            using SqlConnection conn = new SqlConnection(chuoiKN);
            using SqlCommand cmd = new SqlCommand("sp_SuaCongTrinh", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaCT", maCT);
            cmd.Parameters.AddWithValue("@TenCT", tenCT);
            cmd.Parameters.AddWithValue("@DiaDiem", (object)diaDiem ?? DBNull.Value);
            
            if (ngayCapPhep.HasValue)
                cmd.Parameters.AddWithValue("@NgayCapPhep", ngayCapPhep.Value);
            else
                cmd.Parameters.AddWithValue("@NgayCapPhep", DBNull.Value);

            if (ngayKhoiCong.HasValue)
                cmd.Parameters.AddWithValue("@NgayKhoiCong", ngayKhoiCong.Value);
            else
                cmd.Parameters.AddWithValue("@NgayKhoiCong", DBNull.Value);

            if (ngayDuKienHoanThanh.HasValue)
                cmd.Parameters.AddWithValue("@NgayDuKienHoanThanh", ngayDuKienHoanThanh.Value);
            else
                cmd.Parameters.AddWithValue("@NgayDuKienHoanThanh", DBNull.Value);

            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        // Xóa công trình
        public static bool XoaCongTrinh(string maCT)
        {
            using SqlConnection conn = new SqlConnection(chuoiKN);
            using SqlCommand cmd = new SqlCommand("sp_XoaCongTrinh", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaCT", maCT);

            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }
    }
}
