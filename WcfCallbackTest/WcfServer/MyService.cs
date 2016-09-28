using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfServer
{
    class MyService : IMyService
    {
        static ConcurrentDictionary<string, IMyCallback> _clients = new ConcurrentDictionary<string, IMyCallback>();

        public string Name { get; private set; }

        public int Regist(string name)
        {
            Console.WriteLine($"regist {name}");

            Name = name;

            var myCallback = OperationContext.Current.GetCallbackChannel<IMyCallback>();
            _clients.AddOrUpdate(name, myCallback, (key, value) => myCallback);

            var welcome = $"welcome {name}.";
            var message = $"login {name}.";
            foreach (var item in _clients)
            {
                item.Value.SendData(item.Key == name ? welcome : message);
            }
            return 1;
        }

        public int Say(string message)
        {
            Console.WriteLine($"say[{Name}] {message}");
            var response = $"{Name}> {message}";
            foreach (var item in _clients)
            {
                try
                {
                    item.Value.SendData(response);
                }
                catch (CommunicationObjectAbortedException ex)
                {
                    Console.WriteLine(ex.Message);
                    IMyCallback removeObj;
                    Console.WriteLine($"remove {_clients.TryRemove(item.Key, out removeObj)}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return 2;
        }

        public int SayTo(string name, string message)
        {
            Console.WriteLine($"{Name} to {name}: {message}");
            foreach (var item in _clients)
            {
                if (item.Key == Name || item.Key == name)
                {
                    item.Value.SendData($"{Name}->{name}: {message}");
                }
            }
            return 3;
        }
    }
}
