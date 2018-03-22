using BankClientServer;
using BankClientServer.Menu;
using BankClientServer.Services;
using System;
using System.Collections.Generic;

namespace Client
{
    internal class ClientProgramm
    {
        private User _user;

        private AbstractHandler<string[]> _authService;
        private AbstractHandler<string[]> _registrationService;
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

        internal void StartProgramm()
        {
            _entryMenu = new EntryMenu();

            // Authorizatin process
            if (_entryMenu.Input == 1)
            {
                // create auth menu
                _authMenu = new AuthMenu();

                // get user input from auth menu input[login, password]
                string[] input = _authMenu.Input;

                // send user input to creating AuthService constructor for sending to server
                _authService = new AuthService(input, SocketClient._sender);
                _authService.SendMessageToSocket();

                // recive message from server, handle answer in RecieveMessageFromSecket
                try
                {
                    _authService.RecieveMessageFromSocket();
                }
                // when server responded negatively authentification
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }

                // when server responded positively authentification
                _user = new User(input[0]);

                try
                {
                    UserMenuProgramm();
                }
                catch (InvalidOperationException retExc)
                {
                    Console.Clear();
                    Console.WriteLine(retExc.Message);
                }
                finally
                {
                    UserMenuProgramm();
                }
            }

            // Registration process
            else if (_entryMenu.Input == 2)
            {
                // create reg menu
                _registrationMenu = new RegistrationMenu();

                // get user input from reg menu, input[name, surname, birthDate, login, password]
                string[] input = _registrationMenu.Input;

                // send user input to server
                _registrationService = new RegistrationService(input, SocketClient._sender);
                _registrationService.SendMessageToSocket();

                // recive mess from server
                try
                {
                    _registrationService.RecieveMessageFromSocket();
                }
                catch (InvalidOperationException regExc)
                {
                    Console.WriteLine(regExc.Message);
                }

                // positive registration
                _user = new User(input[0], input[1], DateTime.Parse(input[3]), input[4]);

                try
                {
                    UserMenuProgramm();
                }
                catch (InvalidOperationException retExc)
                {
                    Console.Clear();
                    Console.WriteLine(retExc.Message);
                }
                finally
                {
                    UserMenuProgramm();
                }
            }

            // Exit app
            else if (_entryMenu.Input == 3)
            {
                Environment.Exit(0);
            }

            // Input error
            else
            {
                throw new InvalidOperationException("Некоректный ввод ... ");
            }
        }

        private void UserMenuProgramm()
        {
            _userMenu = new UserMenu();

            // Open Bill list
            if (_userMenu.Input == 1)
            {
                // Create BillListService for send/recieve mess to Server
                _billListService = new BillListService(_user, SocketClient._sender);
                _billListService.SendMessageToSocket();

                try
                {
                    _billListService.RecieveMessageFromSocket();
                }
                //when server responded 0 bill
                catch (InvalidOperationException billExc)
                {
                    Console.WriteLine(billExc.Message);
                }
                // positive response
                // get this list from billListService
                List<Bill> billList = _billListService.Answer;

                // output billlist
                _billListMenu = new BillListMenu(billList);
                try
                {
                    BillListMenuProgramm(billList);
                }
                catch (InvalidOperationException erIn)
                {
                    Console.WriteLine(erIn.Message);
                }
            }

            // Create new Bill
            if (_userMenu.Input == 2)
            {
                CreateBillProgramm();
            }

            // Sign out
            if (_userMenu.Input == 3)
            {
                StartProgramm();
            }

            // Input error
            else
            {
                throw new InvalidOperationException("Некоректный ввод ... ");
            }

        }

        private void BillListMenuProgramm(List<Bill> billList)
        {
            // get user input idBill || 2-exit
            int input = _billListMenu.Input;

            // return to user menu
            if (input == 2)
            {
                UserMenuProgramm();
            }
            else
            {
                foreach (Bill item in billList)
                {
                    if (input == item.IdBill)
                    {
                        BillMenuProgramm(item);
                    }
                    else
                    {
                        throw new InvalidOperationException("Нет таких счетов ... ");
                    }
                }
            }
        }

        private void CreateBillProgramm()
        {
            _newBillMenu = new NewBillMenu();

            if (_newBillMenu.Input == 1)
            {
                // create new bill
                _createBillService = new CreateBillService(_user, SocketClient._sender);
                UserMenuProgramm();
            }
            else if (_newBillMenu.Input == 2)
            {
                UserMenuProgramm();
            }
            else
            {
                throw new InvalidOperationException("Некоректный ввод ... ");
            }
        }

        private void BillMenuProgramm(Bill bill)
        {
            Console.WriteLine(bill.ToString());
            _billMenu = new BillMenu();

            // return to user menu
            if (_billMenu.Input == 4)
            {
                UserMenuProgramm();
            }
            // transfer
            else if (_billMenu.Input == 1)
            {
                TransferMenuProgramm(bill);
            }
            // transaction list
            else if (_billMenu.Input == 2)
            {
                TransactionListMenuProgramm(bill);
            }
            // close bill
            else if (_billMenu.Input == 3)
            {
                CloseBillMenuProgramm(bill);
            }
            else
            {
                throw new InvalidOperationException("Некоректный ввод ... ");
            }

        }

        private void CloseBillMenuProgramm(Bill bill)
        {
            Console.WriteLine(bill.ToString());
            _closeBillMenu = new CloseBillMenu(bill.IdBill);
            
            // closing confirm by user
            if (_closeBillMenu.Input == 1)
            {
                
                _closeBillService = new CloseBillService(bill, SocketClient._sender);

                // .... negative 
                if (_closeBillService.Answer == 0)
                {
                    _closeBillMenu.ShowMessage("Не удалосьб закрыть счет ... ");
                    UserMenuProgramm();
                }

                // .... positive completed closing, return User menu
                else if (_closeBillService.Answer == 1)
                {
                    _closeBillMenu.ShowMessage($"bill {bill.IdBill} закрыт ... ");
                    UserMenuProgramm();
                }
            }

            // closing rejected by user
            else if (_closeBillMenu.Input == 2)
            {
                BillMenuProgramm(bill);
            }

            // user input is uncorrect - any int except 1 or 2
            // check for characters make by TryParse in Menu
            else
            {
                throw new InvalidOperationException("Некоректный ввод ... ");
            }
        }

        private void TransactionListMenuProgramm(Bill bill)
        {
            // get transaction list from server
            _transactionService = new TransactionListService(bill, SocketClient._sender);
            
            List<Transaction> trasactionList = _transactionService.Answer;
            _transactionMenu = new TransactionListMenu(trasactionList);

            BillMenuProgramm(bill);
        }

        private void TransferMenuProgramm(Bill bill)
        {
            // menu output
            _transferMenu = new TransferMenu(bill.IdBill);
            
            _transferService = new TransferService(_transferMenu.Input, SocketClient._sender);
            _transferService.SendMessageToSocket();
            _transferService.RecieveMessageFromSocket();

            BillMenuProgramm(bill);
        }
    }
}