using System;

namespace BootNET.Shell;

public class CommandAction : Command
{
    private Action _action;

    /// <summary>
    /// Command without being forced to create a class, with actions.
    /// </summary>
    /// <param name="commandvalues">Commands values wich will be interpreted.</param>
    /// <param name="action">Action that the command will do.</param>
    public CommandAction(string[] commandvalues, Action action) : base(commandvalues)
    {
        _action = action;
    }

    /// <summary>
    /// RebootCommand
    /// </summary>
    public override void Execute()
    {
        _action();
    }
}