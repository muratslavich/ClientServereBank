using System;

namespace BankClientServer.Menu
{
    class BillMenu : AbstractMenu<int>
    {
        private int _idBill;
        private int _input;
        private readonly String _billMenuMessage = "Меню Счета\n" +
            "1-Перевести\n" +
            "2-Выписка\n" +
            "3-Закрыть Счет\n" +
            "4-Выйти из Меню Счета\n";

        public override int Input { get => _input; }

        public BillMenu(int idBill)
        {
            _idBill = idBill;
            ShowMessage(_billMenuMessage);
            Int32.TryParse(Console.ReadLine(), out _input);
        }
    }
}
