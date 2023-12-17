/*
 *  This file is part of the Mirage Desktop Environment.
 *  github.com/mirage-desktop/Mirage
 */
using System.Collections.Generic;

namespace BootNET.Desktop.GraphicsKit.Fonts;

/// <summary>
/// The glyph class, used for caching font glyphs.
/// See: https://github.com/Project-Prism/Prism-OS/tree/main/PrismGraphics/Font/README.md#Glyphs
/// </summary>
public class Glyph
{
    #region Constructors

    /// <summary>
    /// Creates a new instance of the <see cref="Glyph"/> class.
    /// </summary>
    /// <param name="Width">The width of the glyph.</param>
    /// <param name="Height">The height of the glyph.</param>
    public Glyph(ushort Width, ushort Height)
    {
        this.Height = Height;
        this.Width = Width;
        Points = new();
    }

    #endregion

    #region Fields

    public List<(int X, int Y)> Points;
    public ushort Height;
    public ushort Width;

    #endregion
}
