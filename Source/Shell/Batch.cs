using BootNET.Core;
using System.IO;

namespace BootNET.Shell
{
    public static class Batch
    {
        public static void Execute(string filename)
        {
            try
            {
                if (filename.EndsWith(".bat"))
                {
                    string[] lines = File.ReadAllLines(filename);
                    foreach (string line in lines)
                    {
                        if (!(line.StartsWith(";")))
                        {
                            string response = Terminal.CommandManager.ProcessInput(line);
                            BootNET.Core.Console.WriteLine(response);
                        }
                    }
                }
                else
                {
                    BootNET.Core.Console.WriteLine("This file is not a valid script.");
                }
            }
            catch (System.Exception ex)
            {
                BootNET.Core.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}