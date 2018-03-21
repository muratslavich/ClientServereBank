using System;

namespace BankClientServer.Menu
{
    class EntryMenu : AbstractMenu<int>
    {
        private int _input;
        private const String _entryMessage = "Меню входа\n" +
            "1-Авторизация\n" +
            "2-Регистрация\n" +
            "3-Выход";

        public override int Input { get => _input; }

        public EntryMenu()
        {
            Console.Clear();
            ShowMessage(_entryMessage);
            Int32.TryParse(Console.ReadLine(), out _input);
        }
    }
}
