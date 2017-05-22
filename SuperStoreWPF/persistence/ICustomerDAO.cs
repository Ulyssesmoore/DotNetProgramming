using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperStore.model;

namespace SuperStore.persistence
{
    interface ICustomerDAO
    {
//      Registers a new customer
        void CreateCustomer(Customer newCustomer);

//      Gets all existing customers from the database
        IEnumerable<Customer> GetAllCustomers();

        IEnumerable<Product> GetOwnedProducts(string name);
    }
}
