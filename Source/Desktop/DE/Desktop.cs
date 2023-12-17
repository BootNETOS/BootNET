/*
 *  This file is part of the Mirage Desktop Environment.
 *  github.com/mirage-desktop/Mirage
 */
using BootNET.Desktop.SurfaceKit;
using BootNET.Desktop.UIKit;
using System.Drawing;

namespace BootNET.Desktop.DE
{
    /// <summary>
    /// Displays the wallpaper.
    /// </summary>
    public class Desktop : UIWindow
    {
        public Desktop(SurfaceManager surfaceManager) : base(
            surfaceManager,
            (ushort)surfaceManager.Width,
            (ushort)surfaceManager.Height,
            "Desktop",
            titlebar: false)
        {
            Surface.CanRaise = false;
            Surface.Shadow = false;
            Surface.BorderColor = GraphicsKit.Color.Transparent;
            Surface.IsShell = true;
            UICanvasView wallpaper = new UICanvasView(new Size(surfaceManager.Width, surfaceManager.Height));
            wallpaper.Canvas.DrawImage(0, 0, Resources.Wallpaper);
            RootView.Add(wallpaper);
        }
    }
}
