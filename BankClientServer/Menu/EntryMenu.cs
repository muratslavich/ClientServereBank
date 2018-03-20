using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClientServer.Menu
{
    class EntryMenu : AbstractMenu
    {
        private const String _entryMessage = "Меню входа\n1-Авторизация\n2-Регистрация\n3-Выход";

        public EntryMenu()
        {
            this.ShowMessage(_entryMessage);
        }

        
    }
}
