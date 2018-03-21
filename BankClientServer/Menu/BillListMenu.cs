using System;
using System.Collections.Generic;

namespace BankClientServer.Menu
{
    class BillListMenu : AbstractMenu<int>
    {
        private List<String> _billList;
        private int _input;
        private String _billListMenuMessage = "Меню Список счетов\n" +
            "1-Введите Id счета для выбора\n" +
            "2-Возврат в Меню Пользователя";

        public override int Input { get => _input; }

        public BillListMenu(List<String> billList)
        {
            _billList = billList;
            Console.Clear();
            ShowMessage(_billListMenuMessage);
            foreach (var item in _billList)
            {
                ShowMessage(item);
            }
            Int32.TryParse(Console.ReadLine(), out _input);
        }
    }
}
