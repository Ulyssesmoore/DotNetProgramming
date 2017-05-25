using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperStore.model
{
    public class Product
    {
        private int productid;
        private string name;
        private double price;
        private int amountOwned;

        public Product(int productid, string name, double price)
        {
            this.productid = productid;
            this.name = name;
            this.price = price;
        }

        public Product(string name, double price, int amountOwned)
        {
            this.name = name;
            this.price = price;
            this.amountOwned = amountOwned;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public int AmountOwned
        {
            get { return amountOwned; }
            set { amountOwned = value; }
        }

        public int Productid
        {
            get { return productid; }
            set { productid = value; }
        }

        public override string ToString()
        {
            return name + " with price " + price;
        }
    }
}
