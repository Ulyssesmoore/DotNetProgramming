using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SuperStore.persistence
{
    class BaseDAO
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
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection !");
            }
            return conn;
        }
    }
}
