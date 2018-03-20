using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClientServer.Menu
{
    class TransferMenu : AbstractMenu
    {
        private int _amount;
        private int _senderIdBill;
        private int _targetIdBill;
        private String[] _transferPackage = new String[3];

        public String[] TransferPackage { get => _transferPackage; }

        public TransferMenu(int senderIdBill)
        {
            _senderIdBill = senderIdBill;

            ShowMessage("Введите Id счета получателя");
            Int32.TryParse(Console.ReadLine(), out _targetIdBill);
            _transferPackage[0] = _targetIdBill.ToString();
            _transferPackage[1] = _senderIdBill.ToString();

            ShowMessage("Введите сумму перевода");
            Int32.TryParse(Console.ReadLine(), out _amount);
            _transferPackage[2] = _amount.ToString();
        }
    }
}
