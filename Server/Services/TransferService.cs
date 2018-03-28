using Bank;
using System;

namespace Server
{
    internal class TransferService
    {
        private string[] _separetedData;
        private string _transferStatus;

        public TransferService(string[] _separetedData)
        {
            this._separetedData = _separetedData;
        }

        public string TransferStatus
        {
            get
            {
                return _transferStatus;
            }

            set
            {
                _transferStatus = value;
            }
        }

        internal string GetTransactResult()
        {
            MySqlConnect connect = new MySqlConnect();
            connect.DbConnect();
            TransferStatus = connect.ConductTransfer(_separetedData);
            connect.DbClose();
            return TransferStatus;
        }
    }
}