using Client;
using Client.Utils;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

/**
 * Service for send and recieve BillList query message to/from Server
 * 
 * sending String message[3, login]
 * 
 * recieve List<String[idBill, amount]>
 * output recieve list to Console line-by-line
 * 
 * constructor(user, sender)
 * */

namespace Client.Services
{
    class BillListService : AbstractHandler<List<Bill>>
    {
        private string _userLogin;
        private List<Bill> _answer;
        private Socket _sender;
        private RequestGenerator _requestGenerator;
        private ResponseHandler _responseHandler;

        public override List<Bill> Answer
        {
            get
            {
                return _answer;
            }
        }

        public BillListService(User user, Socket sender)
        {
            _userLogin = user.Login;
            _sender = sender;
        }

        public override void SendMessageToSocket()
        {
            _requestGenerator = new RequestGenerator();
            string requestToServer = _requestGenerator.GenerateRequest((int)RequestGenerator.RequestCode.billList, _userLogin);
            byte[] msg = Encoding.ASCII.GetBytes(requestToServer);
            SocketClient.SendMessage(_sender, msg);
        }

        public override void RecieveMessageFromSocket()
        {
            string answer = SocketClient.RecieveMessage(_sender);
            _responseHandler = new ResponseHandler();

            List<string> billList = _responseHandler.ResposeHandlerToList(answer);
            _responseHandler.ResponseHandlerListToBill(billList);
            _answer = _responseHandler.AnswerList;
        }
    }
}
