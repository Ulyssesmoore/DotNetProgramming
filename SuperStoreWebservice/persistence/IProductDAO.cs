using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperStore.model;

namespace SuperStore.persistence
{
    interface IProductDAO
    {
        IEnumerable<Product> GetAllProducts();
    }
}
