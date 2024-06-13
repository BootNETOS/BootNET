/* This code is licensed under the ekzFreeUse license
 * If a license wasn't included with the program,
 * refer to https://github.com/9xbt/SVGAIITerminal/blob/main/LICENSE.md */

using BootNET.Graphics;
using BootNET.GUI;
using Cosmos.System;
using System;
namespace BootNET.Implementations.SVGAIITerminal;
public class SVGAIITerminal
{
    #region Fields

    public int Width, Height;
    public int CursorX, CursorY;
    public Color ForegroundColor = Color.White;
    public Color BackgroundColor = Color.Black;
    public bool CursorVisible = true;

    public Canvas Contents;

    public Action Update;

    #endregion

    #region Constructors

    public SVGAIITerminal(int Width, int Height, Action Update)
    {
        this.Width = Width / 8;
        this.Height = Height / 16;
        this.Update = Update;
        Contents = new Canvas((ushort)Width, (ushort)Height);
    }

    #endregion

    #region Functions

    public void Clear()
    {
        Contents.Clear();
        CursorX = 0;
        CursorY = 0;
    }

    public void Write(object str) => Write(str, ForegroundColor);

    public void Write(object str, Color color)
    {
        foreach (char c in str.ToString())
        {
            TryScroll();

            switch (c)
            {
                case '\n':
                    CursorX = 0;
                    CursorY++;
                    break;

                default:
                    Contents.DrawFilledRectangle(16 / 2 * CursorX, 16 * CursorY, Convert.ToUInt16(16 / 2), 16, 0, BackgroundColor);
                    Contents.DrawACSIIString(color, c.ToString(), 16 / 2 * CursorX, 16 * CursorY);
                    CursorX++;
                    break;
            }
        }

        Update?.Invoke();
    }

    public void WriteLine(object str = null) => Write(str + "\n");

    public void WriteLine(object str, Color color) => Write(str + "\n", color);

    public void DrawImage(Canvas image, bool alpha = false)
    {
        if (image == null)
        {
            throw new ArgumentNullException(nameof(image));
        }

        CursorY += image.Height / 16;

        TryScroll();

        Contents.DrawImage(16 / 2 * CursorX, 16 * CursorY - (image.Height), image, alpha);

        Update?.Invoke();
    }

    public ConsoleKeyInfo ReadKey(bool intercept = false)
    {
        while (true)
        {
            TryDrawCursor();

            if (KeyboardManager.TryReadKey(out var key))
            {
                if (intercept == false)
                {
                    Write(key.KeyChar);
                }

                bool xShift = (key.Modifiers & ConsoleModifiers.Shift) == ConsoleModifiers.Shift;
                bool xAlt = (key.Modifiers & ConsoleModifiers.Alt) == ConsoleModifiers.Alt;
                bool xControl = (key.Modifiers & ConsoleModifiers.Control) == ConsoleModifiers.Control;

                return new ConsoleKeyInfo(key.KeyChar, key.Key.ToConsoleKey(), xShift, xAlt, xControl);
            }
            else
            {
                Update?.Invoke();
            }
        }
    }

    public string LastInput;

    public bool reading = false;

    public string ReadLine()
    {
        ForceDrawCursor();

        int startX = CursorX, startY = CursorY;
        string returnValue = string.Empty;

        reading = true;
        while (reading)
        {
            TryDrawCursor();

            if (KeyboardManager.TryReadKey(out var key))
            {
                switch (key.Key)
                {
                    case ConsoleKeyEx.Enter:
                        Contents.DrawFilledRectangle(16 / 2 * CursorX, 16 * CursorY, Convert.ToUInt16(16 / 2), 16, 0, BackgroundColor);
                        CursorX = 0;
                        CursorY++;
                        TryScroll();
                        LastInput = returnValue;
                        reading = false;
                        break;

                    case ConsoleKeyEx.Backspace:
                        if (!(CursorX == startX && CursorY == startY))
                        {
                            if (CursorX == 0)
                            {
                                Contents.DrawFilledRectangle(16 / 2 * CursorX, 16 * CursorY, Convert.ToUInt16(16 / 2), 16, 0, BackgroundColor);
                                CursorY--;
                                CursorX = Contents.Width / (16 / 2) - 1;
                                Contents.DrawFilledRectangle(16 / 2 * CursorX, 16 * CursorY, Convert.ToUInt16(16 / 2), 16, 0, BackgroundColor);
                            }
                            else
                            {
                                Contents.DrawFilledRectangle(16 / 2 * CursorX, 16 * CursorY, Convert.ToUInt16(16 / 2), 16, 0, BackgroundColor);
                                CursorX--;
                                Contents.DrawFilledRectangle(16 / 2 * CursorX, 16 * CursorY, Convert.ToUInt16(16 / 2), 16, 0, BackgroundColor);
                            }

                            returnValue = returnValue.Remove(returnValue.Length - 1); // Remove the last character of the string
                        }

                        ForceDrawCursor();
                        break;

                    case ConsoleKeyEx.Tab:
                        Write('\t');
                        returnValue += new string(' ', 4);

                        ForceDrawCursor();
                        break;

                    case ConsoleKeyEx.UpArrow:
                        SetCursorPosition(startX, startY);
                        Write(new string(' ', returnValue.Length));
                        SetCursorPosition(startX, startY);
                        Write(LastInput);
                        returnValue = LastInput;

                        ForceDrawCursor();
                        break;

                    default:
                        if (KeyboardManager.ControlPressed)
                        {
                            if (key.Key == ConsoleKeyEx.L)
                            {
                                Clear();
                                returnValue = string.Empty;
                                reading = false;
                            }
                        }
                        else
                        {
                            Write(key.KeyChar.ToString());
                            TryScroll();
                            returnValue += key.KeyChar;
                        }

                        ForceDrawCursor();
                        break;
                }
            }

            Update?.Invoke();
        }

        reading = false;
        return returnValue;
    }

    public void SetCursorPosition(int x, int y)
    {
        CursorX = x;
        CursorY = y;
    }

    public (int Left, int Top) GetCursorPosition()
    {
        return (CursorX, CursorY);
    }

    public static void Beep(uint freq = 800, uint duration = 125)
    {
        PCSpeaker.Beep(freq, duration);
    }

    public void TryScroll()
    {
        if (CursorX >= Width)
        {
            CursorX = 0;
            CursorY++;
        }

        while (CursorY >= Height)
        {
            Contents.DrawImage(0, -16, Contents, false);
            Contents.DrawFilledRectangle(0, Contents.Height - 16, Contents.Width, 16, 0, BackgroundColor);
            Update?.Invoke();
            CursorY--;
        }
    }

    public void ForceDrawCursor()
    {
        Contents.DrawFilledRectangle(16 / 2 * CursorX, 16 * CursorY, Convert.ToUInt16(16 / 2), 16, 0, ForegroundColor);
        Update?.Invoke();
    }

    public void TryDrawCursor()
    {
        if (Cosmos.HAL.RTC.Second != lastSecond)
        {
            Contents.DrawFilledRectangle(16 / 2 * CursorX, 16 * CursorY, Convert.ToUInt16(16 / 2), 16, 0, cursorState ? ForegroundColor : BackgroundColor);
            Update?.Invoke();

            lastSecond = Cosmos.HAL.RTC.Second;
            cursorState = !cursorState;
        }
    }

    #endregion

    #region Private fields

    private byte lastSecond = Cosmos.HAL.RTC.Second;
    private bool cursorState = true;

    #endregion
}