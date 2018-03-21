using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClientServer.Menu
{
    class UserMenu : AbstractMenu<int>
    {
        private int _input;
        private const String _userMenuMessage = "Меню пользователя\n" +
            "1-Открыть список счетов\n" +
            "2-Открыть новый счет\n" +
            "3-Выход";

        public override int Input { get => _input; }

        public UserMenu()
        {
            ShowMessage(_userMenuMessage);
            Int32.TryParse(Console.ReadLine(), out _input);
        }
    }
}
