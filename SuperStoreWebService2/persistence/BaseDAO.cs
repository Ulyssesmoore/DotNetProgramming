using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SuperStore.persistence
{
    public class BaseDAO
    {
        public static MySqlConnection GetConnection()
        {
            MySqlConnection conn = null;
            try
            {
                MySqlConnectionStringBuilder mssb = new MySqlConnectionStringBuilder()
                {
                    Server = "localhost",
                    UserID = "root",
                    Password = "",
                    Database = "superstore"
                };
                conn = new MySqlConnection(mssb.ConnectionString);
                conn.Open();
            }
            catch(Exception ex)
            {
                Debug.Write(ex);
            }
            return conn;
        }
    }
}
