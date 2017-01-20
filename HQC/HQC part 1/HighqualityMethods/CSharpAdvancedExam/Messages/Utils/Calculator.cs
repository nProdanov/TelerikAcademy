using System.Numerics;

namespace Messages.Utils
{
    internal static class Calculator
    {
        internal static BigInteger Calculate(BigInteger firstNumber, BigInteger secondNumber, string operation)
        {
            if (operation == "+")
            {
                return firstNumber + secondNumber;
            }
            else
            {
                return firstNumber - secondNumber;
            }
        }
    }
}
