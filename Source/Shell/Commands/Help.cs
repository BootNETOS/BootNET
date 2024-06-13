using BootNET.GUI;
using BootNET.Implementations.SVGAIITerminal;
using System;
using Kernel = BootNET.Core.Program;
namespace BootNET.Shell.Commands
{
    public class Help : Command
    {
        public Help(string name) : base(name) { }
        public override string Invoke(string[] args)
        {
            Desktop.terminal.Console.ForegroundColor = SVGAIIColor.Magenta;
            Desktop.terminal.Console.WriteLine(Kernel.OS_Name + " Commands");
            Desktop.terminal.Console.ForegroundColor = SVGAIIColor.White;
            Desktop.terminal.Console.WriteLine("Work in progress!");
            Desktop.terminal.Console.WriteLine("For more help visit the website: https://github.com/BootNETOS/BootNET");
            return "";
        }
    }
}
