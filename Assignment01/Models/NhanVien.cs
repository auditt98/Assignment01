using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Assignment01.Helpers;

namespace Assignment01.Models
{
    public class NhanVien
    {
        public string Id { get; set; }
        public string Hoten { get; set; }
        public DateTime Ns { get; set; }
        public string Gt { get; set; }
        public int Idtinh { get; set; }
        public string Sdt { get; set; }
        public int Idpban { get; set; }
        public int Thamnien { get; set; }
        public string Trangthai { get; set; }
        public int Idcv { get; set; }
        public string Username { get; set; }
        public string Pass { get; set; }
        public string Email { get; set; }
        public DateTime Ngayvaolam { get; set; }
        public string Tenpban { get; set; }
        public string Tencv { get; set; }
        public string Tentinh { get; set; }
        public List<NhanVien> nhanVienCungPhong { get; set; }


        public NhanVien()
        {
            

        }

        public NhanVien(string id)
        {
            var connectionHelper = new ConnectionHelper();
            var connectionString = connectionHelper.getConnectionString();
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    //var getNhanVienQuery = "select * from NhanVien where Idnv = @id";
                    var getNhanVienQuery =
@"
select Idnv, Hoten, Ns, Gt, NHANVIEN.Idtinh, Sdt, NHANVIEN.Idpban, Thamnien, Trangthai, NHANVIEN.Idcv, Username, Email, Ngayvaolam, Tentinh, Tencv, Tenpban from NHANVIEN
    inner join CHUCVU on NHANVIEN.Idcv = CHUCVU.Idcv
    inner join PHONGBAN on NHANVIEN.Idpban = PHONGBAN.Idpban
    inner join TINHTHANH on NHANVIEN.Idtinh = TINHTHANH.Idtinh
where Idnv = @id;";
                    var sqlCommand = new SqlCommand(getNhanVienQuery, connection);
                    sqlCommand.Parameters.AddWithValue("@id", id);
                    var reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            this.Id = reader.GetValue(0).ToString();
                            this.Hoten = reader.GetValue(1).ToString();
                            this.Ns = Convert.ToDateTime(reader.GetValue(2));
                            this.Gt = reader.GetValue(3).ToString();
                            this.Idtinh = Convert.ToInt32(reader.GetValue(4));
                            this.Sdt = reader.GetValue(5).ToString();
                            this.Idpban = Convert.ToInt32(reader.GetValue(6));
                            this.Thamnien = Convert.ToInt32(reader.GetValue(7).ToString());
                            this.Trangthai = reader.GetValue(8).ToString();
                            this.Idcv = Convert.ToInt32(reader.GetValue(9));
                            this.Username = reader.GetValue(10).ToString();
                            this.Email = reader.GetValue(11).ToString();
                            this.Ngayvaolam = Convert.ToDateTime(reader.GetValue(12));
                            this.Tentinh = reader.GetValue(13).ToString();
                            this.Tencv = reader.GetValue(14).ToString();
                            this.Tenpban = reader.GetValue(15).ToString();
                        }
                    }
                    reader.Close();
                }
                catch(Exception)
                {
                    throw;
                }
            }
        }

        public void setNhanVienCungPhong()
        {
            var connectionHelper = new ConnectionHelper();
            var connectionString = connectionHelper.getConnectionString();
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    List<NhanVien> nv = new List<NhanVien>();
                    connection.Open();
                    var getNhanVienCungPhongQuery = @"select Idnv from NHANVIEN where Idpban = @idpban";
                    var sqlCommand = new SqlCommand(getNhanVienCungPhongQuery, connection);
                    sqlCommand.Parameters.AddWithValue("@idpban", this.Idpban);
                    var reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var idnv = reader.GetValue(0).ToString();
                            var n = new NhanVien(idnv);
                            nv.Add(n);
                        }
                    }
                    this.nhanVienCungPhong = nv;
                    reader.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        
        

    }
}
