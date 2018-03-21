using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * Class entity - User
 * name
 * surname
 * birthDate
 * login
 * 
 * */

namespace BankClientServer
{
    class User
    {
        private String _name;
        private String _surname;
        private DateTime _birthDate;
        private String _login;
        private string v;

        public string Name { get => _name; private set => _name = value; }
        public string Surname { get => _surname; private set => _surname = value; }
        public DateTime BirthDate { get => _birthDate; private set => _birthDate = value; }
        public string Login { get => _login; set => _login = value; }

        public User(string name, string surname, DateTime birthDate, string login)
        {
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
            Login = login;
        }

        public User(string login)
        {
            Login = login;
        }
    }
}
