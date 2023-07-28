using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootNET.Core
{
    public class Installer
    {
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

        }
    }
}
