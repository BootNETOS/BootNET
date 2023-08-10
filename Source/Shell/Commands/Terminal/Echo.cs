namespace BootNET.Shell.Commands.Terminal;

public class Echo : Command
{
    public Echo(string name) : base(name)
    {
    }

    public override string Invoke(string[] args)
    {
        var response = string.Empty;
        if (args.Length >= 1)
            foreach (var arg in args)
                response += arg + " ";
        else
            response = string.Empty;
        return response;
    }
}