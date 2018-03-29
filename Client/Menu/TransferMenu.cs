using System;

namespace Client.Menu
{
    class TransferMenu : AbstractMenu<string[]>
    {
        private int _amount;
        private int _senderIdBill;
        private int _targetIdBill;
        private string[] _input = new string[3];

        public override string[] Input
        {
            get
            {
                return _input;
            }
            set
            {
                _input = value;
            }
        }

        public TransferMenu(int senderIdBill)
        {
            _senderIdBill = senderIdBill;

            ShowMessage("Введите Id счета получателя");
            int.TryParse(Console.ReadLine(), out _targetIdBill);
            _input[0] = _targetIdBill.ToString();
            _input[1] = _senderIdBill.ToString();

            ShowMessage("Введите сумму перевода");
            int.TryParse(Console.ReadLine(), out _amount);
            _input[2] = _amount.ToString();
        }
    }
}
