using System;

namespace BootNET.Implementations.NTFS.Model.Enums
{
    [Flags]
    public enum MFTIndexRootFlags
    {
        SmallIndex = 0x00,
        LargeIndex = 0x01
    }
}