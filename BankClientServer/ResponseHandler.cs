using BankClientServer.Menu;
using System;

namespace Client
{
    internal class ResponseHandler
    {
        Char _delimiter = ',';
        private String[] _answer;

        public ResponseHandler(String answer)
        {
            _answer = answer.Split(_delimiter);

            switch (int.Parse(_answer[0]))
            {
                case 1:
                    HandleAnswer();
                    break;

                case 2:
                    throw new Exception("Неверный логин");

                case 3:
                    throw new Exception("Неверный пароль");

                default:
                    throw new Exception("Неизвестный ответ от сервера");
                    
            }
        }

        private void HandleAnswer()
        {
            UserMenu userMenu = new UserMenu();
        }
    }
}