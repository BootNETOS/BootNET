using Cosmos.Core.Multiboot;
using Cosmos.HAL.Drivers.Video;
using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootNET.Graphics.Drivers
{
    public unsafe class VBEScreen : Screen
    {
        public VBEDriver Device;
        public ushort width;
        public ushort height;
        public ushort depth;
        public VBEScreen() : this((ushort)Multiboot2.Framebuffer->Width, (ushort)Multiboot2.Framebuffer->Height, Multiboot2.Framebuffer->Bpp) { }
        public VBEScreen(ushort width, ushort height, ushort depth)
        {
            if (Multiboot2.IsVBEAvailable)
            {
                width = (ushort)Multiboot2.Framebuffer->Width;
                height = (ushort)Multiboot2.Framebuffer->Height;
                depth = Multiboot2.Framebuffer->Bpp;
            }
            Device = new(width, height, depth);
        }
        public override ushort Width => width;
        public override ushort Height => height;
        public override ushort Depth => depth;
        public override void Update(bool doublebuffered = false)
        {
            throw new NotImplementedException();
        }
        public override void Clear(uint color)
        {
            throw new NotImplementedException();
        }
        public override void SetPixel(uint x, uint y, uint color)
        {
            throw new NotImplementedException();
        }
        public override void SetMode(ushort width, ushort height, ushort depth = 32)
        {
            throw new NotImplementedException();
        }
        public override void Disable()
        {
            Device.DisableDisplay();
        }
        public override void DefineCursor(uint x, uint y, bool visible)
        {
            throw new NotImplementedException();
        }
        public override void DefineAlphaCursor(uint x, uint y, ushort width, ushort height, bool visible, int[] data)
        {
            throw new NotImplementedException();
        }
        public override void SetCursor(uint x, uint y, bool visible)
        {
            throw new NotImplementedException();
        }
    }
}
