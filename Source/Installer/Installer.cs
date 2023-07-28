using Cosmos.System;
using Cosmos.System.ScanMaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootNET.Installer
{
    public static class Installer
    {
        static ConsoleKeyInfo info;
        static string keyboard;
        public static void InitScreen()
        {
            TUI.PrintInitialScreen();
            KeyEvent keyEvent;
            if (KeyboardManager.TryReadKey(out keyEvent))
            {
                switch (keyEvent.Key)
                {
                    case ConsoleKeyEx.Enter:
                        KeyboardSelection();
                        break;
                    case ConsoleKeyEx.Q:
                        Cosmos.System.Power.Reboot();
                        break;
                }
            }
        }
        public static void KeyboardSelection()
        {
            TUI.PrintKeyboardScreen();
            KeyEvent keyEvent;
            if (KeyboardManager.TryReadKey(out keyEvent))
            {
                switch (keyEvent.Key)
                {
                    case ConsoleKeyEx.Num1:
                        KeyboardManager.SetKeyLayout(new USStandardLayout());
                        keyboard = "uss";
                        break;
                    case ConsoleKeyEx.Num2:
                        KeyboardManager.SetKeyLayout(new DEStandardLayout());
                        keyboard = "des";
                        break;
                    case ConsoleKeyEx.Num3:
                        KeyboardManager.SetKeyLayout(new ESStandardLayout());
                        keyboard = "ess";
                        break;
                    case ConsoleKeyEx.Num4:
                        KeyboardManager.SetKeyLayout(new FRStandardLayout());
                        keyboard = "frs";
                        break;
                    case ConsoleKeyEx.Num5:
                        KeyboardManager.SetKeyLayout(new US_Dvorak());
                        keyboard = "usd";
                        break;
                    case ConsoleKeyEx.Num6:
                        KeyboardManager.SetKeyLayout(new GBStandardLayout());
                        keyboard = "gbs";
                        break;
                    case ConsoleKeyEx.Num7:
                        KeyboardManager.SetKeyLayout(new TRStandardLayout());
                        keyboard = "trs";
                        break;
                }
            }
        }
    }
}
