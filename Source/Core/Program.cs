using BootNET.Graphics;
using BootNET.Graphics.Fonts;
using BootNET.Graphics.Hardware;
using BootNET.Graphics.Hardware.VMWare;
using BootNET.Implementations.Filesystem;
using Cosmos.Core;
using Cosmos.Core.Memory;
using Cosmos.System;
using System.Threading;

namespace BootNET.Core
{
    public class Program : Kernel
    {
        #region Properties
        public static string OS_Name = "BootNET";
        public static string OS_Version = "24.07";
        public static string CPU_Vendor;
        public static string CPU_Brand_String;
        public static string CPU_CycleSpeed;
        public static string Total_RAM;
        public static string Display_Driver;
        #endregion
        #region Drivers
        public static Display Screen;
        public static NtfsCosmosVFS FileSystem;
        #endregion
        protected override void BeforeRun()
        {
            Screen = Display.GetDisplay(1280, 720);
            CPU_Vendor = CPU.GetCPUVendorName();
            CPU_Brand_String = CPU.GetCPUBrandString();
            CPU_CycleSpeed = CPU.GetCPUCycleSpeed().ToString();
            Total_RAM = CPU.GetAmountOfRAM().ToString();
            Display_Driver = HardwareInfo.GetGPU();
        }
        protected override void Run()
        {
            Screen.Clear();
            Screen.DrawString(2, 2, Display_Driver + " FPS: " + Screen.GetFPS().ToString(), Font.Fallback, Color.White);
            Screen.Update();
            Heap.Collect();
        }
    }
}
