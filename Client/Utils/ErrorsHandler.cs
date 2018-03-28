using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClientServer.Utils
{
    class ErrorsHandler
    {
        private string _errorCode;
        private string _errorMessage = null;
        private readonly Dictionary<string, string> _errorsMap = new Dictionary<string, string>
        {
            {"0x01" , "Неверный логин ..." },
            {"0x02" , "Неверный пароль ..." },
            {"0x03" , "Такой логин уже существует ..." },
            {"0x04" , "Нет открытых вкладов ..." },
            {"0x05" , "На счете есть средства ..." },
            {"0x06" , "Ошибка создания счета ..." },
            {"0x07" , "Нет транзакций ..." },
            {"0x08" , "Не достаточно средств на счете ..." },
            {"0x09" , "Счет получателя не существет ..." },
        };

        public ErrorsHandler(string errorCode)
        {
            _errorCode = errorCode;
        }

        public string GetErrorMessage()
        {
            _errorsMap.TryGetValue(_errorCode, out _errorMessage);
            return _errorMessage;
        }
    }
}
