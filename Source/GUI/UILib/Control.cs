namespace BootNet.GUI.UILib
{
    public class Control
    {
        public int x, y, width, height;
        public Theme theme;
        public bool visible;
        public Control(int x, int y, int width, int height, Theme theme, bool visible = true)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.theme = theme;
            this.visible = visible;
        }
        public virtual void Render()
        {

        }
        public void Update()
        {
            if (visible)
            {
                Render();
            }
        }
    }
    public enum ColorPriority
    {
        Primary, Secondary
    }
}
