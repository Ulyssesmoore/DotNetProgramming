using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SuperStore;

namespace SuperStoreWebservice
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISuperStoreService" in both code and config file together.
    [ServiceContract]
    public interface ISuperStoreService
    {
        [OperationContract]
        DateTime GetAllCustomers();

        [OperationContract]
        int Add(int x, int y);
    }
}
