using IL2CPU.API.Attribs;

namespace BootNET.Core
{
    public static class Resources
    {
        [ManifestResourceStream(ResourceName = "BootNET.Resources.program.bmp")]
        public static byte[] rawProgram;
        [ManifestResourceStream(ResourceName = "BootNET.Resources.Mouse.bmp")]
        public static byte[] rawMouse;
        [ManifestResourceStream(ResourceName = "BootNET.Resources.terminal.bmp")]
        public static byte[] rawTerminal;
        [ManifestResourceStream(ResourceName = "BootNET.Resources.ArialCustomCharset16.btf")]
        public static byte[] rawFont;
        [ManifestResourceStream(ResourceName = "BootNET.Resources.clock.bmp")]
        public static byte[] rawClock;
    }
}