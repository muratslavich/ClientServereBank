using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClientServer.Menu
{
    class TransactionListMenu : AbstractMenu
    {
        private List<String> _transactionList;
        private String _transactionListMessage = "Меню список транзакций";

        public TransactionListMenu(List<String> trasactionList)
        {
            _transactionList = trasactionList;
            ShowMessage(_transactionListMessage);
            foreach (var item in _transactionList)
            {
                ShowMessage(item);
            }
            Console.ReadLine();
        }
    }
}
