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

        public List<Bill> ResponseHandlerListToBill(string answer)
        {
            List<Bill> billList = new List<Bill>();
            List<string> listBill = answer.Split(_delimiter).ToList();

            foreach (var item in listBill)
            {
                Bill bill = new Bill();
                string[] separetedBill = item.Split(_innerDelimitter);

                bill.IdBill = int.Parse(separetedBill[0]);
                bill.CreateDate = separetedBill[1]; // .... to do
                bill.Balance = separetedBill[2];

                billList.Add(bill);
            }
            return billList;
        }

        public List<Transaction> ResponseHandlerListToTransaction(string transactions)
        {
            List<Transaction> transactionsList = new List<Transaction>();
            List<string> list = transactions.Split(_delimiter).ToList();

            foreach (var item in list)
            {
                string[] separatedTransaction = item.Split(';');
                Transaction transaction = new Transaction();

                transaction.TransactId = separatedTransaction[0];
                transaction.RecieveId = separatedTransaction[1];
                transaction.Amount = separatedTransaction[2];
                transaction.Date = separatedTransaction[3];

                transactionsList.Add(transaction);
            }
            return transactionsList;
        } 
    }
}