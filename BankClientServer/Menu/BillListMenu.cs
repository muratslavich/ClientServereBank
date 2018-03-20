using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClientServer.Menu
{
    class BillListMenu : AbstractMenu
    {
        private List<String> _billList;
        private int _input;
        private String _billListMenuMessage = "Меню Список счетов\n" +
            "1-Введите Id счета для выбора\n" +
            "2-Возврат в Меню Пользователя";

        public int Input { get => _input; }

        public BillListMenu(List<String> billList)
        {
            _billList = billList;
            ShowMessage(_billListMenuMessage);
            foreach (var item in _billList)
            {
                ShowMessage(item);
            }
            Int32.TryParse(Console.ReadLine(), out _input);
        }
    }
}
