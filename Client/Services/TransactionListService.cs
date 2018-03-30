using Client.Utils;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Client.Services
{
    class TransactionListService : AbstractService
    {
        private string _answer;
        private string _idBill;

        public override string Answer
        {
            get
            {
                return _answer;
            }
        }

        public TransactionListService(string idBill)
        {
            _idBill = idBill;
            SendMessageToSocket();
            RecieveMessageFromSocket();
        }

        private void RecieveMessageFromSocket()
        {
            _answer = SocketClient.RecieveMessage();
        }

        private void SendMessageToSocket()
        {
            RequestGenerator _requestGenerator = new RequestGenerator(RequestGenerator.RequestCode.newBill, _idBill);
            SocketClient.SendMessage(_requestGenerator.Message);
        }
    }
}
