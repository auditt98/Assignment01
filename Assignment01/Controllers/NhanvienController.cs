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
                                TempData["Error"] = "Mật khẩu cũ không chính xác.";
                                return RedirectToAction("Doimatkhau", "Nhanvien", new { id = nhanVienId });
                            }
                            else
                            {
                                if (oldPassword == newPassword)
                                {
                                    TempData["Error"] = "Mật khẩu mới trùng với mật khẩu cũ.";
                                    return RedirectToAction("Doimatkhau", "Nhanvien", new { id = nhanVienId });
                                }
                                else
                                {
                                    var changePasswordQuery = "update NHANVIEN set Pass = @newPass where Idnv = @id";
                                    var changePasswordCommand = new SqlCommand(changePasswordQuery, connection);
                                    changePasswordCommand.Parameters.AddWithValue("@id", nhanVienId);
                                    changePasswordCommand.Parameters.AddWithValue("@newPass", newPassword);
                                    var a = changePasswordCommand.ExecuteNonQuery();
                                    Console.WriteLine(a);
                                    changePasswordCommand.Dispose();
                                    HttpContext.Session.Remove("nhanVienId");
                                    TempData["Success"] = "Đổi mật khẩu thành công.";
                                    return RedirectToAction("Index", "Login");
                                }

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
                    //get the list of TinhThanh
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

                    //get the list of PhongBan
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
                    //get the list of ChucVu

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
            var nhanVienId = HttpContext.Session.GetString("nhanVienId");
            if (nhanVienId != null)
            {
                var nv = new NhanVien(nhanVienId);
                if (nv.isHCNS)
                {
                    ViewData["thongTinNhanVien"] = nv;
                    var name = form["inputName"].ToString();
                    var birthday = Convert.ToDateTime(form["inputBirthday"]);
                    var gender = form["inputGender"].ToString();
                    var tinhThanh = Convert.ToInt32(form["inputTinhThanh"]);
                    var email = form["inputEmail"].ToString();
                    var phone = form["inputPhone"].ToString();
                    var phongBanId = Convert.ToInt32(form["inputPhongBan"]);
                    var chucVuId = Convert.ToInt32(form["inputChucVu"]);
                    var startDate = Convert.ToDateTime(form["inputStartDate"]);
                    var username = form["inputUsername"].ToString();
                    var userId = form["inputId"].ToString();

                    using (var connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();
                            var checkNhanVienIdExistQuery = @"select COUNT(*) from NHANVIEN where Idnv = @userId";
                            var sqlCommand0 = new SqlCommand(checkNhanVienIdExistQuery, connection);
                            sqlCommand0.Parameters.AddWithValue("userId", userId);
                            int countNhanVienIdExist = Convert.ToInt32(sqlCommand0.ExecuteScalar());

                            var checkUsernameExistQuery = @"select count(*) from NHANVIEN where Username = @username";
                            var sqlCommand1 = new SqlCommand(checkUsernameExistQuery, connection);
                            sqlCommand1.Parameters.AddWithValue("username", username);
                            int countUsernameExist = Convert.ToInt32(sqlCommand1.ExecuteScalar());

                            if (countNhanVienIdExist != 0)
                            {
                                TempData["Error"] = "Mã nhân viên bị lặp, vui lòng nhập lại.";
                                return RedirectToAction("Them", "NhanVien");
                            }
                            else if (countUsernameExist != 0)
                            {
                                TempData["Error"] = "Username bị lặp, vui lòng nhập lại.";
                                return RedirectToAction("Them", "NhanVien");
                            }
                            else
                            {
                                var insertNhanVienQuery =
                                    @"
                                insert into NHANVIEN
                                values (@id, @hoTen, @ns, @gt, @idTinh, @sdt, @idPban, 0, N'Đang làm', @idCv, @username, '', @email, @ngayVaoLam);
                            ";
                                var sqlCommand3 = new SqlCommand(insertNhanVienQuery, connection);
                                sqlCommand3.Parameters.AddWithValue("@id", userId);
                                sqlCommand3.Parameters.AddWithValue("@hoTen", name);
                                sqlCommand3.Parameters.AddWithValue("@ns", birthday);
                                sqlCommand3.Parameters.AddWithValue("@gt", gender);
                                sqlCommand3.Parameters.AddWithValue("@idTinh", tinhThanh);
                                sqlCommand3.Parameters.AddWithValue("@sdt", phone);
                                sqlCommand3.Parameters.AddWithValue("@idPban", phongBanId);
                                sqlCommand3.Parameters.AddWithValue("@idCv", chucVuId);
                                sqlCommand3.Parameters.AddWithValue("@username", username);
                                sqlCommand3.Parameters.AddWithValue("@email", email);
                                sqlCommand3.Parameters.AddWithValue("@ngayVaoLam", startDate);
                                var result = sqlCommand3.ExecuteNonQuery();
                                if (result == 0)
                                {
                                    TempData["Error"] = "Có lỗi xảy ra, vui lòng thử lại.";
                                    return RedirectToAction("Them", "NhanVien");
                                }
                                else
                                {
                                    TempData["Success"] = "Thêm nhân viên thành công.";
                                    var thongTinNhanVienChiTiet = new NhanVien(userId);
                                    ViewData["thongTinNhanVienChiTiet"] = thongTinNhanVienChiTiet;
                                    return View("~/Views/NhanVien/AddValidation.cshtml");

                                }
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

        //GET: /NhanVien/Sua/{id}
        public ActionResult Sua(string id)
        {
            var nhanVienId = HttpContext.Session.GetString("nhanVienId");
            if (nhanVienId != null)
            {
                var nv = new NhanVien(nhanVienId);
                if (nv.isHCNS)
                {
                    ViewData["thongTinNhanVien"] = nv;
                    //get list of TinhThanh
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
                    //get list of PhongBan
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
                    //get list of ChucVu
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

                    var nvct = new NhanVien(id);
                    ViewData["thongTinNhanVienChiTiet"] = nvct;

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
        
        //POST: /Nhanvien/Sua/{id}
        [HttpPost]
        public ActionResult Sua(string id, IFormCollection form)
        {
            var nhanVienId = HttpContext.Session.GetString("nhanVienId");

            if (nhanVienId != null)
            {
                var nv = new NhanVien(nhanVienId);
                
                if (nv.isHCNS == true)
                {
                    var name = form["inputName"].ToString();
                    var birthday = Convert.ToDateTime(form["inputBirthday"]);
                    var gender = form["inputGender"].ToString();
                    var tinhThanh = Convert.ToInt32(form["inputTinhThanh"]);
                    var email = form["inputEmail"].ToString();
                    var phone = form["inputPhone"].ToString();
                    var phongBanId = Convert.ToInt32(form["inputPhongBan"]);
                    var chucVuId = Convert.ToInt32(form["inputChucVu"]);
                    var startDate = Convert.ToDateTime(form["inputStartDate"]);
                    var username = form["inputUsername"].ToString();
                    var status = form["inputStatus"].ToString();
                    using (var connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();
                            var updateNhanVienQuery =
                                @"update NHANVIEN set 
                                    Hoten = @hoten,
                                    Ns = @ns,
                                    Gt = @gt,
                                    Idtinh = @tinh,
                                    Sdt = @sdt,
                                    Idpban = @pban,
                                    Idcv = @cv,
                                    Username = @username,
                                    Email = @email,
                                    Ngayvaolam = @ngayVaoLam,
                                    Trangthai = @status
                                where Idnv = @id;";
                            var sqlCommand = new SqlCommand(updateNhanVienQuery, connection);
                            sqlCommand.Parameters.AddWithValue("@hoten", name);
                            sqlCommand.Parameters.AddWithValue("@ns", birthday);
                            sqlCommand.Parameters.AddWithValue("@gt", gender);
                            sqlCommand.Parameters.AddWithValue("@tinh", tinhThanh);
                            sqlCommand.Parameters.AddWithValue("@sdt", phone);
                            sqlCommand.Parameters.AddWithValue("@pban", phongBanId);
                            sqlCommand.Parameters.AddWithValue("@cv", chucVuId);
                            sqlCommand.Parameters.AddWithValue("@username", username);
                            sqlCommand.Parameters.AddWithValue("@email", email);
                            sqlCommand.Parameters.AddWithValue("@ngayVaoLam", startDate);
                            sqlCommand.Parameters.AddWithValue("@id", id);
                            sqlCommand.Parameters.AddWithValue("@status", status);
                            var result = sqlCommand.ExecuteNonQuery();
                            TempData["Success"] = "Sửa nhân viên thành công.";
                            return RedirectToAction("Danhsach", "Nhanvien");
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
                TempData["Error"] = "Vui lòng đăng nhập";
                return RedirectToAction("Index", "Login");
            }
        }

        //GET: /Nhanvien/Xoa/{id}
        public ActionResult Xoa(string id)
        {
            var nhanVienId = HttpContext.Session.GetString("nhanVienId");

            if (nhanVienId != null)
            {
                var nv = new NhanVien(nhanVienId);
                if (nv.isHCNS)
                {
                    var nvct = new NhanVien(id);
                    ViewData["thongTinNhanVien"] = nv;
                    ViewData["thongTinNhanVienChiTiet"] = nvct;
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
        
        //POST: /Nhanvien/Xoa/{id}
        [HttpPost]
        public ActionResult Xoa(string id, IFormCollection form)
        {
            var nhanVienId = HttpContext.Session.GetString("nhanVienId");
            if (nhanVienId != null)
            {
                var nhanVien = new NhanVien(nhanVienId);
                var nvChiTiet = new NhanVien(id);
                if (nhanVien.isHCNS == true)
                {
                    if(nvChiTiet.Trangthai == "Đang làm")
                    {
                        TempData["Error"] = "Không xóa được vì nhân viên đang làm việc";
                        return RedirectToAction("Danhsach", "Nhanvien");
                    }
                    else
                    {
                        using(var connection = new SqlConnection(connectionString))
                        {
                            try
                            {
                                connection.Open();
                                var deleteNhanVienQuery = @"delete from NHANVIEN where Idnv = @id";
                                var sqlCommand = new SqlCommand(deleteNhanVienQuery, connection);
                                sqlCommand.Parameters.AddWithValue("@id", id);
                                sqlCommand.ExecuteNonQuery();
                                TempData["Success"] = "Xóa thành công";
                                return RedirectToAction("Danhsach", "NhanVien");
                            }
                            catch (Exception)
                            {
                                throw;
                            }
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
                TempData["Error"] = "Vui lòng đăng nhập";
                return RedirectToAction("Index", "Login");
            }
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
                        TempData["Error"] = "Tên đăng nhập hoặc mật khẩu không chính xác.";
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
    }
}