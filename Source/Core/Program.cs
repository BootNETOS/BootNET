using BootNET.Graphics.Fonts;
using BootNET.Graphics.Hardware;
using BootNET.GUI;
using BootNET.Implementations.Filesystem;
using BootNET.Shell;
using Cosmos.Core;
using Cosmos.System;
using Cosmos.System.FileSystem;

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
        public static CommandManager commandManager = new();
        public static string CurrentPath = "0:\\";
        public static Font DefaultFont = new(Resources.rawFont, 16);
        #endregion
        #region Drivers
        public static Display Screen;
        public static CosmosVFS FileSystem;
        #endregion
        protected override void BeforeRun()
        {
            Screen = Display.GetDisplay(1280, 720);
            CPU_Vendor = CPU.GetCPUVendorName();
            CPU_Brand_String = CPU.GetCPUBrandString();
            CPU_CycleSpeed = CPU.GetCPUCycleSpeed().ToString();
            Total_RAM = CPU.GetAmountOfRAM().ToString();
            Display_Driver = HardwareInfo.GetGPU();
            Desktop.Initialize();
        }
        protected override void Run()
        {
            Desktop.Update();
        }
    }
}
