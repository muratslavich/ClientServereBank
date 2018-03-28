using Bank;
using System;

namespace Server
{
    internal class CloseBillService
    {
        private string[] _separetedData;
        private string _result;

        public string Result
        {
            get
            {
                return _result;
            }

            set
            {
                _result = value;
            }
        }

        public CloseBillService(string[] _separetedData)
        {
            this._separetedData = _separetedData;
        }

        internal string CloseBill()
        {
            MySqlConnect connect = new MySqlConnect();
            connect.DbConnect();
            Result = connect.CloseBillQuery(_separetedData);
            connect.DbClose();
            return Result;
        }
    }
}