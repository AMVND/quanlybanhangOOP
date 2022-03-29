using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang
{
    internal class MatHang
    {
        private string s;
        public MatHang()
        {
            s = ConfigurationManager.ConnectionStrings["Strconnection"].ConnectionString;
        }
        //Hiển thị
        public DataTable showProduct()
        {
            string sqlselect = "select * from tblMatHang";
            SqlConnection conn = new SqlConnection(s);
            conn.ConnectionString = @"Data Source=DESKTOP-CV2JO5P;Initial Catalog=QLBanHang;Integrated Security=True";
            conn.Open();
            SqlCommand comm = new SqlCommand(sqlselect, conn);
            comm.CommandType = CommandType.Text;
            comm.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }

        //Tìm kiếm
        public DataTable searchProduct(string tenSP)
        {
            string sqlselect = "select * from tblMatHang where TenSP like N'%" + tenSP + "%'";
            SqlConnection conn = new SqlConnection(s);
            conn.ConnectionString = @"Data Source=DESKTOP-CV2JO5P;Initial Catalog=QLBanHang;Integrated Security=True";
            conn.Open();
            SqlCommand comm = new SqlCommand(sqlselect, conn);
            comm.CommandType = CommandType.Text;
            comm.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        //sửa
        public bool updateProduct(string masp, string tensp, DateTime ngaysx, DateTime ngayhh, string donvi, string dongia, string ghichu)
        {
            string SqlUpdate = "UPDATE tblMatHang SET TenSP = N'" + tensp + "', NgaySX = N'" + ngaysx + "', NgayHH = '" + ngayhh + "', DonVi = N'" + donvi + "', DonGia = '" + dongia + "', GhiChu = N'" + ghichu + "' where MaSP = '" + masp + "'";
            SqlConnection conn = new SqlConnection(s);
            conn.ConnectionString = @"Data Source=DESKTOP-CV2JO5P;Initial Catalog=QLBanHang;Integrated Security=True";
            conn.Open();
            SqlCommand comm = new SqlCommand(SqlUpdate, conn);
            comm.CommandType = CommandType.Text;
            comm.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return true;
        }
        // Xóa
        public bool delProduct(string masp)
        {
            string SqlDelete = "delete from tblMatHang where MaSP = '" + masp + "'";
            SqlConnection conn = new SqlConnection(s);
            conn.ConnectionString = @"Data Source=DESKTOP-CV2JO5P;Initial Catalog=QLBanHang;Integrated Security=True";
            conn.Open();
            SqlCommand comm = new SqlCommand(SqlDelete, conn);
            comm.CommandType = CommandType.Text;
            comm.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return true;
        }
        //thêm
        public bool insertProduct(string masp, string tensp, DateTime ngaysx, DateTime ngayhh, string donvi, string dongia, string ghichu)
        {
            string SqlInsert = "insert into tblMatHang values ('" + masp + "',N'" + tensp + "','" + ngaysx + "','" + ngayhh + "',N'" + donvi + "',N'" + dongia + "',N'" + ghichu + "');";
            SqlConnection conn = new SqlConnection(s);
            conn.ConnectionString = @"Data Source=DESKTOP-CV2JO5P;Initial Catalog=QLBanHang;Integrated Security=True";
            conn.Open();
            SqlCommand comm = new SqlCommand(SqlInsert, conn);
            comm.CommandType = CommandType.Text;
            comm.ExecuteNonQuery();
        
            conn.Close();
            return true;
        }
    }
}
