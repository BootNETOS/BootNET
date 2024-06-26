﻿using BootNET.Shell.Commands;
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
                new Kbm("kbm"),
                new VM("vmtools"),
                new Touch("touch"),
                new Del("del"),
                new Mkdir("mkdir"),
                new Rmdir("rmdir"),
                new Run("run"),
                new InitFS("initfs"),
                new Clear("clear"),
                new Ls("ls"),
                new Ls("dir"),
                new Cd("cd"),
                new Neofetch("neofetch"),
                new Calc("calc"),
                new Echo("echo"),
                new Shutdown("shutdown"),
                new Reboot("reboot"),
                new Help("help"),
                new GetGpu("getgpu")
            };
        }

        public String ProcessInput(String input)
        {
            String[] split = input.Split(' ');
            String label = split[0];

            List<String> args = new();

            int ctr = 0;
            foreach (String s in split)
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
            return "Command \"" + label + "\" not found. Write \"help\" for help.";
        }
    }
}