using System;

namespace BootNET.Implementations.NTFS.Model.Enums
{
    [Flags]
    public enum AttributeResidentAllow
    {
        Resident = 1,
        NonResident = 2
    }
}