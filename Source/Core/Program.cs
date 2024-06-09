using Cosmos.System;
using GrapeGL.Graphics.Fonts;
using GrapeGL.Hardware.GPU;

namespace BootNET.Core
{
    public class Program : Kernel
    {
        public static Display Screen;
        public static SVGAIITerminal.SVGAIITerminal Console;
        public static BtfFontFace TerminalFont = Resources.Font;
        protected override void BeforeRun()
        {
            Screen = Display.GetDisplay(1280, 720);
            Screen.Update();
        }
        protected override void Run()
        {
        }
    }
}
