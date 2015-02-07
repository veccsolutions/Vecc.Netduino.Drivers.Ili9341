namespace Vecc.Netduino.Drivers.Ili9341
{
    public partial class Driver
    {
        public void DrawChar(int x, int y, int color, FontCharacter character)
        {
            lock (this)
            {
                SetWindow(x, x + character.Width - 1, y, y + character.Height - 1);

                var pixels = new ushort[character.Width * character.Height];
                var pixelPosition = 0;

                for (var segmentIndex = 0; segmentIndex < character.Data.Length; segmentIndex++)
                {
                    var segment = character.Data[segmentIndex];
                    if (pixelPosition < pixels.Length) { pixels[pixelPosition] = (segment & 0x80) != 0 ? (ushort)color : (ushort)0; pixelPosition++; }
                    if (pixelPosition < pixels.Length) { pixels[pixelPosition] = (segment & 0x40) != 0 ? (ushort)color : (ushort)0; pixelPosition++; }
                    if (pixelPosition < pixels.Length) { pixels[pixelPosition] = (segment & 0x20) != 0 ? (ushort)color : (ushort)0; pixelPosition++; }
                    if (pixelPosition < pixels.Length) { pixels[pixelPosition] = (segment & 0x10) != 0 ? (ushort)color : (ushort)0; pixelPosition++; }
                    if (pixelPosition < pixels.Length) { pixels[pixelPosition] = (segment & 0x8) != 0 ? (ushort)color : (ushort)0; pixelPosition++; }
                    if (pixelPosition < pixels.Length) { pixels[pixelPosition] = (segment & 0x4) != 0 ? (ushort)color : (ushort)0; pixelPosition++; }
                    if (pixelPosition < pixels.Length) { pixels[pixelPosition] = (segment & 0x2) != 0 ? (ushort)color : (ushort)0; pixelPosition++; }
                    if (pixelPosition < pixels.Length) { pixels[pixelPosition] = (segment & 0x1) != 0 ? (ushort)color : (ushort)0; pixelPosition++; }
                }

                //uncomment this to see the characters in the debug window that would be displayed on the screen.
                //var currentBuffer = string.Empty;
                //for (var pixel = 0; pixel < pixels.Length; pixel++)
                //{
                //    if (pixels[pixel] > 0)
                //    {
                //        currentBuffer += "X";
                //    }
                //    else
                //    {
                //        currentBuffer += "-";
                //    }
                //    if (currentBuffer.Length >= character.Width)
                //    {
                //        Debug.Print(currentBuffer);
                //        currentBuffer = string.Empty;
                //    }
                //}

                SendData(pixels);
            }
        }
    }
}
