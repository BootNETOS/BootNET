using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootNET.Graphics
{
    public abstract class Screen
    {
        public abstract ushort Width { get; }
        public abstract ushort Height { get; }
        public abstract ushort Depth { get; }
        public abstract void Update(bool doublebuffered = false);
        public abstract void Clear(uint color);
        public abstract void SetPixel(uint x, uint y, uint color);
        public abstract void SetMode(ushort width, ushort height, ushort depth = 32);
        public abstract void Disable();
        public abstract void DefineCursor(uint x, uint y, bool visible);
        public abstract void DefineAlphaCursor(uint x, uint y, ushort width, ushort height, bool visible, int[] data);
        public abstract void SetCursor(uint x, uint y, bool visible);
    }
}
