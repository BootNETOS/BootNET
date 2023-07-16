using System.Drawing;

namespace BootNet.GUI.UILib
{
    public class Theme
    {
        public Color background, foreground, primary, secondary, hover, click;
        public Theme(Color background, Color foreground, Color primary, Color secondary, Color hover, Color click)
        {
            this.background = background;
            this.foreground = foreground;
            this.primary = primary;
            this.secondary = secondary;
            this.hover = hover;
            this.click = click;
        }
    }
}
