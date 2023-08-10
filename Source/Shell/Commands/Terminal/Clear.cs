using BootNET.Core;

namespace BootNET.Shell.Commands.Terminal;

public class Clear : Command
{
    public Clear(string name) : base(name)
    {
    }

    public override string Invoke(string[] args)
    {
        Console.Clear();
        return "";
    }
}