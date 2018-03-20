using BankClientServer;
using BankClientServer.Menu;
using BankClientServer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    public class MainClient
    {

        static void Main(string[] args)
        {
            AbstractMenu _entryMenu;
            ClientInputHandler _clientInputHandler;
            ResponseHandler _responseHandler;

            try
            {
                SocketClient.StartClient();

                while (true)
                {
                    _entryMenu = new EntryMenu();

                    //wait command
                    String input = Console.ReadLine();

                    //handle command
                    int index = Int32.Parse(input);
                    switch (index)
                    {
                        case 1:
                            Console.Clear();
                            AuthMenu authMenu = new AuthMenu();
                            _clientInputHandler = new AuthService(authMenu.Input, SocketClient._sender);
                            _clientInputHandler.SendMessageToSocket();

                            String answer = SocketClient.RecieveMessage(SocketClient._sender);

                            try
                            {
                                _responseHandler = new ResponseHandler(answer);
                            }
                            catch (Exception e)
                            {
                                Console.Clear();
                                Console.WriteLine(e.Message);
                                Console.WriteLine("Нажмите, чтобы попробовать еще раз");
                                Console.ReadLine();
                                Console.Clear();
                            }

                            break;
                        case 2:
                            break;
                        case 3:
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Uncorrect input");
                            break;
                    }
                }
            }

            //catch (ArgumentNullException ane)
            //{  
            //    Console.WriteLine("ArgumentNullException : {0}",ane.ToString());  
            //}
            catch (SocketException se)
            {  
                Console.WriteLine("SocketException : {0}",se.ToString());
                Console.ReadLine();
            }
            //catch (Exception e)
            //{  
            //    Console.WriteLine("Unexpected exception : {0}", e.ToString());  
            //}

            //try
            //{
            //    SocketClient.RealeseSocket(_sender);
            //}
            //catch (Exception exc)
            //{
            //    Console.WriteLine(exc.ToString());
            //    Console.ReadLine();
            //}

            
        }
    }
}