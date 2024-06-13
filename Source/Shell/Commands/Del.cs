using Cosmos.System.FileSystem.VFS;
using System;
using Kernel = BootNET.Core.Program;

namespace BootNET.Shell.Commands
{
    public class Del : Command
    {
        public Del(string name) : base(name) { }
        public override string Invoke(string[] args)
        {
            string response;
            try
            {
                VFSManager.DeleteFile(Kernel.CurrentPath + args[0]);
                response = "File deleted successfully";
            }
            catch (Exception e)
            {
                response = "Error: Unable to delete file. Exception: " + e.Message;
            }
            return response;
        }
    }
}
