using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Client;

namespace BankClientServer.Services
{
    class CreateBillService : AbstractHandler<Bill>
    {
        private User _user;
        private Socket _sender;
        private Bill _answer;

        public override Bill Answer
        {
            get
            {
                return _answer;
            }
        }

        public CreateBillService(User user, Socket sender)
        {
            _user = user;
            _sender = sender;
        }

        public override void RecieveMessageFromSocket()
        {
            string answer = SocketClient.RecieveMessage(_sender);
            ResponseHandler responseHandler = new ResponseHandler();
            _answer = responseHandler.ResponseHandlerToBill(answer);
            Console.WriteLine("Создан новый счет ... ");
            Console.WriteLine(_answer.ToString());
            Console.ReadLine();
        }

        public override void SendMessageToSocket()
        {
            RequestGenerator requestGenerator = new RequestGenerator();
            string requestToServer = requestGenerator.GenerateRequest((int)RequestGenerator.RequestCode.newBill, _user.Login);
            byte[] msg = Encoding.ASCII.GetBytes(requestToServer);
            SocketClient.SendMessage(_sender, msg);
        }
    }
}
