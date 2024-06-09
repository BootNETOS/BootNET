using GrapeGL.Graphics;
using GrapeGL.Graphics.Fonts;
using IL2CPU.API.Attribs;

namespace BootNET.Core
{
    public static class Resources
    {
        [ManifestResourceStream(ResourceName = "BootNET.Resources.DefaultFont.btf")] public static byte[] rawFont;
        public static BtfFontFace Font = new(rawFont, 16);

        [ManifestResourceStream(ResourceName = "BootNET.Resources.mango.bmp")] private static byte[] rawLogo;
        public static Canvas Logo = Image.FromBitmap(rawLogo, false);

        [ManifestResourceStream(ResourceName = "BootNET.Resources.Mouse.bmp")] private static byte[] rawMouse;
        public static Canvas Mouse;

        [ManifestResourceStream(ResourceName = "BootNET.Resources.MouseText.bmp")] private static byte[] rawMouseText;
        public static Canvas MouseText;

        [ManifestResourceStream(ResourceName = "BootNET.Resources.MouseDrag.bmp")] private static byte[] rawMouseDrag;
        public static Canvas MouseDrag;

        [ManifestResourceStream(ResourceName = "BootNET.Resources.Busy.bmp")] private static byte[] rawBusy;
        public static Canvas Busy;

        [ManifestResourceStream(ResourceName = "BootNET.Resources.Link.bmp")] private static byte[] rawLink;
        public static Canvas Link;

        [ManifestResourceStream(ResourceName = "BootNET.Resources.Error.bmp")] private static byte[] rawError;
        public static Canvas Error;

        [ManifestResourceStream(ResourceName = "BootNET.Resources.Background.bmp")] private static byte[] rawBackground;
        public static Canvas Background;

        public static void GenerateFont() => Font = new BtfFontFace(rawFont, 16);

        public static void Initialize()
        {
            Mouse = Image.FromBitmap(rawMouse, false);
            MouseText = Image.FromBitmap(rawMouseText, false);
            MouseDrag = Image.FromBitmap(rawMouseDrag, false);
            Busy = Image.FromBitmap(rawBusy, false);
            Link = Image.FromBitmap(rawLink, false);
            Error = Image.FromBitmap(rawError, false);
            Background = Image.FromBitmap(rawBackground, false);
        }
    }
}