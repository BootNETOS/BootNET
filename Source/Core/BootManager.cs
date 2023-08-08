using BootNET.Audio;
using BootNET.Filesystem;
using BootNET.Network;
using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using System;
using System.IO;

namespace BootNET.Core
{
    public static class BootManager
    {
        public static bool FilesystemEnabled;
        public static bool Installed;

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
            try
            {
                FilesystemManager.Initialize(true, true);
                FilesystemEnabled = true;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Filesystem is disabled: " + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
                FilesystemEnabled = false;
            }
            Console.WriteLine("Detecting BootNET...");
            try
            {
                if (FilesystemEnabled && Directory.Exists("0:\\BootNET\\"))
                {
                    Console.Write(" Found on 0:\\");
                    Installed = true;
                }
                else
                {
                    Console.Write(" Not found on 0:\\");
                    Installed = false;
                }
            }
            catch
            {
                Installed = false;
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