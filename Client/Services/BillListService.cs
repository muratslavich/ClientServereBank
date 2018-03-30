using Client.Utils;

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
    class BillListService : AbstractService
    {
        private string _answer;
        private string _login;

        public override string Answer 
        {
            get
            {
                return _answer;
            }
        }

        public BillListService(string login)
        {
            _login = login;
            SendMessageToSocket();
            RecieveMessageFromSocket();
        }

        private void SendMessageToSocket()
        {
            RequestGenerator _requestGenerator = new RequestGenerator(RequestGenerator.RequestCode.newBill, _login);
            SocketClient.SendMessage(_requestGenerator.Message);
        }

        private void RecieveMessageFromSocket()
        {
            _answer = SocketClient.RecieveMessage();
        }
    }
}
