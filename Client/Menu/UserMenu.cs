using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Menu
{
    class UserMenu : AbstractMenu<int>
    {
        private int _input;
        private const string _userMenuMessage = "Меню пользователя\n" +
            "1-Открыть список счетов\n" +
            "2-Открыть новый счет\n" +
            "3-Выход";

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

        public UserMenu()
        {
            ShowMessage(_userMenuMessage);
            int.TryParse(Console.ReadLine(), out _input);
        }
    }
}
