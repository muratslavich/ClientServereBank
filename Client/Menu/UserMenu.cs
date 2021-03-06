﻿using System;

namespace Client.Menu
{
    class UserMenu : AbstractMenu<int>
    {
        private int _input;
        private const string _userMenuMessage = "           Меню пользователя\n" +
            "1-Открыть список счетов\n" +
            "2-Открыть новый счет\n" +
            "0-Выход";

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
            Console.Clear();
            ShowMessage(_userMenuMessage);
            int.TryParse(Console.ReadLine(), out _input);
        }
    }
}
