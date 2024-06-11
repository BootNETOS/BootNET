using Cosmos.Core;
using Cosmos.System;
using Kernel = BootNET.Core.Program;

namespace BootNET.Core
{
    public static class HardwareInfo
    {
        public static string GetGPU()
        {
            string ScreenName = Kernel.Screen.GetName();
            if (ScreenName == "SVGAIICanvas")
            {
                return "VMWareSVGAII Accelerated Display Adapter";
            }
            else
            {
                if (ScreenName == "VBECanvas")
                {
                    if (VMTools.IsVirtualBox)
                    {
                        return "VboxVGA Display Adapter (VBE)";
                    }
                    else if (VMTools.IsQEMU)
                    {
                        return "QEMU Display Adapter (VBE)";
                    }
                    else if (CPU.GetCPUVendorName().Contains("Intel"))
                    {
                        return "Intel Graphics Display Adapter (VBE)";
                    }
                    else if (CPU.GetCPUVendorName().Contains("AMD"))
                    {
                        return "AMD Radeon Graphics Display Adapter (VBE)";
                    }
                    else
                    {
                        return "VESA BIOS Extension Display Adapter (VBE)";
                    }
                }
                else
                {
                    return "Basic Display Adapter (VGA)";
                }
            }
        }
    }
}
