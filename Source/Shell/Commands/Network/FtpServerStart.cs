using System;
using System.IO;
using BootNET.Network.CosmosFtp;
using Cosmos.System.Network.Config;
using Console = BootNET.Core.Console;

namespace BootNET.Shell.Commands.Network;

public class FtpServerStart : Command
{
    private FtpServer ftpServer;
    public FtpServerStart(string name) : base(name)
    {
        
    }

    public override string Invoke(string[] args)
    {
        try
        {
            if (args[0] != "" && Directory.Exists(args[0]))
            {
                Console.WriteLine("Server listening on " + NetworkConfiguration.CurrentAddress + ":21");
                using (ftpServer = new(BootNET.Filesystem.FilesystemManager.VFS, args[0]))
                {
                    ftpServer.Listen();
                }
            }
            else
            {
                Console.SetForegroundColor(ConsoleColor.Red);
                Console.WriteLine("Error: Directory not found!");
            }
        }
        catch(Exception ex)
        {
            Console.SetForegroundColor(ConsoleColor.Red);
            Console.WriteLine("Error: " + ex.Message);
        }

        return "";
    }
}