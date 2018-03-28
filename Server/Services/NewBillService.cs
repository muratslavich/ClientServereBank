using Server;

namespace Services
{
    internal class NewBillService : IService
    {
        private string _createdBill;

        public string SendQuery(string[] separetedData)
        {
            MySqlDAO connect = new MySqlDAO();
            connect.DbConnect();
            _createdBill = connect.AddNewBill(separetedData);
            connect.DbClose();
            return _createdBill;
        }
    }
}