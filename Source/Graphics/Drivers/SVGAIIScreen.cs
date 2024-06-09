using Cosmos.HAL.Drivers.Video.SVGAII;

namespace BootNET.Graphics.Drivers
{
    public class SVGAIIScreen : Screen
    {
        public VMWareSVGAII Device;
        public ushort width;
        public ushort height;
        public ushort depth;
        public SVGAIIScreen() : this(1280, 720) { }
        public SVGAIIScreen(ushort width, ushort height, ushort depth = 32)
        {
            Device = new();
            SetMode(width, height, depth);
        }
        public override ushort Width => width;
        public override ushort Height => height;
        public override ushort Depth => depth;
        public override void Update(bool doublebuffer)
        {
            if (doublebuffer == true)
            {
                Device.DoubleBufferUpdate();
            }
            else
            {
                Device.Update(0, 0, width, height);
            }
        }
        public override void Clear(uint color)
        {
            Device.Clear(color);
        }
        public override void SetPixel(ushort x, ushort y, ushort color)
        {
            Device.SetPixel(x, y, color);
        }
        public override void SetMode(ushort width, ushort height, ushort depth = 32)
        {
            Device.SetMode(width, height, depth);
            this.width = width;
            this.height = height;
            this.depth = depth;
        }
        public override void Disable()
        {
            Device.Disable();
        }
        public override void DefineCursor(uint x, uint y, bool visible)
        {
            Device.DefineCursor();
            SetCursor(x, y, visible);
        }
        public override void DefineAlphaCursor(uint x, uint y, ushort width, ushort height, bool visible, int[] data)
        {
            Device.DefineAlphaCursor(width, height, data);
            SetCursor(x, y, visible);
        }
        public override void SetCursor(uint x, uint y, bool visible)
        {
            Device.SetCursor(visible, x, y);
        }
    }
}
