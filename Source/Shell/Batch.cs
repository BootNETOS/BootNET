using System;
using System.IO;
using Console = BootNET.Core.Console;

namespace BootNET.Shell;

public static class Batch
{
    public static void Execute(string filename)
    {
        try
        {
            if (filename.EndsWith(".bat"))
            {
                var lines = File.ReadAllLines(filename);
                foreach (var line in lines)
                    if (!line.StartsWith(";"))
                    {
                        var response = Terminal.CommandManager.ProcessInput(line);
                        Console.WriteLine(response);
                    }
            }
            else
            {
                Console.WriteLine("This file is not a valid script.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}