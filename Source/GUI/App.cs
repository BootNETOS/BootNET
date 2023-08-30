using PrismAPI.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootNET.GUI
{
    internal class App : Window
    {
        public string AppName;
        public Canvas AppIcon;
        public App(int X, int Y, int Width, int Height, string WindowName, string AppName, Canvas AppIcon) : base(X, Y, Width, Height, WindowName)
        {
            this.AppName = AppName;
            this.AppIcon = AppIcon;
        }
        public override void Render()
        {
            
        }
        public override void Update()
        {
            
        }
    }
}
