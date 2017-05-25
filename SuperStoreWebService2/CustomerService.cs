using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SuperStore.persistence;

namespace SuperStoreWebService2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CustomerService" in both code and config file together.
    public class CustomerService : BaseDAO, ICustomerService
    {
        public IEnumerable<Product> GetOwnedProducts(string name)
        {
            var conn = GetConnection();
            var comm = conn.CreateCommand();
            comm.CommandText = "SELECT count(op.entryid) as \"amount_owned\", p.name, p.price FROM owned_products op, products p WHERE op.customerid = (SELECT customerid FROM customers WHERE name = ?name) AND op.productid = p.productid group by p.name";
            comm.Parameters.AddWithValue("?name", name);
            var reader = comm.ExecuteReader();
            while (reader.Read() && reader["name"] != DBNull.Value)
            {
                yield return new Product(reader.GetString("name"), reader.GetDouble("price"), reader.GetInt32("amount_owned"));
            }
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            var conn = GetConnection();
            var comm = conn.CreateCommand();
            comm.CommandText = "SELECT customerid, name, password, budget FROM customers";
            var reader = comm.ExecuteReader();
            while (reader.Read())
            {
                yield return new Customer(reader.GetInt32("customerid"), reader.GetString("name"), reader.GetString("password"),
                    reader.GetDouble("budget"));
            }
        }

        public void CreateCustomer(Customer newCustomer)
        {
            var conn = GetConnection();
            var comm = conn.CreateCommand();
            comm.CommandText = "INSERT INTO customers(name, password, budget) values(?name, ?password, ?budget)";
            comm.Parameters.AddWithValue("?name", newCustomer.Name);
            comm.Parameters.AddWithValue("?password", newCustomer.Password);
            comm.Parameters.AddWithValue("?budget", newCustomer.Budget);
            comm.ExecuteNonQuery();
            conn.Close();
        }
    }
}
