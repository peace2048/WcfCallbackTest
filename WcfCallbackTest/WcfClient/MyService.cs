using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfClient
{
    class MyService : DuplexClientBase<WcfServer.IMyService>, WcfServer.IMyService
    {
        public MyService(InstanceContext callbackInstance) : base(callbackInstance) { }

        public int Regist(string name)
        {
            return Channel.Regist(name);
        }

        public int Say(string message)
        {
            return Channel.Say(message);
        }

        public int SayTo(string name, string message)
        {
            return Channel.SayTo(name, message);
        }
    }
}
