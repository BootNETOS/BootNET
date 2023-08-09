using BootNET.Filesystem;
using BootNET.Core;

namespace BootNET.Shell.Commands
{
    public class WriteRd : Command
    {
        public WriteRd(string name) : base(name)
        {

        }
        public override string Invoke(string[] args)
        {
            string response;
            try
            {
                FilesystemManager.RamDisk.WriteText(args[0], args[1]);
                Console.SetForegroundColor(System.ConsoleColor.Green);
                response = "File writed successfully.";
            }
            catch (System.Exception ex)
            {
                Console.SetForegroundColor(System.ConsoleColor.Red);
                response = "Error while writing: " + ex.Message;
            }
            return response;
        }
    }
}