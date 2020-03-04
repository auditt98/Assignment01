using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Assignment01.Helpers
{
    public class LoginHelper
    {
        private readonly IHttpContextAccessor http;
        private ISession session => http.HttpContext.Session;
        public LoginHelper(IHttpContextAccessor httpAccessor)
        {
            this.http = httpAccessor;
        }

        public bool isLoggedIn()
        {
            if(session.GetString("nhanVienId") != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
