using System;

namespace ExceptionsHomework.Utils
{
    public static class Validator
    {
        private const string OptionalName = "value";

        public static void ValidateIfNonNegativeNumber(int number, string name = Validator.OptionalName)
        {
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException(name, string.Format("{0} must not be a negative number", name));
            }
        }

        public static void ValidateIfNumberInRange(int number, int min, int max, string name = Validator.OptionalName)
        {
            if (number < min || max < number)
            {
                throw new ArgumentOutOfRangeException(name, string.Format("{0} must be in range [{1}-{2}]", name, min, max));
            }
        }

        public static void ValidateIfStringIsValid(string text, string name = "value")
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException(string.Format("{0} must not be a null or empty string", name));
            }
        }
    }
}
