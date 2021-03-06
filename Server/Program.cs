﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            
            TcpListener listener = new TcpListener(2017);

            listener.Start();

            while (true)
            {
                Socket sv = listener.AcceptSocket();
                
                MultiThread mt = new MultiThread(sv);
                Thread thread = new Thread(new ThreadStart(mt.Recieve));
                thread.Start();
            }
        }
    }
    class MultiThread
    {
        static Dictionary<EndPoint, Socket> Clients = new Dictionary<EndPoint, Socket>();
        Socket _sv;
        string _chuoiRecieve;
        NetworkStream ns;
        StreamWriter sw;
        StreamReader sr;
        public MultiThread()
        {

        }
        public MultiThread(Socket sv)
        {
            _sv = sv;
            Clients.Add(sv.RemoteEndPoint, sv);
            ns = new NetworkStream(_sv);
            sw = new StreamWriter(ns);
            sr = new StreamReader(ns);
        }
        public void Recieve()
        {
            while (true)
            {
                _chuoiRecieve = sr.ReadLine();
                Console.WriteLine(_sv.RemoteEndPoint + " : " + _chuoiRecieve);
                SendAllExceptAClient(_sv.RemoteEndPoint + " : " + _chuoiRecieve, _sv.RemoteEndPoint);
            }
        }

        void SendAllExceptAClient(string data, EndPoint client)
        {
            foreach(var item in Clients)
            {
                if(!item.Key.Equals(_sv.RemoteEndPoint))
                {
                    ns = new NetworkStream(item.Value);
                    sw = new StreamWriter(ns);
                    sw.WriteLine(data);
                    sw.Flush();
                    //item.Value.Send(Encoding.ASCII.GetBytes(data));
                }
            }
        }
    }
}
