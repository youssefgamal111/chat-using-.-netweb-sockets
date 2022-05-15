using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
namespace ConsoleApp9
{
    class server
    {
        static void Main(string[] args)
        {
            IPEndPoint ipEnd = new IPEndPoint(IPAddress.Any, 8000);
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sock.Bind(ipEnd);
            sock.Listen(100);
            Socket clientsock = sock.Accept();
             string filename = args[0];
            Console.WriteLine("youssef gamal abdelnasser\n CS\n 5 ");
                Console.WriteLine("sending file: "+filename);
                byte [] arr = new byte[1024];
                byte[] sizearr = BitConverter.GetBytes(filename.Length);
              
                sizearr.CopyTo(arr, 0);
                sizearr = Encoding.ASCII.GetBytes(filename);
                sizearr.CopyTo(arr,4);
            sizearr = File.ReadAllBytes(filename);
                sizearr.CopyTo(arr, 4+filename.Length);
                clientsock.Send(arr);
            clientsock.Shutdown(SocketShutdown.Both);
            clientsock.Close();
            Console.WriteLine("File Sent");

        }
    }
}
















