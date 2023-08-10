namespace BootNET.Graphics.Extensions.GPU.NVIDIA.Structure.BIT.BIOS;

public enum SystemCallbacks
{
    DPMSBypassCallback,
    GetTVFormatCallback, // (NTSC/PAL/etc.)
    SpreadSpectrumBypassCallback,
    DisplaySwitchBypassCallback,
    DeviceControlSettingBypassCallback,
    DDCCallBypassCallback,
    DFPCenterBypassCallback
}