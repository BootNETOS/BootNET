using GrapeGL.Graphics;
using Terminal = BootNET.Core.Program;

namespace BootNET.Core
{
    public static class ConsoleEvents
    {
        public static void Error(string message)
        {
            Terminal.Console.WriteLine("");
            Terminal.Console.ForegroundColor = Color.Red;
            Terminal.Console.Write("[");
            Terminal.Console.ForegroundColor = Color.Red;
            Terminal.Console.Write("ERROR");
            Terminal.Console.ForegroundColor = Color.White;
            Terminal.Console.Write("]: ");
            Terminal.Console.Write(message);
            Terminal.Console.ResetColor();
        }
        public static void Warning(string message)
        {
            Terminal.Console.WriteLine("");
            Terminal.Console.ForegroundColor = Color.White;
            Terminal.Console.Write("[");
            Terminal.Console.ForegroundColor = Color.Yellow;
            Terminal.Console.Write("WARN");
            Terminal.Console.ForegroundColor = Color.White;
            Terminal.Console.Write("]: ");
            Terminal.Console.Write(message);
            Terminal.Console.ResetColor();
        }
        public static void Okay(string message)
        {
            Terminal.Console.WriteLine("");
            Terminal.Console.ForegroundColor = Color.White;
            Terminal.Console.Write("[");
            Terminal.Console.ForegroundColor = Color.Blue;
            Terminal.Console.Write("OK");
            Terminal.Console.ForegroundColor = Color.White;
            Terminal.Console.Write("]: ");
            Terminal.Console.Write(message);
            Terminal.Console.ResetColor();
        }
        public static void Success(string message)
        {
            Terminal.Console.WriteLine("");
            Terminal.Console.ForegroundColor = Color.White;
            Terminal.Console.Write("[");
            Terminal.Console.ForegroundColor = Color.Green;
            Terminal.Console.Write("SUCCESS");
            Terminal.Console.ForegroundColor = Color.White;
            Terminal.Console.Write("]: ");
            Terminal.Console.Write(message);
            Terminal.Console.ResetColor();
        }
        public static void Fatal(string message)
        {
            Terminal.Console.WriteLine("");
            Terminal.Console.ForegroundColor = Color.White;
            Terminal.Console.Write("[");
            Terminal.Console.ForegroundColor = Color.RubyRed;
            Terminal.Console.Write("FATAL");
            Terminal.Console.ForegroundColor = Color.White;
            Terminal.Console.Write("]: ");
            Terminal.Console.Write(message);
            Terminal.Console.ResetColor();
        }
        public static void Info(string message)
        {
            Terminal.Console.WriteLine("");
            Terminal.Console.ForegroundColor = Color.White;
            Terminal.Console.Write("[");
            Terminal.Console.ForegroundColor = Color.Cyan;
            Terminal.Console.Write("INFO");
            Terminal.Console.ForegroundColor = Color.White;
            Terminal.Console.Write("]: ");
            Terminal.Console.Write(message);
            Terminal.Console.ResetColor();
        }
    }
}
