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
            "2-Нет";

        public override int Input
        {
            get
            {
                return _input;
            }
        }

        public CloseBillMenu(int idBill)
        {
            _idBill = idBill;
            ShowMessage(idBill.ToString());
            ShowMessage(_closeBillMenuMessage);
            int.TryParse(Console.ReadLine(), out _input);
        }
    }
}
