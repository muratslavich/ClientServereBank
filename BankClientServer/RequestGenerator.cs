using System;
using System.Text;

namespace BankClientServer
{
    class RequestGenerator
    {
        public enum RequestCode : int
        {
            auth = 1,
            reg,
            billList,
            newBill,
            transferCheck,
            transfer,
            transactionList,
            closeBillCheck,
            closeBill
        }

        public String GenerateRequest(int req, String[] train)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(req + ",");

            //добавляем все кроме последнего элемента
            for (int i = 0; i < train.Length-1; i++)
            {
                sb.Append(train[i] + ",");
            }
            //добавляем последний элемент
            sb.Append(train[train.Length-1]);

            String request = sb.ToString();
            return request;
        }

        // overload
        public String GenerateRequest(int req, String train)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(req + "," + train);
            String request = sb.ToString();
            return request;
        }
    }
}
