using BootNET.Core;

namespace BootNET.Shell.Commands
{
    public class GetGpu : Command
    {
        public GetGpu(string name) : base(name) { }
        public override string Invoke(string[] args)
        {
            string response;
            if (HardwareInfo.GetGPU() == "VMWareSVGAII Accelerated Display Adapter")
            {
                response = HardwareInfo.GetGPU() + "\n Features: \n- Resolution changing \n- Accelerated Cursor support \n- Wallpaper support \n- Accelerated 3D Support";
            }
            else if (HardwareInfo.GetGPU() == "Basic Display Adapter (VGA)")
            {
                response = HardwareInfo.GetGPU() + "\n Features: \n- Resolution changing \n- Basic 2D support";
            }
            else
            {
                response = HardwareInfo.GetGPU() + "\n Features: \n- Wallpaper support \n- 3D Support";
            }
            return response;
        }
    }
}
