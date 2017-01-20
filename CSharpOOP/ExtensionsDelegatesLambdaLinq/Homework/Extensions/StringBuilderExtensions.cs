namespace Homework.Extensions
{
    using System;
    using System.Text;

    public static class StringBuilderExtensions
    {
        public static StringBuilder Substring(this StringBuilder input, int startIndex, int length)
        {
            if (input.Length <= startIndex || startIndex + length >= input.Length)
            {
                throw new ArgumentOutOfRangeException("The Substring is out of a Stringbuilder boundaries");
            }

            var result = new StringBuilder();
            var inputStr = input.ToString();

            for (int i = startIndex; i < startIndex + length; i++)
            {
                result.Append(inputStr[i]);
            }

            return result;
        }
    }
}
