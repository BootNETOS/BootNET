using BootNET.Security;
using BootNET.Shell;
using Cosmos.System;

namespace BootNET.Core
{
    public class Program : Kernel
    {
        public static string Username;
        public static bool LoggedIn;
        public static CommandManager CommandManager = new();
        public static string CurrentDirectory = "0:\\";
        protected override void BeforeRun()
        {
            BootManager.Boot();
        }
        protected override void Run()
        {
            if(LoggedIn)
            {
                CommandManager.HandleConsole(Username, CurrentDirectory, System.ConsoleColor.Magenta, System.ConsoleColor.Blue, '@');
            }
        }
    }
}
