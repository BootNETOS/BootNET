using BootNET.Audio;
using BootNET.Filesystem;
using BootNET.Network;
using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using System;

namespace BootNET.Core
{
    public static class BootManager
    {
        /// <summary>
        /// Boot the system.
        /// </summary>
        public static void Boot()
        {
            Console.WriteLine("Initializing Console...");
            try
            {
                VGAScreen.SetFont(PCScreenFont.Default.CreateVGAFont(), PCScreenFont.Default.Height);
            }
            catch (Exception ex)
            {
                ErrorScreen("Error while initializing Console: " + ex.Message);
            }
            Console.WriteLine("Connecting to Network...");
            try
            {
                NetworkManager.Initialize(new(1, 1, 1, 1));
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Network not connected: " + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("Initializing sound...");
            try
            {
                SoundManager.Initialize();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Sound disabled: " + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("Initializing Filesystem...");
            try
            {
                FilesystemManager.Initialize(true, true);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Filesystem is disabled: " + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        /// <summary>
        /// Print error screen.
        /// </summary>
        /// <param name="message">Message to print.</param>
        public static void ErrorScreen(string message)
        {
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: " + message);
            Console.WriteLine("If it's the first time happening please read documentation on GitHub.");
            Console.WriteLine("Press any key to reboot...");
            Console.ReadKey();
            Cosmos.System.Power.Reboot();
        }
    }
}
