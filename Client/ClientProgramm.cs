using Client;
using Client.Menu;
using Client.Services;
using Client.Utils;
using System;
using System.Collections.Generic;

/**
 * Class ClientProgramm
 * Business logic of the Client programm
 * 
 * public method StartProgramm() is called from main().
 * 
 * private method: process Menu and User input,
 * chek integrity information from user input and server response,
 * manages services for send and recieve data from server.
 * 
 * */


namespace Client
{
    public class ClientProgramm
    {
        private User _user;

        private AbstractHandler<int> _authService;
        private AbstractHandler<int> _registrationService;
        private AbstractHandler<List<Bill>> _billListService;
        private AbstractHandler<Bill> _createBillService;
        private AbstractHandler<int> _closeBillService;
        private AbstractHandler<List<Transaction>> _transactionService;
        private AbstractHandler<int> _transferService;

        private AbstractMenu<string[]> _authMenu;
        private AbstractMenu<int> _userMenu;
        private AbstractMenu<string[]> _registrationMenu;
        private AbstractMenu<int> _entryMenu;
        private AbstractMenu<int> _newBillMenu;
        private AbstractMenu<int> _billListMenu;
        private AbstractMenu<int> _billMenu;
        private AbstractMenu<int> _closeBillMenu;
        private AbstractMenu<int> _transactionMenu;
        private AbstractMenu<string[]> _transferMenu;


        internal AbstractMenu<int> EntryMenu
        {
            get
            {
                return _entryMenu;
            }

            set
            {
                _entryMenu = value;
            }
        }

        /**
         * Method entrance to menu`s tree.
         * Called EntryMenu and handle user choose.
         * 
         * 1-Authorization
         * 2-Registration
         * 3-Exit app
         * 
         * throw InvalidOperationException - wrong input
         * */
        public void StartProgram()
        {
            _entryMenu = new EntryMenu();

            // ... Authorizatin process
            if (_entryMenu.Input == 1)
            {
                AuthProgram();
            }

            // ... Registration process
            else if (_entryMenu.Input == 2)
            {
                RegistrationProgram();
            }

            // ... Exit app
            else if (_entryMenu.Input == 3)
            {
                Environment.Exit(0);
            }

            // ... Input error
            else
            {
                throw new InvalidOperationException("Некоректный ввод ... ");
            }
        }

        /**
         * Method for registration user
         * throw InvalidOperationException - answer error
         * */
        private void RegistrationProgram()
        {
            _registrationMenu = new RegistrationMenu();

            // ... get user input from reg menu, 
            // ... input[name, surname, birthDate, login, password]
            string[] input = _registrationMenu.Input;

            // ... send & recieve
            _registrationService = new RegistrationService(input, SocketClient._sender);
            _registrationService.SendMessageToSocket();
            _registrationService.RecieveMessageFromSocket();

            // ... registration error, return to EntryMenu
            if (_registrationService.Answer == 5)
            {
                throw new InvalidOperationException("Ошибка регистрации ...");
            }
            else if (_registrationService.Answer == 4)
            {
                throw new InvalidOperationException("Такой логин уже существует ...");
            }
            
            // ... positive registration
            else if (_registrationService.Answer == 1)
            {
                //_answe_user = new User(input[0], input[1], DateTime.Parse(input[3]), input[4]);
                UserMenuProgram();
            }

            // ... unknown answer
            else 
            {
                throw new InvalidOperationException("Неизвестный ответ ...");
            }
        }

        /**
         * Method for authorization user
         * throw InvalidOperationException - answer error
         * */
        private void AuthProgram()
        {
            _authMenu = new AuthMenu();

            // ... get user input from auth menu 
            // ... input[login, password]
            string[] input = _authMenu.Input;

            // ... send & recieve
            _authService = new AuthService(input, SocketClient._sender);
            _authService.SendMessageToSocket();
            _authService.RecieveMessageFromSocket();

            // ... errors, return to EntryMenu
            if (_authService.Answer == 3)
            {
                throw new InvalidOperationException("Неверный пароль ...");
            }
            else if (_authService.Answer == 2)
            {
                throw new InvalidOperationException("Неверный логин ...");
            }
            
            // ...positive authentification
            else if (_authService.Answer == 1)
            {
                _user = new User(input[0]);
                UserMenuProgram();
            }

            // ... unknown answer
            else
            {
                throw new InvalidOperationException("Неизвестный ответ ...");
            }


        }

        /**
         * Method intersection user choose
         * 1-open bill list
         * 2-create bill
         * 3-sign out
         * */
        private void UserMenuProgram()
        {
            _userMenu = new UserMenu();

            // Open Bill list
            if (_userMenu.Input == 1)
            {
                BillListMenuProgram();
            }

            // Create new Bill
            if (_userMenu.Input == 2)
            {
                CreateBillProgram();
            }

            // Sign out
            if (_userMenu.Input == 3)
            {
                throw new InvalidOperationException("Выход выполнен ... ");
            }

            // Input error
            else
            {
                _userMenu.ShowMessage("Некоректный ввод... ");
                UserMenuProgram();
            }

        }

        private void BillListMenuProgram()
        {
            // Create BillListService for send/recieve mess to Server
            _billListService = new BillListService(_user, SocketClient._sender);
            _billListService.SendMessageToSocket();
            _billListService.RecieveMessageFromSocket();

            // positive response
            List<Bill> billList = _billListService.Answer;
            _billListMenu = new BillListMenu(billList);
            int input = _billListMenu.Input;

            // 2 - return to user menu
            if (input == 2)
            {
                UserMenuProgram();
            }

            // find desired bill
            else
            {
                foreach (Bill item in billList)
                {
                    if (input == item.IdBill)
                    {
                        BillMenuProgram(item);
                    }
                }

                _billListMenu.ShowMessage("Нет таких счетв ...");
                UserMenuProgram();

            } // if input
        }

        private void CreateBillProgram()
        {
            _newBillMenu = new NewBillMenu();

            if (_newBillMenu.Input == 1)
            {
                // create new bill
                _createBillService = new CreateBillService(_user, SocketClient._sender);
                _createBillService.SendMessageToSocket();
                _createBillService.RecieveMessageFromSocket();
                UserMenuProgram();
            }
            else if (_newBillMenu.Input == 2)
            {
                UserMenuProgram();
            }
            else
            {
                _newBillMenu.ShowMessage("Некоректный ввод ... ");
            }
        }

        private void BillMenuProgram(Bill bill)
        {
            _billMenu = new BillMenu();

            // return to user menu
            if (_billMenu.Input == 4)
            {
                UserMenuProgram();
            }

            // transfer
            else if (_billMenu.Input == 1)
            {
                TransferMenuProgram(bill);
            }

            // transaction list
            else if (_billMenu.Input == 2)
            {
                TransactionListMenuProgram(bill);
            }

            // close bill
            else if (_billMenu.Input == 3)
            {
                CloseBillMenuProgram(bill);
            }
            else
            {
                _billMenu.ShowMessage("Некоректный ввод ... ");
                BillMenuProgram(bill);
            }

        }

        private void CloseBillMenuProgram(Bill bill)
        {
            _closeBillMenu = new CloseBillMenu(bill.IdBill);
            
            // closing confirm by user
            if (_closeBillMenu.Input == 1)
            {
                
                _closeBillService = new CloseBillService(bill, SocketClient._sender);

                // .... negative 
                if (_closeBillService.Answer == 0)
                {
                    _closeBillMenu.ShowMessage("Не удалось закрыть счет ... ");
                    UserMenuProgram();
                }

                // .... positive completed closing, return User menu
                else if (_closeBillService.Answer == 1)
                {
                    _closeBillMenu.ShowMessage($"bill {bill.IdBill} закрыт ... ");
                    UserMenuProgram();
                }
            }

            // closing rejected by user
            else if (_closeBillMenu.Input == 2)
            {
                BillMenuProgram(bill);
            }

            // user input is uncorrect - any int except 1 or 2
            // check for characters make by TryParse in Menu
            else
            {
                _closeBillMenu.ShowMessage("Некоректный ввод ... ");
                BillMenuProgram(bill);
            }
        }

        private void TransactionListMenuProgram(Bill bill)
        {
            // get transaction list from server
            _transactionService = new TransactionListService(bill, SocketClient._sender);
            
            List<Transaction> trasactionList = _transactionService.Answer;
            _transactionMenu = new TransactionListMenu(trasactionList);

            BillMenuProgram(bill);
        }

        private void TransferMenuProgram(Bill bill)
        {
            // menu output
            _transferMenu = new TransferMenu(bill.IdBill);
            
            _transferService = new TransferService(_transferMenu.Input, SocketClient._sender);
            _transferService.SendMessageToSocket();
            _transferService.RecieveMessageFromSocket();

            BillMenuProgram(bill);
        }
    }
}