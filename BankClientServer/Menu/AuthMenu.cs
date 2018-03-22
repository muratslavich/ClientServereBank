﻿using System;

namespace BankClientServer.Menu
{
    class AuthMenu : AbstractMenu<string[]>
    {
        private string _login;
        private string _password;
        private string[] _input = new string[2];

        public override string[] Input
        {
            get
            {
                return _input;
            }
        }

        public AuthMenu()
        {
            Console.Clear();
            ShowMessage("Введите логин");
            _login = Console.ReadLine();
            ShowMessage("Введите пароль");
            _password = Console.ReadLine();
            Console.Clear();
            Input[0] = _login;
            Input[1] = _password;
        }
    }
}
