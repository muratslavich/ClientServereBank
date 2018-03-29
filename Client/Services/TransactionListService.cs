using Client;
using Client.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client.Services
{
    class TransactionListService : AbstractService<List<Transaction>>
    {
        private int _billId;
        private Socket _sender;
        private RequestGenerator _requestGenerator;
        private ResponseHandler _responseHandler;
        private List<Transaction> _answer;

        public override List<Transaction> Answer
        {
            get
            {
                return _answer;
            }
        }

        public TransactionListService(Bill bill, Socket sender)
        {
            _billId = bill.IdBill;
            _sender = sender;
        }

        public override void RecieveMessageFromSocket()
        {
            string answer = SocketClient.RecieveMessage(_sender);
            _responseHandler = new ResponseHandler();

            List<string> transactionList = _responseHandler.ResposeHandlerToList(answer);
            _answer = _responseHandler.ResponseHandlerToTransaction(transactionList);
        }

        public override void SendMessageToSocket()
        {
            _requestGenerator = new RequestGenerator();
            string requestToServer = _requestGenerator.GenerateRequest((int)RequestGenerator.RequestCode.transactionList, _billId);
            byte[] msg = Encoding.ASCII.GetBytes(requestToServer);
            SocketClient.SendMessage(_sender, msg);
        }
    }
}
