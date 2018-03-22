using Client;
using System;
using System.Net.Sockets;
using System.Text;

/**
 * Service for send and recieve Auth message to/from Server
 * 
 * sending String message[1,login,password]
 * 
 * recieve String answer[1 || 2 || 3, login]
 * 1-complete auth
 * 2-login error
 * 3-password error
 * 
 * constructor(String[] input[login, password], sender)
 * */

namespace BankClientServer.Services
{
    class AuthService : AbstractHandler<string[]>
    {
        private string[] _input;
        private string[] _answer;
        private RequestGenerator _requestGenerator;
        private ResponseHandler _responseHandler;
        private Socket _sender;

        public override string[] Answer
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
            _responseHandler = new ResponseHandler();
            _responseHandler.ResponseHandlerToArray(answer);
            _answer = _responseHandler.Answer;
            if (int.Parse(_answer[0]) == 2)
            {
                throw new InvalidOperationException("Неверный логин " + _answer[1]);
            }
            if (int.Parse(_answer[0]) == 3)
            {
                throw new InvalidOperationException("Неверный пароль");
            }
            if (int.Parse(_answer[0]) == 1)
            {
                Console.WriteLine("Вход выполнен " + _answer[1]);
            }
            else
            {
                throw new InvalidOperationException("Неизвестный ответ от сервера");
            }
        }
    }
}
