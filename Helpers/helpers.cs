using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace musicP.Helpers
{
    public class DBUtils
    {
        public static SqlConnection getConnection()
        {
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection("Data Source=DESKTOP-0NKNS8C\\MUSICSERVERSQL;Initial Catalog=Music;Integrated Security=True");
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error connecting to database " + ex.Message);
            }

            return conn;
        }
    }
}