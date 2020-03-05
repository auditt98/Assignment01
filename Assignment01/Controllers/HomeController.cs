using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Assignment01.Models;
using Microsoft.AspNetCore.Http;

namespace Assignment01.Controllers
{
    public class HomeController : Controller
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
                return RedirectToAction("Index", "Login");
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
