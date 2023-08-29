using System;
using BootNET.Core;
using Cosmos.HAL;
using Cosmos.System;
using PrismAPI.Graphics;
using PrismAPI.Graphics.Fonts;

namespace BootNET.GUI.Apps.Core
{
    public class Desktop : Window
    {
        private byte lastMinute = RTC.Minute;

        public static Canvas BackgroundImage = Resources.Background;
        public static bool BackgroundChangeRequest = true;
        static Color TaskbarColor = new(40, 40, 40);
        static string ClockString;
        static int ClockPosition = (Program.Canvas.Width / 2) - (Font.Fallback.MeasureString(DateTime.Now.ToString("ddd M HH:mm")) / 2);
        static int ShutdownPosition = Program.Canvas.Width - 24;
        public Desktop() : base(0, 0, WindowManager.Canvas.Width, WindowManager.Canvas.Height, "WM.Desktop") { Movable = false; }

        public override void Render()
        {
            ClockString = DateTime.Now.ToString("ddd M HH:mm");
            Contents.DrawFilledRectangle(0, 0, Width, 24, 0, TaskbarColor);
            Contents.DrawString(2, 2, "Applications",Font.Fallback,Color.White);
            Contents.DrawString(ClockPosition, 2, ClockString, Font.Fallback, Color.White);
            Contents.DrawImage(ShutdownPosition, 0, Resources.Power);
            if(MouseManager.X >= ShutdownPosition & MouseManager.X <= Width & MouseManager.Y >= 0 & MouseManager.Y <= 24)
            {
                Cosmos.System.Power.Shutdown();
            }
        }

        public override void Update()
        {
            if (BackgroundChangeRequest)
            {
                for (int y = 20; y < Program.Canvas.Height; y += Resources.Background.Height)
                    for (int x = 0; x < Program.Canvas.Width; x += Resources.Background.Width) // Tiling background image
                        Contents.DrawImage(x, y, BackgroundImage, false);

                BackgroundChangeRequest = false;
            }

            if (RTC.Minute != lastMinute)
                Render();

            if (WindowManager.FocusedWindow != WindowManager.LastFocusedWindow)
                Render();
        }
    }
}