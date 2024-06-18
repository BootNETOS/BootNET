using BootNET.Core;
using BootNET.Graphics;
using System;
using Kernel = BootNET.Core.Program;

namespace BootNET.GUI
{
    class Clock : App
    {
        public Clock(ushort width, ushort height, int x, int y) : base(Image.FromBitmap(Resources.rawClock), width, height, x, y)
        {
            name = "Clock";
        }

        public override void AppUpdate()
        {
            DrawHand(Kernel.Screen, Color.White, (x + width / 2), (y + height / 2), DateTime.Now.Hour, 40);
            DrawHand(Kernel.Screen, Color.White, (x + width / 2), (y + height / 2), DateTime.Now.Minute, 60);
            DrawHand(Kernel.Screen, Color.Red, (x + width / 2), (y + height / 2), DateTime.Now.Second, 80);
        }

        static void DrawHand(Canvas canvas, Color color, int xStart, int yStart, int angle, int radius)
        {
            int[] sine = new int[16] { 0, 27, 54, 79, 104, 128, 150, 171, 190, 201, 221, 233, 243, 250, 254, 255 };
            int xEnd, yEnd, quadrant, x_flip, y_flip;

            quadrant = angle / 15;

            switch (quadrant)
            {
                case 0: x_flip = 1; y_flip = -1; break;
                case 1: angle = Math.Abs(angle - 30); x_flip = y_flip = 1; break;
                case 2: angle -= 30; x_flip = -1; y_flip = 1; break;
                case 3: angle = Math.Abs(angle - 60); x_flip = y_flip = -1; break;
                default: x_flip = y_flip = 1; break;
            }

            xEnd = xStart;
            yEnd = yStart;

            if (angle > sine.Length) return;

            xEnd += (x_flip * ((sine[angle] * radius) >> 8));
            yEnd += (y_flip * ((sine[15 - angle] * radius) >> 8));
            canvas.DrawLine(xStart, yStart, xEnd, yEnd, color);
        }
    }
}