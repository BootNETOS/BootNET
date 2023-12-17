using BootNET.Core;
using System;

namespace BootNET.Shell.Commands.Filesystem
{
    public class Dir : Command
    {
        public Dir(string name) : base(name) { }
        public override string Invoke(string[] args)
        {
            string response = "";
            try
            {
                var dir_list = BootManager.FilesystemDriver.GetDirectoryListing(args[0]);
                foreach (var dir in dir_list)
                {
                    response = dir + "\n";
                }
            }
            catch(Exception ex)
            {
                response = "Error: " + ex.Message;
            }
            return response;
        }
    }
}
