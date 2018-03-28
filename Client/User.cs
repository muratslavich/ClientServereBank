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

namespace Client
{
    class User
    {
        private string _name;
        private string _surname;
        private DateTime _birthDate;
        private string _login;

        public string Name
        {
            get { return _name; }
            private set
            {
                _name = value;
            }
        }
        public string Surname
        {
            get { return _surname; }
            private set
            {
                _surname = value;
            }
        }
        public DateTime BirthDate
        {
            get { return _birthDate; }
            private set
            {
                _birthDate = value;
            }
        }
        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
            }
        }

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
