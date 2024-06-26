﻿using BootNET.Graphics;
using Cosmos.Core;
using Cosmos.System;
using System;
using Kernel = BootNET.Core.Program;

namespace BootNET.GUI;

class Dock
{
    ushort Width = 200;
    readonly ushort Height = 30;
    readonly ushort Devide = 20;
    readonly string text = "PowerOFF";
    readonly int strX = 2;
    readonly int strY = (20 - 16) / 2;
    readonly int timeX = Kernel.Screen.Width / 2 - (Kernel.DefaultFont.MeasureString("00:00") / 2);

    public void Update()
    {
        Width = (ushort)(Desktop.apps.Count * Desktop.programlogo.Width + Desktop.apps.Count * Devide);
        Kernel.Screen.DrawFilledRectangle(0, 0, Desktop.ScreenWidth, 20, 0, Desktop.avgCol);
        Kernel.Screen.DrawString(strX, strY, text, Kernel.DefaultFont, Color.White);
        Kernel.Screen.DrawString(timeX, 2, DateTime.Now.ToString("HH:mm"), Kernel.DefaultFont, Color.White);
        Kernel.Screen.DrawString(Kernel.Screen.Width - Kernel.DefaultFont.MeasureString(Kernel.Screen.GetFPS().ToString()) - 2, 2, Kernel.Screen.GetFPS().ToString(), Kernel.DefaultFont, Color.White);
        if (MouseManager.MouseState == MouseState.Left)
        {
            if (MouseManager.X > strX && MouseManager.X < strX + (text.Length * 8) && MouseManager.Y > strY && MouseManager.Y < strY + 16)
            {
                ACPI.Shutdown();
            }
        }
        Kernel.Screen.DrawFilledRectangle((Desktop.ScreenWidth - Width) / 2, Desktop.ScreenHeight - Height, Width, Height, 0, Desktop.avgCol);

        for (int i = 0; i < Desktop.apps.Count; i++)
        {
            Desktop.apps[i].dockX = Devide / 2 + ((Desktop.ScreenWidth - Width) / 2) + (Desktop.programlogo.Width * i) + (Devide * i);
            Desktop.apps[i].dockY = Desktop.ScreenHeight - Desktop.programlogo.Height - Devide / 2;
            Kernel.Screen.DrawImage(Desktop.apps[i].dockX, Desktop.apps[i].dockY, Desktop.apps[i].Icon, false);
        }
    }
}