using BootNET.Graphics;
using Cosmos.Core.Memory;
using Cosmos.System;
using System.Collections.Generic;
using Kernel = BootNET.Core.Program;

namespace BootNET.GUI;

public static class Desktop
{
    public static ushort ScreenWidth;
    public static ushort ScreenHeight;
    public static List<App> apps;
    public static Color avgCol;
    public static Color backCol;
    public static Canvas programlogo;
    static Dock dock;
    static Canvas Cursor;
    public static Terminal terminal;
    public static void Initialize()
    {
        apps = new();
        programlogo = Image.FromBitmap(Core.Resources.rawProgram);
        Cursor = Image.FromBitmap(Core.Resources.rawMouse);
        ScreenWidth = Kernel.Screen.Width;
        ScreenHeight = Kernel.Screen.Height;
        MouseManager.ScreenWidth = ScreenWidth;
        MouseManager.ScreenHeight = ScreenHeight;
        MouseManager.X = MouseManager.ScreenWidth / 2;
        MouseManager.Y = MouseManager.ScreenHeight / 2;
        avgCol = new(128, 36, 171);
        backCol = Color.Black;
        dock = new();
        apps.Add(new TestApp(700, 500, 30, 30));
        apps.Add(new Clock(200, 200, 400, 400));
        apps.Add(new Notepad(300, 200, 100, 100));
        terminal = new(700, 500, 30, 30);
        apps.Add(terminal);
    }
    public static void Update()
    {
        Kernel.Screen.Clear(backCol);
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
