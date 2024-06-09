using Cosmos.HAL.Drivers.Video;
using System;
using static Cosmos.HAL.Drivers.Video.VGADriver;

namespace BootNET.Graphics.Drivers
{
    public class VGAScreen : Screen
    {
        public VGADriver Device;
        public ushort width;
        public ushort height;
        public ushort depth;
        public VGAScreen() : this(320, 200, 8) { }
        public VGAScreen(ushort width, ushort height, ushort depth = 4)
        {
            SetMode(width, height, depth);
        }
        public override ushort Width => throw new NotImplementedException();
        public override ushort Height => throw new NotImplementedException();
        public override ushort Depth => throw new NotImplementedException();
        public override void Update(bool doublebuffered = false)
        {
            //The buffer is already copied to the screen
        }
        public override void Clear(uint color)
        {
            Device.DrawFilledRectangle(0, 0, Width, Height, color);
        }
        public override void SetPixel(ushort x, ushort y, ushort color)
        {
            Device.SetPixel(x, y, color);
        }
        public override void SetMode(ushort width, ushort height, ushort depth = 32)
        {
            Device.SetGraphicsMode(ModeToScreenSize(width, height), (VGADriver.ColorDepth)depth);
            this.width = width;
            this.height = height;
            this.depth = depth;
        }
        public override void Disable()
        {
            throw new NotImplementedException("Cannot disable VGA display.");
        }
        public override void DefineCursor(uint x, uint y, bool visible)
        {
            throw new NotImplementedException("DefineCursor is not available when using VGA.");
        }
        public override void DefineAlphaCursor(uint x, uint y, ushort width, ushort height, bool visible, int[] data)
        {
            throw new NotImplementedException("DefineAlphaCursor is not available when using VGA.");
        }
        public override void SetCursor(uint x, uint y, bool visible)
        {
            throw new NotImplementedException("SetCursor is not available when using VGA");
        }
        private static ScreenSize ModeToScreenSize(ushort width, ushort height)
        {
            if (width == 320 && height == 200)
            {
                return ScreenSize.Size320x200;
            }
            else if (width == 640 && height == 480)
            {
                return ScreenSize.Size640x480;
            }
            else if (width == 720 && height == 480)
            {
                return ScreenSize.Size720x480;
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
