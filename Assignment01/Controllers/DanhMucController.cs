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
        [Route("/DanhMuc/TinhThanh/Them")]
        public ActionResult ThemTinhThanh()
        {
            var nhanVienId = HttpContext.Session.GetString("nhanVienId");
            if (nhanVienId != null)
            {
                var nhanVien = new NhanVien(nhanVienId);
                if (nhanVien.isHCNS == true)
                {
                    ViewData["thongTinNhanVien"] = nhanVien;
                    using (var connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();
                            var getMaxIdttQuery = "SELECT IDENT_CURRENT('TINHTHANH');";
                            var sqlCommand = new SqlCommand(getMaxIdttQuery, connection);
                            int maxIdtt = Convert.ToInt32(sqlCommand.ExecuteScalar());
                            ViewData["newIdTt"] = maxIdtt + 1;
                            sqlCommand.Dispose();
                            Console.WriteLine(ViewData["newIdTt"]);
                            return View("~/Views/DanhMuc/TinhThanh/Them.cshtml");
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
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

        //POST /DanhMuc/TinhThanh/Them
        [HttpPost]
        [Route("/DanhMuc/TinhThanh/Them")]
        public ActionResult ThemTinhThanh(IFormCollection form)
        {
            var newTtName = form["newTtName"].ToString().Trim();
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var checkExistQuery = "select count(*) from TINHTHANH where Tentinh = @tenTt";
                    var sqlCommand0 = new SqlCommand(checkExistQuery, connection);
                    sqlCommand0.Parameters.AddWithValue("@tenTt", newTtName);
                    var checkResult = Convert.ToInt32(sqlCommand0.ExecuteScalar());
                    if (checkResult == 0)
                    {
                        var insertNewTt = "insert into TINHTHANH values(@tt);";
                        var sqlCommand = new SqlCommand(insertNewTt, connection);
                        sqlCommand.Parameters.AddWithValue("@tt", newTtName);
                        var result = sqlCommand.ExecuteNonQuery();
                        if (result == 0)
                        {
                            TempData["Error"] = "Đã có lỗi xảy ra.";
                            return Redirect("/DanhMuc/TinhThanh");
                        }
                        else
                        {
                            return Redirect("/DanhMuc/TinhThanh/");
                        }
                    }
                    else
                    {
                        TempData["Error"] = "Tên tỉnh thành trùng với tỉnh thành đã có";
                        return Redirect("/DanhMuc/TinhThanh/Them");
                    }
                    
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }

        //GET /DanhMuc/TinhThanh/{idTT}/Sua
        [Route("/DanhMuc/TinhThanh/{id}/Sua")]
        public ActionResult SuaTinhThanh(int id)
        {
            var nhanVienId = HttpContext.Session.GetString("nhanVienId");
            if (nhanVienId != null)
            {
                var nhanVien = new NhanVien(nhanVienId);
                if (nhanVien.isHCNS == true)
                {
                    ViewData["thongTinNhanVien"] = nhanVien;
                    using (var connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();
                            var getIdttQuery = "SELECT Idtinh, Tentinh from TINHTHANH where Idtinh = @idTinh;";
                            var sqlCommand = new SqlCommand(getIdttQuery, connection);
                            //int idT = Convert.ToInt32(sqlCommand.ExecuteScalar());
                            sqlCommand.Parameters.AddWithValue("@idTinh", id);
                            var reader = sqlCommand.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var idTt = Convert.ToInt32(reader.GetValue(0));
                                    var tenTt = reader.GetValue(1).ToString();
                                    var thongTinTinhThanh = new TinhThanh(idTt, tenTt);
                                    ViewData["thongTinTinhThanh"] = thongTinTinhThanh;
                                }
                            }
                            sqlCommand.Dispose();
                            return View("~/Views/DanhMuc/TinhThanh/Sua.cshtml");
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
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

        //POST /DanhMuc/TinhThanh/{idTT}/Sua
        [HttpPost]
        [Route("/DanhMuc/TinhThanh/{id}/Sua")]
        public ActionResult SuaTinhThanh(int id, IFormCollection form)
        {
            var nhanVienId = HttpContext.Session.GetString("nhanVienId");
            if (nhanVienId != null)
            {
                var nhanVien = new NhanVien(nhanVienId);
                if (nhanVien.isHCNS == true)
                {
                    using (var connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();
                            var newTenTinh = form["editTtName"].ToString();
                            var editTtQuery = "update TINHTHANH set Tentinh = @newTenTinh where Idtinh = @idTinh;";
                            var sqlCommand = new SqlCommand(editTtQuery, connection);
                            sqlCommand.Parameters.AddWithValue("@idTinh", id);
                            sqlCommand.Parameters.AddWithValue("@newTenTinh", newTenTinh);
                            sqlCommand.ExecuteNonQuery();
                            sqlCommand.Dispose();
                            return Redirect("/DanhMuc/TinhThanh/");
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
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

        //GET /DanhMuc/TinhThanh/{id}/Xoa

        [Route("/DanhMuc/TinhThanh/{id}/Xoa")]
        public ActionResult XoaTinhThanh(int id)
        {
            var nhanVienId = HttpContext.Session.GetString("nhanVienId");
            if (nhanVienId != null)
            {
                var nhanVien = new NhanVien(nhanVienId);
                if (nhanVien.isHCNS == true)
                {
                    ViewData["thongTinNhanVien"] = nhanVien;
                    using (var connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();
                            var getIdPbQuery = "SELECT Idtinh, Tentinh from TINHTHANH where Idtinh = @idTt;";
                            var sqlCommand = new SqlCommand(getIdPbQuery, connection);
                            sqlCommand.Parameters.AddWithValue("@idTt", id);
                            var reader = sqlCommand.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var idTt = Convert.ToInt32(reader.GetValue(0));
                                    var tenTt = reader.GetValue(1).ToString();
                                    var thongTinTinhThanh = new TinhThanh(idTt, tenTt);
                                    ViewData["thongTinTinhThanh"] = thongTinTinhThanh;
                                }
                            }
                            sqlCommand.Dispose();
                            return View("~/Views/DanhMuc/TinhThanh/Xoa.cshtml");
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
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

        //POST /DanhMuc/TinhThanh/{id}/Xoa
        [HttpPost]
        [Route("/DanhMuc/TinhThanh/{id}/Xoa")]
        public ActionResult XoaTinhThanh(int id, IFormCollection form)
        {
            var nhanVienId = HttpContext.Session.GetString("nhanVienId");
            if (nhanVienId != null)
            {
                var nhanVien = new NhanVien(nhanVienId);
                if (nhanVien.isHCNS == true)
                {
                    using (var connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();
                            var deleteIdTinhThanh = form["deleteTtId"].ToString();
                            var deleteTenTinhThanh = form["deleteTtName"].ToString();
                            var deleteTtQuery = "delete from TINHTHANH where Idtinh = @deleteIdTinhThanh and Tentinh = @deleteTenTinhThanh;";
                            var sqlCommand = new SqlCommand(deleteTtQuery, connection);
                            sqlCommand.Parameters.AddWithValue("@deleteIdTinhThanh", id);
                            sqlCommand.Parameters.AddWithValue("@deleteTenTinhThanh", deleteTenTinhThanh);
                            sqlCommand.ExecuteNonQuery();
                            sqlCommand.Dispose();
                            TempData["Success"] = "Xóa thành công";
                            return Redirect("/DanhMuc/TinhThanh/");
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
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
        [Route("/DanhMuc/ChucVu/Them")]
        public ActionResult ThemChucVu()
        {
            var nhanVienId = HttpContext.Session.GetString("nhanVienId");
            if (nhanVienId != null)
            {
                var nhanVien = new NhanVien(nhanVienId);
                if (nhanVien.isHCNS == true)
                {
                    ViewData["thongTinNhanVien"] = nhanVien;
                    //get a new Idcv, this id is just for displaying for now (multiple users probably won't cause problems)
                    //i'll figure out how to do a proper lock of the row on this later
                    using(var connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();
                            var getMaxIdcvQuery = "SELECT IDENT_CURRENT ('CHUCVU');";
                            var sqlCommand = new SqlCommand(getMaxIdcvQuery, connection);
                            //get max of idcv 
                            int maxIdcv = Convert.ToInt32(sqlCommand.ExecuteScalar());
                            ViewData["newIdcv"] = maxIdcv + 1;
                            sqlCommand.Dispose();
                            Console.WriteLine(ViewData["newIdcv"]);
                            return View("~/Views/DanhMuc/ChucVu/Them.cshtml");
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
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
        
        //POST /DanhMuc/ChucVu/Them
        [HttpPost]
        [Route("/DanhMuc/ChucVu/Them")]
        public ActionResult ThemChucVu(IFormCollection form)
        {
            var newCvName = form["newCvName"].ToString().Trim();
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var checkExistQuery = "select count(*) from CHUCVU where Tencv = @tenCv";
                    var sqlCommand0 = new SqlCommand(checkExistQuery, connection);
                    sqlCommand0.Parameters.AddWithValue("@tenCv", newCvName);
                    var checkResult = Convert.ToInt32(sqlCommand0.ExecuteScalar());
                    if(checkResult == 0)
                    {
                        var insertNewCv = "insert into CHUCVU values(@cv);";
                        var sqlCommand = new SqlCommand(insertNewCv, connection);
                        sqlCommand.Parameters.AddWithValue("@cv", newCvName);
                        var result = sqlCommand.ExecuteNonQuery();
                        if (result == 0)
                        {
                            TempData["Error"] = "Đã có lỗi xảy ra.";
                            return RedirectToAction("/DanhMuc/ChucVu/");
                        }
                        else
                        {
                            return Redirect("/DanhMuc/ChucVu/");
                        }
                    }
                    else
                    {
                        TempData["Error"] = "Tên chức vụ trùng với chức vụ đã có";
                        return Redirect("/DanhMuc/ChucVu/Them");
                    }
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }

        //GET /DanhMuc/ChucVu/{id}/Sua
        [Route("/DanhMuc/ChucVu/{id}/Sua")]
        public ActionResult SuaChucVu(int id)
        {
            var nhanVienId = HttpContext.Session.GetString("nhanVienId");
            if (nhanVienId != null)
            {
                var nhanVien = new NhanVien(nhanVienId);
                if (nhanVien.isHCNS == true)
                {
                    ViewData["thongTinNhanVien"] = nhanVien;
                    using (var connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();
                            var getIdcvQuery = "SELECT Idcv, Tencv from CHUCVU where Idcv = @idCv;";
                            var sqlCommand = new SqlCommand(getIdcvQuery, connection);
                            sqlCommand.Parameters.AddWithValue("@idCv", id);
                            var reader = sqlCommand.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var idCv = Convert.ToInt32(reader.GetValue(0));
                                    var tenCv = reader.GetValue(1).ToString();
                                    var thongTinChucVu = new ChucVu(idCv, tenCv);
                                    ViewData["thongTinChucVu"] = thongTinChucVu;
                                }
                            }
                            sqlCommand.Dispose();
                            return View("~/Views/DanhMuc/ChucVu/Sua.cshtml");
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
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

        //POST /DanhMuc/ChucVu/{id}/Sua
        [HttpPost]
        [Route("/DanhMuc/ChucVu/{id}/Sua")]
        public ActionResult SuaChucVu(int id, IFormCollection form)
        {
            var nhanVienId = HttpContext.Session.GetString("nhanVienId");
            if (nhanVienId != null)
            {
                var nhanVien = new NhanVien(nhanVienId);
                if (nhanVien.isHCNS == true)
                {
                    using (var connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();
                            var newTenChucVu = form["editCvName"].ToString();
                            var editCvQuery = "update CHUCVU set Tencv = @newTenChucVu where Idcv = @idCv;";
                            var sqlCommand = new SqlCommand(editCvQuery, connection);
                            sqlCommand.Parameters.AddWithValue("@idCv", id);
                            sqlCommand.Parameters.AddWithValue("@newTenChucVu", newTenChucVu);
                            sqlCommand.ExecuteNonQuery();
                            sqlCommand.Dispose();
                            return Redirect("/DanhMuc/ChucVu/");
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
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

        //GET /DanhMuc/ChucVu/{id}/Xoa
        [Route("/DanhMuc/ChucVu/{id}/Xoa")]
        public ActionResult XoaChucVu(int id)
        {
            var nhanVienId = HttpContext.Session.GetString("nhanVienId");
            if (nhanVienId != null)
            {
                var nhanVien = new NhanVien(nhanVienId);
                if (nhanVien.isHCNS == true)
                {
                    ViewData["thongTinNhanVien"] = nhanVien;
                    using (var connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();
                            var getIdcvQuery = "SELECT Idcv, Tencv from CHUCVU where Idcv = @idCv;";
                            var sqlCommand = new SqlCommand(getIdcvQuery, connection);
                            sqlCommand.Parameters.AddWithValue("@idCv", id);
                            var reader = sqlCommand.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var idCv = Convert.ToInt32(reader.GetValue(0));
                                    var tenCv = reader.GetValue(1).ToString();
                                    var thongTinChucVu = new ChucVu(idCv, tenCv);
                                    ViewData["thongTinChucVu"] = thongTinChucVu;
                                }
                            }
                            sqlCommand.Dispose();
                            return View("~/Views/DanhMuc/ChucVu/Xoa.cshtml");
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
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

        //POST /DanhMuc/ChucVu/{id}/Xoa
        [HttpPost]
        [Route("/DanhMuc/ChucVu/{id}/Xoa")]
        public ActionResult XoaChucVu(int id, IFormCollection form)
        {
            var nhanVienId = HttpContext.Session.GetString("nhanVienId");
            if (nhanVienId != null)
            {
                var nhanVien = new NhanVien(nhanVienId);
                if (nhanVien.isHCNS == true)
                {
                    using (var connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();
                            var deleteIdChucVu = form["deleteCvId"].ToString();
                            var deleteTenChucVu = form["deleteCvName"].ToString();
                            var deleteCvQuery = "delete from CHUCVU where Idcv = @deleteIdChucVu and Tencv = @deleteTenChucVu;";
                            var sqlCommand = new SqlCommand(deleteCvQuery, connection);
                            sqlCommand.Parameters.AddWithValue("@deleteIdChucVu", id);
                            sqlCommand.Parameters.AddWithValue("@deleteTenChucVu", deleteTenChucVu);
                            Console.WriteLine(deleteIdChucVu);
                            Console.WriteLine(deleteTenChucVu);

                            sqlCommand.ExecuteNonQuery();
                            sqlCommand.Dispose();
                            TempData["Success"] = "Xóa thành công";
                            return Redirect("/DanhMuc/ChucVu/");
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
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
        [Route("/DanhMuc/PhongBan/Them")]
        public ActionResult ThemPhongBan()
        {
            var nhanVienId = HttpContext.Session.GetString("nhanVienId");
            if (nhanVienId != null)
            {
                var nhanVien = new NhanVien(nhanVienId);
                if (nhanVien.isHCNS == true)
                {
                    ViewData["thongTinNhanVien"] = nhanVien;
                    using (var connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();
                            var getMaxIdPbQuery = "SELECT IDENT_CURRENT('PHONGBAN');";
                            var sqlCommand = new SqlCommand(getMaxIdPbQuery, connection);
                            int maxIdPb = Convert.ToInt32(sqlCommand.ExecuteScalar());
                            ViewData["newIdPb"] = maxIdPb + 1;
                            sqlCommand.Dispose();
                            Console.WriteLine(ViewData["newIdPb"]);
                            return View("~/Views/DanhMuc/PhongBan/Them.cshtml");
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
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

        //POST: /DanhMuc/PhongBan/Them
        [HttpPost]
        [Route("/DanhMuc/PhongBan/Them")]
        public ActionResult ThemPhongBan(IFormCollection form)
        {
            var newPbName = form["newPbName"].ToString().Trim();
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var checkExistQuery = "select count(*) from PHONGBAN where Tenpban = @tenPb";
                    var sqlCommand0 = new SqlCommand(checkExistQuery, connection);
                    sqlCommand0.Parameters.AddWithValue("@tenPb", newPbName);
                    var checkResult = Convert.ToInt32(sqlCommand0.ExecuteScalar());
                    if(checkResult == 0)
                    {
                        var insertNewPb = "insert into PHONGBAN values(@pb);";
                        var sqlCommand = new SqlCommand(insertNewPb, connection);
                        sqlCommand.Parameters.AddWithValue("@pb", newPbName);
                        var result = sqlCommand.ExecuteNonQuery();
                        if (result == 0)
                        {
                            TempData["Error"] = "Đã có lỗi xảy ra.";
                            return Redirect("/DanhMuc/PhongBan/");
                        }
                        else
                        {
                            return Redirect("/DanhMuc/PhongBan/");
                        }
                    }
                    else
                    {
                        TempData["Error"] = "Tên phòng ban trùng với phòng ban đã có";
                        return Redirect("/DanhMuc/PhongBan/");
                    }
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }

        //GET /DanhMuc/PhongBan/{id}/Sua
        [Route("/DanhMuc/PhongBan/{id}/Sua")]
        public ActionResult SuaPhongBan(int id)
        {
            var nhanVienId = HttpContext.Session.GetString("nhanVienId");
            if (nhanVienId != null)
            {
                var nhanVien = new NhanVien(nhanVienId);
                if (nhanVien.isHCNS == true)
                {
                    ViewData["thongTinNhanVien"] = nhanVien;
                    using (var connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();
                            var getIdPbQuery = "SELECT Idpban, Tenpban from PHONGBAN where Idpban = @idPb;";
                            var sqlCommand = new SqlCommand(getIdPbQuery, connection);
                            sqlCommand.Parameters.AddWithValue("@idPb", id);
                            var reader = sqlCommand.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var idPb = Convert.ToInt32(reader.GetValue(0));
                                    var tenPb = reader.GetValue(1).ToString();
                                    var thongTinPhongBan = new PhongBan(idPb, tenPb);
                                    ViewData["thongTinPhongBan"] = thongTinPhongBan;
                                }
                            }
                            sqlCommand.Dispose();
                            return View("~/Views/DanhMuc/PhongBan/Sua.cshtml");
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
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
        
        //POST /DanhMuc/PhongBan/{id}/Sua
        [HttpPost]
        [Route("/DanhMuc/PhongBan/{id}/Sua")]
        public ActionResult SuaPhongBan(int id, IFormCollection form)
        {
            var nhanVienId = HttpContext.Session.GetString("nhanVienId");
            if (nhanVienId != null)
            {
                var nhanVien = new NhanVien(nhanVienId);
                if (nhanVien.isHCNS == true)
                {
                    using (var connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();
                            var newTenPhongBan = form["editPbName"].ToString();
                            var editPbQuery = "update PHONGBAN set Tenpban = @newTenPhongBan where Idpban = @idPb;";
                            var sqlCommand = new SqlCommand(editPbQuery, connection);
                            sqlCommand.Parameters.AddWithValue("@idPb", id);
                            sqlCommand.Parameters.AddWithValue("@newTenPhongBan", newTenPhongBan);
                            sqlCommand.ExecuteNonQuery();
                            sqlCommand.Dispose();
                            return Redirect("/DanhMuc/PhongBan/");
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
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

        //GET /DanhMuc/Phongban/{id}/Xoa
        [Route("/DanhMuc/PhongBan/{id}/Xoa")]
        public ActionResult XoaPhongBan(int id)
        {
            var nhanVienId = HttpContext.Session.GetString("nhanVienId");
            if (nhanVienId != null)
            {
                var nhanVien = new NhanVien(nhanVienId);
                if (nhanVien.isHCNS == true)
                {
                    ViewData["thongTinNhanVien"] = nhanVien;
                    using (var connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();
                            var getIdPbQuery = "SELECT Idpban, Tenpban from PHONGBAN where Idpban = @idPb;";
                            var sqlCommand = new SqlCommand(getIdPbQuery, connection);
                            sqlCommand.Parameters.AddWithValue("@idPb", id);
                            var reader = sqlCommand.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var idPb = Convert.ToInt32(reader.GetValue(0));
                                    var tenPb = reader.GetValue(1).ToString();
                                    var thongTinPhongBan = new PhongBan(idPb, tenPb);
                                    ViewData["thongTinPhongBan"] = thongTinPhongBan;
                                }
                            }
                            sqlCommand.Dispose();
                            return View("~/Views/DanhMuc/PhongBan/Xoa.cshtml");
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
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

        //POST /DanhMuc/PhongBan/{id}/Xoa
        [HttpPost]
        [Route("/DanhMuc/PhongBan/{id}/Xoa")]
        public ActionResult XoaPhongBan(int id, IFormCollection form)
        {
            var nhanVienId = HttpContext.Session.GetString("nhanVienId");
            if (nhanVienId != null)
            {
                var nhanVien = new NhanVien(nhanVienId);
                if (nhanVien.isHCNS == true)
                {
                    using (var connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();
                            var deleteIdPhongBan = form["deletePbId"].ToString();
                            var deleteTenPhongBan = form["deletePbName"].ToString();
                            var isActiveQuery = @"select COUNT(*) from NHANVIEN where Idpban = @idpban";
                            var sqlCommand0 = new SqlCommand(isActiveQuery, connection);
                            sqlCommand0.Parameters.AddWithValue("@idpban", deleteIdPhongBan);
                            var result = Convert.ToInt32(sqlCommand0.ExecuteScalar());
                            if(result == 0)
                            {
                                var deletePbQuery = "delete from PHONGBAN where Idpban = @deleteIdPhongBan and Tenpban = @deleteTenPhongBan;";
                                var sqlCommand = new SqlCommand(deletePbQuery, connection);
                                sqlCommand.Parameters.AddWithValue("@deleteIdPhongBan", id);
                                sqlCommand.Parameters.AddWithValue("@deleteTenPhongBan", deleteTenPhongBan);
                                sqlCommand.ExecuteNonQuery();
                                sqlCommand.Dispose();
                                TempData["Success"] = "Xóa thành công";
                                return Redirect("/DanhMuc/PhongBan/");
                            }
                            else
                            {
                                TempData["Error"] = "Không thể xóa phòng ban này vì còn hoạt động";
                                return Redirect("/DanhMuc/PhongBan/");
                            }   
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
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
    }
}