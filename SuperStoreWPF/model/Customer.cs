using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperStore.model;
using SuperStore.persistence;

namespace SuperStore
{
    public class Customer
    {
        private string name;
        private string password;
        private double budget;

        public Customer(string name, string password, double budget)
        {
            this.name = name;
            this.password = password;
            this.budget = budget;
        }

        public IEnumerable<Product> GetOwnedProducts()
        {
            ICustomerDAO icdao = new CustomerDAO();
            return icdao.GetOwnedProducts(name);
        }

        public override string ToString()
        {
            return name + " with budget " + password + "\n";
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public double Budget
        {
            get { return budget; }
            set { budget = value; }
        }
        
    }
}
