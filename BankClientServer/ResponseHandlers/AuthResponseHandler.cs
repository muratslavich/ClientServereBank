using BankClientServer.Menu;
using Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClientServer.ResponseHandlers
{
    class AuthResponseHandler : ResponseHandler
    {
        public AuthResponseHandler(string answer) : base(answer)
        {
        }

        public override void HandleAnswer()
        {
            switch (int.Parse(_answer[0]))
            {
                case 1:
                    UserMenu userMenu = new UserMenu();
                    break;

                case 2:
                    throw new Exception("Неверный логин");

                case 3:
                    throw new Exception("Неверный пароль");

                default:
                    throw new Exception("Неизвестный ответ от сервера");

            }
        }
    }
}
