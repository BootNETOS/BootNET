using System.Collections.Generic;
using BootNET.Core;
using BootNET.Network.SimpleHttpServer.Models;
using Cosmos.System.Network.Config;
using Cosmos.System.Network.IPv4.TCP;

namespace BootNET.Network.SimpleHttpServer;

public class HttpServer
{
    #region Fields

    private readonly int Port;
    private TcpListener Listener;
    private readonly HttpProcessor Processor;
    private readonly bool IsActive = true;

    #endregion

    #region Public Methods

    public HttpServer(int port, List<Route> routes)
    {
        Port = port;
        Processor = new HttpProcessor();

        foreach (var route in routes) Processor.AddRoute(route);
    }

    public void Listen()
    {
        Listener = new TcpListener((ushort)Port);
        Listener.Start();

        Console.WriteLine("HTTP Server Listening on " + NetworkConfiguration.CurrentAddress + ":80");

        while (IsActive)
            try
            {
                var s = Listener.AcceptTcpClient();
                Processor.HandleClient(s);
            }
            catch
            {
            }
    }

    #endregion
}