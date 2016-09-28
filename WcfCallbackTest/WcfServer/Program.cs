using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---");
            Console.ReadLine();
            using (var host = new ServiceHost(typeof(MyService)))
            {
                host.Open();
                Console.WriteLine("START");
                Console.ReadLine();
                host.Close();
            }
        }
    }
}
