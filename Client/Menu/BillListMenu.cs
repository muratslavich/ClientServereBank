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
            "       2-Возврат в Меню Пользователя\n";

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

        public BillListMenu(string answer, string login)
        {
            _billList = new ResponseHandler().ResponseHandlerListToBill(answer);

            Console.Clear();
            ShowMessage(login);
            ShowMessage(_billListMenuMessage);

            Console.WriteLine("{0,-5} {1,10} {2,10}\n", "Счет", "Дата создания", "Остаток на счете");

            foreach (var item in _billList)
            {
                Console.WriteLine("{0,-5} {1,10} {2,10}", item.IdBill, item.CreateDate, item.Balance);
            }
            int.TryParse(Console.ReadLine(), out _input);
        }
    }
}
