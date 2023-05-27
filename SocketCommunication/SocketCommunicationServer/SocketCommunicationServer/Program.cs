using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace SocketCommunicationServer
{
    class Program
    {
        static void Main(string[] args)
        {
            int port = 8888;
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint serverEndPoint = new IPEndPoint(ipAddress, port);
            byte[] bytesMsg = new byte[256]; //Reception buffer

            //Socket generation
            Socket listeningSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            listeningSocket.Bind(serverEndPoint);
            listeningSocket.Listen(10);
            Console.WriteLine("Server " + ipAddress + ":" + port + " is opened");

            //Three-way handshaking
            Socket serverSocket = listeningSocket.Accept();

            //Receive packet
            int bytesCount = serverSocket.Receive(bytesMsg);
            string requestMsg = Encoding.UTF8.GetString(bytesMsg, 0, bytesCount);
            Console.WriteLine("recv: " + requestMsg);

            //Send packet
            byte[] responseMsg = Encoding.UTF8.GetBytes("OK");
            serverSocket.Send(responseMsg);

            serverSocket.Shutdown(SocketShutdown.Both);
            serverSocket.Close();
        }
    }
}
