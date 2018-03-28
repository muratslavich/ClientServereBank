using System;
using Services;

namespace Bank.Services
{
    interface IServiceFactory
    {
        IService CreateService();
    }

    class AuthFactory : IServiceFactory
    {
        public IService CreateService()
        {
            return new AuthService();
        }
    }

    class RegFactory : IServiceFactory
    {
        public IService CreateService()
        {
            return new RegService();
        }
    }

    class BillListFactory : IServiceFactory
    {
        public IService CreateService()
        {
            return new BillListService();
        }
    }

    class CloseBillFactory : IServiceFactory
    {
        public IService CreateService()
        {
            return new CloseBillService();
        }
    }

    class NewBillFactory : IServiceFactory
    {
        public IService CreateService()
        {
            return new NewBillService();
        }
    }

    class TransactionFactory : IServiceFactory
    {
        public IService CreateService()
        {
            return new TransactionsService();
        }
    }

    class TransferFactory : IServiceFactory
    {
        public IService CreateService()
        {
            return new TransferService();
        }
    }
}
