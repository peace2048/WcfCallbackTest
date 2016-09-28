using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfServer
{
    interface IMyCallback
    {
        [OperationContract(IsOneWay = true)]
        void SendData(string text);
    }
}
