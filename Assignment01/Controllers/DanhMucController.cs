using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Assignment01.Models;
using Microsoft.AspNetCore.Http;
using Assignment01.Helpers;
using System.Data.SqlClient;

namespace Assignment01.Controllers
{
    public class DanhMucController : Controller
    {
        private static ConnectionHelper connectionHelper = new ConnectionHelper();
        private string connectionString = connectionHelper.getConnectionString();
        public IActionResult Index()
        {
            return View();
        }

        //GET /DanhMuc/TinhThanh/Index


        //GET /DanhMuc/TinhThanh/Them
        //GET /DanhMuc/TinhThanh/Sua
        //GET /DanhMuc/TinhThanh/Xoa


        //GET /DanhMuc/ChucVu/Index
        [Route("/DanhMuc/ChucVu/")]
        public ActionResult ChucVuIndex()
        {
            var nhanVienId = HttpContext.Session.GetString("nhanVienId");
            if (nhanVienId != null)
            {
                var nhanVien = new NhanVien(nhanVienId);
                if (nhanVien.isHCNS == true)
                {
                    ViewData["thongTinNhanVien"] = nhanVien;
                    var chucVuList = new List<ChucVu>();
                    using (var connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();
                            var getAllChucVuQuery = "select Idcv, Tencv from CHUCVU;";
                            var sqlCommand = new SqlCommand(getAllChucVuQuery, connection);
                            var reader = sqlCommand.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var cv = new ChucVu(Convert.ToInt32(reader.GetValue(0)), reader.GetValue(1).ToString());
                                    chucVuList.Add(cv);
                                }
                            }
                            sqlCommand.Dispose();
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                    ViewData["DanhSachChucVu"] = chucVuList;
                    return View("~/Views/DanhMuc/ChucVu/ChucVuIndex.cshtml");

                }
                else
                {
                    TempData["Error"] = "Bạn không có quyền xem trang này.";
                    return RedirectToAction("Index", "Nhanvien", new { id = nhanVienId });
                }
            }
            else
            {
                TempData["Error"] = "Vui lòng đăng nhập.";
                return RedirectToAction("Index", "Login");
            }
        }

        //GET /DanhMuc/ChucVu/Them
        //GET /DanhMuc/ChucVu/Sua
        //GET /DanhMuc/ChucVu/Xoa

        //GET /DanhMuc/Phongban/Index
        //GET /DanhMuc/Phongban/Them
        //GET /DanhMuc/Phongban/Sua
        //GET /DanhMuc/Phongban/Xoa


    }
}