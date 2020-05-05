using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace UDP_ServerBroad
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            UdpClient udpServer = new UdpClient(0);
            udpServer.EnableBroadcast = true;
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Broadcast, 7000);

            Console.WriteLine("Broadcast started: Press Enter");
            Console.ReadLine();

            while (true)
            {
                int number = rand.Next(-1, 2);
                Byte[] sendBytes = Encoding.ASCII.GetBytes(number.ToString());
                try
                {
                    udpServer.Send(sendBytes, sendBytes.Length, endPoint);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }

                Console.WriteLine(" " + number);
                Thread.Sleep(2000);
            }
        }
    }
}
