using System;

namespace BootNET.Network.SimpleHttpServer.Models;

public class Route
{
    public string Name { get; set; } // descriptive name for debugging
    public string Method { get; set; }
    public string Url { get; set; }
    public Action<HttpDiscussion> Callable { get; set; }
}