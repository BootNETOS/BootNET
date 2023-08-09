using Cosmos.System;
using BootNET.Shell;

namespace BootNET.Core
{
    public class Program : Kernel
    {
        protected override void BeforeRun()
        {
            BootManager.Boot();
        }

        protected override void Run()
        {
            Terminal.Run();
        }
    }
}
