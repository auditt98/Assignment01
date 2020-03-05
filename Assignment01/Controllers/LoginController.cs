using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment01.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            var nhanVienId = HttpContext.Session.GetString("nhanVienId");

            if (nhanVienId != null)
            {
                return RedirectToAction("Index", "Nhanvien", new { id = nhanVienId });
            }
            else
            {
                return View();

            }

        }

        public bool isLoggedIn(string id, int isSamePerson)
        {
            string nhanVienId = HttpContext.Session.GetString("nhanVienId");
            if (isSamePerson == 0)
            {
                if (nhanVienId != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                if (nhanVienId != null)
                {
                    if (nhanVienId == id)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

    }
}