using Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BankClientServer.Services
{
    class AuthService : ClientInputHandler
    {
        private string[] _input;
        private RequestGenerator _requestGenerator = new RequestGenerator();
        private Socket _sender;

        public AuthService(string[] input, Socket sender)
        {
            _input = input;
            _sender = sender;
        }

        public override void SendMessageToSocket()
        {
            String requestToServer = _requestGenerator.GenerateRequest((int)RequestGenerator.RequestCode.auth, _input);
            byte[] msg = Encoding.ASCII.GetBytes(requestToServer);
            SocketClient.SendMessage(_sender, msg);
        }
    }
}
