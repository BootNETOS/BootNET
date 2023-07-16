using Cosmos.HAL.Drivers.Video.SVGAII;
using Cosmos.System;
using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootNet.GUI
{
    public class Graphics
    {
        public VMWareSVGAII vMWareSVGAII;
        public ushort Width, Height;
        public Graphics() : this(800, 600)
        {

        }
        public Graphics(ushort Width, ushort Height)
        {
            this.Width = Width;
            this.Height = Height;
            vMWareSVGAII.SetMode(Width, Height);
            MouseManager.ScreenWidth = Width;
            MouseManager.ScreenHeight = Height;
        }
        public void SetMode(ushort Width, ushort Height)
        {
            this.Width = Width;
            this.Height = Height;
            vMWareSVGAII.SetMode(Width, Height);
            MouseManager.ScreenWidth = Width;
            MouseManager.ScreenHeight = Height;
        }
        public void SetCursor(bool visible, uint x, uint y)
        {
            vMWareSVGAII.SetCursor(visible, x, y);
        }
        public void DefineCursor()
        {
            vMWareSVGAII.DefineCursor();
        }
        public void DefineAlphaCursor(ushort width, ushort height, int[] data)
        {
            vMWareSVGAII.DefineAlphaCursor(width, height, data);
        }
        public void DrawPoint(uint x, uint y, uint color)
        {
            vMWareSVGAII.SetPixel(x,y,color);
        }
        public void DrawImage(uint x, uint y, Image image)
        {
            for (uint _x = 0; _x < image.Width; _x++)
            {
                for (uint _y = 0; _y < image.Height; _y++)
                {
                    DrawPoint(x + _x, y + _y, (uint)image.RawData[_x + _y * image.Width]);
                }
            }
        }
        public void DrawCircle(uint x_center, uint y_center, uint radius, uint color)
        {
            /*
            ThrowIfCoordNotValid(x_center + radius, y_center);
            ThrowIfCoordNotValid(x_center - radius, y_center);
            ThrowIfCoordNotValid(x_center, y_center + radius);
            ThrowIfCoordNotValid(x_center, y_center - radius);
            */
            uint x = radius;
            uint y = 0;
            uint e = 0;

            while (x >= y)
            {
                DrawPoint(x_center + x, y_center + y, color);
                DrawPoint(x_center + y, y_center + x, color);
                DrawPoint(x_center - y, y_center + x, color);
                DrawPoint(x_center - x, y_center + y, color);
                DrawPoint(x_center - x, y_center - y, color);
                DrawPoint(x_center - y, y_center - x, color);
                DrawPoint(x_center + y, y_center - x, color);
                DrawPoint(x_center + x, y_center - y, color);

                y++;
                if (e <= 0)
                {
                    e += 2 * y + 1;
                }
                if (e > 0)
                {
                    x--;
                    e -= 2 * x + 1;
                }
            }
        }
        public void DrawRectangle(uint x, uint y, ushort width, ushort height, uint color)
        {
            /*
             * we must draw four lines connecting any vertex of our rectangle to do this we first obtain the position of these
             * vertex (we call these vertexes A, B, C, D as for geometric convention)
             */
            /* The check of the validity of x and y are done in DrawLine() */

            /* The vertex A is where x,y are */
            uint xa = x;
            uint ya = y;

            /* The vertex B has the same y coordinate of A but x is moved of Width pixels */
            uint xb = x + width;
            uint yb = y;

            /* The vertex C has the same x coordiate of A but this time is y that is moved of Height pixels */
            uint xc = x;
            uint yc = y + height;

            /* The Vertex D has x moved of Width pixels and y moved of Height pixels */
            uint xd = x + width;
            uint yd = y + height;

            /* Draw a line betwen A and B */
            DrawLine(xa, ya, xb, yb, color);

            /* Draw a line between A and C */
            DrawLine(xa, ya, xc, yc, color);

            /* Draw a line between B and D */
            DrawLine(xb, yb, xd, yd, color);

            /* Draw a line between C and D */
            //DrawLine(xc, yc, xd, yd, color);
            DrawLine(xc, yc, xd + 1, yd, color);
        }
        public void DrawFillRectangle(uint x, uint y, ushort width, ushort height, uint color)
        {
            for (uint h = 0; h < height; h++)
            {
                for (uint w = 0; w < width; w++)
                {
                    DrawPoint(w + x, y + h, color);
                }
            }
        }
        public void DrawLine(uint x1, uint y1, uint x2, uint y2, uint color)
        {
            // trim the given line to fit inside the canvas boundries
            TrimLine(ref x1, ref y1, ref x2, ref y2);

            uint dx, dy;

            dx = x2 - x1;      /* the horizontal distance of the line */
            dy = y2 - y1;      /* the vertical distance of the line */

            if (dy == 0) /* The line is horizontal */
            {
                DrawHorizontalLine(color, dx, x1, y1);

                /*
                int minx = Math.Min(x1, x2);
                int maxx = Math.Max(x1, x2);

                for (int i = minx; i < maxx; i++)
                {
                    DrawPoint(i, y1, color);
                }
                */

                return;
            }

            if (dx == 0) /* the line is vertical */
            {
                DrawVerticalLine(color, dy, x1, y1);

                /*
                int miny = Math.Min(y1, y2);
                int maxy = Math.Max(y1, y2);

                for (int i = miny; i < maxy; i++)
                {
                    DrawPoint(x1, i, color);
                }
                */

                return;
            }

            /* the line is neither horizontal neither vertical, is diagonal then! */
            DrawDiagonalLine(color, dx, dy, x1, y1);
        }

        #region DrawLine
        private void DrawVerticalLine(uint color, uint dy, uint x1, uint y1)
        {
            uint i;

            for (i = 0; i < dy; i++)
            {
                DrawPoint(x1, (y1 + i), color);
            }
        }

        private void DrawHorizontalLine(uint color, uint dx, uint x1, uint y1)
        {
            uint i;

            for (i = 0; i < dx; i++)
            {
                DrawPoint(((x1 + i)), y1, color);
            }
        }

        protected void TrimLine(ref uint x1, ref uint y1, ref uint x2, ref uint y2)
        {
            // in case of vertical lines, no need to perform complex operations
            if (x1 == x2)
            {
                x1 = (uint)Math.Min(Width - 1, Math.Max(0, x1));
                x2 = x1;
                y1 = (uint)Math.Min(Height - 1, Math.Max(0, y1));
                y2 = (uint)Math.Min(Height - 1, Math.Max(0, y2));

                return;
            }

            // never attempt to remove this part,
            // if we didn't calculate our new values as floats, we would end up with inaccurate output
            float x1_out = x1, y1_out = y1;
            float x2_out = x2, y2_out = y2;

            // calculate the line slope, and the entercepted part of the y axis
            float m = (y2_out - y1_out) / (x2_out - x1_out);
            float c = y1_out - m * x1_out;

            // handle x1
            if (x1_out < 0)
            {
                x1_out = 0;
                y1_out = c;
            }
            else if (x1_out >= Width)
            {
                x1_out = Width - 1;
                y1_out = (Width - 1) * m + c;
            }

            // handle x2
            if (x2_out < 0)
            {
                x2_out = 0;
                y2_out = c;
            }
            else if (x2_out >= Width)
            {
                x2_out = Width - 1;
                y2_out = (Width - 1) * m + c;
            }

            // handle y1
            if (y1_out < 0)
            {
                x1_out = -c / m;
                y1_out = 0;
            }
            else if (y1_out >= Height)
            {
                x1_out = (Height - 1 - c) / m;
                y1_out = Height - 1;
            }

            // handle y2
            if (y2_out < 0)
            {
                x2_out = -c / m;
                y2_out = 0;
            }
            else if (y2_out >= Height)
            {
                x2_out = (Height - 1 - c) / m;
                y2_out = Height - 1;
            }

            // final check, to avoid lines that are totally outside bounds
            if (x1_out < 0 || x1_out >= Width || y1_out < 0 || y1_out >= Height)
            {
                x1_out = 0; x2_out = 0;
                y1_out = 0; y2_out = 0;
            }

            if (x2_out < 0 || x2_out >= Width || y2_out < 0 || y2_out >= Height)
            {
                x1_out = 0; x2_out = 0;
                y1_out = 0; y2_out = 0;
            }

            // replace inputs with new values
            x1 = (uint)x1_out; y1 = (uint)y1_out;
            x2 = (uint)x2_out; y2 = (uint)y2_out;
        }

        private void DrawDiagonalLine(uint color, uint dx, uint dy, uint x1, uint y1)
        {
            uint i, sdx, sdy, dxabs, dyabs, x, y, px, py;

            dxabs = (uint)Math.Abs(dx);
            dyabs = (uint)Math.Abs(dy);
            sdx = (uint)Math.Sign(dx);
            sdy = (uint)Math.Sign(dy);
            x = dyabs >> 1;
            y = dxabs >> 1;
            px = x1;
            py = y1;

            if (dxabs >= dyabs) /* the line is more horizontal than vertical */
            {
                for (i = 0; i < dxabs; i++)
                {
                    y += dyabs;
                    if (y >= dxabs)
                    {
                        y -= dxabs;
                        py += sdy;
                    }
                    px += sdx;
                    DrawPoint(px, py, color);
                }
            }
            else /* the line is more vertical than horizontal */
            {
                for (i = 0; i < dyabs; i++)
                {
                    x += dxabs;
                    if (x >= dyabs)
                    {
                        x -= dyabs;
                        px += sdx;
                    }
                    py += sdy;
                    DrawPoint(px, py, color);
                }
            }
        }
        #endregion
    }
}
