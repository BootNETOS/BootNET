using BootNET.Graphics;
using BootNET.Graphics.Drivers;
using Cosmos.System;
using System.Drawing;

namespace BootNET.Core
{
    public class Program : Kernel
    {
        Screen Display;
        ushort pixelx, pixely;
        protected override void BeforeRun()
        {
            Display = new SVGAIIScreen();
            pixelx = Display.Width / 2;
            Display.SetPixel(pixelx, pixely, Color.White.ToArgb());
        }
        protected override void Run()
        {
        }
    }
}
