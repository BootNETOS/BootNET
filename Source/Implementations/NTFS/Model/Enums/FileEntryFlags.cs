using System;

namespace BootNET.Implementations.NTFS.Model.Enums
{
    [Flags]
    public enum FileEntryFlags : ushort
    {
        FileInUse = 1,
        Directory = 2
    }
}
