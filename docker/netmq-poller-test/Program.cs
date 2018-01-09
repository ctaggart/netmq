
// https://netmq.readthedocs.io/en/latest/poller/

using NetMQ;
using NetMQ.Sockets;
using System;

namespace netmq_poller_test
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var rep1 = new ResponseSocket("@tcp://*:5001"))
            using (var rep2 = new ResponseSocket("@tcp://*:5002"))
            using (var poller = new NetMQPoller { rep1, rep2 })
            {
                // these event will be raised by the Poller
                rep1.ReceiveReady += (s, a) =>
                {
                    // receive won't block as a message is ready
                    string msg = a.Socket.ReceiveFrameString();
                    Console.WriteLine("received on 5001: {0}", msg);
                    // send a response
                    a.Socket.SendFrame("Response");
                };
                rep2.ReceiveReady += (s, a) =>
                {
                    // receive won't block as a message is ready
                    string msg = a.Socket.ReceiveFrameString();
                    Console.WriteLine("received on 5002: {0}", msg);
                    // send a response
                    a.Socket.SendFrame("Response");
                };

                // start polling (on this thread)
                poller.Run();
            }
        }
    }
}
