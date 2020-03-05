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
        [Route("/DanhMuc/TinhThanh/")]
        public ActionResult TinhThanhIndex()
        {
            var nhanVienId = HttpContext.Session.GetString("nhanVienId");
            if (nhanVienId != null)
            {
                var nhanVien = new NhanVien(nhanVienId);
                if (nhanVien.isHCNS == true)
                {
                    ViewData["thongTinNhanVien"] = nhanVien;
                    var tinhThanhList = new List<TinhThanh>();
                    using (var connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();
                            var getAllTinhThanhQuery = "select Idtinh, Tentinh from TINHTHANH;";
                            var sqlCommand = new SqlCommand(getAllTinhThanhQuery, connection);
                            var reader = sqlCommand.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var tt = new TinhThanh(Convert.ToInt32(reader.GetValue(0)), reader.GetValue(1).ToString());
                                    tinhThanhList.Add(tt);
                                }
                            }
                            sqlCommand.Dispose();
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                    ViewData["DanhMucTinhThanh"] = tinhThanhList;
                    return View("~/Views/DanhMuc/TinhThanh/Index.cshtml");

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
                    ViewData["DanhMucChucVu"] = chucVuList;
                    return View("~/Views/DanhMuc/ChucVu/Index.cshtml");

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
        [Route("/DanhMuc/PhongBan/")]
        public ActionResult PhongBanIndex()
        {
            var nhanVienId = HttpContext.Session.GetString("nhanVienId");
            if (nhanVienId != null)
            {
                var nhanVien = new NhanVien(nhanVienId);
                if (nhanVien.isHCNS == true)
                {
                    ViewData["thongTinNhanVien"] = nhanVien;
                    var phongBanList = new List<PhongBan>();
                    using (var connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();
                            var getAllPhongBanQuery = "select Idpban, Tenpban from PHONGBAN;";
                            var sqlCommand = new SqlCommand(getAllPhongBanQuery, connection);
                            var reader = sqlCommand.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var pb = new PhongBan(Convert.ToInt32(reader.GetValue(0)), reader.GetValue(1).ToString());
                                    phongBanList.Add(pb);
                                }
                            }
                            sqlCommand.Dispose();
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                    ViewData["DanhMucPhongBan"] = phongBanList;
                    return View("~/Views/DanhMuc/PhongBan/Index.cshtml");

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

        //GET /DanhMuc/Phongban/Them
        //GET /DanhMuc/Phongban/Sua
        //GET /DanhMuc/Phongban/Xoa


    }
}