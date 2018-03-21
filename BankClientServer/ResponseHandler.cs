using System;
using System.Collections.Generic;
using System.Linq;

namespace Client
{
    class ResponseHandler
    {
        Char _delimiter = ',';
        private String[] _answer;
        private List<String> _answerList;

        public string[] Answer { get => _answer; private set => _answer = value; }
        public List<string> AnswerList { get => _answerList; private set => _answerList = value; }

        public void ResponseHandlerToArray(String answer)
        {
            Answer = answer.Split(_delimiter);
        }

        public void ResposeHandlerToList(String answer)
        {
            AnswerList = answer.Split(_delimiter).ToList();
        }

    }
}