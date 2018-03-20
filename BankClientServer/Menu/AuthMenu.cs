using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClientServer.Menu
{
    class AuthMenu : AbstractMenu
    {
        private String _login;
        private String _password;
        private String[] _input = new String[2];

        public AuthMenu()
        {
            ShowMessage("Введите логин");
            _login = Console.ReadLine();
            ShowMessage("Введите пароль");
            _password = Console.ReadLine();
            Console.Clear();
            Input[0] = _login;
            Input[1] = _password;
        }

        public string[] Input { get => _input; }
        
    }
}
