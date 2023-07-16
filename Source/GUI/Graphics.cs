using BootNet.GUI.UILib;
using Cosmos.Core.Memory;
using Cosmos.Core.Multiboot;
using Cosmos.System;
using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using System.Drawing;

namespace BootNet.GUI
{
    public static class Graphics
    {
        public static Canvas Canvas { get; set; }
        readonly static int[] cursor = new int[]
        {
                1,0,0,0,0,0,0,0,0,0,0,0,
                1,1,0,0,0,0,0,0,0,0,0,0,
                1,2,1,0,0,0,0,0,0,0,0,0,
                1,2,2,1,0,0,0,0,0,0,0,0,
                1,2,2,2,1,0,0,0,0,0,0,0,
                1,2,2,2,2,1,0,0,0,0,0,0,
                1,2,2,2,2,2,1,0,0,0,0,0,
                1,2,2,2,2,2,2,1,0,0,0,0,
                1,2,2,2,2,2,2,2,1,0,0,0,
                1,2,2,2,2,2,2,2,2,1,0,0,
                1,2,2,2,2,2,2,2,2,2,1,0,
                1,2,2,2,2,2,2,2,2,2,2,1,
                1,2,2,2,2,2,2,1,1,1,1,1,
                1,2,2,2,1,2,2,1,0,0,0,0,
                1,2,2,1,0,1,2,2,1,0,0,0,
                1,2,1,0,0,1,2,2,1,0,0,0,
                1,1,0,0,0,0,1,2,2,1,0,0,
                0,0,0,0,0,0,1,2,2,1,0,0,
                0,0,0,0,0,0,0,1,1,0,0,0
        };
        readonly static Color purple = Color.FromArgb(255, 86, 50, 213);
        public static Theme currentTheme;
        static FilledButton button = new("TestFilledButton", 2, 2, "TestFilledButton".Length * 8, 20, new Dark(), ColorPriority.Secondary, PCScreenFont.Default);
        public static void Initialize()
        {
            if (VMTools.IsVMWare)
            {
                Canvas = new SVGAIICanvas(new(640, 480, ColorDepth.ColorDepth32));
            }
            else if (Multiboot2.IsVBEAvailable)
            {
                Canvas = new VBECanvas(new(640,480,ColorDepth.ColorDepth32));
            }
            else
            {
                Canvas = new VGACanvas(new(640,480,ColorDepth.ColorDepth4));
            }
            MouseManager.ScreenWidth = Canvas.Mode.Width;
            MouseManager.ScreenHeight = Canvas.Mode.Height;
            MouseManager.X = MouseManager.ScreenWidth / 2;
            MouseManager.Y = MouseManager.ScreenHeight / 2;
            ThemeManager.RegisterTheme(new Dark());
            ThemeManager.SetTheme(new Dark());
        }
        public static void Update()
        {
            Canvas.Clear(purple);
            button.Update();
            DrawCursor(Canvas, (int)MouseManager.X, (int)MouseManager.Y);
            Heap.Collect();
            Canvas.Display();
        }
        static void DrawCursor(Canvas canvas, int x, int y)
        {
            for (int h = 0; h < 19; h++)
            {
                for (int w = 0; w < 12; w++)
                {
                    if (cursor[h * 12 + w] == 1)
                    {
                        canvas.DrawPoint(Color.White, w + x, h + y);
                    }
                    if (cursor[h * 12 + w] == 2)
                    {
                        canvas.DrawPoint(Color.Black,w+x, h + y);

                    }
                }
            }
        }
    }
}