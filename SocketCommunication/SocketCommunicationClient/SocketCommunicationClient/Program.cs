using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace SocketCommunicationClient
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
            Socket clientSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            //Three-way handshaking
            clientSocket.Connect(serverEndPoint);
            //Error process
            Console.WriteLine("Connected to " + ipAddress + ":" + port);

            //Send packet
            byte[] requestMsg = Encoding.UTF8.GetBytes("hoge");
            clientSocket.Send(requestMsg);

            //Receive packet
            int bytesCount = clientSocket.Receive(bytesMsg);
            string responseMsg = Encoding.UTF8.GetString(bytesMsg, 0, bytesCount);
            Console.WriteLine("recv: " + responseMsg);

            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
        }
    }
}
