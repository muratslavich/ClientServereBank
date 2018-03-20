using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClientServer.Menu
{
    class NewBillMenu : AbstractMenu
    {
        private int _input;
        private String _newBillMenuMessage = "Меню создания нового счета\n" +
            "Подтвердите создание нового счета\n" +
            "1-Да\n" +
            "2-Нет";

        public int Input { get => _input; }

        public NewBillMenu()
        {
            ShowMessage(_newBillMenuMessage);
            Int32.TryParse(Console.ReadLine(), out _input);
        }
    }
}
