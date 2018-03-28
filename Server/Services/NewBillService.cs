using Bank;
using System;

namespace Server
{
    internal class NewBillService
    {
        private string[] _separetedData;
        private string _createdBill;

        public string CreatedBill
        {
            get
            {
                return _createdBill;
            }

            set
            {
                _createdBill = value;
            }
        }

        public NewBillService(string[] _separetedData)
        {
            this._separetedData = _separetedData;
        }

        internal string GetNewBillAsString()
        {
            MySqlConnect connect = new MySqlConnect();
            connect.DbConnect();
            CreatedBill = connect.AddNewBill(_separetedData);
            connect.DbClose();
            return CreatedBill;
        }
    }
}