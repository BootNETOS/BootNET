using System;
using Console = BootNET.Core.Console;

namespace BootNET.Shell.Commands.Power;

public class Reboot : Command
{
    public Reboot(string name) : base(name)
    {
    }

    public override string Invoke(string[] args)
    {
        string response = "Goodbye!";
        try
        {
            Cosmos.System.Power.Reboot();
        }
        catch (Exception ex)
        {
            Console.SetForegroundColor(ConsoleColor.Red);
            response = "Error: " + ex.Message;
        }

        return response;
    }
}