using System;

namespace BootNET.Core
{
    public static class ConsoleEvents
    {
        public static void Error(string message)
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("ERROR");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]: ");
            Console.Write(message);
            Console.ResetColor();
        }
        public static void Warning(string message)
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("WARN");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]: ");
            Console.Write(message);
            Console.ResetColor();
        }
        public static void Okay(string message)
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("OK");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]: ");
            Console.Write(message);
            Console.ResetColor();
        }
        public static void Success(string message)
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("SUCCESS");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]: ");
            Console.Write(message);
            Console.ResetColor();
        }
        public static void Fatal(string message)
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("FATAL");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]: ");
            Console.Write(message);
            Console.ResetColor();
        }
        public static void Info(string message)
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("FATAL");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]: ");
            Console.Write(message);
            Console.ResetColor();
        }
    }
}
