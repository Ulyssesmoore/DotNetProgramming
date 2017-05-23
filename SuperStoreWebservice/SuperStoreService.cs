using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SuperStoreWebservice
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SuperStoreService" in both code and config file together.
    public class SuperStoreService : ISuperStoreService
    {
        public DateTime GetDate()
        {
            return DateTime.Now;
        }

        public int Add(int x, int y)
        {
            return x + y;
        }
    }
}
