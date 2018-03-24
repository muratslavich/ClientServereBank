using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client.Utils
{
    class SocketClient
    {
        
        // incoming data from server
        public static string data = null;

        public static Socket _sender;

        public static void StartClient()
        {
            // Establish the remote endpoint for the socket.  
            // This example uses port 11000 on the local computer.  
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);

            // Create a TCP/IP  socket.  
            _sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            // Connect the socket to the remote endpoint. Catch any errors.  
            _sender.Connect(remoteEP);

            Console.WriteLine("Socket connected to {0}",
            _sender.RemoteEndPoint.ToString());
        }

        public static void SendMessage(Socket sender, byte[] msg)
        {
            // Send the data through the socket.  
            int bytesSent = sender.Send(msg);
        }

        public static string RecieveMessage(Socket sender)
        {
            // Data buffer for incoming data.  
            byte[] bytes = new byte[1024];

            // Receive the response from the remote device.  
            int bytesRec = sender.Receive(bytes);
            string answer = Encoding.ASCII.GetString(bytes, 0, bytesRec);

            return answer; 
        }

        public static void RealeseSocket(Socket sender)
        {
            // Release the socket.  
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
        }
    }
}
