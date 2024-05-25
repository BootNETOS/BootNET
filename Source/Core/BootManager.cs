using Cosmos.HAL.Drivers.Audio;
using Cosmos.System.FileSystem;
using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using Cosmos.System.Network.IPv4.UDP.DHCP;
using System;

namespace BootNET.Core
{
    public static class BootManager
    {
        public static AC97 AudioDriver;
        public static bool AudioEnabled = false;
        public static CosmosVFS FilesystemDriver = new();
        public static bool FilesystemEnabled = false;
        public static DHCPClient xClient = new();
        public static bool InternetEnabled = false;
        public static void Boot()
        {
            try
            {
                VGAScreen.SetFont(PCScreenFont.Default.Data, PCScreenFont.Default.Height);
                Console.Clear();
                ConsoleEvents.Info("If you see this it means the VGA driver is working.");
            }
            catch (Exception ex)
            {
                ConsoleEvents.Fatal("Error while initializing VGA driver: " + ex.Message);
                Console.Beep();
            }
            ConsoleEvents.Info("Connecting to the internet using DHCP...");
            try
            {
                using (var xClient = new DHCPClient())
                {
                    xClient.SendDiscoverPacket();
                }
                ConsoleEvents.Success("Connected to the internet successfully.");
                InternetEnabled = true;
            }
            catch (Exception ex)
            {
                ConsoleEvents.Error("Error while initializing DHCP: " + ex.Message);
                ConsoleEvents.Warning("Internet disabled.");
                InternetEnabled = false;
            }
            ConsoleEvents.Info("Initializing audio driver...");
            try
            {
                AudioDriver = AC97.Initialize(bufferSize: 4096);
                ConsoleEvents.Success("Audio initialized successfully.");
                AudioEnabled = true;
            }
            catch (Exception ex)
            {
                ConsoleEvents.Error("Error while initializing Audio: " + ex.Message);
                ConsoleEvents.Warning("Audio disabled.");
                AudioEnabled = false;
            }
        }
    }
}
