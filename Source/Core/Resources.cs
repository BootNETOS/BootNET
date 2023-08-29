using IL2CPU.API.Attribs;
using PrismAPI.Graphics;

namespace BootNET.Core
{
    public static class Resources
    {
        [ManifestResourceStream(ResourceName = "BootNET.Media.BootLogo.bmp")]
        private readonly static byte[] rawBootLogo;
        [ManifestResourceStream(ResourceName = "BootNET.Media.Mouse.bmp")]
        private readonly static byte[] rawMouse;
        [ManifestResourceStream(ResourceName = "BootNET.Media.MouseDrag.bmp")]
        private readonly static byte[] rawMouseDrag;
        [ManifestResourceStream(ResourceName = "BootNET.Media.MouseText.bmp")]
        private readonly static byte[] rawMouseText;
        [ManifestResourceStream(ResourceName = "BootNET.Media.Link.bmp")]
        private readonly static byte[] rawLink;
        [ManifestResourceStream(ResourceName = "BootNET.Media.Busy.bmp")]
        private readonly static byte[] rawBusy;
        public static Canvas BootLogo = Image.FromBitmap(rawBootLogo);
        public static Canvas Mouse = Image.FromBitmap(rawMouse);
        public static Canvas MouseDrag = Image.FromBitmap(rawMouseDrag);
        public static Canvas MouseText = Image.FromBitmap(rawMouseText);
        public static Canvas Link = Image.FromBitmap(rawLink);
        public static Canvas Busy = Image.FromBitmap(rawBusy);
        
    }
}
