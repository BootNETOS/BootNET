using BootNET.Filesystem;
using BootNET.Core;

namespace BootNET.Shell.Commands
{
    public class ReadRd : Command
    {
        public ReadRd(string name) : base(name)
        {

        }
        public override string Invoke(string[] args)
        {
            string response;
            try
            {
                response = FilesystemManager.RamDisk.ReadText(args[0]);
            }
            catch (System.Exception ex)
            {
                Console.SetForegroundColor(System.ConsoleColor.Red);
                response = "Error while reading: " + ex.Message;
            }
            return response;
        }
    }
}