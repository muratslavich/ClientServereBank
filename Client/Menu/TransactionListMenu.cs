using System;
using System.Collections.Generic;

namespace Client.Menu
{
    class TransactionListMenu : AbstractMenu<int>
    {
        private List<Transaction> _transactionList;
        private string _transactionListMessage = "Меню список транзакций ...";

        public override int Input { get; set; }

        public TransactionListMenu(List<Transaction> trasactionList)
        {
            _transactionList = trasactionList;
            ShowMessage(_transactionListMessage);
            foreach (var item in _transactionList)
            {
                ShowMessage(item.ToString());
            }
            Console.ReadLine();
        }
    }
}
