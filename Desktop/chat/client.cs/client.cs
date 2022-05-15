using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace client.cs
{
    class client
    {
        static void Main(string[] args)
        {
             IPAddress host = IPAddress.Parse("127.0.0.1");
            IPEndPoint ip = new IPEndPoint(host, 8000);
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sock.Connect(ip);
               
                byte[] receivedData = new byte[1024];
                int receivedBytesLen = sock.Receive(receivedData);
                int filenameLength = BitConverter.ToInt32(receivedData,0);
            string fname = Encoding.ASCII.GetString(receivedData, 4, filenameLength);
            var fdata = Encoding.ASCII.GetString(receivedData,4+filenameLength, receivedBytesLen-4-filenameLength);
            File.WriteAllText(fname, fdata);
            sock.Shutdown(SocketShutdown.Both);
            sock.Close();

        }
    }
}
