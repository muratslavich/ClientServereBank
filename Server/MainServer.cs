using Bank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class MainServer
    {
        static void Main(string[] args)
        {
            SocketServer.StartListening();
        }
    }
}
