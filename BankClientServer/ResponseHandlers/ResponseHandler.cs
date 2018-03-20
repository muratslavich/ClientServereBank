using BankClientServer.Menu;
using System;

namespace Client
{
    abstract class ResponseHandler
    {
        Char _delimiter = ',';
        protected String[] _answer;

        public ResponseHandler(String answer)
        {
            _answer = answer.Split(_delimiter);
        }

        public abstract void HandleAnswer();
    }
}