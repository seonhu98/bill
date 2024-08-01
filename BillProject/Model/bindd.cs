using OpenCvSharp.Dnn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;
using System.Windows;



namespace BillProject
{
    public class bindd
    {
        private Socket socket;
        public Socket Mysoket
        {
            get { return socket; }
            set { socket = value; }
        }

        public double[] Conn()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress address = IPAddress.Parse("10.10.21.126");
            socket.Connect(address, 10001);

            byte[] data = new byte[150];
            var jj = new
            {
                protocol = "값호출"
            };

            data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(jj));
            socket.Send(data);
            //receive
            byte[] buffer = new byte[1024];
            int len = socket.Receive(buffer);
            string message = Encoding.UTF8.GetString(buffer);


            var obj = JObject.Parse(message);
            //JArray jArray = new JArray();

            double[] datas = obj["value"].ToObject<double[]>();

            //foreach (var item in datas)
            //{
            //    MessageBox.Show(item.ToString());
            //}
            return datas;
        }

        public string Day()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress address = IPAddress.Parse("10.10.21.126");
            socket.Connect(address, 10001);

            byte[] data = new byte[150];
            var jj = new
            {
                protocol = "DAYDAY"
            };
            data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(jj));
            socket.Send(data);
            //receive
            byte[] buffer = new byte[1024];
            int len = socket.Receive(buffer);
            string message = Encoding.UTF8.GetString(buffer);
            
            return message;
        }
    }
}

