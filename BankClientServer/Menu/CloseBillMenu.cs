using System;

namespace BankClientServer.Menu
{
    class CloseBillMenu : AbstractMenu<int>
    {
        private int _idBill;
        private int _input;
        private String _closeBillMenuMessage = "Меню закрытия счета\n" +
            "Подтвердите закрытие счета\n" +
            "1-Да\n" +
            "2-Нет";

        public override int Input { get => _input; }

        public CloseBillMenu(int idBill)
        {
            _idBill = idBill;
            ShowMessage(_closeBillMenuMessage);
            Int32.TryParse(Console.ReadLine(), out _input);
        }
    }
}
