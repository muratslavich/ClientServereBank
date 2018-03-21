using BankClientServer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Client
{
    class ResponseHandler
    {
        Char _delimiter = ',';
        private String[] _answer;
        private List<Bill> _answerList;

        public string[] Answer { get => _answer; private set => _answer = value; }
        public List<Bill> AnswerList { get => _answerList; private set => _answerList = value; }

        public void ResponseHandlerToArray(String answer)
        {
            Answer = answer.Split(_delimiter);
        }

        public List<String> ResposeHandlerToList(String answer)
        {
            List<String> listBill = answer.Split(_delimiter).ToList();
            return listBill;
        }

        public void ResponseHandlerListToBill(List<String> bills)
        {
            foreach (var item in bills)
            {
                Bill bill = new Bill();
                String[] separetedBill = item.Split(';');

                bill.IdBill = Int32.Parse(separetedBill[0]);
                bill.Login = separetedBill[1];
                bill.CreateDate = DateTime.Parse(separetedBill[2]);
                bill.Balance = Decimal.Parse(separetedBill[3]);

                AnswerList.Add(bill);
            }
        }

    }
}