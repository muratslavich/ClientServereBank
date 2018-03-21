using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClientServer.Menu
{
    class RegistrationMenu : AbstractMenu<String[]>
    {
        private String _name;
        private String _surname;
        private String _birthDate;
        private String _login;
        private String _password;
        private String[] _input = new String[5];

        public override String[] Input { get => _input; }

        public RegistrationMenu()
        {
            Console.Clear();
            Console.WriteLine("Введите ваше Имя");
            _name = Console.ReadLine();
            _input[0] = _name;
            Console.WriteLine("Введите вашу Фамилию");
            _surname = Console.ReadLine();
            _input[1] = _surname;
            Console.WriteLine("Введите дату рождения");
            _birthDate = Console.ReadLine();
            _input[2] = _birthDate;
            Console.WriteLine("Введите ваш логин");
            _login = Console.ReadLine();
            _input[3] = _login;
            Console.WriteLine("Введите ваш пароль");
            _password = Console.ReadLine();
            _input[4] = _password;
        }
    }
}
