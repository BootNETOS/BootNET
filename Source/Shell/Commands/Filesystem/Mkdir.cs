using BootNET.Core;
using System;

namespace BootNET.Shell.Commands.Filesystem
{
    public class Mkdir : Command
    {
        public Mkdir(string name) : base(name) { }
        public override string Invoke(string[] args)
        {
            string response;
            try
            {
                BootManager.FilesystemDriver.CreateDirectory(args[0]);
                response = "Directory created successfully.";
            }
            catch (Exception ex)
            {
                response = "Error: " + ex.Message;
            }
            return response;
        }
    }
}
