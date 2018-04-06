using System;
using Client.Utils;
using System.Text;
using System.Security.Cryptography;

/**
 * Service for send and recieve registration message to/from Server
 * 
 * sending String message[ name, surname, birthDate, login, password]
 * 
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
            _userInput[4] = CalculateHash(input[4]);
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
