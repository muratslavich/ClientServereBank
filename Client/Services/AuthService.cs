using Client;
using Client.Utils;
using System;
using System.Net.Sockets;
using System.Text;

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
            String answer = SocketClient.RecieveMessage(SocketClient._sender);
            if (answer.IndexOf("<0x>") > -1) _answer = "Error";
            else _answer = answer;
        }
    }
}
