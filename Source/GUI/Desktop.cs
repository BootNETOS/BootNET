﻿using BootNET.Graphics;
using Cosmos.Core.Memory;
using Cosmos.System;
using System.Collections.Generic;
using BootNET.Core;
using Kernel = BootNET.Core.Program;

namespace BootNET.GUI;

public static class Desktop
{
    public static ushort ScreenWidth;
    public static ushort ScreenHeight;
    public static List<App> apps = new();
    public static Color avgCol;
    public static Canvas programlogo = Image.FromBitmap(Core.Resources.rawProgram);
    static Dock dock;
    static readonly Canvas Cursor = Image.FromBitmap(Core.Resources.rawMouse);
    public static Terminal terminal;
    public static void Initialize()
    {
        ScreenWidth = Kernel.Screen.Width;
        ScreenHeight = Kernel.Screen.Height;
        MouseManager.ScreenWidth = ScreenWidth;
        MouseManager.ScreenHeight = ScreenHeight;
        MouseManager.X = MouseManager.ScreenWidth / 2;
        MouseManager.Y = MouseManager.ScreenHeight / 2;
        avgCol = Color.UltraViolet;
        dock = new();
        apps.Add(new TestApp(700, 500, 30, 30));
        apps.Add(new Clock(200, 200, 400, 400));
        terminal = new(700, 500, 30, 30);
        apps.Add(terminal);
    }
    public static void Update()
    {
        Kernel.Screen.Clear();
        // Wallpaper: Kernel.Screen.DrawImage(0, 0, wallpaper, false);
        foreach (App app in apps)
        {
            app.Update();
        }
        dock.Update();
        Kernel.Screen.DrawImage((int)MouseManager.X, (int)MouseManager.Y, Cursor);
        Kernel.Screen.Update();
        Heap.Collect();
    }
}
