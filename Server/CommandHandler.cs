using Bank.Services;
using Services;
using System;
using System.Collections.Generic;

namespace Server
{
    internal class CommandHandler
    {
        private string[] _separetedData;
        private string _answer;

        private readonly Dictionary<int, IServiceFactory> _factory = new Dictionary<int, IServiceFactory>
        {
            { 1, new AuthFactory() },
            { 2, new RegFactory() },
            { 3, new BillListFactory() },
            { 4, new NewBillFactory() },
            { 5, new TransferFactory() },
            { 6, new TransactionFactory() },
            { 7, new CloseBillFactory() }
        };

        public CommandHandler(string[] separetedData)
        {
            _separetedData = separetedData;
        }

        internal string HandleCommand()
        {
            int command;
            Int32.TryParse(_separetedData[0], out command);

            IServiceFactory serviceFactory;
            _factory.TryGetValue(command, out serviceFactory);

            IService service = serviceFactory.CreateService();
            _answer = service.SendQuery(_separetedData);
            
            return _answer;
        }
    }
}