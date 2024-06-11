using BootNET.Graphics;
using BootNET.Graphics.Hardware;
using Cosmos.Core.Memory;
using Cosmos.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Kernel = BootNET.Core.Program;

namespace BootNET.GUI
{
    public static class Desktop
    {
        public static ushort ScreenWidth;
        public static ushort ScreenHeight;
        static readonly int[] cursor = new int[]
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
        public static List<App> apps = new();
        public static Color avgCol;
        public static Canvas programlogo = Image.FromBitmap(Core.Resources.rawProgram);
        static Dock dock;
        public static void Initialize()
        {
            ScreenWidth = Kernel.Screen.Width;
            ScreenHeight = Kernel.Screen.Height;
            MouseManager.ScreenWidth = ScreenWidth;
            MouseManager.ScreenHeight = ScreenHeight;
            MouseManager.X = MouseManager.ScreenWidth / 2;
            MouseManager.Y = MouseManager.ScreenHeight / 2;
            avgCol = Color.LightPurple;
            dock = new();
            apps.Add(new TestApp(300, 200, 30, 30));
        }
        public static void Update()
        {
            Kernel.Screen.Clear();
            // Wallpaper: Kernel.Screen.DrawImage(0, 0, wallpaper, false);
            foreach (App app in apps)
            {
                app.Update();
            }
            dock.Update();
            DrawCursor(Kernel.Screen, (int)MouseManager.X, (int)MouseManager.Y);
            Kernel.Screen.Update();
            Heap.Collect();
        }
        static void DrawCursor(Canvas canvas, int x, int y)
        {
            for (int h = 0; h < 19; h++)
            {
                for (int w = 0; w < 12; w++)
                {
                    if (cursor[h * 12 + w] == 1)
                    {
                        canvas[w + x, h + y] = Color.Black;
                    }
                    if (cursor[h * 12 + w] == 2)
                    {
                        canvas[w + x, h + y] = Color.White;
                    }
                }
            }
        }
    }
}
