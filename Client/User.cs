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
    public class User
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Login { get; set; }
        public Bill CurrentBill { get; set; }

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
