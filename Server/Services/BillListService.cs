using Bank;
using System;

namespace Server
{
    internal class BillListService
    {
        private string[] _separetedData;
        private string _bills;

        public string Bills
        {
            get
            {
                return _bills;
            }

            set
            {
                _bills = value;
            }
        }

        public BillListService(string[] _separetedData)
        {
            this._separetedData = _separetedData;
        }

        internal string GetBills()
        {
            MySqlConnect connect = new MySqlConnect();
            connect.DbConnect();
            Bills = connect.GetBillList(_separetedData);
            connect.DbClose();
            return Bills;
        }
    }
}