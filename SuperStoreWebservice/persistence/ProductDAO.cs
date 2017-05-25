using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SuperStore.model;

namespace SuperStore.persistence
{
    class ProductDAO : BaseDAO, IProductDAO
    {
        public IEnumerable<Product> GetAllProducts()
        {
            var conn = GetConnection();
            var comm = conn.CreateCommand();
            comm.CommandText = "SELECT productid, name, price FROM products";
            var reader = comm.ExecuteReader();
            while (reader.Read())
            {
                yield return new Product(reader.GetInt32("productid"), reader.GetString("name"), reader.GetDouble("price"));
            }
        }
    }
}
