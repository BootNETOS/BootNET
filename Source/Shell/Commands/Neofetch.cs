using BootNET.GUI;
using BootNET.Implementations.SVGAIITerminal;
using Kernel = BootNET.Core.Program;
namespace BootNET.Shell.Commands
{
    public class Neofetch : Command
    {
        public Neofetch(string name) : base(name) { }
        public override string Invoke(string[] args)
        {
            Desktop.terminal.Console.ForegroundColor = SVGAIIColor.Magenta;
            Desktop.terminal.Console.Write(@"  _.====.._               "); Desktop.terminal.Console.Write("   " + Kernel.OS_Name + " Version " + Kernel.OS_Version);
            Desktop.terminal.Console.WriteLine();
            Desktop.terminal.Console.Write(@" ,:._       ~-_           "); Desktop.terminal.Console.ForegroundColor = SVGAIIColor.White; Desktop.terminal.Console.Write("   ----------"); Desktop.terminal.Console.ForegroundColor = SVGAIIColor.Magenta;
            Desktop.terminal.Console.WriteLine();
            Desktop.terminal.Console.Write(@"    `\        ~-_         "); Desktop.terminal.Console.Write("   OS: "); Desktop.terminal.Console.ForegroundColor = SVGAIIColor.White; Desktop.terminal.Console.Write(Kernel.OS_Name + " x86"); Desktop.terminal.Console.ForegroundColor = SVGAIIColor.Magenta;
            Desktop.terminal.Console.WriteLine();
            Desktop.terminal.Console.Write(@"      |          `.       "); Desktop.terminal.Console.Write("   Host: "); Desktop.terminal.Console.ForegroundColor = SVGAIIColor.White; Desktop.terminal.Console.Write("host"); Desktop.terminal.Console.ForegroundColor = SVGAIIColor.Magenta;
            Desktop.terminal.Console.WriteLine();
            Desktop.terminal.Console.Write(@"     /            ~-_     "); Desktop.terminal.Console.Write("   Kernel: "); Desktop.terminal.Console.ForegroundColor = SVGAIIColor.White; Desktop.terminal.Console.Write("Cosmos Dev Kit - master branch"); Desktop.terminal.Console.ForegroundColor = SVGAIIColor.Magenta;
            Desktop.terminal.Console.WriteLine();
            Desktop.terminal.Console.Write(@"..-''               ~~--.."); Desktop.terminal.Console.Write("   Shell: "); Desktop.terminal.Console.ForegroundColor = SVGAIIColor.White; Desktop.terminal.Console.Write(Kernel.OS_Name + " Shell Version " + Kernel.OS_Version); Desktop.terminal.Console.ForegroundColor = SVGAIIColor.Magenta;
            Desktop.terminal.Console.WriteLine();
            Desktop.terminal.Console.Write(@"                          "); Desktop.terminal.Console.Write("   Resolution: "); Desktop.terminal.Console.ForegroundColor = SVGAIIColor.White; Desktop.terminal.Console.Write(Kernel.Screen.Width + "x" + Kernel.Screen.Height); Desktop.terminal.Console.ForegroundColor = SVGAIIColor.Magenta;
            Desktop.terminal.Console.WriteLine();
            Desktop.terminal.Console.Write(@"                          "); Desktop.terminal.Console.Write("   CPU: "); Desktop.terminal.Console.ForegroundColor = SVGAIIColor.White; Desktop.terminal.Console.Write(Kernel.CPU_Brand_String); Desktop.terminal.Console.ForegroundColor = SVGAIIColor.Magenta;
            Desktop.terminal.Console.WriteLine();
            Desktop.terminal.Console.Write(@"                          "); Desktop.terminal.Console.Write("   GPU: "); Desktop.terminal.Console.ForegroundColor = SVGAIIColor.White; Desktop.terminal.Console.Write(Kernel.Display_Driver); Desktop.terminal.Console.ForegroundColor = SVGAIIColor.Magenta;
            Desktop.terminal.Console.WriteLine();
            Desktop.terminal.Console.Write(@"                          "); Desktop.terminal.Console.Write("   Memory: "); Desktop.terminal.Console.ForegroundColor = SVGAIIColor.White; Desktop.terminal.Console.Write(Kernel.Total_RAM + "MB"); Desktop.terminal.Console.ForegroundColor = SVGAIIColor.Magenta;
            Desktop.terminal.Console.ForegroundColor = SVGAIIColor.White;
            return "";
        }
    }
}
