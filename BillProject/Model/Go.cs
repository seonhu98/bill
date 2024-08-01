using Newtonsoft.Json;
using OpenCvSharp;
using System.Collections.Generic;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BillProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public class Go
    {
        //Thread thread = new Thread(new ThreadStart(shoot));
        //thread.IsBackground = true;
        //thread.Start();


     static public void shoot(Mat myimg, string text1)
        {
            //string path = @"C:\Users\iot\source\repos\WpfApp2\WpfApp2\imgfolder\apple.png";
            //OpenCvSharp.Mat myimg = new OpenCvSharp.Mat();
            //myimg = Cv2.ImRead(path, ImreadModes.Grayscale);
            //Cv2.Resize(myimg, myimg, new OpenCvSharp.Size(), 0.2, 0.2, InterpolationFlags.Linear);
            IPAddress address = IPAddress.Parse("10.10.21.126");
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.SendBufferSize = 6400;
            socket.Connect(address, 10001);


            //socket.Send(a);
            byte[] bytes;
            bytes = myimg.ImEncode(".png");

            var ss = new
            {
                protocol = "이미지전송"
            };
            byte[] bytes22 = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(ss));
            //byte[] base64 = Encoding.UTF8.GetBytes(Convert.ToBase64String(bytes));
            socket.Send(bytes22);
            Thread.Sleep(100);
            //MessageBox.Show(base64.Length.ToString());
            //socket.Send(bytes);
            //socket.Disconnect(true);
            //socket.Close();

            List<byte[]> bys = new List<byte[]>();

            int len = bytes.Length / 4000;
            int modulo = bytes.Length % 4000;

            for (int i = 0; i < len; i++)
            {
                byte[] bytes1 = new byte[4000];

                for (int j = 0; j < 4000; j++)
                {
                    bytes1[j] = bytes[j + (i * 4000)];
                }

                bys.Add(bytes1);
            }

            byte[] bytes2 = new byte[modulo];

            for (int i = len * 4000; i < len * 4000 + modulo; i++)
            {
                bytes2[i - (len * 4000)] = bytes[i];
            }

            bys.Add(bytes2);



            foreach (var item in bys)
            {

                socket.Send(item);

            }

            Thread.Sleep(100);
            var imdata2 = new
            {
                protocol = "이미지전송완료",
                text = text1

            };

            byte[] go1;
            go1 = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(imdata2));
            socket.Send(go1);
        }
    }
}
