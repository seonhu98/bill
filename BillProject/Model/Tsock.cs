using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BillProject.Model
{
    public class Tsock
    {
        private Socket socket;

        public Socket Mysoket { get { return socket; } set { socket = value; }}

        public void ConnetServ()
        {
            socket=new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress address = IPAddress.Parse("10.10.21.126");
            socket.Connect(address,10001); 
        }
    
    }
}
