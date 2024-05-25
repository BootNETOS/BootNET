using BootNET.Implementations.NTFS.Model;
using System.Collections.Generic;

namespace BootNET.Implementations.NTFS.IO
{
    public class DataFragmentComparer : IComparer<DataFragment>
    {
        public int Compare(DataFragment x, DataFragment y)
        {
            if (x != null && y != null) return x.StartingVCN.CompareTo(y.StartingVCN);
            return 0;
        }
    }
}
