using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SuperStoreWebService2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProductService" in both code and config file together.
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        IEnumerable<Product> GetAllProducts();

        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "SuperStoreWebService2.ContractType".
    [DataContract]
    public class Product
    {
        int productid;
        string name;
        double price;
        int amountOwned;

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

        [DataMember]
        public int Productid
        { 
            get { return productid; }
            set { productid = value; }
        }

        [DataMember]
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        [DataMember]
        public int AmountOwned
        {
            get { return amountOwned; }
            set { amountOwned = value; }
        }
    }
}
