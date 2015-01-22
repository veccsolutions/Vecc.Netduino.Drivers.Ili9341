namespace Vecc.Netduino.Drivers.Ili9341
{
    public partial class Driver
    {
        public void DrawLine(int x0, int y0, int x1, int y1, ushort color)
        {
            lock (this)
            {
                if (x0 == x1)
                {
                    if (y1 > y0)
                    {
                        DrawVerticalLine(x0, y0, y1 - y0, color);
                    }
                    else
                    {
                        DrawVerticalLine(x0, y1, y0 - y1, color);
                    }
                    return;
                }
                if (y0 == y1)
                {
                    if (x1 > x0)
                    {
                        DrawHorizontalLine(x0, y0, x1 - x0, color);
                    }
                    else
                    {
                        DrawHorizontalLine(x1, y0, x0 - x1, color);
                    }
                    return;
                }
                if (x0 == x1 && y0 == y1)
                {
                    SetPixel(x0, y0, color);
                    return;
                }

                if (x0 > x1)
                {
                    //we only go from left to right, since the starting point is to the left of the ending point, swap them
                    var temp = x0;
                    x0 = x1;
                    x1 = x0;
                    temp = y0;
                    y0 = y1;
                    y1 = temp;
                }

                //line formula
                //y=mx + b

                //m = change in y / change in x
                var xDifference = (double)(x0 - x1);
                var yDifference = (double)(y0 - y1);
                var m = yDifference / xDifference;
                var x = x0;
                var b = y0 - (m * x);
                double y;

                for (x = x0; x <= x1; x++)
                {
                    //calculate y
                    y = (m * x) + b;
                    SetPixel((int)x, (int)y, color);
                }
            }
        }
    }
}