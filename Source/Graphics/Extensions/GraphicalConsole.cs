using System;
using BootNET.Core;
using BootNET.Graphics.Fonts;
using Cosmos.HAL;
using IL2CPU.API.Attribs;
using Console = System.Console;
using Kernel = BootNET.Core.Program;

namespace BootNET.Graphics.Extensions;

/// <summary>
///     Graphical Console class, used to write text output to a high resolution console.
///     Supports images, shapes, and everything else.
/// </summary>
[Plug(Target = typeof(Console))]
public static class GraphicalConsole
{
    #region Methods

    #region WriteLine

    public static void WriteLine(string Format, object Value1, object Value2, object Value3)
    {
        WriteLine(string.Format(Format, Value1, Value2, Value3));
    }

    public static void WriteLine(string Format, object Value1, object Value2)
    {
        WriteLine(string.Format(Format, Value1, Value2));
    }

    public static void WriteLine(string Format, params object[] Value)
    {
        WriteLine(string.Format(Format, Value));
    }

    public static void WriteLine(char[] Value, int Index, int Count)
    {
        WriteLine(Value[Index..(Index + Count)]);
    }

    public static void WriteLine(string Format, object Value)
    {
        WriteLine(string.Format(Format, Value));
    }

    public static void WriteLine(string Value)
    {
        Write(Value + Environment.NewLine);
    }

    public static void WriteLine(object Value)
    {
        WriteLine(Value ?? string.Empty);
    }

    public static void WriteLine(char[] Value)
    {
        WriteLine(new string(Value));
    }

    public static void WriteLine(double Value)
    {
        WriteLine(Value.ToString());
    }

    public static void WriteLine(float Value)
    {
        WriteLine(Value.ToString());
    }

    public static void WriteLine(ulong Value)
    {
        WriteLine(Value.ToString());
    }

    public static void WriteLine(bool Value)
    {
        WriteLine(Value.ToString());
    }

    public static void WriteLine(long Value)
    {
        WriteLine(Value.ToString());
    }

    public static void WriteLine(uint Value)
    {
        WriteLine(Value.ToString());
    }

    public static void WriteLine(int Value)
    {
        WriteLine(Value.ToString());
    }

    public static void WriteLine()
    {
        Write(Environment.NewLine);
    }

    /* Decimal type is not working yet... */
    //public static void WriteLine(decimal aDecimal) => WriteLine(aDecimal.ToString());

    #endregion

    #region ReadLine

    public static string ReadLine(bool RedirectOutput = false)
    {
        var Input = string.Empty;

        while (true)
            if (KeyboardEx.TryReadKey(out var Key))
            {
                IsCursorEnabled = false;

                switch (Key.Key)
                {
                    case ConsoleKey.Enter:
                        Write('\n');
                        IsCursorEnabled = true;
                        return Input;
                    case ConsoleKey.Backspace:
                        if (Input.Length > 0)
                        {
                            if (X < SpacingX)
                            {
                                Y -= Font.Fallback.Size;
                                X = Font.Fallback.MeasureString(Buffer.Split('\n')[Y]);
                            }
                            else
                            {
                                X -= Font.Fallback.MeasureString(Buffer[^1].ToString());
                            }

                            Buffer = Buffer[..^1];
                            Input = Input[..^1];

                            Kernel.Canvas.DrawFilledRectangle(X, Y, Font.Fallback.Size, Font.Fallback.Size, 0,
                                Color.FromConsoleColor(BackgroundColor));
                            Kernel.Canvas.Update();
                        }

                        IsCursorEnabled = true;
                        break;
                    default:
                        if (!char.IsControl(Key.KeyChar))
                        {
                            Input += Key.KeyChar;
                            if (!RedirectOutput) Write(Key.KeyChar);
                        }

                        IsCursorEnabled = true;
                        break;
                }
            }
    }

    public static string ReadLine()
    {
        return ReadLine(false);
    }

    #endregion

    #region Write

    public static void Write(string Format, object Value1, object Value2, object Value3)
    {
        Write(string.Format(Format, Value1, Value2, Value3));
    }

    public static void Write(string Format, object Value1, object Value2)
    {
        Write(string.Format(Format, Value1, Value2));
    }

    public static void Write(string Format, params object[] Value)
    {
        Write(string.Format(Format, Value));
    }

    public static void Write(string Format, object Value)
    {
        Write(string.Format(Format, Value));
    }

    public static void Write(object Value)
    {
        Write(Value ?? string.Empty);
    }

    public static void Write(char[] Value)
    {
        Write(new string(Value));
    }

    public static void Write(double Value)
    {
        Write(Value.ToString());
    }

    public static void Write(float Value)
    {
        Write(Value.ToString());
    }

    public static void Write(ulong Value)
    {
        Write(Value.ToString());
    }

    public static void Write(long Value)
    {
        Write(Value.ToString());
    }

    public static void Write(uint Value)
    {
        Write(Value.ToString());
    }

    public static void Write(int Value)
    {
        Write(Value.ToString());
    }

    public static void Write(char[] Value, int Index, int Count)
    {
        if (Value.Length - Index < Count)
            throw new ArgumentException($"Specified count '{nameof(Count)}' is more than the buffer length.");
        if (Value == null) throw new ArgumentNullException(nameof(Value));
        if (Index < 0) throw new ArgumentOutOfRangeException(nameof(Index));
        if (Count < 0) throw new ArgumentOutOfRangeException(nameof(Count));

        for (var I = 0; I < Count; I++) Write(Value[Index + I]);
    }

    public static void Write(string Value)
    {
        // Erase Cursor
        Kernel.Canvas.DrawFilledRectangle(X, Y, 1, Font.Fallback.Size, 0, Color.FromConsoleColor(BackgroundColor));

        for (var I = 0; I < Value.Length; I++) WriteCore(Value[I]);

        // Draw Cursor
        Kernel.Canvas.DrawFilledRectangle(X, Y, 1, Font.Fallback.Size, 0, Color.FromConsoleColor(BackgroundColor));
        Kernel.Canvas.Update();
    }

    public static void Write(char Value)
    {
        // Erase Cursor
        Kernel.Canvas.DrawFilledRectangle(X, Y, 1, Font.Fallback.Size, 0, Color.FromConsoleColor(BackgroundColor));

        WriteCore(Value);

        // Draw Cursor
        Kernel.Canvas.DrawFilledRectangle(X, Y, 1, Font.Fallback.Size, 0, Color.FromConsoleColor(BackgroundColor));
        Kernel.Canvas.Update();
    }

    public static void Write(bool Value)
    {
        Write(Value.ToString());
    }

    /* Decimal type is not working yet... */
    //public static void Write(decimal aDecimal) => Write(aDecimal.ToString());

    #endregion

    #region Misc

    private static void WriteCore(char C)
    {
        if (Y != Kernel.Canvas.Height - Font.Fallback.Size)
        {
            Buffer += C;

            switch (C)
            {
                case '\0':
                    break;
                case '\r':
                    break;
                case '\n':
                    X = SpacingX;
                    Y += Font.Fallback.Size;
                    break;
                case '\b':
                    X -= Font.Fallback.MeasureString(Buffer[^1].ToString());
                    break;
                case '\t':
                    X += Font.Fallback.Size * 4;
                    break;
                default:
                    if (char.IsAscii(C))
                    {
                        Kernel.Canvas.DrawFilledRectangle(X, Y, Font.Fallback.MeasureString(C.ToString()),
                            Font.Fallback.Size, 0, Color.FromConsoleColor(BackgroundColor));
                        Kernel.Canvas.DrawChar(X, Y, C, Font.Fallback, Color.FromConsoleColor(ForegroundColor), false);

                        if (X >= Kernel.Canvas.Width - SpacingX)
                        {
                            X = SpacingX;
                            Y += Font.Fallback.Size;
                        }
                        else
                        {
                            X += Font.Fallback.MeasureString(C.ToString());
                        }
                    }

                    break;
            }
        }
        else
        {
            Clear();
        }
    }

    public static void ResetColor()
    {
        ForegroundColor = ConsoleColor.White;
        BackgroundColor = ConsoleColor.Black;
    }

    public static void Clear()
    {
        X = SpacingX;
        Y = SpacingY;
        Kernel.Canvas.Clear();
        Kernel.Canvas.Update();
        Buffer = string.Empty;
    }

    public static void Initialize(ushort Width, ushort Height)
    {
        Kernel.Canvas = Display.GetDisplay(Width, Height);
        Initialized = true;
        Global.PIT.RegisterTimer(new PIT.PITTimer(() =>
        {
            if (IsCursorVisible && IsCursorEnabled)
            {
                // Draw Cursor
                Kernel.Canvas.DrawFilledRectangle(X, Y, 1, Font.Fallback.Size, 0,
                    Color.FromConsoleColor(ForegroundColor));
                Kernel.Canvas.Update();
                IsCursorVisible = false;
                return;
            }

            // Erase Cursor
            Kernel.Canvas.DrawFilledRectangle(X, Y, 1, Font.Fallback.Size, 0, Color.FromConsoleColor(BackgroundColor));
            Kernel.Canvas.Update();
            IsCursorVisible = true;
        }, 500000000, true));
    }

    public static void SetCursorPosition(int x, int y)
    {
        X = x;
        Y = y;
    }

    #endregion

    #endregion

    #region Fields

    private static bool IsCursorVisible { get; set; } = true;
    private static bool IsCursorEnabled { get; set; } = true;
    private static string Buffer { get; set; } = string.Empty;
    private static int SpacingX { get; } = 0;
    private static int SpacingY { get; } = 0;
    public static int X { get; set; }
    public static int Y { get; set; }
    public static ConsoleColor ForegroundColor { get; set; } = ConsoleColor.White;
    public static ConsoleColor BackgroundColor { get; set; } = ConsoleColor.Black;
    public static bool Initialized { get; set; }

    #endregion
}