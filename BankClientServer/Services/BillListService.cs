using Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

/**
 * Service for send and recieve BillList query message to/from Server
 * 
 * sending String message[3, login]
 * 
 * recieve List<String[idBill, amount]> || List<String[0]>
 * output recieve list to Console line-by-line
 * 0-no bills
 * 
 * constructor(user, sender)
 * */

namespace BankClientServer.Services
{
    class BillListService : ClientInputHandler<List<String>>
    {
        private String _userLogin;
        private List<String> _answer;
        private Socket _sender;
        private RequestGenerator _requestGenerator;
        private ResponseHandler _responseHandler;

        public override List<string> Answer { get => _answer; }

        public BillListService(User user, Socket sender)
        {
            _userLogin = user.Login;
            _sender = sender;
        }

        public override void SendMessageToSocket()
        {
            _requestGenerator = new RequestGenerator();
            String requestToServer = _requestGenerator.GenerateRequest((int)RequestGenerator.RequestCode.billList, _userLogin);
            byte[] msg = Encoding.ASCII.GetBytes(requestToServer);
            SocketClient.SendMessage(_sender, msg);
        }

        public override void RecieveMessageFromSocket()
        {
            String answer = SocketClient.RecieveMessage(_sender);
            _responseHandler = new ResponseHandler();
            _responseHandler.ResposeHandlerToList(answer);
            _answer = _responseHandler.AnswerList;

            if (_answer.Count == 0)
            {
                throw new InvalidOperationException("Нет открытых счетов");
            }
        }
    }
}
