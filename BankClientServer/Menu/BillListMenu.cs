using Client;
using System;
using System.Collections.Generic;

namespace BankClientServer.Menu
{
    class BillListMenu : AbstractMenu<int>
    {
        private List<Bill> _billList;
        private int _input;
        private String _billListMenuMessage = "Меню Список счетов\n" +
            "1-Введите Id счета для выбора\n" +
            "2-Возврат в Меню Пользователя";

        public override int Input { get => _input; }

        public BillListMenu(List<Bill> billList)
        {
            _billList = billList;
            Console.Clear();
            ShowMessage(_billListMenuMessage);
            foreach (var item in _billList)
            {
                ShowMessage(item.ToString());
            }
            Int32.TryParse(Console.ReadLine(), out _input);
        }
    }
}
