using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var cb = new MyCallback();
            var client = new MyService(new InstanceContext(cb));
            string line = Console.ReadLine();
            Console.WriteLine($"REGIST:{client.Regist(line)}");
            do
            {
                line = Console.ReadLine();
                var i = line.IndexOf('>');
                if (i > 0)
                {
                    var message = line.Substring(0, i);
                    var to = line.Substring(i + 1);
                    Console.WriteLine($"SAYTO:{client.SayTo(to, message)}");
                }
                else
                {
                    Console.WriteLine($"SAY:{client.Say(line)}");
                }
            } while (line != "q");
        }
    }
}
