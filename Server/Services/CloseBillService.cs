using Server;

namespace Services
{
    internal class CloseBillService : IService
    {
        private string _result;

        public string SendQuery(string[] separetedData)
        {
            MySqlDAO connect = new MySqlDAO();
            connect.DbConnect();
            _result = connect.CloseBillQuery(separetedData);
            connect.DbClose();
            return _result;
        }
    }
}