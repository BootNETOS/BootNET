using Cosmos.System.FileSystem.VFS;
using System;
using Kernel = BootNET.Core.Program;

namespace BootNET.Shell.Commands
{
    public class Mkdir : Command
    {
        public Mkdir(string name) : base(name) { }
        public override string Invoke(string[] args)
        {
            string response;
            try
            {
                VFSManager.CreateDirectory(Kernel.CurrentPath + args[0]);
                response = "Directory created successfully";
            }
            catch (Exception e)
            {
                response = "Error: Unable to create directory. Exception: " + e.Message;
            }
            return response;
        }
    }
}
