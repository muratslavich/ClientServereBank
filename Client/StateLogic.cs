using Client.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClientServer
{
    class StateLogic
    {
        delegate void DoMenuState();
        DoMenuState _del;
        private Dictionary<int, DoMenuState> _intersection;
        
        public StateLogic()
        {
            _del = Entry;
            _del.Invoke();
        }

        public void Entry()
        {
            AbstractMenu<int> menu = new EntryMenu();
            int userKey = menu.Input;

            _intersection = new Dictionary<int, DoMenuState>
            {
                { 1, Auth },
                { 2, Registration },
                { 3, Entry }
            };

            _intersection.TryGetValue(userKey, out _del);

            if (_del != null) _del.Invoke();
            else menu.ShowMessage("Неккоректный ввод ...");
        }

        public void UserMenu()
        {
            _intersection = new Dictionary<int, DoMenuState>
            {
                { 1, ListOfBill },
                { 2, NewBill },
                { 0, Entry }
            };
        }

        public void BillMenu()
        {
            _intersection = new Dictionary<int, DoMenuState>
            {
                { 1, ListOfTransactions },
                { 2, CloseBill },
                { 3, Transfer },
                { 0, UserMenu }
            };
        }

        public void Auth()
        {
            AbstractMenu<string[]> menu = new RegistrationMenu();
        }

        public void Registration()
        {
            Console.WriteLine("Reg");
        }

        public void ListOfBill()
        {

        }

        public void NewBill()
        {

        }

        public void CloseBill()
        {

        }

        public void ListOfTransactions()
        {

        }

        public void Transfer()
        {

        }
    }
}
