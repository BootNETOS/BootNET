using BootNET.GUI;

namespace BootNET.Shell.Commands
{
    public class Echo : Command
    {
        public Echo(string name) : base(name) { }
        public override string Invoke(string[] args)
        {
            foreach (var s in args)
            {
                Desktop.terminal.Console.Write(s + " ");
            }
            return "";
        }
    }
}
