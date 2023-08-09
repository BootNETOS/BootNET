using BootNET.Filesystem;
using BootNET.Core;

namespace BootNET.Shell.Commands
{
    public class DelRd : Command
    {
        public DelRd(string name) : base(name)
        {

        }
        public override string Invoke(string[] args)
        {
            string response;
            try
            {
                FilesystemManager.RamDisk.DeleteText(args[0]);
                Console.SetForegroundColor(System.ConsoleColor.Green);
                response = "File deleted successfully.";
            }
            catch (System.Exception ex)
            {
                Console.SetForegroundColor(System.ConsoleColor.Red);
                response = "Error while deleting: " + ex.Message;
            }
            return response;
        }
    }
}