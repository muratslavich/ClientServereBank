using Client;
using System;
using System.Collections.Generic;

namespace Client.Menu
{
    class BillListMenu : AbstractMenu<int>
    {
        private List<Bill> _billList;
        private int _input;
        private string _billListMenuMessage = "Меню Список счетов\n" +
            "1-Введите Id счета для выбора\n" +
            "2-Возврат в Меню Пользователя";

        public override int Input
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

        public BillListMenu(List<Bill> billList)
        {
            _billList = billList;
            Console.Clear();
            ShowMessage(_billListMenuMessage);
            foreach (var item in _billList)
            {
                ShowMessage(item.ToString());
            }
            int.TryParse(Console.ReadLine(), out _input);
        }
    }
}
