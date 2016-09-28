using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfClient
{
    class MyCallback : WcfServer.IMyCallback
    {
        public void SendData(string text)
        {
            Console.WriteLine(text);
        }
    }
}
