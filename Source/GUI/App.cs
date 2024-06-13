using BootNET.Graphics;
using BootNET.Graphics.Fonts;
using Cosmos.System;
using Kernel = BootNET.Core.Program;

namespace BootNET.GUI;

public class App
{
    public Canvas Icon;
    public readonly ushort _width;
    public readonly ushort _height;
    public readonly ushort width;
    public readonly ushort height;

    public int dockX;
    public int dockY;
    public ushort dockWidth = 40;
    public ushort dockHeight = 30;

    public int _x;
    public int _y;
    public int x;
    public int y;
    public string name;
    long namex;

    bool pressed;
    public bool visible = false;

    public int _i = 0;

    public App(Canvas Icon, ushort width, ushort height, int x = 0, int y = 0)
    {
        _width = width;
        _height = height;
        _x = x;
        _y = y;

        this.x = x + 2;
        this.y = y + 22;
        this.width = System.Convert.ToUInt16(width - 4);
        this.height = System.Convert.ToUInt16(height - 22);
        this.Icon = Icon;
    }

    public void Update()
    {
        if (_i != 0)
        {
            _i--;
        }

        if (MouseManager.X > dockX && MouseManager.X < dockX + dockWidth && MouseManager.Y > dockY && MouseManager.Y < dockY + dockHeight)
        {
            namex = dockX - (name.Length * 8 / 2) + dockWidth / 2;
            Kernel.Screen.DrawString((int)namex, dockY - 20, name, Kernel.DefaultFont, Color.White);
        }

        if (MouseManager.MouseState == MouseState.Left && _i == 0)
        {
            if (MouseManager.X > dockX && MouseManager.X < dockX + dockWidth && MouseManager.Y > dockY && MouseManager.Y < dockY + dockHeight)
            {
                visible = !visible;
                _i = 60;
            }
        }

        if (MouseManager.MouseState == MouseState.Left)
        {
            if (MouseManager.X > _x && MouseManager.X < _x + 22 && MouseManager.Y > _y && MouseManager.Y < _y + 22)
            {
                this.pressed = true;
            }
        }
        else
        {
            this.pressed = false;
        }

        if (!visible)
            goto end;

        if (this.pressed)
        {
            this._x = (int)MouseManager.X;
            this._y = (int)MouseManager.Y;

            this.x = (int)MouseManager.X + 2;
            this.y = (int)MouseManager.Y + 22;
        }

        Kernel.Screen.DrawFilledRectangle(_x, _y, _width, _height, 0, Color.DeepGray);
        Kernel.Screen.DrawRectangle(_x, _y, _width, _height, 0, Desktop.avgCol);

        Kernel.Screen.DrawString(_x + 2, _y + 2, name, Kernel.DefaultFont, Color.White);
        AppUpdate();

    end:;
    }

    public virtual void AppUpdate()
    {
    }
}