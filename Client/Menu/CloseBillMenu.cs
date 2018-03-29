using System;

namespace Client.Menu
{
    class CloseBillMenu : AbstractMenu<int>
    {
        private int _idBill;
        private int _input;
        private string _closeBillMenuMessage = "Меню закрытия счета\n" +
            "Подтвердите закрытие счета\n" +
            "1-Да\n" +
            "0-Нет";

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

        public CloseBillMenu(Bill infoBill)
        {
            ShowMessage(infoBill.ToString());
            ShowMessage(_closeBillMenuMessage);
            int.TryParse(Console.ReadLine(), out _input);
        }
    }
}
