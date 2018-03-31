using Client.Utils;

namespace Client.Services
{
    class CreateBillService : AbstractService
    {
        private string _answer;
        private string _user;

        public override string Answer
        {
            get
            {
                return _answer;
            }
        }

        public CreateBillService(string login)
        {
            _user = login;
            SendMessageToSocket();
            RecieveMessageFromSocket();
        }

        private void RecieveMessageFromSocket()
        {
            _answer = SocketClient.RecieveMessage();
        }

        private void SendMessageToSocket()
        {
            RequestGenerator _requestGenerator = new RequestGenerator(RequestGenerator.RequestCode.newBill, _user);
            SocketClient.SendMessage(_requestGenerator.Message);
        }
    }
}
