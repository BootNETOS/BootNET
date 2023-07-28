using System;
using System.Collections.Generic;

namespace BootNET.Shell
{

    public class CommandManager
    {
        private readonly List<Command> commands;

        public CommandManager()
        {
            this.commands = new()
            {
                new(""),
            };
        }

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
    }
}