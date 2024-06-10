using BootNET.Implementations.Filesystem;
using Cosmos.Core;
using Cosmos.System;

namespace BootNET.Core
{
    public class Program : Kernel
    {
        public static string OS_Name = "BootNET";
        public static string OS_Version = "24.07";
        public static string CPU_Vendor = CPU.GetCPUVendorName();
        public static string CPU_Brand_String = CPU.GetCPUBrandString();
        public static string CPU_CycleSpeed = CPU.GetCPUCycleSpeed().ToString();
        public static string Total_RAM = CPU.GetAmountOfRAM().ToString();
        public 
        NtfsCosmosVFS FileSystem;
        protected override void BeforeRun()
        {
        }
        protected override void Run()
        {
            
        }
    }
}
