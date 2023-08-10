using System;
using System.Collections.Generic;
using System.Text;
using BootNET.Network.SimpleHttpServer;
using BootNET.Network.SimpleHttpServer.Models;
using Console = BootNET.Core.Console;

namespace BootNET.Shell.Commands.Network;

public class HttpServerStart : Command
{
    public HttpServerStart(string name) : base(name)
    {
        
    }

    public override string Invoke(string[] args)
    {
        

        return "";
    }

    public void Listen()
    {
        try
        {
            var route_config = new List<Route>() {
                new Route() {
                    Name = "Hello Handler",
                    Method = "GET",
                    Url = "/",
                    Callable = (HttpDiscussion result) => {
                        result.Response = new HttpResponse()
                        {
                            Content = Encoding.ASCII.GetBytes(@"<html>" +
                                                              "\t<h1>Hello from <a href=\"https://github.com/aura-systems/Aura-Operating-System\">AuraOS</a>!</h1>" +
                                                              "\t<p>Version: " + 0 + "." + 0 + "</p>" +
                                                              "\t<p>Server Hour: " + DateTime.Now.ToString() + "</p>" +
                                                              "\t<p>Server Boot Time: " + 0 + "</p>" +
                                                              "\t<p>Powered by <a href=\"https://github.com/CosmosOS/Cosmos\">Cosmos</a>.</p>" +
                                                              "</html>"),
                            ReasonPhrase = "OK",
                            StatusCode = "200"
                        };
                    }
                }
            };

            var httpServer = new HttpServer(80, route_config);
            httpServer.Listen();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}