using BootNET.Graphics.Extensions;
using BootNET.Shell;
using Cosmos.System;

namespace BootNET.Core;

public class Program : Kernel
{
    public static bool TerminalMode = true;
    public static Display Canvas { get; set; }

    protected override void BeforeRun()
    {
        BootManager.Boot();
    }

    protected override void Run()
    {
        if (TerminalMode)
        {
            Terminal.Run();
        }
    }
}