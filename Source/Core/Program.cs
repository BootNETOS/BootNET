using BootNET.Security;
using BootNET.Shell;
using Cosmos.System;

namespace BootNET.Core
{
    public class Program : Kernel
    {
        public static string Username;
        public static bool LoggedIn = false;
        public static CommandManager commandManager = new();
        public static string CurrentDirectory = "0:\\";
        protected override void BeforeRun()
        {
            BootManager.Boot();
        }
        protected override void Run()
        {
            if (LoggedIn)
            {
                System.Console.Write(">");
                string input = System.Console.ReadLine();
                string response = commandManager.ProcessInput(input);
                System.Console.WriteLine(response);
            }
            else
            {
                LoginSystem.Login();
            }
        }
    }
}
