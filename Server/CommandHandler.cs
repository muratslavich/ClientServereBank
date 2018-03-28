using System;

namespace Server
{
    internal class CommandHandler
    {
        private string[] _separetedData;
        private string _answer;

        public CommandHandler(string[] separetedData)
        {
            this._separetedData = separetedData;
        }

        internal string DoWork()
        {
            int command;
            Int32.TryParse(_separetedData[0], out command);

            // error
            if (command == 0)
            {
                // handle exception
            }

            // authorization
            else if (command == 1)
            {
                AuthService auth = new AuthService(_separetedData);
                _answer = auth.CheckInBase();
            }

            // registration
            else if (command == 2)
            {
                RegService reg = new RegService(_separetedData);
                _answer = reg.AddNewUser();
            }

            // bill list request
            else if (command == 3)
            {
                BillListService billList = new BillListService(_separetedData);
                _answer = billList.GetBills();
            }

            // new bill request
            else if (command == 4)
            {
                NewBillService newBill = new NewBillService(_separetedData);
                _answer = newBill.GetNewBillAsString();
            }

            // transfer request
            else if (command == 5)
            {
                TransferService transfer = new TransferService(_separetedData);
                _answer = transfer.GetTransactResult();
            }

            // transaction list
            else if (command == 6)
            {
                TransactionsService transactions = new TransactionsService(_separetedData);
                _answer = transactions.GetTransactions();
            }

            // close bill request
            else if (command == 7)
            {
                CloseBillService delete = new CloseBillService(_separetedData);
                _answer = delete.CloseBill();
            }
            
            return _answer;
        }
    }
}