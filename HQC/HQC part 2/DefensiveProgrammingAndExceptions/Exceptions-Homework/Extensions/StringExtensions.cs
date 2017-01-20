using System;
using System.Text;

using ExceptionsHomework.Utils;

namespace ExceptionsHomework.Extensions
{
    public static class StringExtensions
    {
        public static string ExtractEnding(this string text, int count)
        {
            Validator.ValidateIfStringIsValid(text, "Text");
            Validator.ValidateIfNonNegativeNumber(count, "Count");
            if (text.Length < count)
            {
                throw new ArgumentException("Count can not be greather than text'length");
            }

            var result = new StringBuilder();
            for (int i = text.Length - count; i < text.Length; i++)
            {
                result.Append(text[i]);
            }

            return result.ToString();
        }
    }
}
