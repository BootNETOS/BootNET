using Cosmos.System;
using Cosmos.System.Graphics.Fonts;
using System;
using System.Drawing;

namespace BootNet.GUI.UILib
{
    public class TextButton : Button
    {
        public TextButton(string text, int x, int y, int width, int height, Theme theme, ColorPriority priority, PCScreenFont font, Action a = null, bool visible = true) : base(text, x, y, width, height, theme, priority, font, a, visible)
        {

        }
        public override void DrawButton()
        {
            Graphics.Canvas.DrawString(text, font, buttoncolor, x + 2, y + 2);
        }
    }
    public class OutlinedButton : Button
    {
        public OutlinedButton(string text, int x, int y, int width, int height, Theme theme, ColorPriority priority, PCScreenFont font, Action a = null, bool visible = true) : base(text, x, y, width, height, theme, priority, font, a, visible)
        {

        }
        public override void DrawButton()
        {
            Graphics.Canvas.DrawRectangle(buttoncolor, x, y, width, height);
            Graphics.Canvas.DrawString(text, font, theme.foreground, x + 2, y + 2);
        }
    }
    public class FilledButton : Button
    {
        public FilledButton(string text, int x, int y, int width, int height, Theme theme, ColorPriority priority, PCScreenFont font, Action a = null, bool visible = true) : base(text, x, y, width, height, theme, priority, font, a, visible)
        {

        }
        public override void DrawButton()
        {
            Graphics.Canvas.DrawFilledRectangle(buttoncolor, x, y, width, height);
            Graphics.Canvas.DrawString(text, font, theme.foreground, x + 2, y + 2);
        }
    }
    public class Button : Control
    {
        public string text;
        public Action a;
        public ColorPriority priority;
        public PCScreenFont font;
        protected Color buttoncolor;
        public Button(string text, int x, int y, int width, int height, Theme theme, ColorPriority priority, PCScreenFont font, Action a = null, bool visible = true) : base(x, y, width, height, theme, visible)
        {
            this.text = text;
            this.a = a;
            this.priority = priority;
            this.font = font;
        }
        public override void Render()
        {
            if (!IsClicked() & !IsHovered())
            {
                switch (priority)
                {
                    case ColorPriority.Primary: buttoncolor = theme.primary; break;
                    case ColorPriority.Secondary: buttoncolor = theme.secondary; break;
                }
            }
            else if (IsClicked() & IsHovered())
            {
                if (a != null)
                {
                    a.Invoke();
                }
                else
                {
                    OnClick();
                }
                buttoncolor = theme.click;
            }
            else if (IsHovered())
            {
                buttoncolor = theme.hover;
            }
        }
        public virtual void DrawButton()
        {

        }
        public virtual void OnClick()
        {

        }
        public bool IsHovered()
        {
            if (MouseManager.X >= x & MouseManager.X <= x + width & MouseManager.Y >= y & MouseManager.Y <= y + height)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsClicked()
        {
            if (MouseManager.X >= x & MouseManager.X <= x + width & MouseManager.Y >= y & MouseManager.Y <= y + height & MouseManager.MouseState == MouseState.Left)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
