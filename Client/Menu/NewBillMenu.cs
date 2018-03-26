using System;

namespace Client.Menu
{
    class NewBillMenu : AbstractMenu<int>
    {
        private int _input;
        private string _newBillMenuMessage = "Меню создания нового счета\n" +
            "Подтвердите создание нового счета\n" +
            "1-Да\n" +
            "2-Нет";

        public override int Input
        {
            get
            {
                return _input;
            }
            set
            {
                _input = value;
            }
        }

        public NewBillMenu()
        {
            ShowMessage(_newBillMenuMessage);
            int.TryParse(Console.ReadLine(), out _input);
        }
    }
}
