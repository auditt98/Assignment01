using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using Assignment01.Models;
using System.Data.SqlClient;
using Assignment01.Helpers;

namespace Assignment01.Controllers
{
    public class NhanvienController : Controller
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["QLNS"].ConnectionString;
        
        // GET: /Nhanvien/{id:string}
        public ActionResult Index(string id)
        {
            //check for log in

            var nhanVienId = HttpContext.Session.GetString("nhanVienId");

            if(nhanVienId != null)
            {
                if(nhanVienId == id)
                {
                    var nhanVien = new NhanVien(id);
                    ViewData["thongTinNhanVien"] = nhanVien;
                    return View();
                    
                }
                else
                {
                    TempData["Error"] = "Bạn không có quyền xem trang này.";
                    return RedirectToAction("Index", "Nhanvien", new { id = nhanVienId });
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        //GET: /Nhanvien/{id}/DoiMatKhau
        [Route("Nhanvien/{id}/Doimatkhau")]
        public ActionResult DoiMatKhau(string id)
        {
            var nhanVienId = HttpContext.Session.GetString("nhanVienId");

            if (nhanVienId != null)
            {
                if (nhanVienId == id)
                {
                    var nhanVien = new NhanVien(id);
                    ViewData["thongTinNhanVien"] = nhanVien;
                    return View("DoiMatKhau");

                }
                else
                {
                    TempData["Error"] = "Bạn không có quyền xem trang này.";
                    return RedirectToAction("Index", "Nhanvien", new { id = nhanVienId });
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        //POST /Nhanvien/{id}/Doimatkhau
        [HttpPost]
        [Route("Nhanvien/{id}/DoiMatKhau")]
        public ActionResult DoiMatKhau(string id, IFormCollection form)
        {
            //check if the user is logged in and the post route param {id} is the same as session
            var nhanVienId = HttpContext.Session.GetString("nhanVienId");

            if (nhanVienId != null)
            {
                if (nhanVienId == id)
                {
                    //handling password change
                    var oldPassword = form["oldPassword"].ToString();
                    var newPassword = form["newPassword"].ToString();
                    //check if old password is the same as in database
                    using(var connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();
                            var checkUserExistQuery = "select COUNT(*) from NHANVIEN where Idnv = @id and pass = @password";
                            var sqlCommand = new SqlCommand(checkUserExistQuery, connection);
                            sqlCommand.Parameters.AddWithValue("@id", nhanVienId);
                            sqlCommand.Parameters.AddWithValue("@password", oldPassword);
                            var result = Convert.ToInt32(sqlCommand.ExecuteScalar());
                            if(result == 0)
                            {
                                TempData["Error"] = "Mật khẩu cũ không chính xác, vui lòng nhập lại.";
                                return RedirectToAction("Doimatkhau", "Nhanvien", new { id = nhanVienId });
                            }
                            else
                            {
                                //change the password, is it better if i just do [where Idnv = @id and pass = @password] then read
                                // the return value instead of checking if the old password is correct?
                                var changePasswordQuery = "update NHANVIEN set Pass = @newPass where Idnv = @id";
                                var changePasswordCommand = new SqlCommand(changePasswordQuery, connection);
                                changePasswordCommand.Parameters.AddWithValue("@id", nhanVienId);
                                changePasswordCommand.Parameters.AddWithValue("@newPass", newPassword);
                                var a = changePasswordCommand.ExecuteNonQuery();
                                Console.WriteLine(a);
                                changePasswordCommand.Dispose();
                                HttpContext.Session.Remove("nhanVienId");
                                TempData["Success"] = "Đã đổi mật khẩu thành công, vui lòng đăng nhập lại";
                                return RedirectToAction("Index", "Login");
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
                    TempData["Error"] = "Bạn không có quyền thực hiện việc này.";
                    return RedirectToAction("Index", "Nhanvien", new { id = nhanVienId });
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        //GET: /Nhanvien/{id:string}/Nvcungphong
        [Route("Nhanvien/{id}/Nvcungphong")]
        public ActionResult Nvcungphong(string id)
        {
            var nhanVienId = HttpContext.Session.GetString("nhanVienId");

            if (nhanVienId != null)
            {
                if (nhanVienId == id)
                {
                    var nhanVien = new NhanVien(id);
                    nhanVien.setNhanVienCungPhong();
                    ViewData["thongTinNhanVien"] = nhanVien;
                    return View("Nvcungphong");
                }
                else
                {
                    TempData["Error"] = "Bạn không có quyền xem trang này.";
                    return RedirectToAction("Index", "Nhanvien", new { id = nhanVienId });
                }
            }
            else
            {
                TempData["Error"] = "Vui lòng đăng nhập";
                return RedirectToAction("Index", "Login");
            }
        }
        
        //GET: /Nhanvien/Them
        public ActionResult Them()
        {
            var nhanVienId = HttpContext.Session.GetString("nhanVienId");

            if (nhanVienId != null)
            {
                var nv = new NhanVien(nhanVienId);
                if (nv.isHCNS)
                {
                    ViewData["thongTinNhanVien"] = nv;
                    return View();
                }
                else
                {
                    TempData["Error"] = "Bạn không có quyền xem trang này";
                    return RedirectToAction("Index", "Nhanvien", new { id = nhanVienId });

                }
            }
            else
            {
                TempData["Error"] = "Vui lòng đăng nhập";
                return RedirectToAction("Index", "Login");
            }
        }

        //POST: /Nhanvien/Them
        [HttpPost]
        public ActionResult Them(IFormCollection form)
        {
            //Console.WriteLine()
            return Content("");
        }

        //GET: /Nhanvien/DanhSach
        public ActionResult DanhSach()
        {
            var nhanVienId = HttpContext.Session.GetString("nhanVienId");
            List<NhanVien> nvList = new List<NhanVien>();
            if (nhanVienId != null)
            {
                var nv = new NhanVien(nhanVienId);
                if (nv.isHCNS)
                {
                    ViewData["thongTinNhanVien"] = nv;
                    //get all NV
                    using(var connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();
                            var getNhanVienQuery = @"select Idnv from NHANVIEN";
                            var sqlCommand = new SqlCommand(getNhanVienQuery, connection);
                            var reader = sqlCommand.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var idnv = reader.GetValue(0).ToString();
                                    var n = new NhanVien(idnv);
                                    nvList.Add(n);
                                }
                            }
                            reader.Close();
                            ViewData["danhSachNhanVien"] = nvList;
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }

                    return View();
                }
                else
                {
                    TempData["Error"] = "Bạn không có quyền xem trang này";
                    return RedirectToAction("Index", "Nhanvien", new { id = nhanVienId });

                }
            }
            else
            {
                TempData["Error"] = "Vui lòng đăng nhập";
                return RedirectToAction("Index", "Login");
            }
        }

        //GET: /Nhanvien/ChiTiet
        [Route("/NhanVien/ChiTiet/{id}")]
        public ActionResult ChiTiet(string id)
        {
            var nhanVienId = HttpContext.Session.GetString("nhanVienId");

            if (nhanVienId != null)
            {
                var nhanVien = new NhanVien(nhanVienId);
                var nvChiTiet = new NhanVien(id);
                if(nhanVien.isHCNS == true)
                {
                    ViewData["thongTinNhanVien"] = nhanVien;
                    ViewData["thongTinNhanVienChiTiet"] = nvChiTiet;
                    return View("ChiTiet");
                }
                else
                {
                    if(nhanVien.Idpban == nvChiTiet.Idpban)
                    {
                        ViewData["thongTinNhanVien"] = nhanVien;
                        ViewData["thongTinNhanVienChiTiet"] = nvChiTiet;
                        return View("ChiTiet");
                    }
                    else
                    {
                        TempData["Error"] = "Bạn không có quyền xem trang này.";
                        return RedirectToAction("Index", "Nhanvien", new { id = nhanVienId });
                    }
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        //GET: /Nhanvien/Logout
        public ActionResult Logout()
        {
            HttpContext.Session.Remove("nhanVienId");
            return RedirectToAction("Index", "Login");
        }

        //POST: /Nhanvien/Login
        [HttpPost]
        public ActionResult Login(IFormCollection form)
        {
            var username = form["username"].ToString();
            var password = form["password"].ToString();
            using(var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var checkUserExistQuery = "select COUNT(*) from NHANVIEN where username = @username and pass = @password";
                    var sqlCommand = new SqlCommand(checkUserExistQuery, connection);
                    sqlCommand.Parameters.AddWithValue("@username", username);
                    sqlCommand.Parameters.AddWithValue("@password", password);
                    var result = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    if (result == 0)
                    {
                        TempData["Error"] = "Sai tên tài khoản hoặc mật khẩu, vui lòng kiểm tra lại.";
                        return RedirectToAction("Index", "Login");
                    }
                    else
                    {
                        var nhanVien = new NhanVien();
                        var getNhanVienQuery = "select * from NHANVIEN where username = @username and pass = @password";
                        var getNhanVienCommand = new SqlCommand(getNhanVienQuery, connection);
                        getNhanVienCommand.Parameters.AddWithValue("@username", username);
                        getNhanVienCommand.Parameters.AddWithValue("@password", password);
                        var nhanVienReader = getNhanVienCommand.ExecuteReader();
                        if (nhanVienReader.HasRows)
                        {
                            while (nhanVienReader.Read())
                            {
                                nhanVien.Id = nhanVienReader.GetValue(0).ToString();
                                nhanVien.Hoten = nhanVienReader.GetValue(1).ToString();
                            }
                            HttpContext.Session.SetString("nhanVienId", nhanVien.Id);
                            nhanVienReader.Close();
                            return RedirectToAction("Index", "NhanVien", new { id = nhanVien.Id }); 
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }

            }

            return Content("");
        }





        //public bool isLoggedIn(string id, int isSamePerson)
        //{
        //    string nhanVienId = HttpContext.Session.GetString("nhanVienId");
        //    if (isSamePerson == 0)
        //    {
        //        if (nhanVienId != null)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }

        //    }
        //    else
        //    {
        //        if (nhanVienId != null)
        //        {
        //            if (nhanVienId == id)
        //            {
        //                return true;
        //            }
        //            else
        //            {
        //                return false;
        //            }
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //}
    }
}