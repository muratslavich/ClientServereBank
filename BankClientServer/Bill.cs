using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Bill
    {
        private int _idBill;
        private string _login;
        private DateTime _createDate;
        private decimal _balance;

        public int IdBill
        {
            get { return _idBill; }
            set
            {
                _idBill = value;
            }
        }
        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
            }
        }
        public DateTime CreateDate
        {
            get { return _createDate; }
            set
            {
                _createDate = value;
            }
        }
        public decimal Balance
        {
            get { return _balance; }
            set
            {
                _balance = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(IdBill + ";");
            sb.Append(Login + ";");
            sb.Append(CreateDate + ";");
            sb.Append(Balance);
            string bill = sb.ToString();

            return bill;
        }
    }
}
