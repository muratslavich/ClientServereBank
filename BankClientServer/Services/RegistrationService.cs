using Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

/**
 * Service for send and recieve registration message to/from Server
 * 
 * sending String message[2, name, surname, birthDate, login, password]
 * 
 * recieve String answer[1 || 2, login]
 * 1-complete reg
 * 2-reg error
 * 
 * constructor(String[] input[], sender)
 * */

namespace BankClientServer.Services
{
    class RegistrationService : AbstractHandler<string[]>
    {
        private string[] _answer;
        private string[] _input;
        private Socket _sender;
        private RequestGenerator _requestGenerator;
        private ResponseHandler _responseHandler;

        public override string[] Answer
        {
            get { return _answer; }
        }

        public RegistrationService(string[] input, Socket sender)
        {
            _input = input;
            _sender = sender;
        }

        public override void RecieveMessageFromSocket()
        {
            string answer = SocketClient.RecieveMessage(_sender);
            _responseHandler = new ResponseHandler();
            _responseHandler.ResponseHandlerToArray(answer);
            _answer = _responseHandler.Answer;
            if (int.Parse(_answer[0]) == 2)
            {
                throw new InvalidOperationException("Ошибка регистрации " + _answer[1]);
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

        public override void SendMessageToSocket()
        {
            _requestGenerator = new RequestGenerator();
            string requestToServer = _requestGenerator.GenerateRequest((int)RequestGenerator.RequestCode.reg, _input);
            byte[] msg = Encoding.ASCII.GetBytes(requestToServer);
            SocketClient.SendMessage(_sender, msg);
        }
    }
}
