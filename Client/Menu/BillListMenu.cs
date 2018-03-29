using Client.Utils;
using System;
using System.Collections.Generic;

namespace Client.Menu
{
    class BillListMenu : AbstractMenu<int>
    {
        private List<Bill> _billList;
        private int _input;
        private readonly string _billListMenuMessage = "Меню Список счетов\n" +
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

        public void ShowList(List<Bill> billList)
        {
            Console.Clear();
            ShowMessage(_billListMenuMessage);
            foreach (var item in billList)
            {
                ShowMessage(item.ToString());
            }
            int.TryParse(Console.ReadLine(), out _input);
        }

        public void SepareteAnswer(string answer)
        {
            ResponseHandler handler = new ResponseHandler();
            _billList = handler.ResponseHandlerListToBill(answer);
        }
    }
}
