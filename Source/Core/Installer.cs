using BootNET.Filesystem;
using Cosmos.System.ScanMaps;
using System;

namespace BootNET.Core
{
    public class Installer
    {
        public static string kbLayout;
        public static void InitialScreen()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(" " + Info.OS_Name + " " + Info.OS_Version + "Setup");
            Console.WriteLine("=========================");
            Console.WriteLine();
            Console.WriteLine("  This tool will help you setup BootNET.");
            Console.WriteLine("  - Type \"setup\" if you want to continue setup.");
            Console.WriteLine("  - Type \"q\" if you want to exit now and restart.");
            Console.WriteLine("  If you press any other key it will quit.");
            Console.WriteLine();
            Console.Write("  Your choice: ");
            string input = Console.ReadLine();
            switch (input)
            {
                case "setup": DiskSelection();
                    break;
                case "q":
                    Cosmos.System.Power.Reboot();
                    break;
                default: 
                    Cosmos.System.Power.Reboot(); 
                    break;
            }
        }
        public static void DiskSelection()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(" " + Info.OS_Name + " " + Info.OS_Version + "Setup");
            Console.WriteLine("=========================");
            Console.WriteLine();
            Console.WriteLine("  BootNET Setup will format everything contained in disk 0:\\.");
            Console.WriteLine("  We are not responsible of any damage to the disk.");
            Console.WriteLine("  - Type \"yes\" if you want to continue.");
            Console.WriteLine("  - Type \"q\" to quit and restart.");
            Console.WriteLine();
            Console.Write("  Your choice: ");
            string input = Console.ReadLine();
            switch (input)
            {
                case "yes":
                    
                    break;
                case "q":
                    Cosmos.System.Power.Reboot();
                    break;
                default:
                    Cosmos.System.Power.Reboot();
                    break;
            }
        }
        public static void DiskFormatting()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(" " + Info.OS_Name + " " + Info.OS_Version + "Setup");
            Console.WriteLine("=========================");
            Console.WriteLine();
            Console.WriteLine("  Formatting disk 0:\\...");
            FilesystemManager.Format();
            Console.WriteLine("  Done!");
            Console.WriteLine("  Press any key to continue...");
            KeyboardLayout();
        }
        public static void KeyboardLayout()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(" " + Info.OS_Name + " " + Info.OS_Version + "Setup");
            Console.WriteLine("=========================");
            Console.WriteLine();
            Console.WriteLine("  What is your preferred keyboard layout?");
            Console.WriteLine("  You can set the keyboard layout by typing the number.");
            Console.WriteLine("  If your preferred is not present, select US Standard..");
            Console.WriteLine();
            Console.WriteLine("  1. US Standard");
            Console.WriteLine("  2. US Dvorak");
            Console.WriteLine("  3. FR Standard");
            Console.WriteLine("  4. DE Standard");
            Console.WriteLine("  5. ES Standard");
            Console.WriteLine("  6. GB Standard");
            Console.WriteLine("  7. TR Standard");
            Console.WriteLine();
            Console.Write("  Your choice: ");
            string input = Console.ReadLine();
            switch(input)
            {
                case "1":
                    Cosmos.System.KeyboardManager.SetKeyLayout(new USStandardLayout());
                    kbLayout = "USStandard";
                    break;
                case "2":
                    Cosmos.System.KeyboardManager.SetKeyLayout(new US_Dvorak());
                    kbLayout = "USDvorak";
                    break;
                case "3":
                    Cosmos.System.KeyboardManager.SetKeyLayout(new FRStandardLayout());
                    kbLayout = "FRStandard";
                    break;
                case "4":
                    Cosmos.System.KeyboardManager.SetKeyLayout(new DEStandardLayout());
                    kbLayout = "DEStandard";
                    break;
                case "5":
                    Cosmos.System.KeyboardManager.SetKeyLayout(new ESStandardLayout());
                    kbLayout = "ESStandard";
                    break;
                case "6":
                    Cosmos.System.KeyboardManager.SetKeyLayout(new GBStandardLayout());
                    kbLayout = "GBStandard";
                    break;
                case "7":
                    Cosmos.System.KeyboardManager.SetKeyLayout(new TRStandardLayout());
                    kbLayout = "TRStandard";
                    break;
            }
        }
    }
}
