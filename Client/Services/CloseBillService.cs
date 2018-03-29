﻿using Client;
using Client.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client.Services
{
    class CloseBillService : AbstractService<int>
    {
        private int _billId;
        private Socket _sender;
        private int _answer;

        public override int Answer
        {
            get
            {
                return _answer;
            }
        }

        public CloseBillService(Bill bill, Socket sender)
        {
            _billId = bill.IdBill;
            _sender = sender;
        }

        public override void RecieveMessageFromSocket()
        {
            string answer = SocketClient.RecieveMessage(_sender);
            int.TryParse(answer, out _answer);
        }

        public override void SendMessageToSocket()
        {
            RequestGenerator request = new RequestGenerator();
            string requestToServer = request.GenerateRequest((int)RequestGenerator.RequestCode.closeBill, _billId);
            byte[] msg = Encoding.ASCII.GetBytes(requestToServer);
            SocketClient.SendMessage(_sender, msg);
        }
    }
}
