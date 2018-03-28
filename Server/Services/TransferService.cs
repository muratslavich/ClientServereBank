using Server;

namespace Services
{
    internal class TransferService : IService
    {
        private string _transferStatus;

        public string SendQuery(string[] separetedData)
        {
            MySqlDAO connect = new MySqlDAO();
            connect.DbConnect();
            _transferStatus = connect.ConductTransfer(separetedData);
            connect.DbClose();
            return _transferStatus;
        }
    }
}