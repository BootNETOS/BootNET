using BootNET.Graphics;
using Cosmos.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Kernel = BootNET.Core.Program;

namespace BootNET.GUI
{
    public class Notepad : App
    {
        private Queue<KeyEvent> KeyBuffer = new Queue<KeyEvent>();
        string text;
        readonly int textEachLine;
        public Notepad(ushort width, ushort height, int x, int y) : base(Desktop.programlogo, width, height, x, y)
        {
            this.name = "Notepad";
            textEachLine = (int)width / 8;
        }
        public override void AppUpdate()
        {
            Kernel.Screen.DrawFilledRectangle(x, y, width, height, 0, Color.White);

            if (text.Length != 0)
            {
                string s = string.Empty;
                int i = 0;
                foreach (char c in text)
                {
                    s += c;
                    i++;
                    if (i + 1 == textEachLine || c == '\n')
                    {
                        if (c != '\n')
                        {
                            s += "\n";
                        }
                        i = 0;
                    }
                }
                Kernel.Screen.DrawACSIIString(Color.Black, s, x, y);
            }
            else
            {
                Kernel.Screen.DrawACSIIString(Color.LightGray, "Edit anything you want", x, y);
            }
            if (focused)
            {
                if (KeyBuffer.TryDequeue(out var key))
                {
                    switch (key.Key)
                    {
                        case ConsoleKeyEx.Enter:
                            this.text += "\n";
                            break;
                        case ConsoleKeyEx.Backspace:
                            if (this.text.Length != 0)
                            {
                                this.text = this.text.Remove(this.text.Length - 1);
                            }
                            break;
                        default:
                            this.text += key.KeyChar;
                            break;
                    }
                }

                
            }
        }
    }
}
