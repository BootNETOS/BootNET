using IL2CPU.API.Attribs;

namespace BootNET.Core
{
    public static class Resources
    {
        [ManifestResourceStream(ResourceName = "BootNET.Resources.program.bmp")]
        public static byte[] rawProgram;
        [ManifestResourceStream(ResourceName = "BootNET.Resources.Mouse.bmp")]
        public static byte[] rawMouse;
    }
}