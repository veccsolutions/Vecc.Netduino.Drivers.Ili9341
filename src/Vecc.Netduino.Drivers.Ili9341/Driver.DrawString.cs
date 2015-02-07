namespace Vecc.Netduino.Drivers.Ili9341
{
    public partial class Driver
    {
        public void DrawString(int x, int y, string s, int color, Font font)
        {
            var currentX = x;
            foreach (var c in s)
            {
                var character = font.GetFontData(c);

                if (c == '\n') //line feed
                {
                    y += character.Height;
                }
                else if (c == '\r') //carriage return
                {
                    currentX = x;
                }
                else
                {
                    if (currentX + character.Width > Width)
                    {
                        currentX = x; //start over at the left and go to a new line.
                        y += character.Height;
                    }

                    DrawChar(currentX, y, color, character);
                    currentX += character.Width + character.Space;
                }
            }
        }
    }
}
