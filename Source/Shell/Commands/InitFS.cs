using Cosmos.System.FileSystem.VFS;
using System;
using Kernel = BootNET.Core.Program;

namespace BootNET.Shell.Commands
{
    public class InitFS : Command
    {
        public InitFS(string name) : base(name) { }
        public override string Invoke(string[] args)
        {
            string response;
            try
            {
                Kernel.FileSystem = new();
                VFSManager.RegisterVFS(Kernel.FileSystem, false, false);
                response = "Filesystem initalized sucessfully!";
            }
            catch (Exception ex)
            {
                response = "Error while initializing filesystem: " + ex.Message;
            }
            return response;
        }
    }
}
