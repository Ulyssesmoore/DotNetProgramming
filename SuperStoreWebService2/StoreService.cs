using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SuperStore.persistence;

namespace SuperStoreWebService2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StoreService" in both code and config file together.
    public class StoreService : BaseDAO, IStoreService
    {
        public Dictionary<Product, int> GetStock()
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

        public void HandleTransaction(Dictionary<Product, int> transactionDetails, SuperStoreWebService2.Customer buyer, double transactionAmount)
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

        public void AddProductToDatabase(Product p)
        {
            var conn = GetConnection();
            var comm = conn.CreateCommand();
            comm.CommandText = "INSERT INTO products(name, price) VALUES (?name, ?price)";
            comm.Parameters.AddWithValue("?name", p.Name);
            comm.Parameters.AddWithValue("?price", p.Price);
            comm.ExecuteNonQuery();
            comm.CommandText = "INSERT INTO storages(productid, amount_stored) VALUES((SELECT productid FROM products WHERE name = ?pname), ?amount)";
            comm.Parameters.AddWithValue("?pname", p.Name);
            comm.Parameters.AddWithValue("?amount", p.AmountOwned);
            comm.ExecuteNonQuery();
        }
    }
}
