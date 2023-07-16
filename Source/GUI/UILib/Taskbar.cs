using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootNet.GUI.UILib
{
    public class Taskbar : Control
    {
        public Taskbar(int x, int y,int width, int height, Theme theme, bool visible = true) : base(x, y, width, height, theme, visible)
        {

        }
        public override void Render()
        {
            Graphics.Canvas.DrawFilledRectangle(theme.background, x, y, width, height);
        }
    }
}
