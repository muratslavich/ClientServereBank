using Client.Utils;

/**
 * Service for send and recieve registration message to/from Server
 * 
 * sending String message[2, name, surname, birthDate, login, password]
 * 
 * recieve int answer[5 || 4 || 1 ||]
 * 5-reg error
 * 4-existing login error
 * 1-registration complete
 * 0-uncorrect answer
 * 
 * constructor(String[] input[], sender)
 * */

namespace Client.Services
{
    class RegistrationService : AbstractService
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

        public RegistrationService(string[] input)
        {
            _userInput = input;
            SendMessageToSocket();
            RecieveMessageFromSocket();
        }

        private void RecieveMessageFromSocket()
        {
            _answer = SocketClient.RecieveMessage();
        }

        private void SendMessageToSocket()
        {
            RequestGenerator _requestGenerator = new RequestGenerator(RequestGenerator.RequestCode.reg, _userInput);
            SocketClient.SendMessage(_requestGenerator.Message);
        }
    }
}
