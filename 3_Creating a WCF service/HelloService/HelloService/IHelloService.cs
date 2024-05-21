using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HelloService
{
    [ServiceContract]
    public interface IHelloServiceChanged
    {
        [OperationContract]
        string GetMessage(string name);
    }
}