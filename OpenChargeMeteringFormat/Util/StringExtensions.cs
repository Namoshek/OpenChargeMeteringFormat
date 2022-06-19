using System;

namespace OpenChargeMeteringFormat.Util
{
    internal static class StringExtensions
    {
        /// <summary>
        /// Converts the given <paramref name="hex"/> to a byte array.
        /// </summary>
        /// <param name="hex"></param>
        /// <exception cref="ArgumentException"></exception>
        public static byte[] ToByteArray(this string hex)
        {
            if (string.IsNullOrWhiteSpace(hex))
            {
                throw new ArgumentException("The given HEX string is null or white space.", nameof(hex));
            }

            var numberChars = hex.Length;

            if (numberChars % 2 != 0)
            {
                throw new ArgumentException("The given HEX string has an odd length, cannot convert to bytes.", nameof(hex));
            }
            
            var result = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
            {
                result[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }

            return result;
        }

        /// <summary>
        /// Determines whether <paramref name="input"/> is a HEX string.
        /// </summary>
        /// <param name="input"></param>
        public static bool IsHex(this string input)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(input, @"^\b[0-9a-fA-F]+\b$");
        }
    }
}
