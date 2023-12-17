/*
 *  This file is part of the Mirage Desktop Environment.
 *  github.com/mirage-desktop/Mirage
 */
using BootNET.Desktop.GraphicsKit;
using BootNET.Desktop.SurfaceKit;
using BootNET.Desktop.TextKit;
using BootNET.Desktop.UIKit;
using System;
using System.Collections.Generic;

namespace BootNET.Desktop.DE
{
    /// <summary>
    /// System information application.
    /// </summary>
    class About : UIApplication
    {
        /// <summary>
        /// Initialise the application.
        /// </summary>
        public About(SurfaceManager surfaceManager) : base(surfaceManager)
        {
            MainWindow = new UIWindow(surfaceManager, 400, 240, "About This Computer", resizable: false);

            UICanvasView icon = new(Resources.Computer, alpha: true)
            {
                Location = new(24, 24),
            };

            UITextView content = new(GetAboutTextBlock())
            {
                Location = new(112, 24),
                ExplicitWidth = MainWindow.Surface.Canvas.Width - 136,
                Wrapping = true,
                Editable = true,
                ReadOnly = true,
            };

            UIButton close = new("Close");
            close.Location = new(
                MainWindow.Surface.Canvas.Width - close.Size.Width - 24,
                MainWindow.Surface.Canvas.Height - close.Size.Height - 24
            );
            close.OnMouseClick.Bind((args) => MainWindow.Close());

            MainWindow.RootView.Add(icon);
            MainWindow.RootView.Add(content);
            MainWindow.RootView.Add(close);
        }

        /// <summary>
        /// Get the About application's rich text block.
        /// </summary>
        /// <returns>A rich text block with system information.</returns>
        private TextBlock GetAboutTextBlock()
        {
            TextBlock block = new(_logoStyle, "Mirage\n")
            {
                Style = _valueStyle
            };
            block.Append("The Cosmos Desktop Environment\n\n");

            List<(string Name, string Value)> rows = new()
            {
                ("OS", DesktopEnvironment.DistributionName + " " + DesktopEnvironment.DistributionVersion),
                ("Mirage Version", "1.0 Beta"),
                ("Memory", ((int)(Math.Ceiling(Cosmos.Core.CPU.GetAmountOfRAM() / 8.0) * 8.0)).ToString() + " MB"),
                ("CPU", Cosmos.Core.CPU.GetCPUBrandString()),
            };

            foreach (var (Name, Value) in rows)
            {
                block.Style = _headerStyle;
                block.Append(Name + " ");
                block.Style = _valueStyle;
                block.Append(Value + "\n");
            }

            return block;
        }

        /// <summary>
        /// Text style for the logo.
        /// </summary>
        private readonly TextStyle _logoStyle = new(Resources.CantarellLarge, Color.Black);

        /// <summary>
        /// Text style for row headers.
        /// </summary>
        private readonly TextStyle _headerStyle = new(Resources.CantarellBold, Color.Black);

        /// <summary>
        /// Text style for row values.
        /// </summary>
        private readonly TextStyle _valueStyle = new(Resources.Cantarell, Color.DeepGray);
    }
}
