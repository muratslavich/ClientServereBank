using System;
using System.Text;

namespace Client.Utils
{
    class RequestGenerator
    {
        private string[] _userInput;
        private string _message;

        public string Message {
            get { return _message; }
            private set { _message = value; }
        }

        public RequestGenerator(RequestCode code, string[] userInput)
        {
            _userInput = userInput;
            GenerateRequest((int)code, userInput);
        }

        public enum RequestCode : int
        {
            auth = 1,
            reg,
            billList,
            newBill,
            transfer,
            transactionList,
            closeBill
        }

        private void GenerateRequest(int req, string[] train)
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

            Message = sb.ToString();
        }

        // overload -----------------------------------------
        public string GenerateRequest(int req, string train)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(req + "," + train);
            string request = sb.ToString();
            return request;
        }

        public string GenerateRequest(int req, int train)
        {
            return req + "," + train;
        }
    }
}
