using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SuperStoreWebService2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IStoreService" in both code and config file together.
    [ServiceContract]
    public interface IStoreService
    {
        [OperationContract]
        Dictionary<Product, int> GetStock();

        [OperationContract]
        void HandleTransaction(Dictionary<Product, int> transactionDetails, SuperStoreWebService2.Customer buyer,
            double transactionAmount);

        [OperationContract]
        void AddProductToDatabase(Product p);
    }

    [DataContract]
    public class Store
    {
        IEnumerable<Customer> customerList;
        Dictionary<Product, int> stock;

        public Store()
        {
            customerList = GetCustomers();
            IStoreService iss = new StoreService();
            stock = iss.GetStock();
        }

        public bool AddCustomer(string name, string password)
        {
            var b = customerList.Any(c => c.Name == name);
            if (b) return b;
            var r = new Random();
            var newCustomer = new Customer(name, EncryptPassword(password), r.Next(5, 20));
            ICustomerService ics = new CustomerService();
            ics.CreateCustomer(newCustomer);
            customerList = GetCustomers();
            return b;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            ICustomerService ics = new CustomerService();
            return ics.GetAllCustomers();
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

        public static string EncryptPassword(string input)
        {
            byte[] data = Encoding.ASCII.GetBytes(input);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            return Encoding.ASCII.GetString(data);
        }

        [DataMember]
        public Dictionary<Product, int> Stock
        {
            get { return stock; }
            set { stock = value; }
        }

        public void Restock()
        {
        }
    }
}
