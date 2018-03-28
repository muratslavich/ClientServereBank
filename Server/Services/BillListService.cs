using Server;

namespace Services
{
    internal class BillListService : IService
    {
        private string _bills;

        public string SendQuery(string[] separetedData)
        {
            MySqlDAO connect = new MySqlDAO();
            connect.DbConnect();
            _bills = connect.GetBillList(separetedData);
            connect.DbClose();
            return _bills;
        }
    }
}