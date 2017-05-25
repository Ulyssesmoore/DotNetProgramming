using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using SuperStore.persistence;

namespace SuperStore.model
{
    public class Store
    {
        private IEnumerable<Customer> customerList;
        private Dictionary<Product, int> stock;

        public Store()
        {
            customerList = GetCustomers();
        }

        public bool AddCustomer(string name, string password)
        {
            var b = customerList.Any(c => c.Name == name);
            if (b) return b;
            var r = new Random();
            var newCustomer = new Customer(name, EncryptPassword(password), r.Next(5, 20));
            ICustomerDAO icdao = new CustomerDAO();
            icdao.CreateCustomer(newCustomer);
            customerList = GetCustomers();
            return b;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            ICustomerDAO icdao = new CustomerDAO();
            return icdao.GetAllCustomers();
        }

        public Customer CheckLogin(string name, string password)
        {
            Customer customer = null;
            foreach (var c in customerList)
            {
                if (c.Name == name && c.Password == EncryptPassword(password))
                {
                    customer = c;
                }
            }
            return customer;
        }

        private static string EncryptPassword(string input)
        {
            byte[] data = Encoding.ASCII.GetBytes(input);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            return Encoding.ASCII.GetString(data);
        }

        public Dictionary<Product, int> GetStock()
        {
            IStoreDAO isdao = new StoreDAO();
            return isdao.GetStock();
        }

        public void Restock()
        {
        }
    }
}
