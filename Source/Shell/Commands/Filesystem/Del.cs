using System;
using System.IO;

namespace BootNET.Shell.Commands.Filesystem
{
    public class Del : Command
    {
        public Del(string name) : base(name) { }
        public override string Invoke(string[] args)
        {
            string response;
            try
            {
                File.Delete(args[0]);
                response = "File deleted successfully.";
            }
            catch (Exception ex)
            {
                response = "Error: " + ex.Message;
            }
            return response;
        }
    }
}
