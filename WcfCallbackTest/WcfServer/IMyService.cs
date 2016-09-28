using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfServer
{
    [ServiceContract(CallbackContract =typeof(IMyCallback))]
    interface IMyService
    {
        [OperationContract()]
        int Regist(string name);
        [OperationContract()]
        int Say(string message);
        [OperationContract()]
        int SayTo(string name, string message);
    }
}
