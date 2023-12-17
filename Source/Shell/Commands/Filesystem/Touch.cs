using BootNET.Core;
using System;

namespace BootNET.Shell.Commands.Filesystem
{
    public class Touch : Command
    {
        public Touch(string name) : base(name) { }
        public override string Invoke(string[] args)
        {
            string response;
            try
            {
                BootManager.FilesystemDriver.CreateFile(args[0]);
                response = "File created successfully.";
            }
            catch (Exception ex)
            {
                response = "Error: " + ex.Message;
            }
            return response;
        }
    }
}
