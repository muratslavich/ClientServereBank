using Bank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Net;

namespace Server
{
    class MainServer
    {
        static void Main(string[] args)
        {
            // Establish the local endpoint for the socket.  
            // Dns.GetHostName returns the name of the   
            // host running the application.  
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);
            int counter = 0;

            // Create a TCP/IP socket.  
            Socket listener = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and   
            // listen for incoming connections.  
            listener.Bind(localEndPoint);
            listener.Listen(10);

            Console.WriteLine("Waiting for a connection...");

            while (true)
            {
                counter++;
                ThreadPool.QueueUserWorkItem(HandleClient, listener.Accept());
                Console.WriteLine("Connection №" + counter.ToString() + "!");
            }

            //SocketServer.StartListening();
        }

        private static void HandleClient(object state)
        {
            Socket handler = state as Socket;

            // Data buffer for incoming data.  
            byte[] bytes = new Byte[1024];

            try
            {
                while (true)
                {
                    string data = null;

                    // An incoming connection needs to be processed.  
                    bytes = new byte[1024];
                    int bytesRec = handler.Receive(bytes);
                    data += Encoding.ASCII.GetString(bytes, 0, bytesRec);

                    // Show the data on the console.
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Text received : {0}", data);
                    Console.ResetColor();

                    CommandSplitter commandSplitter = new CommandSplitter(data);
                    string[] separetedData = commandSplitter.ParseData();

                    CommandHandler commandHandler = new CommandHandler(separetedData);
                    string answer = commandHandler.HandleCommand();

                    // Echo the data back to the client.  
                    byte[] msg = Encoding.ASCII.GetBytes(answer);

                    handler.Send(msg);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("send : {0}", answer);
                    Console.ResetColor();
                }
            }
            catch (SocketException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Socket realeased with code: " + e.ErrorCode);
                Console.ResetColor();
                handler.Close();
            }
        }
    }
}
