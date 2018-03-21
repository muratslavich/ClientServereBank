using System;

namespace BankClientServer.Menu
{
    class AuthMenu : AbstractMenu<String[]>
    {
        private String _login;
        private String _password;
        private String[] _input = new String[2];

        public override String[] Input { get => _input; }

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
