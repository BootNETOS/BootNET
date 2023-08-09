using SConsole = System.Console;
using GConsole = BootNET.Graphics.Extensions.GraphicalConsole;
using System;
using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;

namespace BootNET.Core
{
    public static class Console
    {
        public static void Initialize()
        {
            try
            {
                GConsole.Initialize(1280, 720);
            }
            catch
            {
                VGAScreen.SetFont(PCScreenFont.Default.CreateVGAFont(), PCScreenFont.Default.Height);
            }
        }
        public static void Write(string text)
        {
            if (GConsole.Initialized)
            {
                GConsole.Write(text);
            }
            else
            {
                SConsole.Write(text);
            }
        }
        public static void WriteLine(string text = "")
        {
            if (GConsole.Initialized)
            {
                GConsole.WriteLine(text);
            }
            else
            {
                SConsole.WriteLine(text);
            }
        }
        public static string ReadLine()
        {
            if (GConsole.Initialized)
            {
                return GConsole.ReadLine();
            }
            else
            {
                return SConsole.ReadLine();
            }
        }
        public static void SetForegroundColor(ConsoleColor color)
        {
            if (GConsole.Initialized)
            {
                GConsole.ForegroundColor = color;
            }
            else
            {
                SConsole.ForegroundColor = color;
            }
        }
        public static void SetBackgroundColor(ConsoleColor color)
        {
            if (GConsole.Initialized)
            {
                GConsole.BackgroundColor = color;
            }
            else
            {
                SConsole.BackgroundColor = color;
            }
        }
        public static void ResetColor()
        {
            if (GConsole.Initialized)
            {
                GConsole.ResetColor();
            }
            else
            {
                SConsole.ResetColor();
            }
        }
    }
}