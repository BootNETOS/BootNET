using Cosmos.System;
using Cosmos.System.Graphics.Fonts;
using System;
using System.ComponentModel;
using System.Drawing;

namespace BootNet.GUI.UILib
{
    public class TextButton : Control
    {
        public string text;
        public Action a;
        public ColorPriority priority;
        public PCScreenFont font;
        Color fg;
        public TextButton(string text, int x, int y, int width, int height, Theme theme, ColorPriority priority, PCScreenFont font, Action a = null, bool visible = true) : base(x, y, width, height, theme, visible)
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
                    case ColorPriority.Primary: fg = theme.primary; break;
                    case ColorPriority.Secondary: fg = theme.secondary; break;
                }
            }
            else if (IsHovered())
            {
                fg = theme.hover;
            }
            else if (IsClicked())
            {
                if (a != null)
                {
                    a.Invoke();
                }
                else
                {
                    OnClick();
                }
                fg = theme.click;
            }
            Graphics.Canvas.DrawString(text, font, fg, x + 2, y + 2);
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
    public class OutlinedButton : Control
    {
        public string text;
        public Action a;
        public ColorPriority priority;
        public PCScreenFont font;
        Color bg;
        public OutlinedButton(string text, int x, int y, int width, int height, Theme theme, ColorPriority priority, PCScreenFont font, Action a = null, bool visible = true) : base(x, y, width, height, theme, visible)
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
                    case ColorPriority.Primary: bg = theme.primary; break;
                    case ColorPriority.Secondary: bg = theme.secondary; break;
                }
            }
            else if (IsHovered())
            {
                bg = theme.hover;
            }
            else if (IsClicked())
            {
                if (a != null)
                {
                    a.Invoke();
                }
                else
                {
                    OnClick();
                }
                bg = theme.click;
            }
            Graphics.Canvas.DrawFilledRectangle(bg, x, y, width, height);
            Graphics.Canvas.DrawString(text, font, theme.foreground, x + 2, y + 2);
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
    public class FilledButton : Control
    {
        public string text;
        public Action a;
        public ColorPriority priority;
        public PCScreenFont font;
        Color line;
        public FilledButton(string text, int x, int y, int width, int height, Theme theme, ColorPriority priority, PCScreenFont font, Action a = null, bool visible = true) : base(x, y, width, height, theme, visible)
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
                    case ColorPriority.Primary: line = theme.primary; break;
                    case ColorPriority.Secondary: line = theme.secondary; break;
                }
            }
            else if (IsHovered())
            {
                line = theme.hover;
            }
            else if (IsClicked())
            {
                if (a != null)
                {
                    a.Invoke();
                }
                else
                {
                    OnClick();
                }
                line = theme.click;
            }
            Graphics.Canvas.DrawString(text, font, theme.foreground, x + 2, y + 2);
            Graphics.Canvas.DrawRectangle(line, x, y, width, height);
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
