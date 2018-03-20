using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClientServer.Menu
{
    abstract class AbstractMenu
    {
        public void ShowMessage(String mess)
        {
            Console.WriteLine(mess);
        }
    }
}
