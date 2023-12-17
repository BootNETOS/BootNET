/*
 *  This file is part of the Mirage Desktop Environment.
 *  github.com/mirage-desktop/Mirage
 */
using BootNET.Desktop.GraphicsKit;
using BootNET.Desktop.SurfaceKit;
using BootNET.Desktop.TextKit;
using System.Collections.Generic;

namespace BootNET.Desktop.UIKit
{
    /// <summary>
    /// A generic dialogue box.
    /// </summary>
    class UIDialogue : UIWindow
    {
        /// <summary>
        /// Initialise a new dialogue box.
        /// </summary>
        /// <param name="surfaceManager">The surface manager to display the dialogue window in.</param>
        /// <param name="title">The title of the dialogue box.</param>
        /// <param name="description">The description of the dialogue box.</param>
        /// <param name="buttons">The buttons in the dialogue box, from left to right.</param>
        /// <param name="icon">The icon to display on the dialogue box. Will be automatically scaled.</param>
        public UIDialogue(
            SurfaceManager surfaceManager,
            string title,
            TextBlock description,
            List<UIButton> buttons,
            Canvas icon)
            : base(
                surfaceManager,
                400,
                128,
                title,
                titlebar: true,
                resizable: false)
        {
            UICanvasView iconView = new(Filters.Scale(64, 64, icon), alpha: true)
            {
                Location = new(24, 24),
            };
            DescriptionView = new UITextView(description)
            {
                Location = new(112, 24),
                ExplicitWidth = Surface.Canvas.Width - 136,
                Wrapping = true
            };
            UIBoxLayout buttonLayout = new(UIBoxOrientation.Horizontal)
            {
                Spacing = 8
            };
            foreach (UIButton button in buttons)
            {
                button.OnMouseClick.Bind((args) => Close());
                buttonLayout.Add(button);
            }
            buttonLayout.LayOut();
            buttonLayout.Location = new(
                Surface.Canvas.Width - buttonLayout.Size.Width - 24,
                Surface.Canvas.Height - buttonLayout.Size.Height - 24
            );
            RootView.Add(iconView);
            RootView.Add(DescriptionView);
            RootView.Add(buttonLayout);
            Surface.SurfaceManager.Focus = Surface;
        }

        /// <summary>
        /// The text view that displays the dialogue's description.
        /// </summary>
        public UITextView DescriptionView { get; init; }
    }
}
