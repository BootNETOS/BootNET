using BootNET.Core;
using System;

namespace BootNET.Shell
{
    /// <summary>
    /// Basic Terminal Shell.
    /// </summary>
    public static class Terminal
    {
        #region Methods
        /// <summary>
        /// Run the terminal.
        /// </summary>
        public static void Run()
        {
            Console.ResetColor();
            Console.Write(">");
            string input = Console.ReadLine();
            string response = Program.commandManager.ProcessInput(input);
            Console.WriteLine(response);
        }
        #endregion
    }
}
