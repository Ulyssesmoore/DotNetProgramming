using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SuperStore.persistence;

namespace SuperStoreWebService2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICustomerService" in both code and config file together.
    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
        IEnumerable<Product> GetOwnedProducts(string name);

        [OperationContract]
        IEnumerable<Customer> GetAllCustomers();

        [OperationContract]
        void CreateCustomer(Customer newCustomer);

    }
    [DataContract]
    public class Customer
    {
        int id;
        string name;
        string password;
        double budget;

        public Customer(string name, string password, double budget)
        {
            this.name = name;
            this.password = password;
            this.budget = budget;
        }

        public Customer(int id, string name, string password, double budget)
        {
            this.id = id;
            this.name = name;
            this.password = password;
            this.budget = budget;
        }

        public override string ToString()
        {
            return name + " with budget " + password + "\n";
        }

        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        [DataMember]
        public double Budget
        {
            get { return budget; }
            set { budget = value; }
        }

    }
}
