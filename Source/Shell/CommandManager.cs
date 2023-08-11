using System;
using System.Collections.Generic;
using BootNET.Shell.Commands.Apps;
using BootNET.Shell.Commands.Filesystem;
using BootNET.Shell.Commands.Network;
using BootNET.Shell.Commands.Terminal;
using Console = BootNET.Core.Console;

namespace BootNET.Shell;

/// <summary>
///     Command manager with a good amount of terminal tools.
/// </summary>
public class CommandManager
{
    #region Fields

    public readonly List<Command> commands;

    #endregion

    #region Constructors

    /// <summary>
    ///     Initialize Command Manager.
    /// </summary>
    public CommandManager()
    {
        commands = new List<Command>
        {
            new(""),
            new Calc("calc"),
            new Clear("clear"),
            new Echo("echo"),
            new Ping("ping"),
            new HttpServerStart("httpserver"),
            new FtpServerStart("ftpserver"),
            new Format("format"),
            new VFSInitialize("initvfs")
        };
    }

    #endregion

    #region Methods

    /// <summary>
    ///     Process input from a string.
    /// </summary>
    /// <param name="input">Input string.</param>
    /// <returns>Return the output of the command.</returns>
    public string ProcessInput(string input)
    {
        var split = input.Split(' ');
        var label = split[0];

        List<string> args = new();

        var ctr = 0;
        foreach (var s in split)
        {
            if (ctr != 0)
                args.Add(s);
            ++ctr;
        }

        foreach (var cmd in commands)
            if (cmd.name == label)
                return cmd.Invoke(args.ToArray());
        Console.SetForegroundColor(ConsoleColor.Red);
        return "Command \"" + label + "\" not found.";
    }

    #endregion
}