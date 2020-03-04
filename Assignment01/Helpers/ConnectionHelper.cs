using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment01.Helpers
{
    public class ConnectionHelper
    {
        private string connectionString;

        public ConnectionHelper()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["QLNS"].ConnectionString;
        }
        public string getConnectionString()
        {
            return this.connectionString;
        }
    }
}
