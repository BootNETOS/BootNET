using Cosmos.System;
using BootNET.Graphics.Extensions;

namespace BootNET.Core
{
    public class Program : Kernel
    {
        protected override void BeforeRun()
        {
            BootManager.Boot();
            GraphicalConsole.Initialize(1280,720);        
        }

        protected override void Run()
        {
            System.Console.WriteLine("It works!");
        }
    }
}
