using PrismAPI.Graphics;
using PrismAPI.Graphics.Animation;
using PrismAPI.Hardware.GPU;
using System.Threading;

namespace BootNET.Core
{
    public static class BootManager
    {
        private static readonly AnimationController A;
        private static readonly AnimationController B;
        private static readonly ColorController C;
        private static Display Canvas = null!;
        private static bool IsEnabled;
        private static bool IsSetup;
        static BootManager()
        {
            A = new(25f, 270f, new(0, 0, 0, 0, 750), AnimationMode.Ease);
            B = new(0f, 360f, new(0, 0, 0, 0, 500), AnimationMode.Linear);
            C = new(Color.Transparent, Color.Black, new(0, 0, 0, 0, 500), AnimationMode.Ease);
            A.IsContinuous = true;
        }
        private static void Update()
        {
            if (B.IsFinished)
            {
                B.Reset();
            }

            ushort H3 = (ushort)(Canvas.Height / 3);
            ushort W2 = (ushort)(Canvas.Width / 2);
            ushort H2 = (ushort)(Canvas.Height / 2);

            Canvas.Clear();
            Canvas.DrawImage(W2 - (Resources.BootLogo.Width / 2), H2 - (Resources.BootLogo.Height / 2), Resources.BootLogo, false);

            int LengthOffset = (int)(B.Current + A.Current);
            int Offset = (int)B.Current;

            Canvas.DrawArc(W2, H2 + (H2 / 2) + (H3 / 2), 19, Color.LightGray, Offset, LengthOffset);
            Canvas.DrawArc(W2, H2 + (H2 / 2) + (H3 / 2), 20, Color.White, Offset, LengthOffset);
            Canvas.DrawArc(W2, H2 + (H2 / 2) + (H3 / 2), 21, Color.LightGray, Offset, LengthOffset);
            Canvas.Update();
        }

        public static void Show(Display Canvas)
        {
            if (IsSetup)
            {
                IsEnabled = true;
                return;
            }

            // Assign the canvas instance.
            BootManager.Canvas = Canvas;

            // Add a timer to update the screen while booting.
            Timer T = new((_) => { if (IsEnabled) { Update(); } }, null, 55, 0);
            IsEnabled = true;
            IsSetup = true;
        }

        public static void Hide()
        {
            IsEnabled = false;
            C.Reset();
        }
    }
}
