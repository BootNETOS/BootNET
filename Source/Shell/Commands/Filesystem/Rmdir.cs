using System;
using System.IO;

namespace BootNET.Shell.Commands.Filesystem
{
    public class Rmdir : Command
    {
        public Rmdir(string name) : base(name) { }
        public override string Invoke(string[] args)
        {
            string response;
            try
            {
                Directory.Delete(args[0]);
                response = "Directory deleted successfully.";
            }
            catch (Exception ex)
            {
                response = "Error: " + ex.Message;
            }
            return response;
        }
    }
}
