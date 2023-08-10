﻿using System;
using System.IO;
using BootNET.Audio;
using BootNET.Filesystem;
using BootNET.Network;
using Cosmos.System;
using Cosmos.System.Network.IPv4;

namespace BootNET.Core;

public static class BootManager
{
    public static bool FilesystemEnabled;
    public static bool Installed;

    /// <summary>
    ///     Boot the system.
    /// </summary>
    public static void Boot()
    {
        Console.WriteLine("Initializing Console...");
        try
        {
            Console.Initialize();
        }
        catch (Exception ex)
        {
            ErrorScreen("Error while initializing Console: " + ex.Message);
        }

        try
        {
            NetworkManager.Initialize(new Address(1, 1, 1, 1));
        }
        catch (Exception ex)
        {
            Console.SetForegroundColor(ConsoleColor.Yellow);
            Console.WriteLine("Network not connected: " + ex.Message);
            Console.SetForegroundColor(ConsoleColor.White);
        }

        try
        {
            SoundManager.Initialize();
        }
        catch (Exception ex)
        {
            Console.SetForegroundColor(ConsoleColor.Yellow);
            Console.WriteLine("Sound disabled: " + ex.Message);
            Console.SetForegroundColor(ConsoleColor.White);
        }

        try
        {
            FilesystemManager.Initialize(true, true);
            FilesystemEnabled = true;
        }
        catch (Exception ex)
        {
            Console.SetForegroundColor(ConsoleColor.Yellow);
            Console.WriteLine("Filesystem is disabled: " + ex.Message);
            Console.SetForegroundColor(ConsoleColor.White);
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

        Console.WriteLine();
    }

    /// <summary>
    ///     Print error screen.
    /// </summary>
    /// <param name="message">Message to print.</param>
    public static void ErrorScreen(string message)
    {
        Console.ResetColor();
        Console.SetForegroundColor(ConsoleColor.Red);
        Console.WriteLine("Error: " + message);
        Console.WriteLine("If it's the first time happening please read documentation on GitHub.");
        Console.WriteLine("Press enter key to reboot...");
        Console.ReadLine();
        Power.Reboot();
    }
}