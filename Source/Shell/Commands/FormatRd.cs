using BootNET.Filesystem;
using BootNET.Core;

namespace BootNET.Shell.Commands
{
    public class FormatRd : Command
    {
        public FormatRd(string name) : base(name)
        {

        }
        public override string Invoke(string[] args)
        {
            string response;
            try
            {
                FilesystemManager.RamDisk.Format();
                Console.SetForegroundColor(System.ConsoleColor.Green);
                response = "Ramdisk formatted successfully.";
            }
            catch (System.Exception ex)
            {
                Console.SetForegroundColor(System.ConsoleColor.Red);
                response = "Error while formatting: " + ex.Message;
            }
            return response;
        }
    }
}