using System.IO;
using Console = BootNET.Core.Console;
using System;

namespace BootNET.Shell.Commands.Filesystem;

public class Ls : Command
{
    public Ls(string name) : base(name)
    {
        
    }

    public override string Invoke(string[] args)
    {
        string response = string.Empty;
        try
        {
            if (args[0] != "")
            {
                response += "Directories: \n";
                foreach (var dir in Directory.GetDirectories(args[0]))
                {
                    response += dir + "\n";
                }

                response += "Files: \n";
                foreach (var file in Directory.GetFiles(args[0]))
                {
                    response += file + "\n";
                }
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