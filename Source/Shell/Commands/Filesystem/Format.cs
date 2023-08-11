using System;
using BootNET.Filesystem;
using Console = BootNET.Core.Console;

namespace BootNET.Shell.Commands.Filesystem;

public class Format : Command
{
    public Format(string name) : base(name)
    {
        
    }

    public override string Invoke(string[] args)
    {
        string response;
        try
        {
            if (args[0] != "" & args[1] != "" & args[2] != "")
            {
                FilesystemManager.FormatPartition(Convert.ToInt16(args[0]),Convert.ToInt16(args[1]),args[2]);
                Console.SetForegroundColor(ConsoleColor.Green);
                response = "Partition formatted successfully.";
            }
            else
            {
                Console.SetForegroundColor(ConsoleColor.Red);
                response = "No partition, disk and format specified!";
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