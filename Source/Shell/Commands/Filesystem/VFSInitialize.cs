using System;
using BootNET.Filesystem;
using Console = BootNET.Core.Console;

namespace BootNET.Shell.Commands.Filesystem;

public class VFSInitialize : Command
{
    public VFSInitialize(string name) : base(name)
    {
        
    }

    public override string Invoke(string[] args)
    {
        string response;
        try
        {
            FilesystemManager.Initialize(true, true);
            Console.SetForegroundColor(ConsoleColor.Green);
            response = "Filesystem initialized successfully.";
        }
        catch (Exception ex)
        {
            Console.SetForegroundColor(ConsoleColor.Red);
            response = "Error: " + ex.Message;
        }
        return response;
    } 
}