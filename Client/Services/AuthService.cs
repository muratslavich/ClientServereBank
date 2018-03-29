using Client.Utils;

/**
 * Service for send and recieve Auth message to/from Server
 * 
 * constructor(String[] input[login, password], sender)
 * */

namespace Client.Services
{
    class AuthService : AbstractService
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

        public AuthService(string[] userInput)
        {
            _userInput = userInput;
            SendMessageToSocket();
            RecieveMessageFromSocket();
        }

        private void SendMessageToSocket()
        {
            RequestGenerator _requestGenerator = new RequestGenerator(RequestGenerator.RequestCode.auth, _userInput);
            SocketClient.SendMessage(_requestGenerator.Message);
        }

        private void RecieveMessageFromSocket()
        {
            _answer = SocketClient.RecieveMessage();
        }
    }
}
