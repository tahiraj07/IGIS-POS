using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace TestProject
{
    class databaza_con
    {
        public string Connection()
        {
            string con = @"Data Source=.;Initial Catalog=databaza;Integrated Security=True";
            return con;
        }
    }
}
