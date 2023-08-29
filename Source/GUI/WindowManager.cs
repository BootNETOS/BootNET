#define SHOW_FPS

using System.Collections.Generic;
using BootNET.Core;
using Cosmos.Core.Memory;
using Cosmos.System;
using PrismAPI.Graphics.Fonts;
using PrismAPI.Hardware.GPU;
using PrismAPI.UI;

namespace BootNET.GUI
{
    public static class WindowManager
    {
        private static short framesToHeapCollect = 10;
        private static bool needToAddTerminal = false;

        public static Display Canvas = Program.Canvas;
        public static List<Window> Windows = new(10);

        public static Window FocusedWindow
        {
            get
            {
                if (Windows.Count < 1)
                    return null;

                return Windows[^1];
            }
        }

        public static Window LastFocusedWindow = null;

        public static void AddWindow(Window wnd) => Windows.Add(wnd);

        public static void RemoveWindow(Window wnd) { try { if (Windows.Contains(wnd)) Windows.Remove(wnd); } catch { } }

        public static void MoveWindowToFront(Window wnd)
        {
            if (!wnd.Name.StartsWith("WM.") && Windows[^1] != wnd)
            {
                RemoveWindow(wnd);
                AddWindow(wnd);
            }
        }

        public static int GetAmountOfWindowsByName(string wnd)
        {
            int counter = 0;

            for (int i = 0; i < Windows.Count; i++)
            {
                if (Windows[i].Name == wnd)
                    counter++;
            }

            return counter;
        }

        public static void Start()
        {
            AddWindow(new Desktop());
        }

        public static void Update()
        {
            for (int i = 0; i < Windows.Count; i++)
            {
                if (Windows[i] != null)
                {
                    Windows[i].Update();

                    Canvas.DrawImage(Windows[i].X, Windows[i].Y, Windows[i].Contents, false);
                }
            }

            if (KeyboardManager.TryReadKey(out var key))
            {
                if (KeyboardManager.AltPressed && key.Key == ConsoleKeyEx.T)
                {
                    needToAddTerminal = true;
                }
                else if (KeyboardManager.AltPressed && key.Key == ConsoleKeyEx.F4 && !FocusedWindow.Name.StartsWith("WM."))
                {
                    RemoveWindow(FocusedWindow);
                }
                else
                {
                    Windows[^1].HandleKey(key);
                }
            }

#if SHOW_FPS
            Canvas.DrawString(2, 22, $"{Canvas.GetFPS()} FPS", Font.Fallback, PrismAPI.Graphics.Color.Black);
#endif

            Canvas.Update();

            framesToHeapCollect--;

            if (framesToHeapCollect <= 0)
            {
                Heap.Collect();
                framesToHeapCollect = 10;
            }

            LastFocusedWindow = FocusedWindow;
            CursorManager.Mouse = Resources.Mouse;
            CursorManager.MouseOffsetX = 0;
            CursorManager.MouseOffsetY = 0;
            CursorManager.LastMouseX = (int)MouseManager.X;
            CursorManager.LastMouseY = (int)MouseManager.Y;
        }
    }
}