using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Client;
using Client.Utils;

namespace Client.Services
{
    class TransferService : AbstractService<int>
    {
        private string[] _train;
        private Socket _sender;
        private int _answer;

        public TransferService(string[] train, Socket sender)
        {
            _train = train;
            _sender = sender;
        }

        public override int Answer
        {
            get
            {
                return _answer;
            }
        }

        public override void RecieveMessageFromSocket()
        {
            string answer = SocketClient.RecieveMessage(_sender);
            int.TryParse(answer, out _answer);
        }

        public override void SendMessageToSocket()
        {
            RequestGenerator request = new RequestGenerator();
            string requestToServer = request.GenerateRequest((int)RequestGenerator.RequestCode.transfer, _train);
            byte[] msg = Encoding.ASCII.GetBytes(requestToServer);
            SocketClient.SendMessage(_sender, msg);
        }
    }
}
