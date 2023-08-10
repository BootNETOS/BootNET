using System;
using BootNET.Network;
using Console = BootNET.Core.Console;

namespace BootNET.Shell.Commands.Network;

public class Ping : Command
{
    public Ping(string name) : base(name)
    {
    }

    public override string Invoke(string[] args)
    {
        try
        {
            NetworkManager.PingHost(args[0]);
        }
        catch (Exception ex)
        {
            Console.SetForegroundColor(ConsoleColor.Red);
            Console.WriteLine("Error: " + ex.Message);
        }

        return "";
    }
}