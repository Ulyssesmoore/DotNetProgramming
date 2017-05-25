using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SuperStore.persistence;

namespace SuperStoreWebService2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProductService" in both code and config file together.
    public class ProductService : BaseDAO, IProductService
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
