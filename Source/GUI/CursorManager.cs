using BootNET.Core;
using Cosmos.System;
using PrismAPI.Graphics;

namespace BootNET.GUI
{
    public static class CursorManager
    {
        public static Canvas Mouse = Resources.Mouse;
        public static int LastMouseX = (int)MouseManager.X, LastMouseY = (int)MouseManager.Y, MouseOffsetX = 0, MouseOffsetY = 0;

        public static void Initialize()
        {
            MouseManager.ScreenWidth = WindowManager.Canvas.Width;
            MouseManager.ScreenHeight = WindowManager.Canvas.Height;
        }

        public static void Update()
        {
            WindowManager.Canvas.DrawImage((int)MouseManager.X - MouseOffsetX, (int)MouseManager.Y - MouseOffsetY, Mouse, true);
        }
    }
}