using Server;

namespace Services
{
    internal class RegService : IService
    {
        private string _regResult;

        public string SendQuery(string[] separetedData)
        {
            MySqlDAO connect = new MySqlDAO();
            connect.DbConnect();
            _regResult = connect.DoRegistration(separetedData);
            connect.DbClose(); 

            return _regResult;
        }
    }
}