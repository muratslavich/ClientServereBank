using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Server
{
    class SocketServer
    {
        // Incoming data from the client.  
        public static string data = null;
        static Socket handler;

        public static void StartListening()
        {
            

            // Establish the local endpoint for the socket.  
            // Dns.GetHostName returns the name of the   
            // host running the application.  
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

            // Create a TCP/IP socket.  
            Socket listener = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and   
            // listen for incoming connections.  
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);

                // Start listening for connections.  
                Console.WriteLine("Waiting for a connection...");
                // Program is suspended while waiting for an incoming connection.  
                handler = listener.Accept();

                Thread thread = new Thread(DoServer);
                thread.Start();

                return;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nPress ENTER to continue...");
            Console.Read();

        }

        private static void DoServer()
        {
            // Data buffer for incoming data.  
            byte[] bytes = new Byte[1024];

            while (true)
            {
                data = null;

                // An incoming connection needs to be processed.  
                bytes = new byte[1024];
                int bytesRec = handler.Receive(bytes);
                data += Encoding.ASCII.GetString(bytes, 0, bytesRec);

                // Show the data on the console.  
                Console.WriteLine("Text received : {0}", data);

                CommandSplitter commandSplitter = new CommandSplitter(data);
                string[] separetedData = commandSplitter.ParseData();

                CommandHandler commandHandler = new CommandHandler(separetedData);
                string answer = commandHandler.HandleCommand();

                // Echo the data back to the client.  
                byte[] msg = Encoding.ASCII.GetBytes(answer);

                handler.Send(msg);
                Console.WriteLine("send", answer);
                //handler.Shutdown(SocketShutdown.Both);
                //handler.Close();
            }
        }
    }
}
