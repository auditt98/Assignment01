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
        
        //nhanvien/asd
        public ActionResult Index(string id)
        {
            //check for log in
            //LoginHelper loginHelper = new LoginHelper(HttpContext);
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

        //nhanvien/asjdhas/nhanviencungphong
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
                    //return Content("");
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
                return RedirectToAction("Index", "Login");
            }
        }

        [Route("Nhanvien/{id}/Nvcungphong/{idnv}")]
        public ActionResult ChiTietNVCP(string id, string idnv)
        {
            return Content("");
        }


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
                    if (result == 0) //if the user doesnt exist
                    {
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

                            //return RedirectToRoute("/NhanVien/Index/", nhanVien.Id);
                            //return Redirect("NhanVien/Index/" + );
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



    }
}