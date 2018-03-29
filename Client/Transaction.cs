using System;
using System.Text;

namespace Client
{
    internal class Transaction
    {
        private int _senderId;
        private int _recipientId;
        private DateTime _date;
        private decimal _amount;
        private int _transactId;

        public int SenderId
        {
            get
            {
                return _senderId;
            }

            set
            {
                _senderId = value;
            }
        }

        public int RecieveId
        {
            get
            {
                return _recipientId;
            }

            set
            {
                _recipientId = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return _date;
            }

            set
            {
                _date = value;
            }
        }

        public decimal Amount
        {
            get
            {
                return _amount;
            }

            set
            {
                _amount = value;
            }
        }

        public int TransactId
        {
            get
            {
                return _transactId;
            }

            set
            {
                _transactId = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(TransactId + ";");
            sb.Append(RecieveId + ";");
            sb.Append(SenderId + ";");
            sb.Append(Amount + ";");
            sb.Append(Date);
            string transaction = sb.ToString();

            return transaction;
        }
    }
}