using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient();
            client.Connect("127.0.0.1", 2017);
            MultiThread mt = new MultiThread(client);

            while (true)
            {
                Thread t1 = new Thread(new ThreadStart(mt.Recive));
                Thread t2 = new Thread(new ThreadStart(mt.Send));
                t2.Start();
                t1.Start();
                Thread.Sleep(1000);
            }
        }
       
    }

    class MultiThread
    {
        TcpClient _client;
        NetworkStream ns;
        StreamReader nhan;
        StreamWriter gui;
        string _rec;

        public MultiThread()
        {

        }
        public MultiThread(TcpClient client)
        {
            _client = client;
            ns = _client.GetStream();
            gui = new StreamWriter(ns);
            nhan = new StreamReader(ns);
        }

        public void Recive()
        {
            _rec = nhan.ReadLine();
            Console.WriteLine(_rec);
        }

        public void Send()
        {
            string send = Console.ReadLine();
            gui.WriteLine(send);
            gui.Flush();
        }
    }
}
