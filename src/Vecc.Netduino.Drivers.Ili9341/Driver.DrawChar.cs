namespace Vecc.Netduino.Drivers.Ili9341
{
    public partial class Driver
    {
        public void DrawChar(int x, int y, int color, FontCharacter character)
        {
            lock (this)
            {
                var pixels = new ushort[character.Width * character.Height];

                SetWindow(x, x + character.Width - 1, y, y + character.Height - 1);

                for (var pixel = 0; pixel < character.Data.Length; pixel++)
                {
                    var data = character.Data[pixel];

                    pixels[7 + (pixel * 8)] = (data & 0x80) != 0 ? (ushort)color : (ushort)0;
                    pixels[6 + (pixel * 8)] = (data & 0x40) != 0 ? (ushort)color : (ushort)0;
                    pixels[5 + (pixel * 8)] = (data & 0x20) != 0 ? (ushort)color : (ushort)0;
                    pixels[4 + (pixel * 8)] = (data & 0x10) != 0 ? (ushort)color : (ushort)0;
                    pixels[3 + (pixel * 8)] = (data & 0x8) != 0 ? (ushort)color : (ushort)0;
                    pixels[2 + (pixel * 8)] = (data & 0x4) != 0 ? (ushort)color : (ushort)0;
                    pixels[1 + (pixel * 8)] = (data & 0x2) != 0 ? (ushort)color : (ushort)0;
                    pixels[0 + (pixel * 8)] = (data & 0x1) != 0 ? (ushort)color : (ushort)0;
                }

                SendData(pixels);
            }
        }
    }
}
