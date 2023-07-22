using BootNET.Filesystem;
using BootNET.Network;
using Cosmos.System;

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
            TaskManager.Update();
        }
    }
}
