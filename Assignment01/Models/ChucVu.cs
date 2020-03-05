using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Assignment01.Helpers;

namespace Assignment01.Models
{
    public class ChucVu
    {
        public int Idcv { get; set; }
        public string Tencv { get; set; }
        public ChucVu() { }

        public ChucVu(int id, string ten)
        {
            this.Idcv = id;
            this.Tencv = ten;
        }


    }

}
