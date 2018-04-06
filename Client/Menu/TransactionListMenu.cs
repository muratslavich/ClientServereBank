using Client.Utils;
using System;
using System.Collections.Generic;

namespace Client.Menu
{
    class TransactionListMenu : AbstractMenu<int>
    {
        private List<Transaction> _transactionList;
        private string _transactionListMessage = "          Меню список транзакций ...\n";

        public override int Input { get; set; }

        public TransactionListMenu(string trasactionList)
        {
            _transactionList = new ResponseHandler().ResponseHandlerListToTransaction(trasactionList);
            Console.Clear();
            ShowMessage(_transactionListMessage);

            Console.WriteLine("{0,-10} {1,25} {2,25} {3,30}\n", "Транзакция", "Счет получателя", "Сумма", "Дата платежа");

            foreach (var item in _transactionList)
            {
                Console.WriteLine("{0,-10} {1,25} {2,25} {3,30}", item.TransactId, item.RecieveId, item.Amount, item.Date );
            }
            Console.ReadLine();
        }
    }
}
