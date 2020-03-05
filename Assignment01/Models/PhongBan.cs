using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Assignment01.Helpers;

namespace Assignment01.Models
{
    public class PhongBan
    {
        public int Idpban { get; set; }
        public string Tenpban { get; set; }
        public PhongBan(int id, string ten)
        {
            this.Idpban = id;
            this.Tenpban = ten;
        }
    }
}
