using Server;

namespace Services
{
    internal class TransactionsService : IService
    {
        private string _transactions;

        public string SendQuery(string[] separetedData)
        {
            MySqlDAO connect = new MySqlDAO();
            connect.DbConnect();
            _transactions = connect.GetMyTransactions(separetedData);
            connect.DbClose();
            return _transactions;
        }
    }
}