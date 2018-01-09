using NetMQ;
using NetMQ.Sockets;
using System;

namespace netmq_poller_test_client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var req1 = new RequestSocket(">tcp://127.0.0.1:5001"))
            using (var req2 = new RequestSocket(">tcp://127.0.0.1:5002"))
            {
                req1.SendFrame("request from 5001");
                var rsp1 = req1.ReceiveFrameString();
                Console.WriteLine("rsp1: {0}", rsp1);

                req2.SendFrame("request from 5002");
                var rsp2 = req2.ReceiveFrameString();
                Console.WriteLine("rsp2: {0}", rsp2);
            }
        }
    }
}
