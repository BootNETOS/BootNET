﻿using BootNET.Graphics.Extensions;
using BootNET.Shell;
using Cosmos.System;

namespace BootNET.Core;

public class Program : Kernel
{
    public static Display Canvas { get; set; }
    public static bool TerminalMode = true;

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
        else
        {
            
        }
    }
}