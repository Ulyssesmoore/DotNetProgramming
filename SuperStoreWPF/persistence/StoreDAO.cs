using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperStore.model;

namespace SuperStore.persistence
{
    class StoreDAO : BaseDAO, IStoreDAO
    {
        public Dictionary<Product,int> GetStock()
        {
            var stock = new Dictionary<Product, int>();
            var conn = GetConnection();
            var comm = conn.CreateCommand();
            comm.CommandText = "SELECT p.productid, p.name, p.price, s.amount_stored FROM products p, storages s WHERE p.productid = s.productid";
            var reader = comm.ExecuteReader();
            while (reader.Read())
            {
                stock.Add(new Product(reader.GetInt32("productid"), reader.GetString("name"), reader.GetDouble("price")),
                    reader.GetInt32("amount_stored"));
            }
            return stock;
        }
    }
}
