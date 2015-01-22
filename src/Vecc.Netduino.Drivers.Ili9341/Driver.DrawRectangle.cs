namespace Vecc.Netduino.Drivers.Ili9341
{
    public partial class Driver
    {
        public void DrawRectangle(int x, int y, int width, int height, ushort color)
        {
            var x1 = (x + width);
            var y1 = (y + height);

            DrawVerticalLine(x, y, height, color); //left
            DrawVerticalLine(x1, y, height, color); //right
            DrawHorizontalLine(x, y, width, color); //top
            DrawHorizontalLine(x, y1, width, color); //bottom
        }
    }
}
