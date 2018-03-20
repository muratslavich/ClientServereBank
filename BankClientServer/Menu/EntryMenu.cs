using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClientServer.Menu
{
    class EntryMenu : AbstractMenu
    {
        private int _input;
        private const String _entryMessage = "Меню входа\n" +
            "1-Авторизация\n" +
            "2-Регистрация\n" +
            "3-Выход";

        public int Input { get => _input; }

        public EntryMenu()
        {
            ShowMessage(_entryMessage);
            Int32.TryParse(Console.ReadLine(), out _input);
        }
    }
}
