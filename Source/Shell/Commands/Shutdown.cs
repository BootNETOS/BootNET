using Cosmos.System;

namespace BootNET.Shell.Commands
{
    public class Shutdown : Command
    {
        public Shutdown(string name) : base(name) { }
        public override string Invoke(string[] args)
        {
            Power.Shutdown();
            return "";
        }
    }
}
