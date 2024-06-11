using BootNET.Core;
using BootNET.Graphics;
using BootNET.Graphics.Fonts;
using BootNET.Implementations.SVGAIITerminal;
using Cosmos.System;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.IO;
using Kernel = BootNET.Core.Program;

namespace BootNET.GUI
{
    public class Terminal : App
    {
        private readonly Queue<KeyEvent> KeyBuffer = new();
        readonly SVGAIITerminal Console;
        public string returnValue = string.Empty;
        public int startX = 0, startY = 0;
        public Terminal(ushort width, ushort height, int x, int y) : base(Image.FromBitmap(Core.Resources.rawTerminal), width, height, x, y)
        {
            this.name = "Terminal";
            Console = new(width, height, Font.Fallback, TerminalUpdate);
        }
        public override void AppUpdate()
        {
            TerminalUpdate();
            Console.TryDrawCursor();

            if (KeyBuffer.TryDequeue(out var key))
            {
                switch (key.Key)
                {
                    case ConsoleKeyEx.Enter:
                        Console.Contents.DrawFilledRectangle(Console.Font.Size / 2 * Console.CursorX, Console.Font.Size * Console.CursorY, System.Convert.ToUInt16(Console.Font.Size / 2), Console.Font.Size, 0, Console.BackgroundColor);
                        Console.CursorX = 0;
                        Console.CursorY++;
                        Console.TryScroll();
                        Console.LastInput = returnValue;
                        switch (returnValue)
                        {
                            case "clear": Console.Clear(); break;
                            default: Console.WriteLine("Command not found."); break;
                        }
                        //Shell.Run(returnValue, Console);
                        Console.Font = Font.Fallback;
                        DrawPrompt();

                        startX = Console.CursorX;
                        startY = Console.CursorY;
                        returnValue = string.Empty;
                        break;

                    case ConsoleKeyEx.Backspace:
                        try
                        {
                            if (!(Console.CursorX == startX && Console.CursorY == startY))
                            {
                                if (Console.CursorX == 0)
                                {
                                    Console.Contents.DrawFilledRectangle(Console.Font.Size / 2 * Console.CursorX, Console.Font.Size * Console.CursorY, System.Convert.ToUInt16(Console.Font.Size / 2), Console.Font.Size, 0, Console.BackgroundColor);
                                    Console.CursorY--;
                                    Console.CursorX = width / (Console.Font.Size / 2) - 1;
                                    Console.Contents.DrawFilledRectangle(Console.Font.Size / 2 * Console.CursorX, Console.Font.Size * Console.CursorY, System.Convert.ToUInt16(Console.Font.Size / 2), Console.Font.Size, 0, Console.BackgroundColor);
                                }
                                else
                                {
                                    Console.Contents.DrawFilledRectangle(Console.Font.Size / 2 * Console.CursorX, Console.Font.Size * Console.CursorY, System.Convert.ToUInt16(Console.Font.Size / 2), Console.Font.Size, 0, Console.BackgroundColor);
                                    Console.CursorX--;
                                    Console.Contents.DrawFilledRectangle(Console.Font.Size / 2 * Console.CursorX, Console.Font.Size * Console.CursorY, System.Convert.ToUInt16(Console.Font.Size / 2), Console.Font.Size, 0, Console.BackgroundColor);
                                }

                                returnValue = returnValue.Remove(returnValue.Length - 1); // Remove the last character of the string
                            }
                        }
                        catch { }

                        Console.ForceDrawCursor();
                        break;

                    case ConsoleKeyEx.Tab:
                        Console.Write('\t');
                        returnValue += new string(' ', 4);

                        Console.ForceDrawCursor();
                        break;

                    case ConsoleKeyEx.UpArrow:
                        Console.SetCursorPosition(startX, startY);
                        Console.Write(new string(' ', returnValue.Length));
                        Console.SetCursorPosition(startX, startY);
                        Console.Write(Console.LastInput);
                        returnValue = Console.LastInput;

                        Console.ForceDrawCursor();
                        break;

                    default:
                        if (KeyboardManager.ControlPressed)
                        {
                            if (key.Key == ConsoleKeyEx.L)
                            {
                                Console.Clear();
                                returnValue = string.Empty;
                                Console.reading = false;
                            }
                        }
                        else
                        {
                            Console.Write(key.KeyChar.ToString());
                            Console.TryScroll();
                            returnValue += key.KeyChar;
                        }

                        Console.ForceDrawCursor();
                        break;
                }
            }
        }
        public void DrawPrompt()
        {
            Console.Write(">");
        }
        public void TerminalUpdate()
        {
            Kernel.Screen.DrawImage(x,y,Console.Contents, false);
        }
        public override void HandleKey(KeyEvent key)
        {
            KeyBuffer.Enqueue(key);
        }
    }
}
