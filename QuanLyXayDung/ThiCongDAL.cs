using Microsoft.Data.SqlClient;
using System.Data;
using System;

namespace QuanLyXayDung
{
    internal class ThiCongDAL
    {
        static string chuoiKN = @"Server=localhost\SQLEXPRESS;Database=QuanLyXayDung;Trusted_Connection=True;TrustServerCertificate=True;";

        // Lấy danh sách Nhân viên (ComboBox)
        public static DataTable GetDSNhanVien()
        {
            using (SqlConnection conn = new SqlConnection(chuoiKN))
            using (SqlCommand cmd = new SqlCommand("sp_LayDanhSachNhanVien", conn))
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

        // Lấy danh sách Công trình (ComboBox)
        public static DataTable GetDSCongTrinh()
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

        // Lấy danh sách Thi công (Grid)
        public static DataTable GetAll()
        {
            using (SqlConnection conn = new SqlConnection(chuoiKN))
            using (SqlCommand cmd = new SqlCommand("sp_LayDanhSachThiCong", conn))
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

        public static bool PhanCongNhanVien(string maNV, string maCT)
        {
            using (SqlConnection conn = new SqlConnection(chuoiKN))
            using (SqlCommand cmd = new SqlCommand("sp_PhanCongNhanVien", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaNV", maNV);
                cmd.Parameters.AddWithValue("@MaCT", maCT);

                conn.Open();
                try
                {
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }

        public static bool ChamCong(string maNV, string maCT, int soNgayCong)
        {
            using (SqlConnection conn = new SqlConnection(chuoiKN))
            using (SqlCommand cmd = new SqlCommand("sp_ChamCong", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaNV", maNV);
                cmd.Parameters.AddWithValue("@MaCT", maCT);
                cmd.Parameters.AddWithValue("@SoNgayCong", soNgayCong);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public static bool XoaPhanCong(string maNV, string maCT)
        {
            using (SqlConnection conn = new SqlConnection(chuoiKN))
            using (SqlCommand cmd = new SqlCommand("sp_XoaPhanCong", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaNV", maNV);
                cmd.Parameters.AddWithValue("@MaCT", maCT);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
