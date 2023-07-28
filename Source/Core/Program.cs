using BootNET.Shell;
using Cosmos.System;

namespace BootNET.Core
{
    public class Program : Kernel
    {
        public static CommandManager commandManager;
        protected override void BeforeRun()
        {
            BootManager.Boot();

        }

        protected override void Run()
        {
        }
    }
}
