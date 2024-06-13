using BootNET.Graphics;
using BootNET.GUI;
using BootNET.Implementations.SVGAIITerminal;
using System;

namespace BootNET.Shell.Commands
{
    public class Clear : Command
    {
        public Clear(string name) : base(name) { }
        public override string Invoke(string[] args)
        {
            Desktop.terminal.Console.Clear();
            return "";
        }
    }
}
