using BootNET.Shell.Commands.ACPI;
using BootNET.Shell.Commands.Filesystem;
using BootNET.Shell.Commands.General;
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
                //ACPI Commands
                new Halt("halt"),
                new Reboot("reboot"),
                new Shutdown("shutdown"),
                //Filesystem Commands
                new Del("del"),
                new Dir("ls"),
                new Dir("dir"),
                new Mkdir("mkdir"),
                new Rmdir("rmdir"),
                new Touch("touch"),
                //General Commands
                new Echo("echo"),
                new Run("run")
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
            return "Command \"" + label + "\" not found.";
        }
    }
}