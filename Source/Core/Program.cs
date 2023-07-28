using BootNET.Filesystem;
using BootNET.Installer;
using BootNET.Network;
using Cosmos.System;

namespace BootNET.Core
{
    public class Program : Kernel
    {

        protected override void BeforeRun()
        {
            BootManager.Boot();
            TUI.PrintScreen();
        }

        protected override void Run()
        {
            TaskManager.Update();
        }
    }
}
