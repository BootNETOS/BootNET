using BootNET.Implementations.NTFS.Model;
using BootNET.Implementations.NTFS.Model.Attributes;

namespace BootNET.Implementations.NTFS.IO
{
    public class NtfsFile : NtfsFileEntry
    {
        internal NtfsFile(Ntfs ntfs, FileRecord record, AttributeFileName fileName)
            : base(ntfs, record, fileName)
        {
        }

        public override string ToString()
        {
            return FileName.FileName;
        }
    }
}