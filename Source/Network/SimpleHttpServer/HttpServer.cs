using Cosmos.System.Network.IPv4.TCP;
using BootNET.Network.SimpleHttpServer.Models;
using System.Collections.Generic;
using BootNET.Core;

namespace BootNET.Network.SimpleHttpServer
{
    public class HttpServer
    {
        #region Fields

        private int Port;
        private TcpListener Listener;
        private HttpProcessor Processor;
        private bool IsActive = true;

        #endregion

        #region Public Methods

        public HttpServer(int port, List<Route> routes)
        {
            Port = port;
            Processor = new HttpProcessor();

            foreach (var route in routes)
            {
                Processor.AddRoute(route);
            }
        }

        public void Listen()
        {
            Listener = new TcpListener((ushort)Port);
            Listener.Start();

            Console.WriteLine("HTTP Server Listening on port 80...");

            while (IsActive)
            {
                try
                {
                    var s = Listener.AcceptTcpClient();
                    Processor.HandleClient(s);
                }
                catch
                {

                }
            }
        }

        #endregion

    }
}



