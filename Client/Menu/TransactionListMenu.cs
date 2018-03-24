using Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Menu
{
    class TransactionListMenu : AbstractMenu<int>
    {
        private List<Transaction> _transactionList;
        private string _transactionListMessage = "Меню список транзакций ...";

        public override int Input { get; }

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
