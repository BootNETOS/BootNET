using BootNET.Graphics;
using BootNET.Graphics.Hardware;
using BootNET.Graphics.Hardware.Legacy;
using BootNET.Implementations.Filesystem;
using Cosmos.Core;
using Cosmos.System;

namespace BootNET.Core
{
    public class Program : Kernel
    {
        #region Properties
        public static string OS_Name = "BootNET";
        public static string OS_Version = "24.07";
        public static string CPU_Vendor = CPU.GetCPUVendorName();
        public static string CPU_Brand_String = CPU.GetCPUBrandString();
        public static string CPU_CycleSpeed = CPU.GetCPUCycleSpeed().ToString();
        public static string Total_RAM = CPU.GetAmountOfRAM().ToString();
        #endregion
        #region Drivers
        public static Display Screen;
        public static NtfsCosmosVFS FileSystem;
        #endregion

        protected override void BeforeRun()
        {
            Screen = new VGACanvas(320, 200);
        }
        protected override void Run()
        {
            Screen.Clear();
            Screen.DrawFilledRectangle(0,0,30,30,0,Color.White);
            Screen.Update();
        }
    }
}
