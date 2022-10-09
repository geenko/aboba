using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace program
{
    class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            String host = "localhost";
            int port = 3306;
            string database = "railway";
            string user = "root";
            string password = "zqxwec132";

            return DBMySqlUtils.GetDBConnection(host, port, database, user, password);
        }
    }
}
