namespace Vecc.Netduino.Drivers.Ili9341
{
    public partial class Driver
    {
        public void DrawVerticalLine(int x, int y, int length, ushort color)
        {
            lock (this)
            {
                SetWindow(x, x, y, y + length);

                var buffer = new ushort[length];
                for (int i = 0; i < length; i++)
                {
                    buffer[i] = color;
                }

                SendData(buffer);
            }
        }
    }
}
