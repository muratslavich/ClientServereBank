using System;

namespace Client.Menu
{
    class EntryMenu : AbstractMenu<int>
    {
        private int _input;
        private const string _entryMessage = "          Меню входа\n" +
            "1-Авторизация\n" +
            "2-Регистрация\n" +
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

        public EntryMenu()
        {
            ShowMessage(_entryMessage);
            int.TryParse(Console.ReadLine(), out _input);
        }
    }
}
