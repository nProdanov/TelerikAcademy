using System;

using ExceptionsHomework.Utils;

namespace ExceptionsHomework.Extensions
{
    public static class IntegerExtensions
    {
        public static bool CheckIfPrimeNumber(this int number)
        {
            Validator.ValidateIfNonNegativeNumber(number, "Prime number");

            var isPrime = true;

            for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
            {
                if (number % divisor == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            return isPrime;
        }
    }
}
