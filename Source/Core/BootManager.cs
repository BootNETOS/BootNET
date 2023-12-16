using Cosmos.HAL.Drivers.Audio;
using Cosmos.System.Audio;
using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using Cosmos.System.Network.IPv4.UDP.DHCP;
using System;

namespace BootNET.Core
{
    public static class BootManager
    {
        public static AC97 AudioDriver;
        public static CosmosVFS FilesystemDriver = new();
        public static bool FilesystemEnabled = false;
        public static void Boot()
        {
            //Setting VGA Font
            VGAScreen.SetFont(PCScreenFont.Default.CreateVGAFont(), PCScreenFont.Default.Height);
            Console.Clear();
            Console.WriteLine("Connecting using Ethernet...");
            try
            {
                //DHCP Client
                using (var xClient = new DHCPClient())
                {
                    xClient.SendDiscoverPacket();
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Connected successfully.");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error while connecting: " + ex.Message);
                Console.ResetColor();
            }
            try
            {
                VFSManager.RegisterVFS(FilesystemDriver, false);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Filesystem enabled");
                Console.ResetColor();
                FilesystemEnabled = true;
            }
            catch(Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Filesystem disabled: " + ex.Message);
                Console.ResetColor();
                FilesystemEnabled = false;
            }
            try
            {
                AudioDriver = AC97.Initialize(bufferSize: 4096);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Audio disabled: " + ex.Message);
                Console.ResetColor();
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Welcome to BootNET!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }
    }
}
