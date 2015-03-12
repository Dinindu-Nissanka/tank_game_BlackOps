using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace TankGame_BlackOps.Communication
{
    public class Receiver
    {
        public static List<string> read_buffer;
        private Thread receiver_thread;
        private int port_listen = 7000;
        private TcpListener list;
        private string message;
        public Receiver() {
            receiver_thread = new Thread(new ThreadStart(receiver_start));
        }

        public void receiver_start()
        {
            list = new TcpListener(IPAddress.Parse(Sender.ip), port_listen);
            while (true)
            {
                list.Start();
                TcpClient clnt = list.AcceptTcpClient();
                Stream str = clnt.GetStream();
                Byte[] bytes = new Byte[256];

                int i;
                message = null;

                while ((i = str.Read(bytes, 0, bytes.Length)) != 0)
                {
                    message = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    read_buffer.Add(message);
                }
                str.Close();
                list.Stop();
                clnt.Close();
            }
        }
    }
}
