using Cosmos.Core.Multiboot;
using Cosmos.HAL.Drivers.Video;
using System;
using System.Drawing;

namespace BootNET.Graphics.Drivers
{
    public unsafe class VBEScreen : Screen
    {
        public VBEDriver Device;
        public ushort width;
        public ushort height;
        public ushort depth;
        internal int Stride;
        internal int Pitch;
        internal int BytesPerPixel;
        Color color;
        public VBEScreen() : this((ushort)Multiboot2.Framebuffer->Width, (ushort)Multiboot2.Framebuffer->Height, Multiboot2.Framebuffer->Bpp) { }
        public VBEScreen(ushort width, ushort height, ushort depth)
        {
            if (Multiboot2.IsVBEAvailable)
            {
                width = (ushort)Multiboot2.Framebuffer->Width;
                height = (ushort)Multiboot2.Framebuffer->Height;
                depth = Multiboot2.Framebuffer->Bpp;
                this.width = width;
                this.height = height;
                this.depth = depth;
                Stride = depth / 8;
                Pitch = width * BytesPerPixel;
                BytesPerPixel = depth / 8;
            }
            Device = new(width, height, depth);
        }
        public override ushort Width => width;
        public override ushort Height => height;
        public override ushort Depth => depth;
        public override void Update(bool doublebuffered = false)
        {
            Device.Swap();
        }
        public override void Clear(uint color)
        {
            Device.ClearVRAM(color);
        }
        public override void SetPixel(ushort x, ushort y, ushort color)
        {
            this.color = Color.FromArgb(color);
            uint offset;
            offset = (uint)GetPointOffset(x, y);

            if (this.color.A < 255)
            {
                if (this.color.A == 0)
                {
                    return;
                }
                this.color = AlphaBlend(this.color, GetPointColor(x, y), this.color.A);
            }

            Device.SetVRAM(offset, this.color.B);
            Device.SetVRAM(offset + 1, this.color.G);
            Device.SetVRAM(offset + 2, this.color.R);
            Device.SetVRAM(offset + 3, this.color.A);
        }
        public override void SetMode(ushort width, ushort height, ushort depth = 32)
        {
            try
            {
                Device.VBESet(width, height, depth);
                this.width = width;
                this.height = height;
                this.depth = depth;
                Stride = depth / 8;
                Pitch = width * BytesPerPixel;
                BytesPerPixel = depth / 8;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception while changing resolution: " + ex.Message);
            }
        }
        public override void Disable()
        {
            Device.DisableDisplay();
        }
        public override void DefineCursor(uint x, uint y, bool visible)
        {
            throw new NotImplementedException("DefineCursor is not available when using VBE.");
        }
        public override void DefineAlphaCursor(uint x, uint y, ushort width, ushort height, bool visible, int[] data)
        {
            throw new NotImplementedException("DefineAlphaCursor is not available when using VBE.");
        }
        public override void SetCursor(uint x, uint y, bool visible)
        {
            throw new NotImplementedException("SetCursor is not available when using VBE.");
        }
        internal int GetPointOffset(ushort x, ushort y)
        {
            return (x * Stride) + (y * Pitch);
        }
        private Color GetPointColor(ushort aX, ushort aY)
        {
            uint offset = (uint)GetPointOffset(aX, aY);
            return Color.FromArgb((int)Device.GetVRAM(offset));
        }
        private static Color AlphaBlend(Color to, Color from, byte alpha)
        {
            byte R = (byte)(((to.R * alpha) + (from.R * (255 - alpha))) >> 8);
            byte G = (byte)(((to.G * alpha) + (from.G * (255 - alpha))) >> 8);
            byte B = (byte)(((to.B * alpha) + (from.B * (255 - alpha))) >> 8);
            return Color.FromArgb(R, G, B);
        }
    }
}
