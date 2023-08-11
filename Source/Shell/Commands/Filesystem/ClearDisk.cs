using System;
using BootNET.Filesystem;
using Console = BootNET.Core.Console;

namespace BootNET.Shell.Commands.Filesystem;

public class ClearDisk : Command
{
    public ClearDisk(string name) : base(name)
    {
        
    }

    public override string Invoke(string[] args)
    {
        string response;
        try
        {
            if (args[0] != "")
            {
                FilesystemManager.Clear(Convert.ToInt16(args[0]));
                Console.SetForegroundColor(ConsoleColor.Green);
                response = "Disk cleared successfully.";
            }
            else
            {
                Console.SetForegroundColor(ConsoleColor.Red);
                response = "No disk specified!";
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