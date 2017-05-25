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

        public void HandleTransaction(Dictionary<Product, int> transactionDetails, Customer buyer, double transactionAmount)
        {
            var conn = GetConnection();
            var comm = conn.CreateCommand();
            comm.CommandText = "UPDATE customers SET budget = (budget + ?transactionValue) where customerid = ?id";
            comm.Parameters.AddWithValue("?transactionValue", transactionAmount);
            comm.Parameters.AddWithValue("?id", buyer.Id);
            comm.ExecuteNonQuery();
            foreach (KeyValuePair<Product, int> entry in transactionDetails)
            {
                comm.CommandText =
                    "update storages set amount_stored = (amount_stored - " + Convert.ToString(entry.Value) + ") where productid = " + Convert.ToString(entry.Key.Productid);
                comm.ExecuteNonQuery();
            }
            string sql = "INSERT INTO owned_products(customerid, productid) VALUES ";
            foreach (KeyValuePair<Product, int> entry in transactionDetails)
            {
                for (int i = 0; i < entry.Value; i++)
                {
                    sql += "(" + Convert.ToString(buyer.Id) + ", " + Convert.ToString(entry.Key.Productid) + "),";
                }
            }
            sql = sql.Remove(sql.Length - 1, 1) + ";";
            comm.CommandText = sql;
            comm.ExecuteNonQuery();
        }
    }
}
