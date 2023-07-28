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
        public static void PrintScreen()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
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
            Console.WriteLine("     - To repair a previous installation press R");
            Console.WriteLine("     - To quit and restart, press Q.");
        }
    }
}
