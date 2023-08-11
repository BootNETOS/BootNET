using BootNET.Core;
using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;

namespace BootNET.Filesystem;

/// <summary>
///     Basic implementation of Cosmos Virtual Filesystem (<see cref="CosmosVFS" />)
/// </summary>
public class FilesystemManager
{
    #region Fields

    public static CosmosVFS VFS { get; set; }

    #endregion

    #region Methods

    /// <summary>
    ///     Initialize <see cref="CosmosVFS" /> using <see cref="VFSManager" />.
    /// </summary>
    /// <param name="showInfo">Show drive info.</param>
    /// <param name="allowReinitialization">Allow reinitialization.</param>
    public static void Initialize(bool showInfo, bool allowReinitialization)
    {
        VFS = new CosmosVFS();
        VFSManager.RegisterVFS(VFS, showInfo, allowReinitialization);
    }

    /// <summary>
    ///     Clear
    /// </summary>
    /// <param name="disk">Disk number, if you have only one disk put nothing.</param>
    public static void Clear(int disk = 0)
    {
        var SelectedDisk = VFS.Disks[disk];
        SelectedDisk.Clear();
    }

    public static void CreatePartition(int size, int disk = 0)
    {
        var SelectedDisk = VFS.Disks[disk];
        SelectedDisk.CreatePartition(size);
    }

    public static void FormatPartition(int disk = 0, int partition = 1, string format = "FAT32", bool quick = true)
    {
        var SelectedDisk = VFS.Disks[disk];
        SelectedDisk.FormatPartition(partition,format, quick);
    }
    #endregion
}