using Bank;
using System;

namespace Server
{
    internal class TransactionsService
    {
        private string[] _separetedData;
        private string _transactions;

        public string Transactions
        {
            get
            {
                return _transactions;
            }

            set
            {
                _transactions = value;
            }
        }

        public TransactionsService(string[] _separetedData)
        {
            this._separetedData = _separetedData;
        }

        internal string GetTransactions()
        {
            MySqlConnect connect = new MySqlConnect();
            connect.DbConnect();
            Transactions = connect.GetMyTransactions(_separetedData);
            connect.DbClose();
            return Transactions;
        }
    }
}