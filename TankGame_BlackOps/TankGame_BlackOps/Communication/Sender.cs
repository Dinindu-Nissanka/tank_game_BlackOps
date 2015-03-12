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
    public class Sender
    {
        public static List<string> send_buffer;
        public static string ip = "127.0.0.1";
        private Thread sender_thread;
        private int connect_port = 6000;
        private TcpClient tcpclient;
        public Sender() {
            sender_thread = new Thread(new ThreadStart(sender_start));
        }
        public void sender_start()
        {
            while (true) {
                if (send_buffer.Count != 0)
                {
                    for (int i = 0; i < send_buffer.Count; i++) {
                        send_message(send_buffer.ElementAt(i));
                        send_buffer.RemoveAt(i);
                        i--;
                    }
                }
            }
        }
        private void send_message(string message)
        {
            tcpclient = new TcpClient();
            tcpclient.Connect(IPAddress.Parse(ip), connect_port);
            Stream stm = tcpclient.GetStream();

            ASCIIEncoding asen = new ASCIIEncoding();
            byte[] ba = asen.GetBytes(message);

            stm.Write(ba, 0, ba.Length);
            stm.Close();
            tcpclient.Close();
        }
    }
}
