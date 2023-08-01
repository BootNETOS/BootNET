namespace BootNET.Graphics.Extensions.GPU.NVIDIA.Structure.BIT.BIOS
{
    public enum POSTCallbacks
    {
        GetPanelID,
        GetTVFormat,
        GetBootDevice,
        GetPanelExpansion,
        PerformPOSTCompleteCallback,
        GetRAMConfiguration, // (OEM Specific – should be obsolete)
        GetTVConnectionType, // (SVIDEO/Composite/etc.)
        OEMExternalInitialization,
    }
}