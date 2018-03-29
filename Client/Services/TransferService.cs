using Client.Utils;

namespace Client.Services
{
    class TransferService : AbstractService
    {
        private string[] _userInput;
        private string _answer;

        public override string Answer
        {
            get
            {
                return _answer;
            }
        }

        public TransferService(string[] userInput)
        {
            _userInput = userInput;
            SendMessageToSocket();
            RecieveMessageFromSocket();
        }

        private void RecieveMessageFromSocket()
        {
            _answer = SocketClient.RecieveMessage();
        }

        private void SendMessageToSocket()
        {
            RequestGenerator _requestGenerator = new RequestGenerator(RequestGenerator.RequestCode.transfer, _userInput);
            SocketClient.SendMessage(_requestGenerator.Message);
        }
    }
}
