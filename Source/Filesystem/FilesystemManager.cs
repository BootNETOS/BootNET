using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;

namespace BootNET.Filesystem
{
    /// <summary>
    /// Basic implementation of Cosmos Virtual Filesystem (<see cref="CosmosVFS"/>)
    /// </summary>
    public class FilesystemManager
    {
        #region Methods
        /// <summary>
        /// Initialize <see cref="CosmosVFS"/> using <see cref="VFSManager"/>.
        /// </summary>
        /// <param name="showInfo">Show drive info.</param>
        /// <param name="allowReinitialization">Allow reinitialization.</param>
        public static void Initialize(bool showInfo, bool allowReinitialization)
        {
            VFS = new();
            VFSManager.RegisterVFS(VFS, showInfo, allowReinitialization);
        }
        /// <summary>
        /// Format 
        /// </summary>
        /// <param name="disk">Disk number, if you have only one disk put nothing.</param>
        public static void Format(int disk = 0)
        {
            Disk SelectedDisk = VFS.Disks[disk];
            SelectedDisk.Clear();
            SelectedDisk.CreatePartition(512);
            SelectedDisk.CreatePartition((SelectedDisk.Size - 512) / 1048576);
            SelectedDisk.FormatPartition(1, "FAT32", true);
        }
        #endregion

        #region Fields
        public static CosmosVFS VFS { get; set; }
        public static Ramdisk RamDisk { get; set; }
        #endregion
    }
}
