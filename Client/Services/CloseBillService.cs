using Client.Utils;

namespace Client.Services
{
    class CloseBillService : AbstractService
    {
        private int _billId;
        private string _answer;

        public override string Answer
        {
            get
            {
                return _answer;
            }
        }

        public CloseBillService(Bill bill)
        {
            _billId = bill.IdBill;
            SendMessageToSocket();
            RecieveMessageFromSocket();
        }

        private void RecieveMessageFromSocket()
        {
            _answer = SocketClient.RecieveMessage();
        }

        private void SendMessageToSocket()
        {
            RequestGenerator _requestGenerator = new RequestGenerator(RequestGenerator.RequestCode.closeBill, _billId.ToString());
            SocketClient.SendMessage(_requestGenerator.Message);
        }
    }
}
