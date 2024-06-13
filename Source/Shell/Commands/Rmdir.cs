using Cosmos.System.FileSystem.VFS;
using System;
using Kernel = BootNET.Core.Program;

namespace BootNET.Shell.Commands
{
    public class Rmdir : Command
    {
        public Rmdir(string name) : base(name) { }
        public override string Invoke(string[] args)
        {
            string response;
            try
            {
                VFSManager.DeleteDirectory(Kernel.CurrentPath + args[0], true);
                response = "Directory deleted successfully";
            }
            catch (Exception e)
            {
                response = "Error: Unable to delete directory. Exception: " + e.Message;
            }
            return response;
        }
    }
}
