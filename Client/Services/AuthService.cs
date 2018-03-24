using Client;
using Client.Utils;
using System;
using System.Net.Sockets;
using System.Text;

/**
 * Service for send and recieve Auth message to/from Server
 * 
 * sending String message[1,login,password]
 * 
 * recieve int answer[0 || 1 || 2 || 3]
 * 1-complete auth
 * 2-login error
 * 3-password error
 * 0-answer error
 * 
 * constructor(String[] input[login, password], sender)
 * */

namespace Client.Services
{
    class AuthService : AbstractHandler<int>
    {
        private string[] _input;
        private int _answer;
        private RequestGenerator _requestGenerator;
        private ResponseHandler _responseHandler;
        private Socket _sender;

        public override int Answer
        {
            get
            {
                return _answer;
            }
        }

        public AuthService(string[] input, Socket sender)
        {
            _input = input;
            _sender = sender;
        }

        public override void SendMessageToSocket()
        {
            _requestGenerator = new RequestGenerator();
            string requestToServer = _requestGenerator.GenerateRequest((int)RequestGenerator.RequestCode.auth, _input);
            byte[] msg = Encoding.ASCII.GetBytes(requestToServer);
            SocketClient.SendMessage(_sender, msg);
        }

        public override void RecieveMessageFromSocket()
        {
            string answer = SocketClient.RecieveMessage(_sender);
            int.TryParse(answer, out _answer);
        }
    }
}
