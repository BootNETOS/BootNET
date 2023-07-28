using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BootNET.Core;

namespace BootNET.Installer
{
    public class TUI
    {
        public static void PrintInitialScreen()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(" " + Info.OS_Name + " " + Info.OS_Version + " Setup");
            Console.WriteLine("====================");
            Console.WriteLine();
            Console.WriteLine("Welcome to " + Info.OS_Name + " Setup.");
            Console.WriteLine();
            Console.WriteLine("This will install system files to the disk.");
            Console.WriteLine();
            Console.WriteLine("     - To setup a new installation, press ENTER");
            Console.WriteLine("     - To repair a previous installation press R (WIP)");
            Console.WriteLine("     - To quit and restart, press Q.");
        }
        public static void PrintKeyboardScreen()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(" " + Info.OS_Name + " " + Info.OS_Version + " Setup");
            Console.WriteLine("====================");
            Console.WriteLine();
            Console.WriteLine("Please your preferred keyboard map. To set it, press the number.");
            Console.WriteLine();
            Console.WriteLine("     1. US_Standard");
            Console.WriteLine("     2. DE_Standard");
            Console.WriteLine("     3. ES_Standard");
            Console.WriteLine("     4. FR_Standard");
            Console.WriteLine("     5. US_Dvorak");
            Console.WriteLine("     6. GB_Standard");
            Console.WriteLine("     7. TR_Standard");
        }
    }
}
