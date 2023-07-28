using System;
using System.Collections.Generic;

namespace BootNET.Shell
{
    /// <summary>
    /// Command manager with a good amount of terminal tools.
    /// </summary>
    public class CommandManager
    {
        #region Constructors
        /// <summary>
        /// Initialize Command Manager.
        /// </summary>
        public CommandManager()
        {
            this.commands = new()
            {
                new(""),
            };
        }
        #endregion

        #region Methods
        /// <summary>
        /// Process input from a string.
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <returns>Return the output of the command.</returns>
        public string ProcessInput(string input)
        {
            string[] split = input.Split(' ');
            string label = split[0];

            List<string> args = new();

            int ctr = 0;
            foreach (string s in split)
            {
                if (ctr != 0)
                    args.Add(s);
                ++ctr;
            }

            foreach (Command cmd in this.commands)
            {
                if (cmd.name == label)
                    return cmd.Invoke(args.ToArray());

            }
            Console.ForegroundColor = ConsoleColor.Red;
            return "Command \"" + label + "\" not found.";
        }
        #endregion

        #region Fields
        public readonly List<Command> commands;
        #endregion
    }
}