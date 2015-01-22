using SecretLabs.NETMF.Hardware.Netduino;

namespace Vecc.Netduino.Drivers.Ili9341.Sandbox
{
    public class Program
    {
        public static void Main()
        {
            var tft = new Driver(isLandscape: true,
                                 lcdChipSelectPin: Pins.GPIO_PIN_D5,
                                 dataCommandPin: Pins.GPIO_PIN_D6,
                                 backlightPin: Pins.GPIO_PIN_D7);
            var font = new StandardFixedWidthFont();
            tft.ClearScreen();
            tft.DrawString(10, 10, "Hello world!", 0xF800, font);
            tft.BacklightOn = true;
        }
    }
}
