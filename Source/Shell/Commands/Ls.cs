using BootNET.GUI;
using BootNET.Implementations.SVGAIITerminal;
using System;
using System.IO;
using Kernel = BootNET.Core.Program;

namespace BootNET.Shell.Commands
{
    public class Ls : Command
    {
        public Ls(string name) : base(name) { }
        public override string Invoke(string[] args)
        {
            try
            {
                var files = Directory.GetFiles(Kernel.CurrentPath);
                var directories = Directory.GetDirectories(Kernel.CurrentPath);
                Desktop.terminal.Console.WriteLine();
                Desktop.terminal.Console.ForegroundColor = SVGAIIColor.Magenta;
                Desktop.terminal.Console.WriteLine("Directories: ");
                Desktop.terminal.Console.ForegroundColor = SVGAIIColor.White;
                foreach (var directory in directories)
                {
                    Desktop.terminal.Console.WriteLine(directory);
                }
                Desktop.terminal.Console.ForegroundColor = SVGAIIColor.Magenta;
                Desktop.terminal.Console.WriteLine("Files:");
                Desktop.terminal.Console.ForegroundColor = SVGAIIColor.White;
                foreach (var file in files)
                {
                    Desktop.terminal.Console.WriteLine(file);
                }

            }
            catch (Exception ex)
            {
                Desktop.terminal.Console.WriteLine("Error: " + ex.Message);
            }
            return "";
        }
    }
}
