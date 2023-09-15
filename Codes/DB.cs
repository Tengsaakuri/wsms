using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WSMS.Codes
{
    public class DB
    {
        private static readonly string connectionString = "Data Source=TIERON-PC\\SQLEXPRESS;Initial Catalog=Water_DB;Integrated Security=True";

        public static SqlConnection Con()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
