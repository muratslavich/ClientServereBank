using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClientServer.Menu
{
    class UserMenu : AbstractMenu
    {
        private const String _userMenuMessage = "Меню пользователя\n1-Открыть список счетов\n2-Открыть новый счет\n3-Выход";

        public UserMenu()
        {
            ShowMessage(_userMenuMessage);
            Console.ReadLine();
        }
    }
}
