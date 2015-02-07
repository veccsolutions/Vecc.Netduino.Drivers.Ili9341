using System;
using Microsoft.SPOT;

namespace Vecc.Netduino.Drivers.Ili9341
{
    public class NetduinoHelpersFont : Font
    {
        private readonly byte _height;
        private byte[] _widths;
        private byte[][] _bitmaps;

        public NetduinoHelpersFont(byte[] bitmaps, ushort[] descriptors, byte height, int characterPadPixels)
        {
            _height = height;
            var bitmapCount = descriptors.Length / 2;

            _widths = new byte[bitmapCount];
            _bitmaps = new byte[bitmapCount][];
            for (var index = 0; index < bitmapCount; index++)
            {
                var width = (byte)descriptors[index * 2];
                var offset = descriptors[index * 2 + 1];
                _widths[index] = (byte)(width + characterPadPixels);
                //in the helpers bitmap, each row ends on a byte,
                //so if the character is 10 pixels wide, we need 2 bytes (though only the first 2 bits of the second byte are used)
                //if the character is 1 pixel wide, we need 1 byte (though only the first bit is used)
                //since dividing a number returns the floor of the result, 1/8=0, 7/8=0, 8/8=1, 10/8=1. We need to add 1 to the result, but subtract 1 from the width
                var bitmap = new byte[height * (((width - 1) / 8) + 1)]; //in theory.
                Array.Copy(bitmaps, offset, bitmap, 0, bitmap.Length);
                _bitmaps[index] = BuildBitmap(width, bitmap, characterPadPixels);
            }
        }

        public override byte SpaceWidth
        {
            get { return 5; }
        }

        public override FontCharacter GetFontData(char character)
        {
            var characterIndex = character - ' ';
            if (characterIndex < 0 || characterIndex > _bitmaps.Length)
            {
                return new FontCharacter
                {
                    Data = null,
                    Height = _height,
                    Width = 0,
                    Space = 0
                };
            }

            return new FontCharacter
            {
                Data = _bitmaps[characterIndex],
                Height = _height,
                Width = _widths[characterIndex],
                Space = 0
            };
        }

        private byte[] BuildBitmap(byte width, byte[] segments, int characterPadPixels)
        {
            var bitmap = string.Empty;
            var bytesPerHelperRow = ((width - 1) / 8) + 1;
            var bytesForVeccFont = (_height * (width + characterPadPixels)) / 8 + 1;

            var result = new byte[bytesForVeccFont];

            for (var row = 0; row < _height; row++)
            {
                var rowBitmap = string.Empty;

                for (var segmentIndex = 0; segmentIndex < bytesPerHelperRow; segmentIndex++)
                {
                    rowBitmap += ToBinary(segments[row * bytesPerHelperRow + segmentIndex]);
                }

                bitmap += rowBitmap.Substring(0, width);
                //pad pixels.
                for (var x = 0; x < characterPadPixels; x++)
                {
                    bitmap += "0";
                }
            }

            width = (byte)(width + characterPadPixels);

            for (var index = 0; index < result.Length; index++)
            {
                var segment = bitmap.Length < (index * 8 + 8)
                    ? bitmap.Substring(index * 8)
                    : bitmap.Substring(index * 8, 8);

                while (segment.Length < 8)
                {
                    segment = segment + "0";
                }

                result[index] = ParseBinary(segment);
            }

            return result;
        }

        private static string ToBinary(byte value)
        {
            var result = string.Empty;

            result = GetBit(value, 128) +
                     GetBit(value, 64) +
                     GetBit(value, 32) +
                     GetBit(value, 16) +
                     GetBit(value, 8) +
                     GetBit(value, 4) +
                     GetBit(value, 2) +
                     GetBit(value, 1);

            return result;
        }

        private static string GetBit(byte value, byte bit)
        {
            return (value & bit) == bit ? "1" : "0";
        }

        private static byte ParseBinary(string binary)
        {
            //This looks a little bit crazy, but here's why:
            //Convert to a char array before accessing the characters. 
            //It is faster than accessing the characters in a string by the indexers when going through the entire string.
            //For (x=....) is also faster than foreach.
            //++result is faster than result++ or result += 1 because of how the interpreter handles it.
            //it was something along the lines of using result++ allocates a new object on the heap, whereas ++result does not. 
            //Minimal performance increase, but, it is a performance increase
            var result = 0;
            var bits = binary.ToCharArray();
            if (bits[0] == '1')
            {
                result = 1;
            }

            for (var bit = 1; bit < bits.Length; bit++)
            {
                result = result << 1;
                if (bits[bit] == '1') //this bit is turned on, add 1.
                {
                    ++result; //faster than result++.
                }
            }

            return (byte)result;
        }
    }
}
