using System.IO;
using Kernel = BootNET.Core.Program;

namespace BootNET.Shell.Commands
{
    public class Cd : Command
    {
        public Cd(string name) : base(name) { }
        public override string Invoke(string[] args)
        {
            if (Directory.Exists(args[0]))
            {
                Kernel.CurrentPath = args[0];
            }
            return "";
        }
    }
}