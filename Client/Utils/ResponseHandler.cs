using Client;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Client.Utils
{
    class ResponseHandler
    {
        char _delimiter = ',';
        private string[] _answer;
        private List<Bill> _answerList;

        public string[] Answer
        {
            get { return _answer; }
            private set
            {
                _answer = value;
            }
        }
        public List<Bill> AnswerList
        {
            get { return _answerList; }
            private set
            {
                _answerList = value;
            }
        }

        public void ResponseHandlerToArray(string answer)
        {
            Answer = answer.Split(_delimiter);
        }

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

        public void ResponseHandlerListToBill(List<string> bills)
        {
            foreach (var item in bills)
            {
                Bill bill = new Bill();
                string[] separetedBill = item.Split(';');

                bill.IdBill = int.Parse(separetedBill[0]);
                bill.Login = separetedBill[1];
                bill.CreateDate = DateTime.Parse(separetedBill[2]);
                bill.Balance = Decimal.Parse(separetedBill[3]);

                AnswerList.Add(bill);
            }
        }

        public List<Transaction> ResponseHandlerToTransaction(List<string> transactions)
        {
            List<Transaction> transactionsList = new List<Transaction>();
            foreach (var item in transactions)
            {
                string[] separatedTransaction = item.Split(';');
                Transaction transaction = new Transaction();

                transaction.SenderId = int.Parse(separatedTransaction[0]);
                transaction.RecieveId = int.Parse(separatedTransaction[1]);
                transaction.Date = DateTime.Parse(separatedTransaction[2]);
                transaction.Amount = decimal.Parse(separatedTransaction[3]);

                transactionsList.Add(transaction);
            }
            return transactionsList;
        } 
    }
}