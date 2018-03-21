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
        private String _login;
        private DateTime _createDate;
        private decimal _balance;

        public int IdBill { get => _idBill; set => _idBill = value; }
        public string Login { get => _login; set => _login = value; }
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }
        public decimal Balance { get => _balance; set => _balance = value; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(IdBill + ";");
            sb.Append(Login + ";");
            sb.Append(CreateDate + ";");
            sb.Append(Balance);
            String bill = sb.ToString();

            return bill;
        }
    }
}
