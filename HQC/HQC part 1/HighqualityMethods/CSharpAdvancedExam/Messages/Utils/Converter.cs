using System.Numerics;
using System.Text;

namespace Messages.Utils
{
    internal static class Converter
    {
        internal static BigInteger ConvertGreatNumbertToNumber(string text)
        {
            var numberAsText = new StringBuilder();

            for (int i = 0; i < text.Length - 2; i += 3)
            {
                numberAsText.Append(ConvertGreatTextToDigit(text.Substring(i, 3)));
            }

            var number = BigInteger.Parse(numberAsText.ToString());
            return number;
        }

        internal static string ConvertNumberToGreatNumber(BigInteger number)
        {
            var numberAsText = number.ToString();
            var greatNumber = new StringBuilder();

            foreach (var ch in numberAsText)
            {
                greatNumber.Append(ConvertDigitToGreatText(ch));
            }

            return greatNumber.ToString();
        }

        private static char ConvertGreatTextToDigit(string greatDigit)
        {
            switch (greatDigit)
            {
                case "cad": return '0';
                case "xoz": return '1';
                case "nop": return '2';
                case "cyk": return '3';
                case "min": return '4';
                case "mar": return '5';
                case "kon": return '6';
                case "iva": return '7';
                case "ogi": return '8';
                default: return '9';
            }
        }

        private static string ConvertDigitToGreatText(char c)
        {
            switch (c)
            {
                case '0': return "cad";
                case '1': return "xoz";
                case '2': return "nop";
                case '3': return "cyk";
                case '4': return "min";
                case '5': return "mar";
                case '6': return "kon";
                case '7': return "iva";
                case '8': return "ogi";
                default: return "yan";
            }
        }
    }
}
