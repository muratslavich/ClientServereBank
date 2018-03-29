using Client;
using Client.Menu;
using Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClientServer
{
    class StateLogic
    {
        private User user;

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
            AbstractMenu<int> menu = new UserMenu();
            int userKey = menu.Input;

            _intersection = new Dictionary<int, DoMenuState>
            {
                { 1, ListOfBill },
                { 2, NewBill },
                { 0, Entry }
            };

            _intersection.TryGetValue(userKey, out _del);

            if (_del != null) _del.Invoke();
            else
            {
                menu.ShowMessage("Неккоректный ввод ...");
                _del = UserMenu;
                _del.Invoke();
            }
        }

        public void BillMenu()
        {
            AbstractMenu<int> menu = new BillMenu();
            int userKey = menu.Input;

            _intersection = new Dictionary<int, DoMenuState>
            {
                { 1, ListOfTransactions },
                { 2, CloseBill },
                { 3, Transfer },
                { 0, UserMenu }
            };

            _intersection.TryGetValue(userKey, out _del);

            if (_del != null) _del.Invoke();
            else
            {
                menu.ShowMessage("Неккоректный ввод ...");
                _del = BillMenu;
                _del.Invoke();
            }
        }

        public void Auth()
        {
            AbstractMenu<string[]> menu = new AuthMenu();
            string[] userInput = menu.Input;

            AbstractService service = new AuthService(userInput);
            string answer = service.Answer;

            if (answer.IndexOf("<0x>") > -1) menu.ShowMessage(answer);
            else
            {
                _del = UserMenu;
                _del.Invoke();
            }
        }

        public void Registration()
        {
            AbstractMenu<string[]> menu = new RegistrationMenu();
            string[] userInput = menu.Input;

            AbstractService service = new RegistrationService(userInput);
            string answer = service.Answer;

            if (answer.IndexOf("<0x>") > -1) menu.ShowMessage(answer);
            else
            {
                _del = UserMenu;
                _del.Invoke();
            }
        }

        public void ListOfBill()
        {
            AbstractService service = new BillListService(user.Login);
            string answer = service.Answer;

            if (answer.IndexOf("<0x>") > -1) Console.WriteLine(answer);
            else
            {
                AbstractMenu<int> menu = new BillListMenu();

            }            
            
        }

        public void NewBill()
        {
            AbstractMenu<int> menu = new NewBillMenu();
            int userKey = menu.Input;

            // hiden local method
            DoMenuState doThis = delegate
            {
                AbstractService creater = new CreateBillService(user);
                // .... check answer for errors
            };

            _intersection = new Dictionary<int, DoMenuState>
            {
                { 1, doThis },
                { 0, UserMenu },
            };

            if (_del != null) _del.Invoke();
            else
            {
                menu.ShowMessage("Неккоректный ввод ...");
                _del = BillMenu;
                _del.Invoke();
            }
        }

        public void CloseBill()
        {
            AbstractMenu<int> menu = new CloseBillMenu(user.CurrentBill);
            int userKey = menu.Input;

            DoMenuState doThis = delegate
            {
                AbstractService creater = new CloseBillService(user.CurrentBill);
                // .... check answer for errors
            };

            _intersection = new Dictionary<int, DoMenuState>
            {
                { 1, doThis },
                { 0, UserMenu },
            };

            if (_del != null) _del.Invoke();
            else
            {
                menu.ShowMessage("Неккоректный ввод ...");
                _del = BillMenu;
                _del.Invoke();
            }
        }

        public void ListOfTransactions()
        {

        }

        public void Transfer()
        {
            AbstractMenu<string[]> menu = new TransferMenu(user.CurrentBill.IdBill);
            string[] userInput = menu.Input;

            AbstractService service = new TransferService(userInput);
            string answer = service.Answer;

            if (answer.IndexOf("<0x>") > -1) menu.ShowMessage(answer);

            _del = BillMenu;
            _del.Invoke();
        }
    }
}
