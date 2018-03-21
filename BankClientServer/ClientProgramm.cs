using BankClientServer;
using BankClientServer.Menu;
using BankClientServer.Services;
using System;
using System.Collections.Generic;

namespace Client
{
    internal class ClientProgramm
    {
        //private String _answer;
        //private String[] _input;
        private User _user;

        private ClientInputHandler<String[]> _authService;
        private ClientInputHandler<String[]> _registrationService;
        private ClientInputHandler<List<Bill>> _billListService;

        private AbstractMenu<String[]> _authMenu;
        private AbstractMenu<int> _userMenu;
        private AbstractMenu<String[]> _registrationMenu;
        private AbstractMenu<int> _entryMenu;
        private AbstractMenu<int> _newBillMenu;
        private AbstractMenu<int> _billListMenu;

        internal void StartProgramm()
        {
            _entryMenu = new EntryMenu();

            // Authorizatin process
            if (_entryMenu.Input == 1)
            {
                // create auth menu
                _authMenu = new AuthMenu();

                // get user input from auth menu input[login, password]
                String[] input = _authMenu.Input;

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

            // Registration process                     ???
            else if (_entryMenu.Input == 2)
            {
                _registrationMenu = new RegistrationMenu();
                String[] input = _registrationMenu.Input;
            }

            // Exit app
            else if (_entryMenu.Input == 3)
            {
                Environment.Exit(0);
            }

            // Input error
            else
            {
                throw new InvalidOperationException("Некоректный ввод");
            }
        }

        // handle UserMenu
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
                BillListMenuProgramm(billList);
            }

            // Create new Bill
            if (_userMenu.Input == 2)
            {

            }

            // Sign out
            if (_userMenu.Input == 3)
            {
                throw new InvalidOperationException("Выход выполнен");
            }

            // Input error
            else
            {
                throw new InvalidOperationException("Некоректный ввод");
            }

        }

        private void BillListMenuProgramm(List<Bill> billList)
        {
            // get user input idBill || 2-exit
            int input = _billListMenu.Input;

            if (input == 2)
            {
                throw new InvalidOperationException("Выход в меню пользователя");
            }
            else
            {
                foreach (Bill item in billList)
                {
                    if (input == item.IdBill)
                    {

                    }
                    else
                    {
                        throw new InvalidOperationException("Нет таких счетов ... ");
                    }
                }
            }
        }
    }
}