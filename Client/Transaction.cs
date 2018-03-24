using System;
using System.Text;

namespace Client
{
    internal class Transaction
    {
        private int _senderId;
        private int _recieveId;
        private DateTime _date;
        private decimal _amount;

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
                return _recieveId;
            }

            set
            {
                _recieveId = value;
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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(SenderId + ";");
            sb.Append(RecieveId + ";");
            sb.Append(Date + ";");
            sb.Append(Amount);
            string transaction = sb.ToString();

            return transaction;
        }
    }
}