using BootNet.GUI;
using Cosmos.System;

namespace BootNet.Core
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
