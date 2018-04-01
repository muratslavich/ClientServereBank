using BankClientServer;
using Client.Utils;
using System;

namespace Client
{
    public class MainClient
    {
        static void Main(string[] args)
        {
            //try
            //{
               SocketClient.StartClient();

                while (true)
                {
                    try
                    {
                        //client.StartProgram();
                        StateLogic logic = new StateLogic();
                    
                    }
                    catch (InvalidOperationException ie)
                    {
                        Console.WriteLine(ie.Message);
                        Console.WriteLine("Нажмите любую клавишу для продолжения ... ");
                        Console.ReadLine();
                    }
                }
                //SocketClient.RealeseSocket(SocketClient._sender);
            //}
            //catch (Exception se)
            //{
            //    Console.WriteLine("SocketException : {0}", se.ToString());
            //    Console.ReadLine();
            //}
        }
    }
}