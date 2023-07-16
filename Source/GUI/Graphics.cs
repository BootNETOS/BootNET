using Cosmos.System;
using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootNet.GUI
{
    public static class Graphics
    {
        public static Canvas Canvas { get; set; }
        public static void Initialize()
        {
            Canvas = FullScreenCanvas.GetFullScreenCanvas();
            MouseManager.ScreenWidth = Canvas.Mode.Width;
            MouseManager.ScreenHeight = Canvas.Mode.Height;
        }
        public static void Update()
        {
            Canvas.Clear();
            Canvas.Display();
        }
    }
}
