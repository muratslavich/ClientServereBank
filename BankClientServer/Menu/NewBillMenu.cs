using System;

namespace BankClientServer.Menu
{
    class NewBillMenu : AbstractMenu<int>
    {
        private int _input;
        private String _newBillMenuMessage = "Меню создания нового счета\n" +
            "Подтвердите создание нового счета\n" +
            "1-Да\n" +
            "2-Нет";

        public override int Input { get => _input; }

        public NewBillMenu()
        {
            ShowMessage(_newBillMenuMessage);
            Int32.TryParse(Console.ReadLine(), out _input);
        }
    }
}
