using Client;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Client.Utils
{
    class ResponseHandler
    {
        private char _delimiter = ',';
        private readonly char _innerDelimitter = ';';

        public List<string> ResposeHandlerToList(string answer)
        {
            List<string> listBill = answer.Split(_delimiter).ToList();
            return listBill;
        }

        public Bill ResponseHandlerToBill(string answer)
        {
            Bill bill = new Bill();
            string[] separeted  = answer.Split(';');

            bill.IdBill = int.Parse(separeted[0]);
            bill.Login = separeted[1];
            bill.CreateDate = DateTime.Parse(separeted[2]);
            bill.Balance = Decimal.Parse(separeted[3]);

            return bill;
        }

        public List<Bill> ResponseHandlerListToBill(string answer)
        {
            List<Bill> billList = new List<Bill>();
            List<string> listBill = answer.Split(_delimiter).ToList();

            foreach (var item in listBill)
            {
                Bill bill = new Bill();
                string[] separetedBill = item.Split(_innerDelimitter);

                bill.IdBill = int.Parse(separetedBill[0]);
                bill.CreateDate = DateTime.Parse(separetedBill[1]);
                bill.Balance = Decimal.Parse(separetedBill[2]);

                billList.Add(bill);
            }
            return billList;
        }

        public List<Transaction> ResponseHandlerToTransaction(List<string> transactions)
        {
            List<Transaction> transactionsList = new List<Transaction>();
            foreach (var item in transactions)
            {
                string[] separatedTransaction = item.Split(';');
                Transaction transaction = new Transaction();
                int transactId = 0;
                int recipientId = 0;
                int billId = 0;
                decimal amount = 0;
                DateTime transactDate = new DateTime();

                int.TryParse(separatedTransaction[0], out billId);
                int.TryParse(separatedTransaction[1], out recipientId);
                DateTime.TryParse(separatedTransaction[2], out transactDate);
                decimal.TryParse(separatedTransaction[3], out amount);
                int.TryParse(separatedTransaction[0], out transactId);

                transaction.TransactId = transactId;
                transaction.RecieveId = recipientId;
                transaction.SenderId = billId;
                transaction.Amount = amount;
                transaction.Date = transactDate;

                transactionsList.Add(transaction);
            }
            return transactionsList;
        } 
    }
}