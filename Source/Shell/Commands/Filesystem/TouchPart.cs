using System;
using BootNET.Filesystem;
using Console = BootNET.Core.Console;

namespace BootNET.Shell.Commands.Filesystem;

public class TouchPart : Command
{
    public TouchPart(string name) : base(name)
    {
        
    }

    public override string Invoke(string[] args)
    {
        string response;
        try
        {
            if (args[0] != "" & args[1] != "")
            {
                FilesystemManager.CreatePartition(Convert.ToInt16(args[2]),Convert.ToInt16(args[0]));
                Console.SetForegroundColor(ConsoleColor.Green);
                response = "Partition created successfully.";
            }
            else
            {
                Console.SetForegroundColor(ConsoleColor.Red);
                response = "No disk and size specified!";
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