using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
    abstract class ClientInputHandler
    {
        public abstract void SendMessageToSocket();
    }
}