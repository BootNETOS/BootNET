using System;
using System.IO;
using Console = BootNET.Core.Console;

namespace BootNET.Shell.Commands.Filesystem;

public class Touch : Command
{
    public Touch(string name) : base(name)
    {
        
    }

    public override string Invoke(string[] args)
    {
        string response;
        try
        {
            if (args[0] != "")
            {
                File.Create(args[0]);
                Console.SetForegroundColor(ConsoleColor.Green);
                response = "File created successfully!";
            }
            else
            {
                Console.SetForegroundColor(ConsoleColor.Red);
                response = "No path specified!";
            }
        }
        catch (Exception ex)
        {
            Console.SetForegroundColor(ConsoleColor.Red);
            response = "Error: " + ex.Message;
        }
        return response;
    }
}