using BootNET.Filesystem;
using BootNET.Core;

namespace BootNET.Shell.Commands
{
    public class LsRd : Command
    {
        public LsRd(string name) : base(name)
        {

        }
        public override string Invoke(string[] args)
        {
            string response = string.Empty;
            try
            {
                foreach (var file in FilesystemManager.RamDisk.DirectoryListing())
                {
                    response += file + "\n";
                }
            }
            catch (System.Exception ex)
            {
                Console.SetForegroundColor(System.ConsoleColor.Red);
                response = "Error while directory listing: " + ex.Message;
            }
            return response;
        }
    }
}