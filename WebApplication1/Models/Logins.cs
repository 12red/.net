using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Logins
    {

        public int id { set; get; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
