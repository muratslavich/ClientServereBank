using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Menu
{
    class TransferMenu : AbstractMenu<string[]>
    {
        private int _amount;
        private int _senderIdBill;
        private int _targetIdBill;
        private string[] _transferPackage = new string[3];

        public override string[] Input
        {
            get
            {
                return _transferPackage;
            }
            set
            {

            }
        }

        public TransferMenu(int senderIdBill)
        {
            _senderIdBill = senderIdBill;

            ShowMessage("Введите Id счета получателя");
            int.TryParse(Console.ReadLine(), out _targetIdBill);
            _transferPackage[0] = _targetIdBill.ToString();
            _transferPackage[1] = _senderIdBill.ToString();

            ShowMessage("Введите сумму перевода");
            int.TryParse(Console.ReadLine(), out _amount);
            _transferPackage[2] = _amount.ToString();
        }
    }
}
