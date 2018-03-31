using Client.Utils;
using System;
using System.Collections.Generic;

namespace Client.Menu
{
    class BillListMenu : AbstractMenu<int>
    {
        private List<Bill> _billList;
        private int _input;
        private readonly string _billListMenuMessage = "            Меню Список счетов\n" +
            "       Id-Введите Id счета для выбора\n" +
            "       2-Возврат в Меню Пользователя";

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

        public BillListMenu(string answer)
        {
            _billList = new ResponseHandler().ResponseHandlerListToBill(answer);

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
