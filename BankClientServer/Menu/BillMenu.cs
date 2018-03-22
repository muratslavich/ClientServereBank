﻿using Client;
using System;

namespace BankClientServer.Menu
{
    class BillMenu : AbstractMenu<int>
    {
        private int _input;
        private readonly string _billMenuMessage = "Меню Счета\n" +
            "1-Перевести\n" +
            "2-Выписка\n" +
            "3-Закрыть Счет\n" +
            "4-Выйти из Меню Счета\n";

        public override int Input
        {
            get
            {
                return _input;
            }
        }

        public BillMenu()
        {
            ShowMessage(_billMenuMessage);
            int.TryParse(Console.ReadLine(), out _input);
        }
    }
}
