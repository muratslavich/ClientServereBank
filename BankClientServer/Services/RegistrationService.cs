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
 * recieve int answer[5 || 4 || 1 ||]
 * 5-reg error
 * 4-existing login error
 * 1-registration complete
 * 0-uncorrect answer
 * 
 * constructor(String[] input[], sender)
 * */

namespace BankClientServer.Services
{
    class RegistrationService : AbstractHandler<int>
    {
        private int _answer;
        private string[] _input;
        private Socket _sender;
        private RequestGenerator _requestGenerator;

        public override int Answer
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
            int.TryParse(answer, out _answer);
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
