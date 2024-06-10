using Cosmos.HAL.Drivers.Video;
using System;

namespace BootNET.Graphics.Hardware.Legacy
{
    public class VGACanvas : Display
    {
        public VGACanvas(ushort Width, ushort Height) : base(Width, Height)
        {
            SetMode(Width, Height);
            _IsEnabled = true;
        }
        static VGADriver.ScreenSize ModeToScreenSize(ushort Width, ushort Height)
        {
            if (Width == 320 & Height == 200)
            {
                return VGADriver.ScreenSize.Size320x200;
            }
            else if (Width == 640 & Height == 480)
            {
                return VGADriver.ScreenSize.Size640x480;
            }
            else if (Width == 720 & Height == 480)
            {
                return VGADriver.ScreenSize.Size720x480;
            }
            else
            {
                throw new NotImplementedException("Mode not supported in VGA.");
            }
        }
        static VGADriver.ColorDepth GetColorDepth(ushort Width, ushort Height)
        {
            if (Width == 320 & Height == 200)
            {
                return VGADriver.ColorDepth.BitDepth8;
            }
            else if (Width == 640 & Height == 480)
            {
                return VGADriver.ColorDepth.BitDepth4;
            }
            else if (Width == 720 & Height == 480)
            {
                return VGADriver.ColorDepth.BitDepth4;
            }
            else
            {
                throw new NotImplementedException("Mode not supported in VGA");
            }
        }
        private void SetMode(ushort Width, ushort Height)
        {
            Device.SetGraphicsMode(ModeToScreenSize(Width, Height), GetColorDepth(Width, Height));
        }
        public override bool IsEnabled
        {
            get => _IsEnabled;
            set => Device.SetGraphicsMode(ModeToScreenSize(_Width, _Height), GetColorDepth(_Width, _Height));
        }
        public new ushort Height
        {
            get
            {
                return _Height;
            }
            set
            {
                SetMode(_Width, Height);
            }
        }

        public new ushort Width
        {
            get
            {
                return _Width;
            }
            set
            {
                SetMode(Width, _Height);
            }
        }
        public override string GetName()
        {
            return nameof(VGACanvas);
        }
        public override void DefineCursor(Canvas Cursor)
        {
            throw new NotImplementedException();
        }
        public override void SetCursor(uint X, uint Y, bool IsVisible)
        {
            throw new NotImplementedException();
        }
        public override void Update()
        {
            //Already updating
        }
        private readonly VGADriver Device;
        private readonly bool _IsEnabled;
        private readonly ushort _Width;
        private readonly ushort _Height;
    }
}
