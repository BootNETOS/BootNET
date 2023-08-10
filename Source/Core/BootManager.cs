using System;
using BootNET.Audio;
using BootNET.Graphics;
using BootNET.Graphics.Extensions;
using BootNET.Network;
using Cosmos.System;
using Cosmos.System.Network.IPv4;
using IL2CPU.API.Attribs;

namespace BootNET.Core;

public static class BootManager
{
    [ManifestResourceStream(ResourceName = "BootNET.Resources.BootLogo.bmp")]
    public static byte[] bootLogo;

    public static Canvas BootLogo = Image.FromBitmap(bootLogo);

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

        if (GraphicalConsole.Initialized)
        {
            Program.Canvas.DrawImage(0, GraphicalConsole.Y + 1, BootLogo, false);
            GraphicalConsole.Y += 101;
        }
        else
        {
            Console.SetForegroundColor(ConsoleColor.DarkMagenta);
            Console.WriteLine("Welcome to BootNET!");
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