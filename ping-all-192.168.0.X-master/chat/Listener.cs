using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;

namespace chat
{
    class Listener
    {
        public static void Server()
        {
            string strIP = "127.0.0.1";
            Int32 port;
            port = 13000;
            IPAddress ip = IPAddress.Parse(strIP);
            TcpListener OneTcpListener = new TcpListener(ip, port);
            OneTcpListener.Start();
            Socket ClientSocket = OneTcpListener.AcceptSocket();
            if (ClientSocket.Connected)
            {
                MessageBox.Show("Connected !");
            }
        }
    }
}
