using Server;

namespace Services
{
    internal class AuthService : IService
    {
        private string _auth;

        public string SendQuery(string[] separetedData)
        {
            // check
            MySqlDAO connect = new MySqlDAO();
            connect.DbConnect();
            _auth = connect.CheckAuthorization(separetedData);
            connect.DbClose();

            return _auth;
        }
    }
}