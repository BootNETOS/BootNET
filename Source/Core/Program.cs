using Cosmos.System;
using GrapeGL.Graphics.Fonts;
using GrapeGL.Hardware.GPU;

namespace BootNET.Core
{
    public class Program : Kernel
    {
        public static SVGAIITerminal.SVGAIITerminal Console;
        public static Display Screen;
        static BtfFontFace TerminalFont = new(Resources.fontData, 16);
        protected override void BeforeRun()
        {
            Screen = Display.GetDisplay(1280, 720);
            Console = new(Screen.Width, Screen.Height, TerminalFont);
        }
        protected override void Run()
        {

        }
    }
}
