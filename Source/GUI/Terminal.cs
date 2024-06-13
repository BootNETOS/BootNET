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
        private KeyEvent keyEvent;
        public readonly SVGAIITerminal Console;
        public string returnValue = string.Empty;
        public int startX = 0, startY = 0;
        public Terminal(ushort width, ushort height, int x, int y) : base(Image.FromBitmap(Core.Resources.rawTerminal), width, height, x, y)
        {
            name = "Terminal";
            Console = new(width-2, height-22, TerminalUpdate);
            Console.WriteLine("Welcome to " + Kernel.OS_Name + " Version " + Kernel.OS_Version);
            Console.WriteLine();
            DrawPrompt();
        }
        public override void AppUpdate()
        {
            TerminalUpdate();
            Console.TryDrawCursor();

            if (KeyboardManager.TryReadKey(out keyEvent))
            {
                switch (keyEvent.Key)
                {
                    case ConsoleKeyEx.Enter:
                        Console.Contents.DrawFilledRectangle(16 / 2 * Console.CursorX, 16 * Console.CursorY, System.Convert.ToUInt16(16 / 2), 16, 0, Console.BackgroundColor);
                        Console.CursorX = 0;
                        Console.CursorY++;
                        Console.TryScroll();
                        Console.LastInput = returnValue;
                        string returnstring = Kernel.commandManager.ProcessInput(returnValue);
                        Console.WriteLine(returnstring);
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
                                    Console.Contents.DrawFilledRectangle(16 / 2 * Console.CursorX, 16 * Console.CursorY, System.Convert.ToUInt16(16 / 2), 16, 0, Console.BackgroundColor);
                                    Console.CursorY--;
                                    Console.CursorX = width / (16 / 2) - 1;
                                    Console.Contents.DrawFilledRectangle(16 / 2 * Console.CursorX, 16 * Console.CursorY, System.Convert.ToUInt16(16 / 2), 16, 0, Console.BackgroundColor);
                                }
                                else
                                {
                                    Console.Contents.DrawFilledRectangle(16 / 2 * Console.CursorX, 16 * Console.CursorY, System.Convert.ToUInt16(16 / 2), 16, 0, Console.BackgroundColor);
                                    Console.CursorX--;
                                    Console.Contents.DrawFilledRectangle(16 / 2 * Console.CursorX, 16 * Console.CursorY, System.Convert.ToUInt16(16 / 2), 16, 0, Console.BackgroundColor);
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
                            if (keyEvent.Key == ConsoleKeyEx.L)
                            {
                                Console.Clear();
                                returnValue = string.Empty;
                                Console.reading = false;
                            }
                        }
                        else
                        {
                            Console.Write(keyEvent.KeyChar.ToString());
                            Console.TryScroll();
                            returnValue += keyEvent.KeyChar;
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
    }
}
