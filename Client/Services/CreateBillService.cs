using Client.Utils;

namespace Client.Services
{
    class CreateBillService : AbstractService
    {
        private string _answer;
        private User _user;

        public override string Answer
        {
            get
            {
                return _answer;
            }
        }

        public CreateBillService(User user)
        {
            _user = user;
            SendMessageToSocket();
            RecieveMessageFromSocket();
        }

        private void RecieveMessageFromSocket()
        {
            _answer = SocketClient.RecieveMessage();
        }

        private void SendMessageToSocket()
        {
            RequestGenerator _requestGenerator = new RequestGenerator(RequestGenerator.RequestCode.newBill, _user.Login);
            SocketClient.SendMessage(_requestGenerator.Message);
        }
    }
}
