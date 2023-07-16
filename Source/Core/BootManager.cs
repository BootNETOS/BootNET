using BootNet.GUI;
using System;

namespace BootNet.Core
{
    public static class BootManager
    {
        static readonly Random random = new();
        public static Task graphics = new("graphics", "Used for making desktop work.", (uint)random.Next(), Graphics.Update, true, true);
        public static void Boot()
        {
            Console.WriteLine("Starting graphical mode...");
            Graphics.Initialize();
            TaskManager.RegisterProcess(graphics);
        }
    }
}
