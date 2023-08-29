﻿using BootNET.Audio;
using BootNET.GUI;
using BootNET.Network;
using Cosmos.System;
using PrismAPI.Hardware.GPU;

namespace BootNET.Core
{
    public class Program : Kernel
    {
        public static Display Canvas;
        protected override void BeforeRun()
        {
            Canvas = Display.GetDisplay(1280, 720);
            BootManager.Show(Canvas);
            try
            {
                AudioManager.Initialize();
                NetworkManager.Initialize();
            }
            catch { }
            BootManager.Hide();
            Canvas.Update();
            WindowManager.Start();
        }
        protected override void Run()
        {
            WindowManager.Update();
        }
    }
}
