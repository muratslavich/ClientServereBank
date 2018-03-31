using Client;
using Client.Menu;
using Client.Services;
using Client.Utils;
using System;
using System.Collections.Generic;

namespace BankClientServer
{
    class StateLogic
    {
        private User _user;

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
                _user = new User(userInput[0]); //login
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
                _user = new User(userInput[3]);
                _del = UserMenu;
                _del.Invoke();
            }
        }

        public void ListOfBill()
        {
            AbstractService service = new BillListService(_user.Login);
            string answer = service.Answer;

            if (answer.IndexOf("<0x>") > -1) Console.WriteLine(answer); // .... to remake output without console
            else
            {
                AbstractMenu<int> menu = new BillListMenu(answer);

                List<Bill> billList = new ResponseHandler().ResponseHandlerListToBill(answer);

                foreach (var item in billList)
                {
                    if (menu.Input == item.IdBill)
                    {
                        _user.CurrentBill = item;
                        _del = BillMenu;
                        _del.Invoke();
                    }
                }
            }

        }

        public void NewBill()
        {
            AbstractMenu<int> menu = new NewBillMenu();
            int userKey = menu.Input;

            // hiden local method
            DoMenuState doThis = delegate
            {
                AbstractService creater = new CreateBillService(_user.Login);
                // .... check answer for errors
            };

            _intersection = new Dictionary<int, DoMenuState>
            {
                { 1, doThis },
                { 0, UserMenu },
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

        public void CloseBill()
        {
            AbstractMenu<int> menu = new CloseBillMenu(_user.CurrentBill);
            int userKey = menu.Input;

            DoMenuState doThis = delegate
            {
                AbstractService creater = new CloseBillService(_user.CurrentBill);
                _user.CurrentBill = null;
                // .... check answer for errors
            };

            _intersection = new Dictionary<int, DoMenuState>
            {
                { 1, doThis },
                { 0, UserMenu },
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

        public void ListOfTransactions()
        {
            AbstractService service = new TransactionListService(_user.CurrentBill.IdBill.ToString());
            string answer = service.Answer;

            if (answer.IndexOf("<0x>") > -1) Console.WriteLine(answer); // .... to remake output without console
            else
            {
                AbstractMenu<int> menu = new TransactionListMenu(answer);

                _del = BillMenu;
                _del.Invoke();

            }
        }

        public void Transfer()
        {
            AbstractMenu<string[]> menu = new TransferMenu(_user.CurrentBill.IdBill);
            string[] userInput = menu.Input;

            AbstractService service = new TransferService(userInput);
            string answer = service.Answer;

            if (answer.IndexOf("<0x>") > -1) menu.ShowMessage(answer);

            _del = BillMenu;
            _del.Invoke();
        }
    }
}
